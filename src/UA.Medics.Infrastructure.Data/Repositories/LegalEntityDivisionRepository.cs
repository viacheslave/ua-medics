using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UA.Medics.Domain;

namespace UA.Medics.Infrastructure.Data
{
	public class LegalEntityDivisionRepository : BaseRepository<LegalEntityDivision>
	{
		public LegalEntityDivisionRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}

		protected override ValueTask<LegalEntityDivision> FindAsync(DbSet<LegalEntityDivision> set, LegalEntityDivision record)
		{
			return set.FindAsync(record.Id);
		}

		protected override void Update(LegalEntityDivision record, LegalEntityDivision dbRecord)
		{
			dbRecord.Email = record.Email;
			dbRecord.Lat = record.Lat;
			dbRecord.Lng = record.Lng;
			dbRecord.Location = record.Location;
			dbRecord.Name = record.Name;
			dbRecord.Phone = record.Phone;
			dbRecord.ResidenceAddresses = record.ResidenceAddresses;
			dbRecord.ResidenceArea = record.ResidenceArea;
			dbRecord.ResidenceRegion = record.ResidenceRegion;
			dbRecord.ResidenceSettlement = record.ResidenceSettlement;
			dbRecord.ResidenceSettlementKoatuu = record.ResidenceSettlementKoatuu;
			dbRecord.ResidenceSettlementType = record.ResidenceSettlementType;
			dbRecord.Type = record.Type;
		}
	}
}
