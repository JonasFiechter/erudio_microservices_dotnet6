using Duende.IdentityServer;
using Duende.IdentityServer.Models;

using System.Collections.Generic;

namespace GeekShopping.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string Custommer = "Custommer";

        public static IEnumerable<IdentityResource> IdentityResources => 
            new List<IdentityResource>
            {
                new IdentityResource.OpenId(),
                new IdentityResource.Email(),
                new IdentityResource.Profile(),
            };
        
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope> 
            {
                new ApiScope("geek_shopping", "GeekShopping Server"),
                new ApiScope(name: "read", "Read data."),
                new ApiScope(name: "write", "Write data."),
                new ApiScope(name: "delete", "Delete data."),
            };

        public static IEnumerable<Client> Clients => 
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = {
                        new Secret("my_secret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {
                        "read", "write", "profile"
                    }
                },

                new Client
                {
                    ClientId = "geek_shopping",
                    ClientSecrets = {
                        new Secret("my_secret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"http://localhost:36637/signin-oidc" },
                    PostLogoutRedirectUris = {"http://localhost:36637/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "geek_shopping"
                    }
                }
            };
    }
}