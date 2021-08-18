using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using CsvHelper;
using CsvHelper.Configuration;

namespace UA.Medics.Infrastructure.DataProvider
{
	/// <summary>
	///		Provides CSV records downloaded from a given url
	/// </summary>
	public class FileDownloader : IFileDownloader
	{
		private readonly HttpClient _httpClient;

		public FileDownloader(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		/// <summary>
		///		Gets enumerated CSV records
		/// </summary>
		/// <typeparam name="TRecord">Record type</typeparam>
		/// <typeparam name="TRecordMap">Record type map</typeparam>
		/// <param name="url">CSV file location</param>
		/// <returns>Iterator instance</returns>
		public async IAsyncEnumerable<TRecord> GetCsvRecords<TRecord, TRecordMap>(string url)
			where TRecord : new()
			where TRecordMap : ClassMap<TRecord>
		{
			var stream = await _httpClient.GetStringAsync(url);//  url.GetStringAsync();
			using var reader = new StringReader(stream);

			CsvReader csvReader = new(reader, new CsvConfiguration(CultureInfo.InvariantCulture));

			csvReader.Context.RegisterClassMap<TRecordMap>();

			TRecord template = new TRecord();

			await foreach (var csvRecord in csvReader.EnumerateRecordsAsync(template))
			{
				yield return csvRecord;
			}
		}
	}
}
