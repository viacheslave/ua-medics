using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;
using UA.Medics.Application;
using UA.Medics.Domain;

namespace UA.Medics.Infrastructure.Data
{
	public class ApplicationDbContext : DbContext, IUnitOfWork, IApplicationDbContext
	{
		private IDbContextTransaction _transaction;
		private readonly IAppConfiguration _appConfiguration;

		public DbSet<LegalEntity> LegalEntity { get; set; }

		public DbSet<LegalEntityDivision> LegalEntityDivision { get; set; }

		public DbSet<Doctor> Doctor { get; set; }

		public DbSet<StatsByDoctorAge> StatsByDoctorAge { get; set; }

		public ApplicationDbContext(IAppConfiguration appConfiguration)
		{
			_appConfiguration = appConfiguration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseNpgsql(
					_appConfiguration.DbConnectionString,
					a => a.MigrationsAssembly("UA.Medics.Infrastructure.Data"))
				;

			//optionsBuilder.LogTo(System.Console.WriteLine);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.Entity<LegalEntity>()
				.HasKey(m => m.Id);

			modelBuilder
				.Entity<LegalEntityDivision>()
				.HasKey(m => m.Id);

			modelBuilder
				.Entity<Doctor>()
				.HasKey(nameof(UA.Medics.Domain.Doctor.PartyTempId), nameof(UA.Medics.Domain.Doctor.LegalEntityId));

			modelBuilder
				.Entity<StatsByDoctorAge>()
				.HasKey(
					nameof(UA.Medics.Domain.StatsByDoctorAge.StatsDate),
					nameof(UA.Medics.Domain.StatsByDoctorAge.LegalEntityId),
					nameof(UA.Medics.Domain.StatsByDoctorAge.PartyTempId),
					nameof(UA.Medics.Domain.StatsByDoctorAge.PersonAgeGroup));
		}

		public async Task BeginTransaction()
		{
			_transaction = await Database.BeginTransactionAsync();
		}

		public async Task Commit()
		{
			try
			{
				await  SaveChangesAsync();
				await _transaction.CommitAsync();
			}
			finally
			{
				await _transaction.DisposeAsync();
			}
		}

		public async Task Rollback()
		{
			await _transaction.RollbackAsync();
			await _transaction.DisposeAsync();
		}
	}
}
