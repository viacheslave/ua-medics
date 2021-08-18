using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UA.Medics.Domain;

namespace UA.Medics.Application
{
	public class LegalEntityDivisionSyncService : ILegalEntityDivisionSyncService
	{
		private readonly IRepository<LegalEntityDivision> _legalEntityDivisionRepository;
		private readonly ILegalEntityDivisionProvider _legalEntityDivisionProvider;
		private readonly ILinksProvider _linksProvider;
		private readonly IProgress<string> _progress;

		public LegalEntityDivisionSyncService(
			IRepository<LegalEntityDivision> legalEntityDivisionRepository,
			ILegalEntityDivisionProvider legalEntityDivisionProvider,
			ILinksProvider linksProvider,
			IProgress<string> progress)
		{
			_legalEntityDivisionRepository = legalEntityDivisionRepository;
			_legalEntityDivisionProvider = legalEntityDivisionProvider;
			_linksProvider = linksProvider;
			_progress = progress;
		}

		/// <summary>
		///		Syncs legal entity divisions
		/// </summary>
		/// <returns></returns>
		public async Task Sync()
		{
			var links = await _linksProvider.GetLinks(DataSetType.LegalEntityDivision);
			var topLink = links.First();

			var records = await _legalEntityDivisionProvider.GetRecords(topLink);

			foreach (var record in records)
				await _legalEntityDivisionRepository.AddOrUpdate(record);

			await _legalEntityDivisionRepository.UnitOfWork.BeginTransaction();
			await _legalEntityDivisionRepository.UnitOfWork.Commit();
		}
	}
}
