using System;
using Quartz;
using Quartz.Spi;

namespace UA.Medics.Infrastructure.Jobs
{
	public class JobFactory : IJobFactory
	{
		private readonly IServiceProvider _serviceProvider;

		public JobFactory(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
		{
			var jobType = bundle.JobDetail.JobType;

			var job = _serviceProvider.GetService(jobType);
			if (job == null)
				throw new InvalidOperationException("Unable to resolve job");

			return job as IJob;
		}

		public void ReturnJob(IJob job) 
		{
		}
	}
}
