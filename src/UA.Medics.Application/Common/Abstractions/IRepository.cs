using System.Threading.Tasks;

namespace UA.Medics.Application
{
	public interface IRepository<T>
	{
		IUnitOfWork UnitOfWork { get; }

		Task AddOrUpdate(T record);

		Task AddRange(T[] records);
	}
}