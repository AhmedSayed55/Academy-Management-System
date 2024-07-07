using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ahmed_Sayed_Final_Project.Models
{
    public class Professor
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        [Required(ErrorMessage = "You have to provide a valid Name")]
        [MinLength(10, ErrorMessage = "full name mut not be less than 10 characters")]
        [MaxLength(50, ErrorMessage = "the full name must not exceed 50 characters")]
        public string FullName { get; set; }
        [MinLength(14, ErrorMessage = "national number must not be less than 14 digits")]
        [MaxLength(14, ErrorMessage = "national number must not be more than 14 digits")]
        [RegularExpression("[0-9]{14}", ErrorMessage = "the national number should be 14 digits")]
        public string NationalNumber { get; set; }
        [Range(3000, 35000, ErrorMessage = "salary must be between 3000 and 35000")]
        public int Salary { get; set; }
        [Range(1000, double.MaxValue, ErrorMessage = "Bonus must not be less than 1000")]
        public double Bonus { get; set; }
        [ValidateNever]
        public List<Course> courses { get; set; }

    }
}
