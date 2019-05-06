using De.Kjg.Diversity.Unity.Net.Loader;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.Net.Services
{
    public class YoutubeService
    {
        private const string BaseSearchUrl = "http://gdata.youtube.com/feeds/api/videos?v=2&alt=jsonc&format=1";

        public void Search(ServiceJSONResultCallback callback, string searchString, int startIndex = 1, int maxResults = 25)
        {
            var url = BaseSearchUrl + "&start-index=" + startIndex + "&max-results=" + maxResults;
            url += "&q=" + WWW.EscapeURL(searchString);

            var loader = new JSONLoader(new UrlRequest(url))
                .AddDoneHandler((jsonObject) => callback(jsonObject))
                .Start();
        }
    }
}
