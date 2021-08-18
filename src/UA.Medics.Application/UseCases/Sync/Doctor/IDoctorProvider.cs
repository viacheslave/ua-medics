using System.Collections.Generic;
using System.Threading.Tasks;
using UA.Medics.Application;
using UA.Medics.Domain;

namespace UA.Medics.Application
{
	public interface IDoctorProvider
	{
		Task<IReadOnlyCollection<Doctor>> GetRecords(LinkEntry linkEntry);
	}
}