using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Forms.Web.Mvc;
using Kentico.Components.Web.Mvc.FormComponents;

namespace SeventyeightDigital.MasonryImageGalleryWidget
{
    public class MasonryImageGalleryWidgetViewModel
    {
        /// <summary>
        /// Urls of images
        /// </summary>
        public IList<string> Urls { get; set; }
        /// <summary>
        /// Column / Image width in pixels.
        /// </summary>
        public int ColumnWidth { get; set; }
        /// <summary>
        /// Image padding in pixels.
        /// </summary>
        public int Padding { get; set; }
        /// <summary>
        /// Bool for maintaining Horizontal Order.
        /// </summary>
        public string HorizontalOrder { get; set; }
        /// <summary>
        /// Bool for setting right-to-left layout.
        /// </summary>
        public string RightToLeft { get; set; }
        /// <summary>
        /// Bool for setting bottom-up layout layout.
        /// </summary>
        public string BottomToTop { get; set; }

        public Guid GalleryID { get; set; }
    }


}
