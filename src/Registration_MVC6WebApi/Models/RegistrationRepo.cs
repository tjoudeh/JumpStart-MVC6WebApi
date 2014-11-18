using System;
using System.Collections.Generic;
using System.Linq;


namespace Registration_MVC6WebApi.Models
{
    public class RegistrationRepo : IRegistrationRepo
    {
        private readonly RegistrationDbContext _db;

        public RegistrationRepo(RegistrationDbContext db)
        {
            _db = db;
        }
        public Course AddCourse(Course course)
        {
            _db.Courses.Add(course);

            if (_db.SaveChanges() > 0)
            {
                return course;
            }
            return null;

        }

        public bool DeleteCourse(int courseId)
        {
            var course = _db.Courses.FirstOrDefault(c => c.Id == courseId);
            if (course != null)
            {
                _db.Courses.Remove(course);
                return _db.SaveChanges() > 0;
            }
            return false;
        }

        public Course GetCourse(int courseId)
        {
            return _db.Courses.FirstOrDefault(c => c.Id == courseId);
        }

        public IEnumerable<Course> GetCourses()
        {
            return _db.Courses.AsEnumerable();
        }
    }
}