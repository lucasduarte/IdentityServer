using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace Security.IdentityServer.Configuration
{
    public class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientName = "Katana Hybrid Client Demo",
                    Enabled = true,
                    ClientId = "katanaclient",
                    ClientSecrets = new List<Secret>
                    { 
                        new Secret("secret".Sha256())
                    },

                    Flow = Flows.Hybrid,
                    
                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Profile,
                        Constants.StandardScopes.Email,
                        Constants.StandardScopes.Roles,
                        Constants.StandardScopes.OfflineAccess,
                        "read",
                        "write"
                    },
                    
                    ClientUri = "https://identityserver.io",

                    RequireConsent = false,
                    AccessTokenType = AccessTokenType.Reference,
                    
                    RedirectUris = new List<string>
                    {
                        "http://localhost:2672/",
                        "https://localhost:44300/"
                    },

                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:2672/",
                        "https://localhost:44300/"
                    },

                    LogoutUri = "https://localhost:44300/Home/OidcSignOut",
                    LogoutSessionRequired = true
                },
       
                new Client 
                {
                    ClientName = "MVC Client",
                    ClientId = "mvc",
                    Flow = Flows.Implicit,

                    RedirectUris = new List<string>
                    {
                        "https://localhost:44322/"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:44322/"
                    },
                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "profile",
                        "roles",
                        "sampleApi"
                    }
                }
            };
        }
    }
}