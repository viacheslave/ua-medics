using System;

namespace UA.Medics.Infrastructure.DataProvider
{
	public class DoctorCsvRecord
	{
		public Guid LegalEntityId { get; set; }

		public Guid? LegalEntityDivisionId { get; set; }

		public string EmployeeSpeciality { get; set; }

		public string PartyName { get; set; }

		public int PartyTempId { get; set; }
	}
}
