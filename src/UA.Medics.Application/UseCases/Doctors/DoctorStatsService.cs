using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UA.Medics.Application;
using UA.Medics.Domain;

namespace UA.Medics.Infrastructure.Data
{
	public class DoctorStatsService : IDoctorStatsService
	{
		private readonly IApplicationDbContext _dbContext;

		public DoctorStatsService(IApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<DoctorInfoDto>> GetDoctors(GetDoctorsQuery query)
		{
			var data =
				from doctor in _dbContext.Doctor
				join legalEntity in _dbContext.LegalEntity
					on doctor.LegalEntityId equals legalEntity.Id into joined
				from legalEntity in joined.DefaultIfEmpty()
				orderby doctor.PartyName
				select new { doctor, legalEntity };

			return data
				.AsEnumerable()
				.Select(dataItem => new DoctorInfoDto
				{
					Id = dataItem.doctor.PartyTempId,
					Name = dataItem.doctor.PartyName,
					Speciality = dataItem.doctor.EmployeeSpeciality,
					LegalEntityId = dataItem.legalEntity?.Id,
					LegalEntityName = dataItem.legalEntity?.Name,
					LegalEntityCareType = dataItem.legalEntity?.CareType
				});
		}

		public async Task<IEnumerable<DoctorInfoDto>> GetNewDoctors(GetNewDoctorsQuery query)
		{
			const int newDoctorsRangeDays = 60;

			var comparingDates = DateRangeHelper.GetComparingDates(
				GetDates(),
				earliest: query.date.AddDays(-newDoctorsRangeDays), 
				latest:   query.date);

			var results = new List<DoctorInfoDto>();

			foreach (var dates in comparingDates)
				results.AddRange(await GetNewDoctors(dates));

			return results
				.OrderByDescending(info => info.AvailableFrom);
		}

		public async Task<DoctorStatsDto> GetDoctorStats(GetDoctorStatsQuery query)
		{
			// TODO include
			var legalEntity = await _dbContext.LegalEntity.FindAsync(query.LegalEntityId);
			var doctor = await _dbContext.Doctor.FindAsync(query.PartyTempId, query.LegalEntityId);

			var stats = _dbContext.StatsByDoctorAge
				.Where(s => s.PartyTempId == query.PartyTempId && s.LegalEntityId == query.LegalEntityId)
				.ToList();

			var dto = new DoctorStatsDto
			{
				DoctorInfo = new DoctorInfoDto()
				{
					Id = doctor.PartyTempId,
					Name = doctor.PartyName,
					LegalEntityId = legalEntity.Id,
					LegalEntityName = legalEntity.Name,
					LegalEntityCareType = legalEntity.CareType,
					Speciality = doctor.EmployeeSpeciality,
				},

				Stats = stats
					.GroupBy(s => s.StatsDate)
					.Select(gr => new DoctorDeclarationsStatsDto
					{
						StatsDate = gr.Key,
						AgeDeclarations = gr.ToDictionary(x => x.PersonAgeGroup, x => x.CountDeclarations)
					})
					.OrderByDescending(s => s.StatsDate)
					.ToArray()
			};

			return dto;
		}

		private async Task<IEnumerable<DoctorInfoDto>> GetNewDoctors(DateTime date)
		{
			const int statsIntervalDays = 7;

			var previousDoctors =
				(from s in _dbContext.StatsByDoctorAge
				 where s.StatsDate == date.AddDays(-statsIntervalDays)
				 group s by new { s.LegalEntityId, s.PartyTempId }
				into g
				 select g.Key).ToList();

			if (previousDoctors.Count == 0)
				return Enumerable.Empty<DoctorInfoDto>();

			var currentDoctors =
				(from s in _dbContext.StatsByDoctorAge
				 where s.StatsDate == date
				 group s by new { s.LegalEntityId, s.PartyTempId }
				into g
				 select g.Key).ToList();

			var doctorsJoinedStats =
				from current in currentDoctors
				join previous in previousDoctors
					on new { current.PartyTempId, current.LegalEntityId } equals new { previous.PartyTempId, previous.LegalEntityId } into joined
				from previous in joined.DefaultIfEmpty()
				where previous is null
				select current;

			var joinedSet =
				from d in doctorsJoinedStats
				join s in _dbContext.Doctor.AsEnumerable()
					on new { d.PartyTempId, d.LegalEntityId } equals new { s.PartyTempId, s.LegalEntityId } into joined
				from s in joined.DefaultIfEmpty()
				select new { Stats = d, Doctor = s };

			var doctorInfos = new List<DoctorInfoDto>();

			foreach (var item in joinedSet)
			{
				var legalEntity = await _dbContext.LegalEntity.FindAsync(item.Stats.LegalEntityId);

				var doctorInfo = new DoctorInfoDto
				{
					Id = item.Stats.PartyTempId,
					Name = item.Doctor?.PartyName,
					Speciality = item.Doctor?.EmployeeSpeciality,
					LegalEntityId = legalEntity?.Id,
					LegalEntityName = legalEntity?.Name,
					LegalEntityCareType = legalEntity?.CareType,
					AvailableFrom = date
				};

				doctorInfos.Add(doctorInfo);
			}

			return doctorInfos;
		}

		private IReadOnlyList<DateTime> GetDates()
		{
			return _dbContext.StatsByDoctorAge
				.Select(s => s.StatsDate)
				.Distinct()
				.OrderBy(s => s)
				.ToList();
		}
	}
}
