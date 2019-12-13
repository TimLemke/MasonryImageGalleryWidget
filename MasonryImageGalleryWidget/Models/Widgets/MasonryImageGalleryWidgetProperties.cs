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
    public class MasonryImageGalleryWidgetProperties : IWidgetProperties
    {
        /// <summary>
        /// Selected images property.
        /// </summary>
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.AllowedExtensions), ".png;.jpg;.jpeg")]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.MaxFilesLimit), 0)]
        [EditingComponent(MediaFilesSelector.IDENTIFIER, Order = 0, Label = "Images")]
        public IList<MediaFilesSelectorItem> Images { get; set; }

        /// <summary>
        /// Width of gallery images and columns as pixels.
        /// </summary>
        [EditingComponent(IntInputComponent.IDENTIFIER, ExplanationText = "Column / Image width in pixels", Label = "Column / Image Width", Order = 1)]
        public int ColumnWidth { get; set; } = 300;

        /// <summary>
        /// Padding of images in pixels.
        /// </summary>
        [EditingComponent(IntInputComponent.IDENTIFIER, ExplanationText = "Image padding in pixels", Label = "Image Padding", Order = 2)]
        public int Padding { get; set; } = 0;

        /// <summary>
        /// Dropdown for selecting maintaining horizontal order of images.
        /// </summary>
        [EditingComponent(DropDownComponent.IDENTIFIER, ExplanationText = "Maintain horizontal order of images?", Label = "Horizontal Order", Order = 3)]
        [EditingComponentProperty(nameof(DropDownProperties.DataSource), "false;No\r\ntrue;Yes")]
        public string HorizontalOrder { get; set; } = "false";

        /// <summary>
        /// Dropdown for selecting right to left order of images.
        /// </summary>
        [EditingComponent(DropDownComponent.IDENTIFIER, ExplanationText = "Layout images right to left?", Label = "Right to left layout", Order = 4)]
        [EditingComponentProperty(nameof(DropDownProperties.DataSource), "true;No\r\nfalse;Yes")]
        public string RightToLeft { get; set; } = "true";

        /// <summary>
        /// Dropdown for selecting bottom to top order of images.
        /// </summary>
        [EditingComponent(DropDownComponent.IDENTIFIER, ExplanationText = "Layout images bottom to top?", Label = "Bottom to top layout", Order = 5)]
        [EditingComponentProperty(nameof(DropDownProperties.DataSource), "true;No\r\nfalse;Yes")]
        public string BottomToTop { get; set; } = "true";

        public Guid GalleryID { get; set; } = Guid.NewGuid();
    }

}
