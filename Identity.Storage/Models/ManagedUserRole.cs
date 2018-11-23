using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Storage.Models
{
	public class ManagedUserRole : IdentityUserRole<Guid>
	{
		public ManagedUser User { get; set; }

		public ManagedRole Role { get; set; }
	}
}
