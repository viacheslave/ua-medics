using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using UA.Medics.Application;

namespace UA.Medics.Infrastructure.DataProvider
{
	/// <summary>
	///		HTML page parser
	/// </summary>
	public class PageParser : IPageParser
	{
		internal const string DataGovDomain = "https://data.gov.ua";

		private readonly HttpClient _httpClient;

		public PageParser(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		/// <summary>
		///  Provides collection of links on a given page
		/// </summary>
		/// <param name="url">Page url</param>
		/// <returns>Collection of links</returns>
		public async Task<IReadOnlyCollection<LinkEntry>> GetLinks(string url)
		{
			var html = await GetHtmlPage(url);

			var document = new HtmlDocument();
			document.LoadHtml(html);

			var lis = document.DocumentNode.Descendants("li")
				.Where(li => li.HasClass("resource-list__item"))
				.ToList();

			var entries = new List<LinkEntry>();

			foreach (var li in lis)
			{
				var link = GetLink(li);
				var uploadDate = GetUploadDate(li);

				var entry = new LinkEntry(new Uri($"{DataGovDomain}{link}"), uploadDate);
				entries.Add(entry);
			}

			entries.Insert(0, GetFreshEntry(document));

			return entries;

			static LinkEntry GetFreshEntry(HtmlDocument document)
			{
				var headerDiv = document.DocumentNode.Descendants("div").First(div => div.HasClass("header-container"));

				var linkAnchor = headerDiv.Descendants("a").First(a => a.HasClass("resource-url-analytics"));
				var link = linkAnchor.GetAttributeValue("href", "");

				var section = document.DocumentNode.Descendants("section").First(section => section.HasClass("additional-info"));
				var sectionContainers = section.Descendants("div").Where(div => div.HasClass("additional-info-container__item")).ToList();

				var revisionBlock = sectionContainers[1].Descendants("p").First(p => p.HasClass("dataset-details"));
				var revisionText = revisionBlock.InnerText;

				var uploadDate = ParseDate(revisionText, "(.*),(.*),.*");

				return new LinkEntry(new Uri(link), uploadDate);
			}

			static DateTime GetUploadDate(HtmlAgilityPack.HtmlNode li)
			{
				var revisionDiv = li.Descendants("div").First(div => div.HasClass("revision-body"));
				var revisionBlock = revisionDiv.Descendants("b").First();
				var revisionText = revisionBlock.InnerText;

				return ParseDate(revisionText, ".*:(.*),(.*),.*");
			}

			static string GetLink(HtmlNode li)
			{
				var linkAnchor = li.Descendants("a").First(a => a.HasClass("resource-url-analytics"));
				var link = linkAnchor.GetAttributeValue("href", "");
				return link;
			}

			static DateTime ParseDate(string revisionText, string regex)
			{
				var re = new Regex(regex);

				var match = re.Match(revisionText);

				var monthDay = match.Groups[1].Value.Trim();
				var year = int.Parse(match.Groups[2].Value.Trim());

				var monthDayDate = DateTime.ParseExact(monthDay, "MMMM d", new CultureInfo("uk-UA"));

				var uploadDate = new DateTime(year, monthDayDate.Month, monthDayDate.Day);
				return uploadDate;
			}
		}

		private async Task<string> GetHtmlPage(string url)
		{
			return await _httpClient.GetStringAsync(url);// url.GetStringAsync();
		}
	}
}
