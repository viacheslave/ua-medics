using System.Collections.Generic;
using System.Threading.Tasks;
using UA.Medics.Domain;

namespace UA.Medics.Application
{
	public interface IStatsByDoctorAgeProvider
	{
		Task<IReadOnlyCollection<StatsByDoctorAge>> GetRecords(LinkEntry linkEntry);
	}
}