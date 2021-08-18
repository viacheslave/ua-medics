using System;
using System.Collections.Generic;

namespace UA.Medics.Tests
{
	public class DateRangeDatesFixture
	{
		public IReadOnlyList<DateTime> Dates { get; }

		public DateRangeDatesFixture()
		{
			Dates = new List<DateTime>
			{
				new DateTime(2021, 08, 01),
				new DateTime(2021, 08, 08),
				new DateTime(2021, 08, 15),
			};
		}
	}
}