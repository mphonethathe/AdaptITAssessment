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
    public class RegistrationController : Controller
    {

        private readonly ITrainingRegistrationLogic _registrationLogic;
        public RegistrationController(ITrainingRegistrationLogic registrationLogic)
        {
            _registrationLogic = registrationLogic;
        }
        [HttpPost]
        public async Task<ActionResult<TrainingRegistration>> CreateRegistration(TrainingRegistration training)
        {
            try
            {
                if(training == null)
                {
                    return BadRequest();
                }

                var CreateRegistration = await _registrationLogic.CreateTrainingRegistration(training);

                if ((Convert.ToInt32(CreateRegistration.Id) > 0))
                {
                    return CreatedAtAction(nameof(GetRegistration), new { id = CreateRegistration.Id }, CreateRegistration);
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict, "");
                }

            }
            catch(Exception ex)
            {

                if(ex.Message == "NoSeats")
                {
                    return StatusCode(StatusCodes.Status409Conflict, "NoSeats");
                }else if (ex.Message =="AlreadyRegistered")
                {
                    return StatusCode(StatusCodes.Status409Conflict, "AlreadyRegistered");
                }

                return StatusCode(StatusCodes.Status500InternalServerError,
                  $"Error saving data: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<TrainingRegistration>> UpdateRegistration(TrainingRegistration training)
        {
            try
            {
                if (training == null)
                {
                    return BadRequest();
                }

                var CreateRegistration = await _registrationLogic.UpdateTrainingRegistration(training);

                return CreatedAtAction(nameof(GetRegistration), new { id = CreateRegistration.Id }, CreateRegistration);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  $"Error saving data: {ex.Message}");
            }
        }

        [HttpGet("GetRegistration/{id:int}")]
        public async Task<ActionResult<TrainingRegistration>> GetRegistration(int id)
        {
            try
            {
                var result = await _registrationLogic.GetTrainingRegistration(id);

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
                var delegateToDelete = await _registrationLogic.GetTrainingRegistration(id);

                if (delegateToDelete == null)
                {
                    return NotFound($"Delegate with Id = {id} not found.");
                }

                await _registrationLogic.DeleteTrainingRegistration(id);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception )
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }

        [HttpGet("GetAllRegistration")]
        public async Task<ActionResult<IEnumerable<TrainingRegistration>>> GetAllRegistration()
        {
            try
            {
                var result = await _registrationLogic.GetAllTrainingRegistration();

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


        [HttpGet("GetDelegateRegistration/{id:int}")]
        public  ActionResult<IEnumerable<TrainingRegistration>> GetDelegateRegistration(int id)
        {
            try
            {
                var result =  _registrationLogic.GetAllDeleteRegistration(id);

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
