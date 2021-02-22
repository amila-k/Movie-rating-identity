using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext
//dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext
namespace IdentityPlural.Configuration
{
    public class InMemoryConfiguration
    {
        // used for scopes
        public static IEnumerable<IdentityResource> IdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        // not sure what's the purpose
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "socialnetworkresource",
                    Scopes = new[] { "socialnetworkscope" }
                },
                new ApiResource
                {
                    Name = "profile"
                }
            };
        }

        // used for scopes
        public static IEnumerable<ApiScope> ApiScopes()
        {
            return new[] {
                new ApiScope("socialnetworkscope", "Social Network"),
                new ApiScope("myscope", "My Scope")
            };
        }

        public static IEnumerable<Client> Clients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "socialnetworkclient",
                    ClientSecrets = new [] { new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    //RequireClientSecret = false,
                    AllowedScopes = { "profile", "myscope", "socialnetworkscope" }
                },
                new Client
                {
                    ClientId = "socialnetworkclientimplicit",
                    ClientSecrets = new [] { new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Implicit,
                    //RequireClientSecret = false,
                    AllowedScopes = { "openid", "profile", "myscope", "socialnetworkscope" },
                    RedirectUris = new[] { "http://localhost:4200/signin-callback", "http://localhost:4200/login-success" },
                    AllowAccessTokensViaBrowser = true
                },
                                new Client
                {
                    ClientId = "socialnetworkclientcode",
                    ClientSecrets = new [] { new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    //RequireClientSecret = false,
                    AllowedScopes = { "openid", "profile", "myscope", "socialnetworkscope" },
                    RedirectUris = new[] { "http://localhost:4200/signin-callback", "http://localhost:4200/login-success" },
                    AllowAccessTokensViaBrowser = true
                }
            };
        }

        public static IEnumerable<TestUser> Users()
        {
            return new[]
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "amila",
                    Password = "Test123!"
                }
            };
        }
    }
}
