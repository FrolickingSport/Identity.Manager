using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Identity.Storage.Models
{
	public class Client
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string SecretHash { get; set; }

		public ICollection<ManagedIdentityResource> AllowedResources { get; set; }

		public ICollection<ManagedRole> PossibleRoles { get; set; }

		public IdentityServer4.Models.Client Convert()
		{
			return new IdentityServer4.Models.Client()
			{
				ClientId = Id.ToString(),
				ClientName = Name,
				AllowedGrantTypes = IdentityServer4.Models.GrantTypes.ResourceOwnerPassword,

				ClientSecrets =
					{
						new IdentityServer4.Models.Secret(SecretHash)
					},
				AllowedScopes = AllowedResources.Select(c => c.Name).ToList()
			};
		}
	}
}
