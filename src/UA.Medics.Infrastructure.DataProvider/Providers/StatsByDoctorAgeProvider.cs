using System.Collections.Generic;
using System.Threading.Tasks;
using UA.Medics.Application;
using UA.Medics.Domain;

namespace UA.Medics.Infrastructure.DataProvider
{
	public class StatsByDoctorAgeProvider : IStatsByDoctorAgeProvider
	{
		private readonly IFileDownloader _fileDownloader;

		public StatsByDoctorAgeProvider(IFileDownloader fileDownloader)
		{
			_fileDownloader = fileDownloader;
		}

		public async Task<IReadOnlyCollection<StatsByDoctorAge>> GetRecords(LinkEntry linkEntry)
		{
			var records = _fileDownloader
				.GetCsvRecords<StatsByDoctorAgeCsvRecord, StatsByDoctorAgeCsvRecordMap>(linkEntry.Link.AbsoluteUri);

			var entities = new List<StatsByDoctorAge>();

			await foreach (var record in records)
			{
				var entity = new StatsByDoctorAge()
				{
					StatsDate = linkEntry.UploadDate,

					LegalEntityId = record.LegalEntityId,
					PartyTempId = record.PartyTempId,
					PersonAgeGroup = record.PersonAgeGroup,
					CountDeclarations = record.CountDeclarations
				};

				entities.Add(entity);
			}

			return entities;
		}
	}
}
