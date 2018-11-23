using Identity.Storage.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Manager.Areas.v1.Controllers
{
	public class BasicController : Controller
	{
		protected ManagedDbContext DbContext { get; private set; }

		public BasicController(ManagedDbContext context)
		{
			DbContext = context;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (DbContext != null)
				{
					DbContext.Dispose();
					DbContext = null;
				}
			}

			base.Dispose(disposing);
		}

		~BasicController()
		{
			Dispose(false);
		}
	}
}
