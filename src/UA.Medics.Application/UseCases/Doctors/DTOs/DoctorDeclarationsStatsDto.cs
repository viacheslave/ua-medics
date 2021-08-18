using System;
using System.Collections.Generic;

namespace UA.Medics.Domain
{
	public class DoctorDeclarationsStatsDto
	{
		public DateTime StatsDate { get; set; }

		public Dictionary<string, int> AgeDeclarations { get; set; } = new Dictionary<string, int>();
	}
}
