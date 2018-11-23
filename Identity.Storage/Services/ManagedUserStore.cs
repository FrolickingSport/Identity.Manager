using Identity.Storage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Storage.Services
{
	public class ManagedUserStore : UserStore<ManagedUser, ManagedRole, Data.ManagedDbContext, Guid, ManagedUserClaim, ManagedUserRole, IdentityUserLogin<Guid>, IdentityUserToken<Guid>, IdentityRoleClaim<Guid>>
	{
		public ManagedUserStore(Data.ManagedDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
		{
		}
	}
}
