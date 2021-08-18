using System.Collections.Generic;
using System.Threading.Tasks;
using UA.Medics.Application;

namespace UA.Medics.Infrastructure.DataProvider
{
	public interface IPageParser
	{
		Task<IReadOnlyCollection<LinkEntry>> GetLinks(string url);
	}
}