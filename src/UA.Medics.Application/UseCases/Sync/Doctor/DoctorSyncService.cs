using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UA.Medics.Domain;

namespace UA.Medics.Application
{
	public class DoctorSyncService : IDoctorSyncService
	{
		private readonly IDoctorRepository _doctorRepository;
		private readonly IDoctorProvider _doctorProvider;
		private readonly ILinksProvider _linksProvider;
		private readonly IProgress<string> _progress;

		public DoctorSyncService(
			IDoctorRepository doctorRepository,
			IDoctorProvider doctorProvider,
			ILinksProvider linksProvider,
			IProgress<string> progress)
		{
			_doctorRepository = doctorRepository;
			_doctorProvider = doctorProvider;
			_linksProvider = linksProvider;
			_progress = progress;
		}

		/// <summary>
		///		Syncs doctors
		/// </summary>
		/// <returns></returns>
		public async Task Sync()
		{
			var links = await _linksProvider.GetLinks(DataSetType.Doctor);

			foreach (var link in links.OrderBy(l => l.UploadDate))
			{
				_progress.Report($"--- Doctors {link.UploadDate}");

				if (await _doctorRepository.Any(link.UploadDate))
				{
					_progress.Report("--- -- Skipped");
					continue;
				}

				var records = await _doctorProvider.GetRecords(link);

				foreach (var record in records)
					await _doctorRepository.AddOrUpdate(record);

				await _doctorRepository.UnitOfWork.BeginTransaction();
				await _doctorRepository.UnitOfWork.Commit();
			}
		}
	}
}
