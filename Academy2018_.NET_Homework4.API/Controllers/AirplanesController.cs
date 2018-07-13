using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy2018_.NET_Homework4.Core.Abstractions;
using Academy2018_.NET_Homework4.Shared.DTOs;
using Academy2018_.NET_Homework4.Shared.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academy2018_.NET_Homework4.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Airplanes")]
    public class AirplanesController : Controller
    {
        private readonly IService<AirplaneDto> _airplanesService;

        public AirplanesController(IService<AirplaneDto> airplanesService)
        {
            _airplanesService = airplanesService;
        }

        // GET: api/Airplanes
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_airplanesService.GetAll());
        }

        // GET: api/Airplanes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_airplanesService.GetById(id));
            }
            catch (NotExistException)
            {
                return NotFound();
            }
        }
        
        // POST: api/Airplanes
        [HttpPost]
        public IActionResult Post([FromBody]AirplaneDto dto)
        {
            try
            {
                var createdId = _airplanesService.Add(dto);
                return CreatedAtAction("Get",
                    _airplanesService.GetById(createdId));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch (NullBodyException)
            {
                return BadRequest();
            }
        }
        
        // PUT: api/Airplanes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]AirplaneDto dto)
        {
            try
            {
                _airplanesService.Update(id, dto);
                return Ok();
            }
            catch (NotExistException)
            {
                return NotFound();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch (NullBodyException)
            {
                return BadRequest();
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _airplanesService.Delete(id);
                return NoContent();
            }
            catch (NotExistException)
            {
                return NotFound();
            }
        }
    }
}
