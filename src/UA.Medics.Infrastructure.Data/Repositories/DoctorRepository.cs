using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UA.Medics.Domain;

namespace UA.Medics.Infrastructure.Data
{
	public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public DoctorRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		protected override ValueTask<Doctor> FindAsync(DbSet<Doctor> set, Doctor record)
		{
			return set.FindAsync(record.PartyTempId, record.LegalEntityId);
		}

		protected override void Update(Doctor record, Doctor dbRecord)
		{
			dbRecord.LegalEntityId = record.LegalEntityId;
			dbRecord.LegalEntityDivisionId = record.LegalEntityDivisionId;
			dbRecord.EmployeeSpeciality = record.EmployeeSpeciality;
			dbRecord.PartyName = record.PartyName;

			dbRecord.DateUpdated = record.DateUpdated;
		}

		public Task<bool> Any(DateTime date)
		{
			return _dbContext.Set<Doctor>().AnyAsync(d => d.DateCreated == date);
		}
	}
}
