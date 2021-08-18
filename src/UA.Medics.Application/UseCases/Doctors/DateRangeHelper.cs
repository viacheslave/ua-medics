using System;
using System.Collections.Generic;
using System.Linq;

namespace UA.Medics.Infrastructure.Data
{
	internal static class DateRangeHelper
	{
		public static IReadOnlyList<DateTime> GetComparingDates(
			IReadOnlyList<DateTime> dates, DateTime earliest, DateTime latest)
		{
			var result = new List<DateTime>();

			foreach (var date in dates)
				if (earliest <= date && date <= latest)
					result.Add(date);

			if (result.Count == 0)
			{
				var lastDateLessThan = dates.LastOrDefault(d => d <= latest);
				
				result.Add(
					lastDateLessThan == default 
						? dates[^1] 
						: lastDateLessThan);
			}

			return result;
		}
	}
}
