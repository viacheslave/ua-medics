using System;
using System.Collections.Generic;
using System.Linq;

namespace UA.Medics.Infrastructure.Data
{
	internal static class DateRangeHelper
	{
		public static IReadOnlyList<(DateTime previousDate, DateTime currentDate)> GetDatePairs(
			IReadOnlyList<DateTime> dates, 
			DateTime earliest, 
			DateTime latest)
		{
			var result = new List<(DateTime previousDate, DateTime currentDate)>();

			for (int i = 0; i < dates.Count; i++)
				if (i > 0 && earliest <= dates[i] && dates[i] <= latest)
					result.Add((dates[i - 1], dates[i]));

			if (result.Count == 0)
				result.Add((dates[^2], dates[^1]));

			return result;
		}
	}
}
