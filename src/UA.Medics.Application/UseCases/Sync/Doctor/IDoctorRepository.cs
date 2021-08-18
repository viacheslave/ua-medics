using System;
using System.Threading.Tasks;
using UA.Medics.Application;

namespace UA.Medics.Domain
{
	public interface IDoctorRepository : IRepository<Doctor>
	{
		/// <summary>
		///		Checks created doctors for a given date
		/// </summary>
		/// <param name="date">Date in question</param>
		/// <returns></returns>
		Task<bool> Any(DateTime date);
	}
}