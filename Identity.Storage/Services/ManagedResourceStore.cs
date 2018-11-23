using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Storage.Services
{
	public class ManagedResourceStore : IResourceStore, IDisposable
	{
		private Data.ManagedDbContext _context;

		public ManagedResourceStore(Data.ManagedDbContext context)
		{
			_context = context;
		}

		public async Task<ApiResource> FindApiResourceAsync(string name)
		{
			var resource = await _context.ApiResources.FindAsync().ConfigureAwait(false);

			if (resource == null)
				return null;

			return new ApiResource(name, resource.DisplayName, resource.UserClaims.Select(c => c.ClaimType));
		}

		public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
		{
			var resources = await _context.ApiResources.Where(a => scopeNames.Contains(a.Name)).ToListAsync();

			return resources.Select(r => new ApiResource(r.Name, r.DisplayName, r.UserClaims.Select(c => c.ClaimType)));
		}

		public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
		{
			var resources = await _context.ApiResources.Where(a => scopeNames.Contains(a.Name)).ToListAsync();

			return resources.Select(r => new IdentityResource(r.Name, r.DisplayName, r.UserClaims.Select(c => c.ClaimType)));
		}

		public async Task<Resources> GetAllResourcesAsync()
		{
			var apiResources = await _context.ApiResources.AsQueryable().ToListAsync().ConfigureAwait(false);

			var api = apiResources.Select(r => new ApiResource(r.Name, r.DisplayName, r.UserClaims.Select(c => c.ClaimType)));

			var identityResources = await _context.IdentityResources.AsQueryable().ToListAsync().ConfigureAwait(false);

			var identity = identityResources.Select(r => new IdentityResource(r.Name, r.DisplayName, r.UserClaims.Select(c => c.ClaimType)));

			return new Resources(identity, api);
		}

		protected void Dispose(bool dispose)
		{
			if (dispose)
			{
				if (_context != null)
				{
					_context.Dispose();
					_context = null;
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		~ManagedResourceStore()
		{
			Dispose(false);
		}
	}
}
