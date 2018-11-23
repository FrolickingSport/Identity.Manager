using Identity.Manager.Areas.v1.Models;
using Identity.Storage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Manager.Areas.v1.Controllers
{
	[Area("v1")]
	public class AccountController : Controller
	{
		private readonly UserManager<ManagedUser> _userManager;
		private readonly RoleManager<ManagedRole> _roleManager;

		public AccountController(
			UserManager<ManagedUser> userManager,
			RoleManager<ManagedRole> roleManager
			)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}

		[HttpPost]
		public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var user = new ManagedUser { UserName = model.UserName, FirstName = model.FirstName, LastName = model.LastName, Email = model.Email };

			var result = await _userManager.CreateAsync(user, model.Password);
			
			string role = "Basic User";

			if (result.Succeeded)
			{
				await _userManager.AddToRoleAsync(user, role);
				await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("userName", user.UserName));
				await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("firstName", user.FirstName));
				await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("lastName", user.LastName));
				await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("email", user.Email));
				await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("role", role));

				return Ok(new ProfileViewModel(user));
			}

			return BadRequest(result.Errors);
		}
	}
}
