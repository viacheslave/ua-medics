using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UA.Medics.Application;
using UA.Medics.Domain;

namespace UA.Medics.WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DoctorsController : ApiController
	{
		/// <summary>
		///		Returns all doctors
		/// </summary>
		/// <returns>Collection of doctors data</returns>
		[HttpGet("")]
		public async Task<IEnumerable<DoctorInfoDto>> GetDoctors()
		{
			return await Mediator.Send(new GetDoctorsQuery());
		}

		/// <summary>
		///		Returns newest doctors
		/// </summary>
		/// <returns>Collection of new doctors</returns>
		[HttpGet("new")]
		public async Task<IEnumerable<DoctorInfoDto>> GetNewDoctors()
		{
			return await Mediator.Send(new GetNewDoctorsQuery(DateTime.Today));
		}

		/// <summary>
		///		Returns doctor history of declarations
		/// </summary>
		/// <param name="legalEntityId">Legal Entity</param>
		/// <param name="partyTempId">Doctor</param>
		/// <returns>Doctor's data</returns>
		[HttpGet("history/{legalEntityId}/{partyTempId:int}")]
		public async Task<DoctorStatsDto> GetDoctorHistory(Guid legalEntityId, int partyTempId)
		{
			return await Mediator.Send(new GetDoctorStatsQuery(legalEntityId , partyTempId));
		}
	}
}
