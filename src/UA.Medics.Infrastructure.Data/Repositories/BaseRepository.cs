using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UA.Medics.Application;

namespace UA.Medics.Infrastructure.Data
{
	public abstract class BaseRepository<T> : IRepository<T>
		 where T : class
	{
		private readonly ApplicationDbContext _dbContext;

		public BaseRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IUnitOfWork UnitOfWork => _dbContext;

		public async Task AddOrUpdate(T record)
		{
			var dbRecord = await FindAsync(_dbContext.Set<T>(), record);
			if (dbRecord is null)
			{
				await _dbContext.Set<T>().AddAsync(record);
				return;
			}

			Update(record, dbRecord);
		}

		public async Task AddRange(T[] records)
		{
			await _dbContext.Set<T>().AddRangeAsync(records);
		}

		protected virtual ValueTask<T> FindAsync(DbSet<T> set, T record) => ValueTask.FromResult<T>(default);

		protected virtual void Update(T record, T dbRecord) { }
	}
}
