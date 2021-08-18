using CsvHelper.Configuration;
using System.Collections.Generic;

namespace UA.Medics.Infrastructure.DataProvider
{
	public interface IFileDownloader
	{
		IAsyncEnumerable<TRecord> GetCsvRecords<TRecord, TRecordMap>(string url)
			where TRecord : new()
			where TRecordMap : ClassMap<TRecord>;
	}
}