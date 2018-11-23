using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Manager.Services;
using Identity.Storage.Data;
using Identity.Storage.Models;
using Identity.Storage.Services;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Identity.Manager
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ManagedDbContext>(options =>
			   options.UseSqlServer(Configuration.GetConnectionString("default")));

			services.AddIdentity<ManagedUser, ManagedRole>()
				.AddEntityFrameworkStores<ManagedDbContext>()
				.AddDefaultTokenProviders();

			services.AddIdentityServer()
				.AddDeveloperSigningCredential()
				.AddInMemoryPersistedGrants()
				.AddClientStore<ManagedClientStore>()
				.AddResourceStore<ManagedResourceStore>()
				.AddClientStore<ManagedClientStore>()
				.AddAspNetIdentity<ManagedUser>();

			services.AddMvc();

			services.AddTransient<IProfileService, IdentityClaimsProfileService>();

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				// base-address of your identityserver
				options.Authority = Configuration.GetValue<string>("Address");

				// name of the API resource
				options.Audience = "IdentityAPI";

				options.RequireHttpsMetadata = false;
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();
		}
	}
}
