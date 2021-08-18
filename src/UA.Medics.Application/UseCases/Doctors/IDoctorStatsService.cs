using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UA.Medics.Domain;

namespace UA.Medics.Application
{
	public interface IDoctorStatsService
	{
		Task<IEnumerable<DoctorInfoDto>> GetDoctors(GetDoctorsQuery query);

		Task<IEnumerable<DoctorInfoDto>> GetNewDoctors(GetNewDoctorsQuery query);

		Task<DoctorStatsDto> GetDoctorStats(GetDoctorStatsQuery query);
	}
}