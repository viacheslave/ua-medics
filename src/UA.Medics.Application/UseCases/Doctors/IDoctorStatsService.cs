using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UA.Medics.Domain;

namespace UA.Medics.Application
{
	public interface IDoctorStatsService
	{
		Task<IEnumerable<DoctorInfoDto>> GetDoctors(GetDoctorsQuery query);

		Task<IEnumerable<NewDoctorInfoDto>> GetNewDoctors(GetNewDoctorsQuery query);

		Task<IEnumerable<DismissedDoctorInfoDto>> GetDismissedDoctors(GetDismissedDoctorsQuery query);

		Task<DoctorStatsDto> GetDoctorStats(GetDoctorStatsQuery query);
	}
}