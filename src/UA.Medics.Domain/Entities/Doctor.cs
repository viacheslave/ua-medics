using System;

namespace UA.Medics.Domain
{
	public class Doctor
	{
		public Guid LegalEntityId { get; set; }

		public Guid? LegalEntityDivisionId { get; set; }

		public string EmployeeSpeciality { get; set; }

		public string PartyName { get; set; }

		public int PartyTempId { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateUpdated { get; set; }
	}
}
