using System;
using BusinessLogic.Data;
using BusinessLogic.Logic;
using Core.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApi
{
	public class Startup
	{
		public IConfiguration Configuration { get; }


		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(ServiceCollection services)
		{

			services.AddDbContext<MarketDbContext>(opt =>
			{
				opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
			});

			services.AddTransient<IProductRepository, ProductRepository>();
			services.AddControllers();
		}

		public void Configure(ApplicationBuilder App, IWebHostEnvironment env)
		{
			if (env.IsDevelopment()) {
				App.UseDeveloperExceptionPage();
			}

			App.UseRouting();
			App.UseAuthentication();
			App.UseAuthorization();
			App.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}

