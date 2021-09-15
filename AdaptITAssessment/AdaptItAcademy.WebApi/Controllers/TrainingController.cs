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
    public class TrainingController : Controller
    {

        private readonly ITrainingLogic _trainingLogic;
        public TrainingController(ITrainingLogic trainingLogic)
        {
            _trainingLogic = trainingLogic;
        }
        [HttpPost]
        public async Task<ActionResult<Training>> CreateTraining(Training training)
        {
            try
            {
                if(training == null)
                {
                    return BadRequest();
                }

                var CreateTraining = await _trainingLogic.CreateTraining(training);

                return CreatedAtAction(nameof(GetTraining), new { id = CreateTraining.Id }, CreateTraining);
                
                

            }
            catch(Exception ex)
            {
                if (ex.Message == "TrainingExist")
                {
                    return StatusCode(StatusCodes.Status409Conflict, "TrainingExist");
                }else if (ex.Message == "InValidDate")
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "InValidDate");
                }
                else if (ex.Message == "InValidClosingDate")
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "InValidClosingDate");
                }

                return StatusCode(StatusCodes.Status500InternalServerError,
                  $"Error saving data");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Training>> UpdateTraining(Training training)
        {
            try
            {
                if (training == null)
                {
                    return BadRequest();
                }

                var CreateTraining = await _trainingLogic.UpdateTraining(training);

                return CreatedAtAction(nameof(GetTraining), new { id = CreateTraining.Id }, CreateTraining);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  $"Error saving data: {ex.Message}");
            }
        }

        [HttpGet("GetTraining/{id:int}")]
        public async Task<ActionResult<Training>> GetTraining(int id)
        {
            try
            {
                var result = await _trainingLogic.GetTraining(id);

                if (result == null)
                {                   
                   return NoContent();
                }

                return result;
            }
            catch (Exception ex)
            {
                if (ex.Message == "TrainingExist")
                {
                    return StatusCode(StatusCodes.Status409Conflict, "TrainingExist");
                }
                else if (ex.Message == "InValidDate")
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "InValidDate");
                }
                else if (ex.Message == "InValidClosingDate")
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "InValidClosingDate");
                }

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Course>> Delete(int id)
        {
            try
            {
                var delegateToDelete = await _trainingLogic.GetTraining(id);

                if (delegateToDelete == null)
                {
                    return NotFound($"Delegate with Id = {id} not found.");
                }

                await _trainingLogic.DeleteTraining(id);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex )
            {
                if (ex.Message == "registered")
                {

                    return StatusCode(StatusCodes.Status409Conflict, "This delegate can not be deleted because is already registred for a training");
                }

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }

        [HttpGet("GetAllTraining")]
        public async Task<ActionResult<IEnumerable<Training>>> GetAllTraining()
        {
            try
            {
                var result = await _trainingLogic.GetAllTraining();

                if (result == null )
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


        [HttpGet("GetUpComingTraining")]
        public ActionResult<IEnumerable<Training>> GetUpComingTraining()
        {
            try
            {
                var result =  _trainingLogic.GetCourseUpComingTraining();

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
