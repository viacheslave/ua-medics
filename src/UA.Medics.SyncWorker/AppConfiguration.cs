using Microsoft.Extensions.Configuration;
using UA.Medics.Application;

namespace UA.Medics.SyncWorker
{
	public class AppConfiguration : IAppConfiguration
	{
		private readonly IConfiguration _configuration;

		public AppConfiguration(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string DbConnectionString => _configuration.GetConnectionString("DefaultConnection");
	}
}
