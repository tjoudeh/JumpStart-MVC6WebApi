using System;
using System.Collections;
using System.Collections.Generic;

namespace Registration_MVC6WebApi.Models
{
    public interface IRegistrationRepo
    {
        IEnumerable<Course> GetCourses();
        Course GetCourse(int courseId);
        Course AddCourse(Course course);
        bool DeleteCourse(int courseId);

    }
}