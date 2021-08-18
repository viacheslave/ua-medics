using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UA.Medics.Domain;

namespace UA.Medics.Application.UseCases.Doctors.Queries
{
	public class GetDismissedDoctorsQueryHandler : IRequestHandler<GetDismissedDoctorsQuery, IEnumerable<DismissedDoctorInfoDto>>
	{
		private readonly IDoctorStatsService _doctorStatsService;

		public GetDismissedDoctorsQueryHandler(IDoctorStatsService doctorStatsService)
		{
			_doctorStatsService = doctorStatsService;
		}

		public Task<IEnumerable<DismissedDoctorInfoDto>> Handle(GetDismissedDoctorsQuery request, CancellationToken cancellationToken)
		{
			return _doctorStatsService.GetDismissedDoctors(request);
		}
	}
}
