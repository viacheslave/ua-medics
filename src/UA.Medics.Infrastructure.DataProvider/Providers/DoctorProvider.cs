using System.Collections.Generic;
using System.Threading.Tasks;
using UA.Medics.Application;
using UA.Medics.Domain;

namespace UA.Medics.Infrastructure.DataProvider
{
	public class DoctorProvider : IDoctorProvider
	{
		private readonly IFileDownloader _fileDownloader;

		public DoctorProvider(IFileDownloader fileDownloader)
		{
			_fileDownloader = fileDownloader;
		}

		public async Task<IReadOnlyCollection<Doctor>> GetRecords(LinkEntry linkEntry)
		{
			var records = _fileDownloader
				.GetCsvRecords<DoctorCsvRecord, DoctorCsvRecordMap>(linkEntry.Link.AbsoluteUri);

			var entities = new List<Doctor>();

			await foreach (var record in records)
			{
				var entity = new Doctor()
				{
					LegalEntityId = record.LegalEntityId,
					LegalEntityDivisionId = record.LegalEntityDivisionId,
					EmployeeSpeciality = record.EmployeeSpeciality,
					PartyName = record.PartyName,
					PartyTempId = record.PartyTempId,

					DateCreated = linkEntry.UploadDate,
					DateUpdated = linkEntry.UploadDate
				};

				entities.Add(entity);
			}

			return entities;
		}
	}
}
