using System.Threading.Tasks;

namespace UA.Medics.Application
{
	public interface IStatsByDoctorAgeSyncService
	{
		Task Sync();
	}
}