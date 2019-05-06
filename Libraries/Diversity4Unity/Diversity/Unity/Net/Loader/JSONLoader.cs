using De.Kjg.Diversity.Unity.Net.JSON;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.Net.Loader
{
    public delegate void JSONLoaderFinished(JSONObject jsonObject);

    public class JSONLoader : GenericBaseLoader<JSONLoader, JSONLoaderFinished>
    {
        private JSONLoaderFinished _doneDelegate;

        public JSONObject Result { get; private set; }

        public JSONLoader(UrlRequest request) : base(request)
        {
        }

        protected override void OnDownloadDone(WWW www)
        {
            Result = JSONObject.FromUnknown(JSON.JSON.JsonDecode(www.text));

            if (_doneDelegate != null)
            {
                _doneDelegate(Result);
            }
        }

        protected override void AddDoneHanlderInternal(JSONLoaderFinished doneHandler)
        {
            _doneDelegate += doneHandler;
        }
    }
}
