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
		[InlineData("2021-08-15", "2021-08-15")]
		[InlineData("2021-08-16", "2021-08-15")]
		[InlineData("2021-08-14", "2021-08-08")]
		[InlineData("2021-08-01", "2021-08-01")]
		[InlineData("2021-07-31", "2021-08-15")]
		public void Should_Provide_ClosestDate(string queryDateStr, string resultDateStr)
		{
			var queryDate = DateTime.Parse(queryDateStr);
			var resultDate = DateTime.Parse(resultDateStr);

			var dates = DateRangeHelper.GetComparingDates(_fixture.Dates, queryDate, queryDate);
			var top = dates[0];

			Assert.Equal(resultDate, top);
		}
	}
}
