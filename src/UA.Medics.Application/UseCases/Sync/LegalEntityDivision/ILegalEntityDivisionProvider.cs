using System.Collections.Generic;
using System.Threading.Tasks;
using UA.Medics.Application;
using UA.Medics.Domain;

namespace UA.Medics.Application
{
	public interface ILegalEntityDivisionProvider
	{
		Task<IReadOnlyCollection<LegalEntityDivision>> GetRecords(LinkEntry linkEntry);
	}
}