using System.Threading.Tasks;
using UA.Medics.Domain;
using UA.Medics.Infrastructure.DataProvider;
using Xunit;

namespace UA.Medics.Tests
{
	public class LinksProviderTests
	{
		[Theory]
		[InlineData(DataSetType.LegalEntity)]
		[InlineData(DataSetType.LegalEntityDivision)]
		[InlineData(DataSetType.Doctor)]
		[InlineData(DataSetType.StatsDeclarationsByDoctorAge)]
		public async Task Should_GetLinks_Return_Links_Collection(DataSetType type)
		{
			var linksProvider = new LinksProvider(new PageParser(new System.Net.Http.HttpClient()));

			var links = await linksProvider.GetLinks(type);

			Assert.True(links.Count > 10);
		}
	}
}
