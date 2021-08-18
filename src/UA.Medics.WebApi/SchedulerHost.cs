using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using UA.Medics.Infrastructure.Jobs;

namespace UA.Medics.WebApi
{
	/// <summary>
	///		Starts / stops Quartz scheduler
	/// </summary>
	public class SchedulerHost : IHostedService
	{
		private readonly JobScheduler _jobScheduler;

		public SchedulerHost(JobScheduler jobScheduler)
		{
			_jobScheduler = jobScheduler;
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			//await _jobScheduler.Init(cancellationToken);
		}

		public async Task StopAsync(CancellationToken cancellationToken)
		{
			//await _jobScheduler.Shutdown(cancellationToken);
		}
	}
}
