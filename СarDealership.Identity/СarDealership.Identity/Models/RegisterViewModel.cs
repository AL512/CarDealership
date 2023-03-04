using System.ComponentModel.DataAnnotations;

namespace СarDealership.Identity.Models
{
    /// <summary>
    /// ViewModel для регистрации пользователя
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Required]
        public string Username { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        /// <summary>
        /// Подтверждение пароля
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// Адрес возврата
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
