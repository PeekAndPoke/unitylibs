using UnityEngine;

namespace De.Kjg.Diversity.Unity.Net.Loader
{
    public delegate void ImageFinished(Texture2D image);

    public class ImageLoader : GenericBaseLoader<ImageLoader, ImageFinished>
    {
        private ImageFinished _doneDelegate;

        public Texture2D Result { get; private set; }

        public ImageLoader(UrlRequest request) : base(request)
        {
        }

        protected override void OnDownloadDone(WWW www)
        {
            Result = www.texture;

            if (_doneDelegate != null)
            {
                _doneDelegate(Result);
            }            
        }

        protected override void AddDoneHanlderInternal(ImageFinished doneHandler)
        {
            _doneDelegate += doneHandler;
        }
    }
}
