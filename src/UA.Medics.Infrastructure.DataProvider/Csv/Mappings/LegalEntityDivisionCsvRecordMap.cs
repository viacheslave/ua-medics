namespace UA.Medics.Infrastructure.DataProvider
{
	public class LegalEntityDivisionCsvRecordMap : CsvHelper.Configuration.ClassMap<LegalEntityDivisionCsvRecord>
	{
		public LegalEntityDivisionCsvRecordMap()
		{
			Map(m => m.LegalEntityId).Index(0).Name("legal_entity_id");
			Map(m => m.Id).Index(1).Name("division_id");
			Map(m => m.Name).Index(2).Name("division_name");
			Map(m => m.Type).Index(3).Name("division_type");
			Map(m => m.Phone).Index(4).Name("division_phone");
			Map(m => m.Email).Index(5).Name("division_email");

			Map(m => m.ResidenceArea).Index(6).Name("residence_area");
			Map(m => m.ResidenceRegion).Index(7).Name("residence_region");
			Map(m => m.ResidenceSettlement).Index(8).Name("residence_settlement");
			Map(m => m.ResidenceSettlementType).Index(9).Name("residence_settlement_type");
			Map(m => m.ResidenceAddresses).Index(10).Name("residence_addresses");
			Map(m => m.ResidenceSettlementKoatuu).Index(11).Name("residence_settlement_koatuu");

			Map(m => m.Location).Index(12).Name("location");
			Map(m => m.Lat).Index(13).Name("lat");
			Map(m => m.Lng).Index(14).Name("lng");
		}
	}
}
