using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UA.Medics.Domain;

namespace UA.Medics.Application.UseCases.Doctors.Queries
{
	public class GetNewDoctorsQueryHandler : IRequestHandler<GetNewDoctorsQuery, IEnumerable<NewDoctorInfoDto>>
	{
		private readonly IDoctorStatsService _doctorStatsService;

		public GetNewDoctorsQueryHandler(IDoctorStatsService doctorStatsService)
		{
			_doctorStatsService = doctorStatsService;
		}

		public Task<IEnumerable<NewDoctorInfoDto>> Handle(GetNewDoctorsQuery request, CancellationToken cancellationToken)
		{
			return _doctorStatsService.GetNewDoctors(request);
		}
	}
}
