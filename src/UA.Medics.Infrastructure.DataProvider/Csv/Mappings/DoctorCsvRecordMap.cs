namespace UA.Medics.Infrastructure.DataProvider
{
	public class DoctorCsvRecordMap : CsvHelper.Configuration.ClassMap<DoctorCsvRecord>
	{
		public DoctorCsvRecordMap()
		{
			Map(m => m.LegalEntityId).Index(0).Name("legal_entity_id");
			Map(m => m.LegalEntityDivisionId).Index(1).Name("division_id");
			Map(m => m.EmployeeSpeciality).Index(2).Name("employee_speciality");
			Map(m => m.PartyName).Index(3).Name("party_name");
			Map(m => m.PartyTempId).Index(4).Name("party_temp_id");
		}
	}
}
