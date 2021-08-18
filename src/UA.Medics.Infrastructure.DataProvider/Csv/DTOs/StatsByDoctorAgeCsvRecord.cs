using System;

namespace UA.Medics.Infrastructure.DataProvider
{
	public class StatsByDoctorAgeCsvRecord
	{
		public Guid LegalEntityId { get; set; }

		public int PartyTempId { get; set; }

		public string PersonAgeGroup { get; set; }

		public int CountDeclarations { get; set; }
	}
}
