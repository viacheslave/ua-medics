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
		public async Task<IEnumerable<NewDoctorInfoDto>> GetNewDoctors()
		{
			return await Mediator.Send(
				new GetNewDoctorsQuery(DateTime.Today.AddDays(-60), DateTime.Today));
		}

		/// <summary>
		///		Returns newest doctors according to the lattest stats
		/// </summary>
		/// <returns>Collection of new doctors</returns>
		[HttpGet("new/latest")]
		public async Task<IEnumerable<NewDoctorInfoDto>> GetNewDoctorsLatest()
		{
			return await Mediator.Send(
				new GetNewDoctorsQuery(DateTime.Today, DateTime.Today));
		}

		/// <summary>
		///		Returns dismissed doctors
		/// </summary>
		/// <returns>Collection of new doctors</returns>
		[HttpGet("dismissed")]
		public async Task<IEnumerable<DismissedDoctorInfoDto>> GetDismissedDoctors()
		{
			return await Mediator.Send(
				new GetDismissedDoctorsQuery(DateTime.Today.AddDays(-60), DateTime.Today));
		}

		/// <summary>
		///		Returns dismissed doctors according to the lattest stats
		/// </summary>
		/// <returns>Collection of new doctors</returns>
		[HttpGet("dismissed/latest")]
		public async Task<IEnumerable<DismissedDoctorInfoDto>> GetDismissedDoctorsLatest()
		{
			return await Mediator.Send(
				new GetDismissedDoctorsQuery(DateTime.Today, DateTime.Today));
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
