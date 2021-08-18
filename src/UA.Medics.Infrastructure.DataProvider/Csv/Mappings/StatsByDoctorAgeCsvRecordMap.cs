namespace UA.Medics.Infrastructure.DataProvider
{
	public class StatsByDoctorAgeCsvRecordMap : CsvHelper.Configuration.ClassMap<StatsByDoctorAgeCsvRecord>
	{
		public StatsByDoctorAgeCsvRecordMap()
		{
			Map(m => m.LegalEntityId).Index(0).Name("legal_entity_id");
			Map(m => m.PartyTempId).Index(1).Name("party_temp_id");
			Map(m => m.PersonAgeGroup).Index(2).Name("person_age_group");
			Map(m => m.CountDeclarations).Index(3).Name("count_declarations");
		}
	}
}
