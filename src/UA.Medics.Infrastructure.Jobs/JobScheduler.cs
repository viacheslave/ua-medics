using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Quartz;
using Quartz.Spi;

namespace UA.Medics.Infrastructure.Jobs
{
	public class JobScheduler
	{
		public IScheduler Scheduler { get; set; }

		private readonly ISchedulerFactory _schedulerFactory;
		private readonly IJobFactory _jobFactory;
		private readonly IReadOnlyCollection<JobInfo> _jobsInfos;

		public JobScheduler(IJobFactory jobFactory, ISchedulerFactory schedulerFactory, IEnumerable<JobInfo> jobInfos)
		{
			_jobFactory = jobFactory;
			_schedulerFactory = schedulerFactory;
			_jobsInfos = jobInfos.ToList();
		}

		public async Task Init(CancellationToken cancellationToken = default)
		{
			Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
			Scheduler.JobFactory = _jobFactory;

			foreach (var jobInfo in _jobsInfos)
			{
				var jobDetail = BuildJobDetail(jobInfo);

				var trigger = TriggerBuilder
					.Create()
					.WithIdentity($"trigger-{jobInfo.Type.Name}")
					.WithCronSchedule(jobInfo.Cron)
					.Build();

				if (jobInfo.RunNow)
				{
					await RunNow(jobInfo, cancellationToken);
				}

				await Scheduler.ScheduleJob(jobDetail, trigger, cancellationToken);
			}

			await Scheduler.Start(cancellationToken);
		}

		public async Task Shutdown(CancellationToken cancellationToken = default) => Scheduler?.Shutdown(cancellationToken);

		public async Task RunNow(JobInfo jobInfo, CancellationToken cancellationToken = default)
		{
			var jobDetail = BuildJobDetail(jobInfo);

			var triggerKey = new TriggerKey($"trigger-now-{jobInfo.Type.Name}-{DateTime.UtcNow.Ticks}");

			var trigger = TriggerBuilder
				.Create()
				.WithIdentity(triggerKey)
				.StartNow()
				.Build();

			await Scheduler.ScheduleJob(jobDetail, trigger, cancellationToken);
		}

		private static IJobDetail BuildJobDetail(JobInfo jobInfo)
		{
			var jobKey = new JobKey($"job-{jobInfo.Type.Name}-{DateTime.UtcNow.Ticks}");

			return JobBuilder
				.Create(jobInfo.Type)
				.WithIdentity(jobKey)
				.WithDescription(jobInfo.Type.Name)
				.SetJobData(new JobDataMap())
				.Build();
		}
	}
}
