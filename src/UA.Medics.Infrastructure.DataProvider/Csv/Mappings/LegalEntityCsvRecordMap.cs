namespace UA.Medics.Infrastructure.DataProvider
{
	public class LegalEntityCsvRecordMap : CsvHelper.Configuration.ClassMap<LegalEntityCsvRecord>
	{
		public LegalEntityCsvRecordMap()
		{
			Map(m => m.Id).Index(0).Name("legal_entity_id");
			Map(m => m.Name).Index(1).Name("legal_entity_name");
			Map(m => m.Edrpou).Index(2).Name("legal_entity_edrpou");
			Map(m => m.CareType).Index(3).Name("care_type");
			Map(m => m.PropertyType).Index(4).Name("property_type");
			Map(m => m.Email).Index(5).Name("legal_entity_email");
			Map(m => m.Phone).Index(6).Name("legal_entity_phone");
			Map(m => m.OwnerName).Index(7).Name("legal_entity_owner_name");
			Map(m => m.RegistrationArea).Index(8).Name("registration_area");
			Map(m => m.RegistrationSettlement).Index(9).Name("registration_settlement");
			Map(m => m.RegistrationAddresses).Index(10).Name("registration_addresses");
			Map(m => m.Lat).Index(11).Name("lat");
			Map(m => m.Lng).Index(12).Name("lng");
		}
	}
}
