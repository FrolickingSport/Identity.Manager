using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Storage.Models
{
	public class ManagedUser : IdentityUser<Guid>
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public bool IsBlocked { get; set; }
		
		public bool IsDeleted { get; set; }

		public ICollection<ManagedUserRole> Roles { get; }

		public ICollection<ManagedUserClaim> Claims { get; }
	}
}
