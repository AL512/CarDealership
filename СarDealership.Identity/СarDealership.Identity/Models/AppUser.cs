using Microsoft.AspNetCore.Identity;

namespace СarDealership.Identity.Models
{
    /// <summary>
    /// Пользователь приложения
    /// </summary>
    public class AppUser : IdentityUser
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
    }
}
