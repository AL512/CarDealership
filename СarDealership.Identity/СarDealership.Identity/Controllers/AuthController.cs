using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using СarDealership.Identity.Models;

namespace СarDealership.Identity.Controllers
{
    /// <summary>
    /// Контроллер аутентификация
    /// </summary>
    public class AuthController : Controller
    {
        /// <summary>
        /// Менеджер входа пользователя
        /// </summary>
        private readonly SignInManager<AppUser> _signInManager;
        /// <summary>
        /// Менеджер управления пользователями
        /// </summary>
        private readonly UserManager<AppUser> _userManager;
        /// <summary>
        /// Интерфейс для связи с сервером идентификации
        /// </summary>
        private readonly IIdentityServerInteractionService _interactionService;
        /// <summary>
        /// Контроллер аутентификация
        /// </summary>
        /// <param name="signInManager">Менеджер входа пользователя</param>
        /// <param name="userManager">Менеджер управления пользователями</param>
        /// <param name="interacService">Интерфейс для связи с сервером идентификации</param>
        public AuthController(SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            IIdentityServerInteractionService interactionService) =>
            (_signInManager, _userManager, _interactionService) =
            (signInManager, userManager, interactionService);

        /// <summary>
        /// Отображает форму ввода логина
        /// </summary>
        /// <param name="returnUrl">URL возврата</param>
        /// <returns>Отображение ввода логина</returns>
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var viewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="loginVM">ViewModel логина</param>
        /// <returns>Отображение из которого пришел запрос</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = await _userManager.FindByNameAsync(viewModel.Username);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return View(viewModel);
            }

            var result = await _signInManager.PasswordSignInAsync(viewModel.Username,
                viewModel.Password, false, false);
            if (result.Succeeded)
            {
                return Redirect(viewModel.ReturnUrl);
            }
            ModelState.AddModelError(string.Empty, "Login error");
            return View(viewModel);
        }
        /// <summary>
        /// Отображает форму регистрации пользователя
        /// </summary>
        /// <param name="returnUrl">URL возврата</param>
        /// <returns>Отображение регистрации пользователя</returns>
        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            var viewModel = new RegisterViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="regVM">ViewModel регистрации пользователя</param>
        /// <returns>Отображение из которого пришел запрос</returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = new AppUser
            {
                UserName = viewModel.Username
            };

            var result = await _userManager.CreateAsync(user, viewModel.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Redirect(viewModel.ReturnUrl);
            }
            ModelState.AddModelError(string.Empty, "Error occurred");
            return View(viewModel);
        }
        /// <summary>
        /// Воход пользователя из системы
        /// </summary>
        /// <param name="logoutId">Идентификатор выхода из системы</param>
        /// <returns>перенаправления после выхода из системы</returns>
        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await _signInManager.SignOutAsync();
            var logoutRequest = await _interactionService.GetLogoutContextAsync(logoutId);
            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }
    }
}
