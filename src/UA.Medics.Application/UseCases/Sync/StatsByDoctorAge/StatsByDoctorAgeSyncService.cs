using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UA.Medics.Domain;

namespace UA.Medics.Application
{
	public class StatsByDoctorAgeSyncService : IStatsByDoctorAgeSyncService
	{
		private readonly IStatsByDoctorAgeRepository _statsDoctorAgeRepository;
		private readonly IStatsByDoctorAgeProvider _statsByDoctorAgeProvider;
		private readonly ILinksProvider _linksProvider;
		private readonly IProgress<string> _progress;

		public StatsByDoctorAgeSyncService(
			IStatsByDoctorAgeRepository statsDoctorAgeRepository,
			IStatsByDoctorAgeProvider statsByDoctorAgeProvider,
			ILinksProvider linksProvider,
			IProgress<string> progress)
		{
			_statsDoctorAgeRepository = statsDoctorAgeRepository;
			_statsByDoctorAgeProvider = statsByDoctorAgeProvider;
			_linksProvider = linksProvider;
			_progress = progress;
		}

		/// <summary>
		///		Syncs statistics of doctors by linked people age
		/// </summary>
		/// <returns></returns>
		public async Task Sync()
		{
			var links = await _linksProvider.GetLinks(DataSetType.StatsDeclarationsByDoctorAge);

			foreach (var link in links.OrderBy(l => l.UploadDate))
			{
				_progress.Report($"--- Stats by Doctors, Age {link.UploadDate}");

				if (await _statsDoctorAgeRepository.Any(link.UploadDate))
				{
					_progress.Report("--- -- Skipped");
					continue;
				}

				var records = await _statsByDoctorAgeProvider.GetRecords(link);

				await _statsDoctorAgeRepository.AddRange(records.ToArray());

				await _statsDoctorAgeRepository.UnitOfWork.BeginTransaction();
				await _statsDoctorAgeRepository.UnitOfWork.Commit();
			}
		}
	}
}
