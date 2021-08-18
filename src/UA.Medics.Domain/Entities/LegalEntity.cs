using System;

namespace UA.Medics.Domain
{
	public class LegalEntity
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Edrpou { get; set; }

		public string CareType { get; set; }

		public string PropertyType { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

		public string OwnerName { get; set; }

		public string RegistrationArea { get; set; }

		public string RegistrationSettlement { get; set; }

		public string RegistrationAddresses { get; set; }

		public string Lat { get; set; }

		public string Lng { get; set; }
	}
}
