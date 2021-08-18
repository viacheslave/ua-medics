using System;

namespace UA.Medics.Infrastructure.Jobs
{
	public record JobInfo (
			bool RunNow,
			string Cron,
			Type Type
		);
}
