using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UA.Medics.Application;
using UA.Medics.Infrastructure.Configuration;
using UA.Medics.Infrastructure.Data;

namespace UA.Medics.SyncWorker
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var configurationRoot = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddEnvironmentVariables()
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.Build();

			var serviceProvider = BuildServiceProvider(configurationRoot);
			using var scope = serviceProvider.CreateScope();

			var progress = scope.ServiceProvider.GetRequiredService<IProgress<string>>();

			while (true)
			{
				await Task.Delay(TimeSpan.FromSeconds(5));

				try
				{
					var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
					dbContext.Database.Migrate();

					break;
				}
				catch (Exception ex)
				{
					progress.Report(ex.Message);
				}
			}

			var dataSyncer = scope.ServiceProvider.GetRequiredService<IDataSyncService>();

			await dataSyncer.SyncAll();

			Console.WriteLine("All done.");
		}

		private static ServiceProvider BuildServiceProvider(IConfiguration configuration)
		{
			var services = new ServiceCollection();

			services.AddApplicationServices();
			services.AddInfrastructureServices();

			services.AddTransient(c => configuration);
			services.AddTransient<IProgress<string>>(_ => new Progress<string>(Console.WriteLine));
			services.AddSingleton(_ => new HttpClient());

			services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
			services.AddScoped<ApplicationDbContext>();

			return services.BuildServiceProvider();
		}
	}
}
