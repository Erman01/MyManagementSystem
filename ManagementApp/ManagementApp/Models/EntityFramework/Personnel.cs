using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManagementApp.Models.EntityFramework
{
    public class Personnel
    {
        public int Id { get; set; }
       
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public short? Salary { get; set; }

        [Display(Name = "Date od Birth")]
        public DateTime? DateOfBirth { get; set; }

        public bool Gender { get; set; }

        [Display(Name = "Marrital Status")]
        public bool MarritalStatus { get; set; }

        [Display(Name = "Image Description")]
        public string ImageDescription { get; set; }

        [Display(Name = "Choose an Image")]
        public string ImagePath { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}