using ManagementApp.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.ViewModels
{
    public class ImageformViewModel
    {
        public User User { get; set; }

        public List<Image> Images { get; set; }
        public List<ImageGallery> ImageGalleries { get; set; }
    }
}