using System;

namespace UA.Medics.Domain
{
	public class StatsByDoctorAge
	{
		public DateTime StatsDate { get; set; }

		public Guid LegalEntityId { get; set; }

		public int PartyTempId { get; set; }

		public string PersonAgeGroup { get; set; }

		public int CountDeclarations { get; set; }
	}
}
