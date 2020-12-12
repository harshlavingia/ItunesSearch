using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using ItunesSearch.Models;
using Newtonsoft.Json.Linq;

namespace ItunesSearch.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public async Task<ActionResult> Search(SearchResultsModel searchResult)
		{
			if (!string.IsNullOrEmpty(searchResult.SearchKeyword))
			{
				string searchkeyword = searchResult.SearchKeyword.Trim();
				//string baseUrl = "https://itunes.apple.com/search?{0}";
				//string baseUrl = "https://itunes.apple.com/search?term={0}";					// temporarily changed to generic search
				string baseUrl = "https://itunes.apple.com/search?limit=25&term={0}";           // limiting result to max 25 (To Do: pagination)
				string apiUrl = string.Format(baseUrl, Server.UrlEncode(searchkeyword));

				searchResult = await GetSearchResults(searchResult, apiUrl);
			}
			return View("Index", searchResult);
		}

		// TO DO - Caching mechanism to avoid more network call - itunes Search API is limited to approximately 20 calls per minute 
		private async Task<SearchResultsModel> GetSearchResults(SearchResultsModel searchResult, string apiUrl)
		{
			var client = new HttpClient();
			var result = await client.GetAsync(apiUrl);			
			if (result.IsSuccessStatusCode)
			{
				// Read all of the response and deserialise it into an instance
				var content = await result.Content.ReadAsStringAsync();				// JSON
				searchResult.RawJson = content;
				JObject jsonSearch = JObject.Parse(content);

				// get JSON result objects into a list
				IList<JToken> jsonSearchResults = jsonSearch["results"].Children().ToList();
				searchResult.ListSearchResult = new List<Results>();
				foreach (JToken jresult in jsonSearchResults)
				{
					Results oResults = jresult.ToObject<Results>();             // ToObject uses JsonSerializer internally
					searchResult.ListSearchResult.Add(oResults);
				}
				return searchResult;
			}
			return null;
		}

		public ActionResult Stats(Results oResults)
		{
			//ViewBag.Message = "Search result click statistics";
			if (oResults == null || oResults.trackId == null)
			{
				//return View();
				return ViewStats(new StatsModel());
			}
			else
			{
				System.Web.HttpContext.Current.Application.Lock();
				Dictionary<string, Results> DC_Stats = System.Web.HttpContext.Current.Application[StatsModel.APP_DCSTATE] as Dictionary<string, Results>;
				if (DC_Stats == null)
				{
					DC_Stats = new Dictionary<string, Results>();
					System.Web.HttpContext.Current.Application[StatsModel.APP_DCSTATE] = DC_Stats;
				}

				if (DC_Stats.ContainsKey(oResults.trackId))
					DC_Stats[oResults.trackId].clickCount++;
				else
				{
					DC_Stats.Add(oResults.trackId, oResults);
					DC_Stats[oResults.trackId].clickCount++;
				}
				System.Web.HttpContext.Current.Application.UnLock();

				return Redirect(oResults.trackViewUrl);
			}
		}
		public ActionResult ViewStats(StatsModel oStatsModel)
		{
			//Dictionary<string, Results> dc = oStatsModel.DCStats;
			Dictionary<string, Results> dc = System.Web.HttpContext.Current.Application[StatsModel.APP_DCSTATE] as Dictionary<string, Results>;
			return View("Stats", oStatsModel);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";
			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";
			return View();
		}
	}
}