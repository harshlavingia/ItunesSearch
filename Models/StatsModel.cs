using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItunesSearch.Models
{
	public class StatsModel
	{
		public static readonly string APP_DCSTATE = "application_DCStats";
		// temporarily saving stats in application variables, TO DO - save into DB on regular interval of 15-30 min
		public Dictionary<string, Results> DCStats
		{
			get
			{
				return HttpContext.Current.Application[APP_DCSTATE] as Dictionary<string, Results>;
			}			
		}
	}
}