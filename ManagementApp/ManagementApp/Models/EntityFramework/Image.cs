using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.Models.EntityFramework
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public User User { get; set; }
    }
}