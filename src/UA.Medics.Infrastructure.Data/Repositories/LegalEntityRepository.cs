using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UA.Medics.Domain;

namespace UA.Medics.Infrastructure.Data
{
	public class LegalEntityRepository : BaseRepository<LegalEntity>
	{
		public LegalEntityRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}

		protected override ValueTask<LegalEntity> FindAsync(DbSet<LegalEntity> set, LegalEntity record)
		{
			return set.FindAsync(record.Id);
		}

		protected override void Update(LegalEntity record, LegalEntity dbRecord)
		{
			dbRecord.Name = record.Name;
			dbRecord.CareType = record.CareType;
			dbRecord.Edrpou = record.Edrpou;
			dbRecord.Email = record.Email;
			dbRecord.Lat = record.Lat;
			dbRecord.Lng = record.Lng;
			dbRecord.OwnerName = record.OwnerName;
			dbRecord.Phone = record.Phone;
			dbRecord.PropertyType = record.PropertyType;
			dbRecord.RegistrationAddresses = record.RegistrationAddresses;
			dbRecord.RegistrationArea = record.RegistrationArea;
			dbRecord.RegistrationSettlement = record.RegistrationSettlement;
		}
	}
}
