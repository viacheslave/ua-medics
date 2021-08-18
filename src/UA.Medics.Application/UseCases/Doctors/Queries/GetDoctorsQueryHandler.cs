using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UA.Medics.Domain;

namespace UA.Medics.Application.UseCases.Doctors.Queries
{
	public class GetDoctorsQueryHandler : IRequestHandler<GetDoctorsQuery, IEnumerable<DoctorInfoDto>>
	{
		private readonly IDoctorStatsService _doctorStatsService;

		public GetDoctorsQueryHandler(IDoctorStatsService doctorStatsService)
		{
			_doctorStatsService = doctorStatsService;
		}

		public Task<IEnumerable<DoctorInfoDto>> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
		{
			return _doctorStatsService.GetDoctors(request);
		}
	}
}
