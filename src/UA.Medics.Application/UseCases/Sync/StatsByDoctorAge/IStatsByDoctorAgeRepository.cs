using System;
using System.Threading.Tasks;
using UA.Medics.Domain;

namespace UA.Medics.Application
{
	public interface IStatsByDoctorAgeRepository : IRepository<StatsByDoctorAge>
	{
		/// <summary>
		///		Checks stats for a given date
		/// </summary>
		/// <param name="date">Date in question</param>
		/// <returns></returns>
		Task<bool> Any(DateTime date);
	}
}