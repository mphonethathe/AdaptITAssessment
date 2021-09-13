using AdaptItAcademy.BusinessLogic.DataLogic;
using AdaptItAcademy.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptItAcademy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {

        private readonly ICourseLogic _courseLogic;
        public CourseController(ICourseLogic courseLogic)
        {
            _courseLogic = courseLogic;
        }
        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse(Course course)
        {
            try
            {
                if(course == null)
                {
                    return BadRequest();
                }

                var CreateCourse= await _courseLogic.CreateCourse(course);

                return CreatedAtAction(nameof(GetCourse), new { id = CreateCourse.Id }, CreateCourse);


            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  $"Error saving data: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Delegates>> UpdateCourse(Course course)
        {
            try
            {
                if (course == null)
                {
                    return BadRequest();
                }

                var CreateCourse = await _courseLogic.UpdateCourse(course);

                return CreatedAtAction(nameof(GetCourse), new { id = CreateCourse.Id }, CreateCourse);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  $"Error saving data: {ex.Message}");
            }
        }

        [HttpGet("GetCourse/{id:int}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            try
            {
                var result = await _courseLogic.GetCourse(id);

                if (result == null)
                {                   
                   return NoContent();
                }

                return result;
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Course>> Delete(int id)
        {
            try
            {
                var acourseToDelete = await _courseLogic.GetCourse(id);

                if (acourseToDelete == null)
                {
                    return NotFound($"Course with Id = {id} not found.");
                }

                await _courseLogic.DeleteCourse(id);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }

        [HttpGet("GetAllCourses")]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
        {
            try
            {
                var result = await _courseLogic.GetAllCourses();

                if (result == null)
                {
                    return NoContent();
                }

                return result.ToList();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }



    }
}
