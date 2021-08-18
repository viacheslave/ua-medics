using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UA.Medics.Application;
using UA.Medics.Domain;

namespace UA.Medics.Infrastructure.Data
{
	public class StatsByDoctorAgeRepository : BaseRepository<StatsByDoctorAge>, IStatsByDoctorAgeRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public StatsByDoctorAgeRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public Task<bool> Any(DateTime date)
		{
			return _dbContext.Set<StatsByDoctorAge>().AnyAsync(d => d.StatsDate == date);
		}
	}
}
