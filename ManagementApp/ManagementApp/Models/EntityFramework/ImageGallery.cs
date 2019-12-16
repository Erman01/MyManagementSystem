using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.Models.EntityFramework
{
    public class ImageGallery
    {
        
            public int Id { get; set; }
            public string GalleryImageName { get; set; }
            public string GalleryImagePath { get; set; }
            public User User { get; set; }
        
    }
}