using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UA.Medics.Application;
using UA.Medics.Infrastructure.Configuration;

namespace UA.Medics.WebApi
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
			services
				.AddControllers()
				.AddJsonOptions(c => c.JsonSerializerOptions.WriteIndented = true);

			services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "UA.Medics.WebApi", Version = "v1" }));

			services.AddApplicationServices();
			services.AddInfrastructureServices();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UA.Medics.WebApi v1"));

			app.UseRouting();

			app.UseEndpoints(endpoints => endpoints.MapControllers());
		}
	}
}
