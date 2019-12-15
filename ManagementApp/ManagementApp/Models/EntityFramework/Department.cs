using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagementApp.Models.EntityFramework
{
    public class Department
    {
        public Department()
        {
            Personnels = new List<Personnel>();
        }
        public int Id { get; set; }

        [Display(Name ="Department Name")]
        public string DepartmentName { get; set; }
        public List<Personnel> Personnels { get; set; }
    }
}