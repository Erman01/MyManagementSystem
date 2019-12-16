using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagementApp.Models.EntityFramework
{
    public class Image
    {
        public int Id { get; set; }
       
        [Display(Name ="Image Name")]
        public string ImageName { get; set; }
       
        [Display(Name ="Choose an Image")]
        public string ImagePath { get; set; }
        public User User { get; set; }
    }
}