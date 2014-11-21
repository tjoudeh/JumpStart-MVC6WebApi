using Microsoft.AspNet.Mvc;
using Registration_MVC6WebApi.Models;
using System;
using System.Collections.Generic;

namespace Registration_MVC6WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        private IRegistrationRepo _registrationRepo;

        public CoursesController(IRegistrationRepo registrationRepo)
        {
            _registrationRepo = registrationRepo;
        }

        [HttpGet]
        public IEnumerable<Course> GetAllCourses()
        {
            return _registrationRepo.GetCourses();
        }

        [HttpGet("{courseId:int}", Name = "GetCourseById")]
        public IActionResult GetCourseById(int courseId)
        {

            var course = _registrationRepo.GetCourse(courseId);
            if (course == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(course);
        }

        [HttpPost]
        public IActionResult AddCourse([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                Context.Response.StatusCode = 400;
                return new ObjectResult(new CourseStatusModel { Id = 1 , Description= "Course model is invalid" });
            }
            else
            {
               var addedCourse =  _registrationRepo.AddCourse(course);

                if (addedCourse != null)
                {
                    string url = Url.RouteUrl("GetCourseById", new { courseId = course.Id }, Request.Scheme, Request.Host.ToUriComponent());

                    Context.Response.StatusCode = 201;
                    Context.Response.Headers["Location"] = url;
                    return new ObjectResult(addedCourse);
                }
                else
                {
                    Context.Response.StatusCode = 400;
                    return new ObjectResult(new CourseStatusModel { Id = 2, Description = "Failed to save course" });
                }
               
            }
        }

        [HttpDelete("{courseId:int}")]
        public IActionResult DeleteCourse(int courseId)
        {
            var result = _registrationRepo.DeleteCourse(courseId);
            if (result)
            {
                return new HttpStatusCodeResult(204); 
            }
            else
            {
                return HttpNotFound();
            }
        }

    }

}