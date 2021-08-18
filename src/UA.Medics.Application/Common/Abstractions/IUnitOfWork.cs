using System.Threading.Tasks;

namespace UA.Medics.Application
{
	public interface IUnitOfWork
	{
		Task BeginTransaction();
		Task Commit();
		Task Rollback();
	}
}
