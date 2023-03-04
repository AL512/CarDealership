using System.ComponentModel.DataAnnotations;

namespace СarDealership.Identity.Models
{
    /// <summary>
    /// ViewModel для логина
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Логин
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
        /// Адрес возврата
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
