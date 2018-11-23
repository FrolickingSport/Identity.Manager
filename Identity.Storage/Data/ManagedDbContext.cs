using Identity.Storage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Storage.Data
{
	public class ManagedDbContext : IdentityDbContext<ManagedUser, ManagedRole, Guid,ManagedUserClaim, ManagedUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
	{
		public DbSet<Models.Client> Clients { get; set; }

		public DbSet<Models.ManagedIdentityResource> IdentityResources { get; set; }

		public DbSet<Models.ManagedApiResource> ApiResources { get; set; }
	}
}
