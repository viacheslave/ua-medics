using System;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using UA.Medics.Infrastructure.Data;

namespace UA.Medics.Application
{
	public static class DependencyInjection
	{
		public static void AddApplicationServices(this IServiceCollection services)
		{
			services.AddMediatR(Assembly.GetExecutingAssembly());

			services.AddTransient<IProgress<string>>(c =>
				new Progress<string>(
					s => c.GetRequiredService<ILogger<DataSyncService>>().LogInformation(s)));

			services.AddTransient<IDataSyncService, DataSyncService>();
			services.AddTransient<IDoctorStatsService, DoctorStatsService>();

			services.AddTransient<ILegalEntitySyncService, LegalEntitySyncService>();
			services.AddTransient<ILegalEntityDivisionSyncService, LegalEntityDivisionSyncService>();
			services.AddTransient<IDoctorSyncService, DoctorSyncService>();
			services.AddTransient<IStatsByDoctorAgeSyncService, StatsByDoctorAgeSyncService>();
		}
	}
}
