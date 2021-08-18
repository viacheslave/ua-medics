using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quartz;
using UA.Medics.Application;

namespace UA.Medics.Infrastructure.Jobs
{
	/// <summary>
	///		Triggers data sync
	/// </summary>
	[DisallowConcurrentExecution]
	public class SyncDataJob : IJob
	{
		private readonly IDataSyncService _dataProvider;
		private readonly ILogger<SyncDataJob> _logger;

		public SyncDataJob(IDataSyncService dataProvider, ILogger<SyncDataJob> logger)
		{
			_dataProvider = dataProvider;
			_logger = logger;
		}

		public async Task Execute(IJobExecutionContext context)
		{
			await Task.Delay(TimeSpan.FromSeconds(5));

			try
			{
				await _dataProvider.SyncAll();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Job failed");
			}
		}
	}
}
