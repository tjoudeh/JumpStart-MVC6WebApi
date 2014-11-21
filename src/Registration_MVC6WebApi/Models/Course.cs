using System;
using System.ComponentModel.DataAnnotations;

namespace Registration_MVC6WebApi.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }
        public int Credits { get; set; }
    }

    public class CourseStatusModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}