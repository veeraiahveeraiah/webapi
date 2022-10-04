using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webapi123.Models
{
    public class PersonalDetails
    {

        [Required(ErrorMessage = "Please enter Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter FatherName")]
        [Display(Name = "FatherName")]
        public string FatherName { get; set; }
        [Required(ErrorMessage = "Please enter MotherName")]
        [Display(Name = "MotherName")]
        public string MotherName { get; set; }
        [Required(ErrorMessage = "Please enter familyIncome")]
        [Display(Name = "FamilyIncome")]
        public string familyIncome { get; set; }
        [Required(ErrorMessage = "Please enter Course")]
        [Display(Name = "Course")]
        public string Course { get; set; }

        


    }
}