using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityModel;

namespace СarDealership.Identity
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("СarDealershipWebAPI", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("СarDealershipWebAPI", "Web API", new []
                    { JwtClaimTypes.Name})
                {
                    Scopes = { "СarDealershipWebAPI" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
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
