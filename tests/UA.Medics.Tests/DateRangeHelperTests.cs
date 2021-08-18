using System;
using System.Threading.Tasks;
using UA.Medics.Domain;
using UA.Medics.Infrastructure.Data;
using UA.Medics.Infrastructure.DataProvider;
using Xunit;

namespace UA.Medics.Tests
{
	[Trait("Category", "Unittest")]
	public class DateRangeHelperTests : IClassFixture<DateRangeDatesFixture>
	{
		private readonly DateRangeDatesFixture _fixture;

		public DateRangeHelperTests(DateRangeDatesFixture fixture)
		{
			_fixture = fixture;
		}

		[Theory]
		[InlineData("2021-07-01", "2021-07-31", "2021-08-15")] // no previous data
		[InlineData("2021-07-01", "2021-08-01", "2021-08-15")] // no previous data
		[InlineData("2021-07-01", "2021-08-14", "2021-08-08")]
		[InlineData("2021-07-01", "2021-08-15", "2021-08-15")]
		[InlineData("2021-07-01", "2021-08-16", "2021-08-15")]
		public void Should_Provide_ClosestDate(string fromDateStr, string toDateStr, string resultDateStr)
		{
			var fromDate = DateTime.Parse(fromDateStr);
			var toDate = DateTime.Parse(toDateStr);
			var resultDate = DateTime.Parse(resultDateStr);

			var dates = DateRangeHelper.GetDatePairs(_fixture.Dates, fromDate, toDate);
			var (previousDate, currentDate) = dates[^1];

			Assert.Equal(resultDate, currentDate);
		}
	}
}
