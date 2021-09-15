using AdaptItAcademy.BusinessLogic.DataLogic;
using AdaptItAcademy.DataAccess.Models;
using AdaptItAcademy.DataAccess.Services.delegates;
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
    public class DelegateController : Controller
    {

        private readonly IDelegateLogic _delegatesLogic;

        public DelegateController(IDelegateLogic delegatesLogic)
        {
            _delegatesLogic = delegatesLogic;
        }
        [HttpPost]
        public async Task<ActionResult<Delegates>> CreateDelegate(Delegates delegates)
        {
            try
            {
                if(delegates == null)
                {
                    return BadRequest();
                }

                var CreateDelegate = await _delegatesLogic.CreateDelegate(delegates);
      
                 return CreatedAtAction(nameof(GetDelegate), new { id = CreateDelegate.Id }, CreateDelegate);

            }
            catch(Exception ex)
            {
                if(ex.Message == "EmailExist")
                {
                    return StatusCode(StatusCodes.Status409Conflict, "EmailExist");
                }
                else if (ex.Message == "InvalidNumber")
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "InvalidPhone");
                }
                else if (ex.Message == "InvalidEmail")
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "InvalidEmail");
                }

                return StatusCode(StatusCodes.Status500InternalServerError,
                  $"Error saving data");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Delegates>> UpdateDelegate(Delegates delegates)
        {
            try
            {
                if (delegates == null)
                {
                    return BadRequest();
                }

                var CreateDelegate = await _delegatesLogic.UpdateDelegate(delegates);

                return CreatedAtAction(nameof(GetDelegate), new { id = CreateDelegate.Id }, CreateDelegate);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  $"Error saving data: {ex.Message}");
            }
        }

        [HttpGet("GetDelegate/{id:int}")]
        public async Task<ActionResult<Delegates>> GetDelegate(int id)
        {
            try
            {
                var result = await _delegatesLogic.GetDelegate(id);

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
                var delegateToDelete = await _delegatesLogic.GetDelegate(id);

                if (delegateToDelete == null)
                {
                    return NotFound($"Delegate with Id = {id} not found.");
                }


                await _delegatesLogic.DeleteDelegate(id);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex )
            {
    
                if (ex.Message == "registered")
                {
                    return StatusCode(StatusCodes.Status409Conflict, "This delegate can not be deleted because is already registred for a training");
                }

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error deleting data from the database");
            }
        }

        [HttpGet("GetAllDelegate")]
        public async Task<ActionResult<IEnumerable<Delegates>>> GetAllDelegate()
        {
            try
            {
                var result = await _delegatesLogic.GetAllDelegate();

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
