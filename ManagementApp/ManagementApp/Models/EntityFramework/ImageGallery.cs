using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagementApp.Models.EntityFramework
{
    public class ImageGallery
    {

        public int Id { get; set; }

        [Display(Name = "Gallery Name")]
        public string GalleryImageName { get; set; }

        [Display(Name = "Choose a cover photo")]
        public string GalleryImagePath { get; set; }
        public User User { get; set; }

    }
}