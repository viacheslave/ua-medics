using Microsoft.EntityFrameworkCore;
using UA.Medics.Domain;

namespace UA.Medics.Application
{
	public interface IApplicationDbContext : IUnitOfWork
	{
		DbSet<Doctor> Doctor { get; set; }

		DbSet<LegalEntity> LegalEntity { get; set; }

		DbSet<LegalEntityDivision> LegalEntityDivision { get; set; }

		DbSet<StatsByDoctorAge> StatsByDoctorAge { get; set; }
	}
}