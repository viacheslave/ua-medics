using MediatR;
using System;
using System.Collections.Generic;
using UA.Medics.Domain;

namespace UA.Medics.Application
{
	public record GetDoctorsQuery : IRequest<IEnumerable<DoctorInfoDto>> { }

	public record GetNewDoctorsQuery(DateTime date) : IRequest<IEnumerable<DoctorInfoDto>> { }

	public record GetDoctorStatsQuery(Guid LegalEntityId, int PartyTempId) : IRequest<DoctorStatsDto> { };
}
