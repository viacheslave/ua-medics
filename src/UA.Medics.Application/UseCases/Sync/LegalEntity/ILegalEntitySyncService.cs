using System.Threading.Tasks;

namespace UA.Medics.Application
{
	public interface ILegalEntitySyncService
	{
		Task Sync();
	}
}