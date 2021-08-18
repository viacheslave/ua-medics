using System;

namespace UA.Medics.Domain
{
	public class DismissedDoctorInfoDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Speciality { get; set; }

		public Guid? LegalEntityId { get; set; }

		public string LegalEntityName { get; set; }

		public string LegalEntityCareType { get; set; }

		public DateTime DismissedFrom { get; set; }
	}
}
