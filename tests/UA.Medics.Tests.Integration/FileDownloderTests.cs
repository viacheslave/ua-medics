using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UA.Medics.Domain;
using UA.Medics.Infrastructure.DataProvider;
using Xunit;

namespace UA.Medics.Tests.Integration
{
	[Trait("Category", "Integration")]
	public class FileDownloderTests
	{
		[Fact]
		public async Task CsvRecords_Collection_Test()
		{
			var httpClient = new HttpClient();

			var downloader = new FileDownloader(httpClient);
			var url = LinksProvider.LocationMap[DataSetType.LegalEntity];

			var pageParser = new PageParser(httpClient);
			var links = await pageParser.GetLinks(url);

			var entry = links.First();

			var records = downloader.GetCsvRecords<LegalEntityCsvRecord, LegalEntityCsvRecordMap>(entry.Link.AbsoluteUri);

			var enumerator = records.GetAsyncEnumerator();

			var result = await enumerator.MoveNextAsync();
			var record = enumerator.Current;

			Assert.True(result);
			Assert.NotNull(record);
			Assert.NotEqual(Guid.Empty, record.Id);
		}
	}
}
