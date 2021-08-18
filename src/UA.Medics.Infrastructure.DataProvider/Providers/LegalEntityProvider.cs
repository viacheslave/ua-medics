using System.Collections.Generic;
using System.Threading.Tasks;
using UA.Medics.Application;
using UA.Medics.Domain;

namespace UA.Medics.Infrastructure.DataProvider
{
	public class LegalEntityProvider : ILegalEntityProvider
	{
		private readonly IFileDownloader _fileDownloader;

		public LegalEntityProvider(IFileDownloader fileDownloader)
		{
			_fileDownloader = fileDownloader;
		}

		public async Task<IReadOnlyCollection<LegalEntity>> GetRecords(LinkEntry linkEntry)
		{
			var records = _fileDownloader.GetCsvRecords<LegalEntityCsvRecord, LegalEntityCsvRecordMap>(linkEntry.Link.AbsoluteUri);

			var entities = new List<LegalEntity>();

			await foreach (var record in records)
			{
				var entity = new LegalEntity()
				{
					Id = record.Id,
					Name = record.Name,
					CareType = record.CareType,
					Edrpou = record.Edrpou,
					Email = record.Email,
					Lat = record.Lat,
					Lng = record.Lng,
					OwnerName = record.OwnerName,
					Phone = record.Phone,
					PropertyType = record.PropertyType,
					RegistrationAddresses = record.RegistrationAddresses,
					RegistrationArea = record.RegistrationArea,
					RegistrationSettlement = record.RegistrationSettlement
				};

				entities.Add(entity);
			}

			return entities;
		}
	}
}
