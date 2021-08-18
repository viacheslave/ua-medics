using System.Collections.Generic;
using System.Threading.Tasks;
using UA.Medics.Domain;

namespace UA.Medics.Application
{
	public interface ILinksProvider
	{
		Task<IReadOnlyCollection<LinkEntry>> GetLinks(DataSetType type);
	}
}