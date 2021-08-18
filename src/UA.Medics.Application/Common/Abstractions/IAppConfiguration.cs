namespace UA.Medics.Application
{
	public interface IAppConfiguration
	{
		/// <summary>
		///		Database connection str
		/// </summary>
		string DbConnectionString { get; }
	}
}
