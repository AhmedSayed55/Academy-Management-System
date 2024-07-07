using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ahmed_Sayed_Final_Project.Models
{
    public class Course
    {

        public int Id { get; set; }
        [DisplayName("Name")]
        [Required(ErrorMessage = "You have to provide a valid Course Name")]
        [MinLength(2, ErrorMessage = "course name must not be less than 2 characters")]
        [MaxLength(50, ErrorMessage = "the course name must not exceed 50 characters")]
        public string CourseName { get; set; }
        [DisplayName("Code")]
        [MinLength(5, ErrorMessage = "course code must not be less than 5 digits")]
        [MaxLength(5, ErrorMessage = "course code must not be more than 5 digits")]
        [RegularExpression("[0-9]{5}", ErrorMessage = "the Corse code should be 5 digits")]
        public string CourseCode { get; set; }
        [Range(3000, 30000, ErrorMessage = "price must be between 3000 and 30000")]
        public double Price { get; set; }
        public string Description { get; set; }


        [Display(Name = "Professor")]
        public int ProfessorId { get; set; }
        [ValidateNever]
        public Professor Professor { get; set; }

    }
}



