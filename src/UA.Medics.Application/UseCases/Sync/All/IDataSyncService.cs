using System.Threading.Tasks;

namespace UA.Medics.Application
{
	public interface IDataSyncService
	{
		Task SyncAll();
	}
}