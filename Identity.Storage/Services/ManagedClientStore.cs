using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Storage.Services
{
	public class ManagedClientStore : IClientStore, IDisposable
	{
		private Data.ManagedDbContext _context;

		public ManagedClientStore(Data.ManagedDbContext context)
		{
			_context = context;
		}

		public async Task<Client> FindClientByIdAsync(string clientId)
		{
			var client = await _context.Clients.FindAsync(clientId).ConfigureAwait(false);

			return client?.Convert();
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

		~ManagedClientStore()
		{
			Dispose(false);
		}
	}
}
