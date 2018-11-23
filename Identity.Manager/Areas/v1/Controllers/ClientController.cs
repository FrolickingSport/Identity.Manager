using Identity.Storage.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Manager.Areas.v1.Controllers
{
	public class ClientController : BasicController
	{
		public ClientController(ManagedDbContext context)
			: base(context)
		{
		}

		[HttpGet]
		public async Task<ActionResult<Models.ViewClientModel>> GetClient([FromQuery] string id)
		{
			var client = await  DbContext.Clients.FindAsync(id);

			if (client == null)
				return BadRequest();

			return new Models.ViewClientModel()
			{
				Id = client.Id,
				Name = client.Name,
				Description = client.Description,
				AllowedScopes = client.AllowedResources.Select(r => r.Name),
				PossibleRoles = client.PossibleRoles.Select(r => r.Name)
			};
		}

		[HttpPost]
		public async Task<IActionResult> CreateClient([FromBody] string id)
		{
			throw new NotImplementedException();
		}

		[HttpPut]
		public async Task<IActionResult> UpdateClient([FromQuery] string id)
		{
			throw new NotImplementedException();
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteClient([FromQuery] string id)
		{
			throw new NotImplementedException();
		}
	}
}
