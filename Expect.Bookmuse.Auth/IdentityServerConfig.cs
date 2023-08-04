using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Expect.Bookmuse.Auth
{
	public static class IdentityServerConfig
	{
		public static IEnumerable<ApiResource> GetApiResources()
		{
			return new List<ApiResource>()
			{
				new ApiResource("getbooks", "GetBooks")
				{
					Scopes = {"getbooks.read", "getbooks.write"}
				},
				new ApiResource("crud", "Crud")
				{
					Scopes = {"crud.read", "crud.write"}
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
				new ApiScope("getbooks", "GetBooks"),
				new ApiScope("crud","Crud")
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
					AllowedScopes = {"getbooks", "crud"},
				}
			};
		}

		public static List<TestUser> GetTestUsers()
		{
			return new List<TestUser>();
		}
	}
}