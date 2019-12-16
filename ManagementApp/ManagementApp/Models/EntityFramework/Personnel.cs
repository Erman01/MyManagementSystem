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

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Range(100,10000,ErrorMessage =("Salary must be between 100 and 10000"))]
        [Required(ErrorMessage = "Salary is required")]
        public short? Salary { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage ="Gender is required")]
        public bool Gender { get; set; }

        [Required(ErrorMessage = "Marrital status is required")]

        [Display(Name = "Marrital Status")]
        public bool MarritalStatus { get; set; }

        [Display(Name = "Image Description")]
        public string ImageDescription { get; set; }

        [Display(Name = "Choose an Image")]
        public string ImagePath { get; set; }

        [Display(Name = "Department Name")]

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}