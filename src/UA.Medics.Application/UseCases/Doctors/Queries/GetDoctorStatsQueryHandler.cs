using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UA.Medics.Domain;

namespace UA.Medics.Application.UseCases.Doctors.Queries
{
	public class GetDoctorStatsQueryHandler : IRequestHandler<GetDoctorStatsQuery, DoctorStatsDto>
	{
		private readonly IDoctorStatsService _doctorStatsService;

		public GetDoctorStatsQueryHandler(IDoctorStatsService doctorStatsService)
		{
			_doctorStatsService = doctorStatsService;
		}

		public Task<DoctorStatsDto> Handle(GetDoctorStatsQuery request, CancellationToken cancellationToken)
		{
			return _doctorStatsService.GetDoctorStats(request);
		}
	}
}
