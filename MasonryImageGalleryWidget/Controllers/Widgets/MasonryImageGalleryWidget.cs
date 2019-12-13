using CMS.MediaLibrary;
using CMS.SiteProvider;
using Kentico.PageBuilder.Web.Mvc;
using SeventyeightDigital.MasonryImageGalleryWidget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

[assembly: RegisterWidget("Kentico.MasonryImageGalleryWidget", typeof(MasonryImageGalleryWidgetController), "Masonry Image Gallery Widget", IconClass = "icon-pictures")]

namespace SeventyeightDigital.MasonryImageGalleryWidget
{
    public class MasonryImageGalleryWidgetController : WidgetController<MasonryImageGalleryWidgetProperties>
    {
        /// <summary>
        /// Creates an instance of <see cref="MasonryImageGalleryWidgetController"/> class.
        /// </summary>
        public MasonryImageGalleryWidgetController()
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="MasonryImageGalleryWidget"/> class.
        /// </summary>
        /// <param name="propertiesRetriever">Retriever for widget properties.</param>
        /// <param name="currentPageRetriever">Retriever for current page where is the widget used.</param>
        /// <remarks>Use this constructor for tests to handle dependencies.</remarks>
        public MasonryImageGalleryWidgetController(IComponentPropertiesRetriever<MasonryImageGalleryWidgetProperties> propertiesRetriever,
                                        ICurrentPageRetriever currentPageRetriever) : base(propertiesRetriever, currentPageRetriever)
        {
        }
        public ActionResult Index()

        {
            MasonryImageGalleryWidgetProperties properties = GetProperties();

            var ImageUrls = new List<string>();
            if (properties.Images != null)
            {
                foreach (var image in properties.Images)
                {
                    ImageUrls.Add(GetDirectImageUrlFromMediaLibrary(image.FileGuid));
                }
            }

            var model = new MasonryImageGalleryWidgetViewModel()
            {

                Urls = ImageUrls,
                ColumnWidth = properties.ColumnWidth,
                Padding = properties.Padding,
                HorizontalOrder = properties.HorizontalOrder,
                RightToLeft = properties.RightToLeft,
                BottomToTop = properties.BottomToTop,
                GalleryID = properties.GalleryID
            };
            return PartialView("Widgets/_MasonryImageGalleryWidget", model);
        }

        string GetDirectImageUrlFromMediaLibrary(Guid imageGuid)
        {
            //get filenale
            string fileName = null;
            var libs = MediaLibraryInfoProvider.GetMediaLibraries().ToList();
            foreach (var lib in libs)
            {
                var folder = lib.Children.FirstOrDefault();

                foreach (var image in folder)
                {
                    if (!string.IsNullOrEmpty(image.GetProperty("Guid").ToString()))
                    {
                        if (image.GetProperty("Guid").ToString() == imageGuid.ToString())
                        {
                            fileName = image.GetProperty("FileName").ToString();
                        }
                    }
                }
            }

            var siteName = SiteContext.CurrentSiteName;

            var urlMediaFileInfo = MediaFileInfoProvider.GetMediaFileInfo(imageGuid, siteName);

            string url = MediaLibraryHelper.GetDirectUrl(urlMediaFileInfo);

            return url;

        }
    }

}
