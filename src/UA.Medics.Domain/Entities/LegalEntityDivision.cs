using System;

namespace UA.Medics.Domain
{
	public class LegalEntityDivision
	{
		public Guid Id { get; set; }

		public Guid LegalEntityId { get; set; }

		public string Name { get; set; }

		public string Type { get; set; }

		public string Phone { get; set; }

		public string Email { get; set; }

		public string ResidenceArea { get; set; }

		public string ResidenceRegion { get; set; }

		public string ResidenceSettlement { get; set; }

		public string ResidenceSettlementType { get; set; }

		public string ResidenceAddresses { get; set; }

		public string ResidenceSettlementKoatuu { get; set; }

		public string Location { get; set; }

		public string Lat { get; set; }

		public string Lng { get; set; }
	}
}
