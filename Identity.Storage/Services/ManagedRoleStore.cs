using Identity.Storage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Storage.Services
{
	public class ManagedRoleStore : RoleStore<ManagedRole, Data.ManagedDbContext, Guid, ManagedUserRole, IdentityRoleClaim<Guid>>
	{
		public ManagedRoleStore(Data.ManagedDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
		{
		}
	}
}
