using Identity.Storage.Models;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Manager.Services
{
	public class IdentityClaimsProfileService : IProfileService
	{
		private readonly IUserClaimsPrincipalFactory<ManagedUser> _claimsFactory;
		private readonly UserManager<ManagedUser> _userManager;

		public IdentityClaimsProfileService(UserManager<ManagedUser> userManager, IUserClaimsPrincipalFactory<ManagedUser> claimsFactory)
		{
			_userManager = userManager;
			_claimsFactory = claimsFactory;
		}

		public async Task GetProfileDataAsync(ProfileDataRequestContext context)
		{
			var sub = context.Subject.GetSubjectId();
			var user = await _userManager.FindByIdAsync(sub);
			var principal = await _claimsFactory.CreateAsync(user);

			var claims = principal.Claims.Where(c => context.Client.AllowedScopes.Contains(c.Type)).ToList();

			var roles = await _userManager.GetRolesAsync(user);
			foreach (string role in roles)
			{
				claims.Add(new Claim(JwtClaimTypes.Role, role));
			}

			context.IssuedClaims = claims;
		}

		public async Task IsActiveAsync(IsActiveContext context)
		{
			var sub = context.Subject.GetSubjectId();
			var user = await _userManager.FindByIdAsync(sub);
			context.IsActive = user != null && !user.IsBlocked && !user.IsDeleted;
		}
	}
}
