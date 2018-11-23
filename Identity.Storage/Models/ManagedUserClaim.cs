using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Storage.Models
{
	public class ManagedUserClaim : IdentityUserClaim<Guid>
	{
		public Services.ClaimValueType ValueType { get; set; }
	}
}
