using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace backend.Configs
{
    public class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "testScope",
                    UserClaims = {
                        "testScope"
                    }
                },
                new IdentityResource {
                    Name = "offline_access",
                    UserClaims = {
                        "offline_access"
                    }
                }
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("api", "API")
            };

        public static IEnumerable<Client> Clients(Dictionary<string, string> clientUrls) =>
            new[]
            {
                new Client
                {
                    ClientId = "ro.client",
                    ClientName = "Resource Owner Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "api" }
                },
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
                    // RequirePkce = true,
                    RequireConsent = false,
                    AllowOfflineAccess = true,
                    // AlwaysIncludeUserClaimsInIdToken = true,
                    // AlwaysSendClientClaims = true,

                    RedirectUris = { $"{clientUrls["Mvc"]}/signin-oidc" },
                    PostLogoutRedirectUris = { $"{clientUrls["Mvc"]}/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "api", "testScope"
                    },

                    RefreshTokenUsage = TokenUsage.ReUse,
                    RefreshTokenExpiration = TokenExpiration.Sliding
                }
            };
    }
}
