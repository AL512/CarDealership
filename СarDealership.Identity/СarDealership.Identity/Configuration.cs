using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityModel;

namespace СarDealership.Identity
{
    /// <summary>
    /// Информация о клиентах и ресурсах
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// Список доступных областей для клиентского приложения
        /// </summary>
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("СarDealershipWebAPI", "Web API")
            };

        /// <summary>
        /// Список требований(claims) о пользователе
        /// </summary>
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        /// <summary>
        /// Список API ресурсов
        /// </summary>
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("СarDealershipWebAPI", "Web API", new []
                    { JwtClaimTypes.Name})
                {
                    Scopes = { "СarDealershipWebAPI" }
                }
            };
        /// <summary>
        /// Список приложений, которые могут использовать систему
        /// </summary>
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    // ИД клиента. Он должен совпадать с тем,
                    // который у клиента
                    ClientId = "cardealership-web-app",
                    ClientName = "СarDealership Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "http://localhost:3001/signin-oidc"
                    },
                    AllowedCorsOrigins =
                    {
                        "http://localhost:3001"
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:3001/signout-oidc"
                    },
                    // Области, доступные клиенту
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "СarDealershipWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}
