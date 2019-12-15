using ManagementApp.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.ViewModels
{
    public class PersonnelFormViewModel
    {
        public List<Department> Departments { get; set; }
        public Personnel Personnel { get; set; }
    }
}