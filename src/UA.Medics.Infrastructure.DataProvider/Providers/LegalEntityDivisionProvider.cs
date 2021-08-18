using System.Collections.Generic;
using System.Threading.Tasks;
using UA.Medics.Application;
using UA.Medics.Domain;

namespace UA.Medics.Infrastructure.DataProvider
{
	public class LegalEntityDivisionProvider : ILegalEntityDivisionProvider
	{
		private readonly IFileDownloader _fileDownloader;

		public LegalEntityDivisionProvider(IFileDownloader fileDownloader)
		{
			_fileDownloader = fileDownloader;
		}

		public async Task<IReadOnlyCollection<LegalEntityDivision>> GetRecords(LinkEntry linkEntry)
		{
			var records = _fileDownloader
				.GetCsvRecords<LegalEntityDivisionCsvRecord, LegalEntityDivisionCsvRecordMap>(linkEntry.Link.AbsoluteUri);

			var entities = new List<LegalEntityDivision>();

			await foreach (var record in records)
			{
				var entity = new LegalEntityDivision()
				{
					Email = record.Email,
					Id = record.Id,
					Location = record.Location,
					LegalEntityId = record.LegalEntityId,
					Lng = record.Lng,
					Lat = record.Lat,
					Name = record.Name,
					Phone = record.Phone,
					Type = record.Type,
					ResidenceAddresses = record.ResidenceAddresses,
					ResidenceArea = record.ResidenceArea,
					ResidenceRegion = record.ResidenceRegion,
					ResidenceSettlement = record.ResidenceSettlement,
					ResidenceSettlementKoatuu = record.ResidenceSettlementKoatuu,
					ResidenceSettlementType = record.ResidenceSettlementType
				};

				entities.Add(entity);
			}

			return entities;
		}
	}
}
