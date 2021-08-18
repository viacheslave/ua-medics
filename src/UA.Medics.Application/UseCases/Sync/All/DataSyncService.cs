using System;
using System.Threading.Tasks;

namespace UA.Medics.Application
{
	/// <summary>
	///		Synchronizes external medics data with database
	/// </summary>
	public class DataSyncService : IDataSyncService
	{
		private readonly ILegalEntitySyncService _legalEntitySyncService;
		private readonly ILegalEntityDivisionSyncService _legalEntityDivisionSyncService;
		private readonly IDoctorSyncService _doctorSyncService;
		private readonly IStatsByDoctorAgeSyncService _statsByDoctorAgeSyncService;
		private readonly IProgress<string> _progress;

		public DataSyncService(
			ILegalEntitySyncService legalEntitySyncService,
			ILegalEntityDivisionSyncService legalEntityDivisionSyncService,
			IDoctorSyncService doctorSyncService,
			IStatsByDoctorAgeSyncService statsByDoctorAgeSyncService,
			IProgress<string> progress)
		{
			_legalEntitySyncService = legalEntitySyncService;
			_legalEntityDivisionSyncService = legalEntityDivisionSyncService;
			_doctorSyncService = doctorSyncService;
			_statsByDoctorAgeSyncService = statsByDoctorAgeSyncService;
			_progress = progress;
		}

		/// <summary>
		///		Entire sync
		/// </summary>
		/// <returns></returns>
		public async Task SyncAll()
		{
			_progress.Report("Sync fresh legal entities...");
			await _legalEntitySyncService.Sync();

			_progress.Report("Sync fresh legal entity divisions...");
			await _legalEntityDivisionSyncService.Sync();

			_progress.Report("Sync doctors...");
			await _doctorSyncService.Sync();

			_progress.Report("Sync stats by doctors, age...");
			await _statsByDoctorAgeSyncService.Sync();

			_progress.Report("Sync completed");
		}
	}
}
