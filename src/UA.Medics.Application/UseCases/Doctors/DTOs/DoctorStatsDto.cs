using System;

namespace UA.Medics.Domain
{
	public class DoctorStatsDto
	{
		public DoctorInfoDto DoctorInfo { get; set; }

		public DoctorDeclarationsStatsDto[] Stats { get; set; } = Array.Empty<DoctorDeclarationsStatsDto>();
	}
}
