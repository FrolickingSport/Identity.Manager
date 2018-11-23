using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Manager.Areas.v1.Models
{
	public class CreateClientModel
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public IEnumerable<string> AllowedScopes { get; set; }

		public IEnumerable<string> PossibleRoles { get; set; }
	}
}
