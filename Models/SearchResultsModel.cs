using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItunesSearch.Models
{
	public class SearchResultsModel
	{
		public string SearchKeyword { get; set; }
		public string RawJson { get; set; }

		public List<Results> ListSearchResult { get; set; }
	}

	public class Results
	{
		public int clickCount { get; set; }

		public string wrapperType { get; set; }				// track"
		public string kind { get; set; }					// song"
		public string artistId { get; set; }				// 909253
		public string collectionId { get; set; }			// 1469577723
		public string trackId { get; set; }					// 1469577741
		public string artistName { get; set; }				// Jack Johnson"
		public string collectionName { get; set; }			// Jack Johnson and Friends: Sing-A-Longs and Lullabies for the Film Curious George"
		public string trackName { get; set; }				// Upside Down"
		public string collectionCensoredName { get; set; }  // Jack Johnson and Friends: Sing-A-Longs and Lullabies for the Film Curious George"
		public string trackCensoredName { get; set; }		// Upside Down"
		public string artistViewUrl { get; set; }			// https://music.apple.com/us/artist/jack-johnson/909253?uo=4"
		public string collectionViewUrl { get; set; }		// https://music.apple.com/us/album/upside-down/1469577723?i=1469577741&uo=4"
		public string trackViewUrl { get; set; }			// https://music.apple.com/us/album/upside-down/1469577723?i=1469577741&uo=4"
		public string previewUrl { get; set; }				// https://audio-ssl.itunes.apple.com/itunes-assets/AudioPreview123/v4/75/5a/fc/755afca1-d911-be2b-c0fb-f99d6d52ce1a/mzaf_4156076990936187406.plus.aac.p.m4a"
		public string artworkUrl30 { get; set; }			// https://is4-ssl.mzstatic.com/image/thumb/Music123/v4/be/38/d0/be38d058-31ed-c0ea-91e6-12052865fd20/source/30x30bb.jpg"
		public string artworkUrl60 { get; set; }			// https://is4-ssl.mzstatic.com/image/thumb/Music123/v4/be/38/d0/be38d058-31ed-c0ea-91e6-12052865fd20/source/60x60bb.jpg"
		public string artworkUrl100 { get; set; }			// https://is4-ssl.mzstatic.com/image/thumb/Music123/v4/be/38/d0/be38d058-31ed-c0ea-91e6-12052865fd20/source/100x100bb.jpg"
		public string collectionPrice { get; set; }			// 6.99
		public string trackPrice { get; set; }				// 1.29
		public string releaseDate { get; set; }				// 2006-02-06T12:00:00Z"
		public string collectionExplicitness { get; set; }  // notExplicit"
		public string trackExplicitness { get; set; }		// notExplicit"
		public string discCount { get; set; }				// 1
		public string discNumber { get; set; }				// 1
		public string trackCount { get; set; }				// 14
		public string trackNumber { get; set; }				// 1
		public string trackTimeMillis { get; set; }			// 208643
		public string country { get; set; }					// USA"
		public string currency { get; set; }				// USD"
		public string primaryGenreName { get; set; }		// Rock"
		public string isStreamable { get; set; }			// true
	}
}