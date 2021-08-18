using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using UA.Medics.Application;
using UA.Medics.Domain;
using UA.Medics.Infrastructure.Data;
using UA.Medics.Infrastructure.DataProvider;
using UA.Medics.Infrastructure.Jobs;

namespace UA.Medics.Infrastructure.Configuration
{
	public static class DependencyInjection
	{
		public static void AddInfrastructureServices(this IServiceCollection services)
		{
			services.AddLogging(configure => configure.AddConsole());

			services.AddHttpClient();

			services.AddTransient<IAppConfiguration, AppConfiguration>();

			services.AddTransient<ILinksProvider, LinksProvider>();
			services.AddTransient<IFileDownloader, FileDownloader>();
			services.AddTransient<IPageParser, PageParser>();
			services.AddTransient<IStatsByDoctorAgeProvider, StatsByDoctorAgeProvider>();

			services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
			services.AddTransient<ApplicationDbContext>();

			services.AddTransient<IRepository<LegalEntity>, LegalEntityRepository>();
			services.AddTransient<IRepository<LegalEntityDivision>, LegalEntityDivisionRepository>();
			services.AddTransient<IDoctorRepository, DoctorRepository>();
			services.AddTransient<IStatsByDoctorAgeRepository, StatsByDoctorAgeRepository>();

			services.AddTransient<ILegalEntityProvider, LegalEntityProvider>();
			services.AddTransient<ILegalEntityDivisionProvider, LegalEntityDivisionProvider>();
			services.AddTransient<IDoctorProvider, DoctorProvider>();
			services.AddTransient<IStatsByDoctorAgeProvider, StatsByDoctorAgeProvider>();

			//services.AddHostedService<SchedulerHost>();
		}

		private static void ConfigureQuartz(IServiceCollection services)
		{
			services.AddSingleton<IJobFactory, JobFactory>();
			services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
			services.AddSingleton<JobScheduler>();

			services.AddSingleton(new JobInfo(
					RunNow: true,
					Cron: "0 0 1 * * ?", // every day at 1am
					Type: typeof(SyncDataJob)
				));

			services.AddSingleton<SyncDataJob>();
		}
	}
}
