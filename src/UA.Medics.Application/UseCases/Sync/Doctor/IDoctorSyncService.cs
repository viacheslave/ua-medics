using System.Threading.Tasks;

namespace UA.Medics.Application
{
	public interface IDoctorSyncService
	{
		Task Sync();
	}
}