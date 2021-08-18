using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UA.Medics.Domain;

namespace UA.Medics.Application
{
	public class LegalEntitySyncService : ILegalEntitySyncService
	{
		private readonly IRepository<LegalEntity> _legalEntityRepository;
		private readonly ILegalEntityProvider _legalEntityProvider;
		private readonly ILinksProvider _linksProvider;
		private readonly IProgress<string> _progress;

		public LegalEntitySyncService(
			IRepository<LegalEntity> legalEntityRepository,
			ILegalEntityProvider legalEntityProvider,
			ILinksProvider linksProvider,
			IProgress<string> progress)
		{
			_legalEntityRepository = legalEntityRepository;
			_linksProvider = linksProvider;
			_legalEntityProvider = legalEntityProvider;
			_progress = progress;
		}

		/// <summary>
		///		Syncs legal entities
		/// </summary>
		/// <returns></returns>
		public async Task Sync()
		{
			var links = await _linksProvider.GetLinks(DataSetType.LegalEntity);
			var topLink = links.First();

			var records = await _legalEntityProvider.GetRecords(topLink);

			foreach (var record in records)
				await _legalEntityRepository.AddOrUpdate(record);

			await _legalEntityRepository.UnitOfWork.BeginTransaction();
			await _legalEntityRepository.UnitOfWork.Commit();
		}
	}
}
