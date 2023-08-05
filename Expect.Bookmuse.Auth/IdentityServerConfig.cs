using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace Expect.Bookmuse.Auth
{
	public static class IdentityServerConfig
	{
		public static IEnumerable<ApiResource> GetApiResources()
		{
			return new List<ApiResource>()
			{
				new ApiResource("getbooks", "Main Service GetBooks API")
				{
					Scopes = {"getbooks"}
				},
				new ApiResource("crud", "Main Service Crud API")
				{
					Scopes = {"crud"}
				}
			};
		}

		public static IEnumerable<IdentityResource> GetIdentityResources()
		{
			return new List<IdentityResource>()
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile(),
			};
		}

		public static IEnumerable<ApiScope> GetApiScopes()
		{
			return new List<ApiScope>()
			{
				new ApiScope("getbooks", "Main Service GetBooks API"),
				new ApiScope("crud","Main Service Crud API")
			};
		}

		public static IEnumerable<Client> GetClients()
		{
			return new List<Client>
			{
				new Client()
				{
					ClientId = "admin",
					AllowedGrantTypes = GrantTypes.ClientCredentials,
					ClientSecrets =
					{
						new Secret("admin_secret".Sha256())
					},
					AllowedScopes = { "getbooks" , "crud" },
					Claims =
					{
						new()
						{
							Type = "controller",
							Value = "getbooks",
						},
					}
				}
			};
		}

		public static List<TestUser> GetTestUsers()
		{
			return new List<TestUser>();
		}
	}
}