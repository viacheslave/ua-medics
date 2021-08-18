using System.Collections.Generic;
using System.Threading.Tasks;
using UA.Medics.Application;
using UA.Medics.Domain;

namespace UA.Medics.Infrastructure.DataProvider
{
	/// <summary>
	///		Wraps page parser
	/// </summary>
	public class LinksProvider : ILinksProvider
	{
		public static readonly IReadOnlyDictionary<DataSetType, string> LocationMap = new Dictionary<DataSetType, string>
		{
			[DataSetType.LegalEntity] =
				"https://data.gov.ua/dataset/a1d554df-be4b-4d3f-8063-dd0db4d83ff5/resource/ca4792f5-322f-4482-938e-b12cf14c516e",

			[DataSetType.LegalEntityDivision] =
				"https://data.gov.ua/dataset/a1d554df-be4b-4d3f-8063-dd0db4d83ff5/resource/d98f7120-59fd-47f6-a5a5-e7f220bebc53",

			[DataSetType.Doctor] =
				"https://data.gov.ua/dataset/a8228262-5576-4a14-beb8-789573573546/resource/5cc693dd-226d-4c6a-b085-7586bc919e53",

			[DataSetType.StatsDeclarationsByDoctorAge] =
				"https://data.gov.ua/dataset/a8228262-5576-4a14-beb8-789573573546/resource/a9ee1ed3-9277-4bc7-99ec-85f951c7b3c5",
		};

		private readonly IPageParser _pageParser;

		public LinksProvider(IPageParser pageParser)
		{
			_pageParser = pageParser;
		}

		/// <summary>
		///  Provides collection of links on a given page
		/// </summary>
		/// <param name="type">Data set type<see cref="DataSetType"/></param>
		/// <returns>Collection of links</returns>
		public async Task<IReadOnlyCollection<LinkEntry>> GetLinks(DataSetType type)
		{
			return await _pageParser.GetLinks(LocationMap[type]);
		}
	}
}
