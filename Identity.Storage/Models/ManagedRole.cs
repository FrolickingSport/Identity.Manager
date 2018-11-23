using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Storage.Models
{
	public class ManagedRole : IdentityRole<Guid>
	{
		public string Description { get; set; }

		public ICollection<ManagedUser> Users { get; }

		public ICollection<ManagedUserClaim> Claims { get; }
	}
}
