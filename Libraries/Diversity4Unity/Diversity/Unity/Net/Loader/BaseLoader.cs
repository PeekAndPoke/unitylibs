using System.Collections;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.Net.Loader
{
    abstract public class BaseLoader
    {
        public UrlRequest Request { get; private set; }

        private WWW _www;
        private bool _isLoading;

        protected BaseLoader(UrlRequest request)
        {
            this.Request = request;
        }

        protected virtual void LoadData()
        {
            UnityEngine.Debug.Log("Loading _" + Request.Url + "_");
            _www = new WWW(Request.Url);
            _isLoading = true;
            NetModule.Behaviour.StartCoroutine(MonitorProgress());
            NetModule.Behaviour.StartCoroutine(WaitForDownload());
        }

        protected abstract void OnDownloadDone(WWW www);

        private IEnumerator MonitorProgress()
        {
            while (_isLoading == true)
            {
                UnityEngine.Debug.Log(_www.progress);
                yield return new WaitForSeconds(0.1F);
            }
        }

        private IEnumerator WaitForDownload()
        {
            yield return _www;
            _isLoading = false;
            OnDownloadDone(_www);
        }
    }
}