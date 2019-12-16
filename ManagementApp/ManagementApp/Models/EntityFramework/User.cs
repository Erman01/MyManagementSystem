using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.Models.EntityFramework
{
    public class User
    {
        public User()
        {
            Images = new List<Image>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public List<Image> Images { get; set; }

    }
}