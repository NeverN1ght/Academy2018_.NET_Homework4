using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy2018_.NET_Homework4.Core.Abstractions;
using Academy2018_.NET_Homework4.Core.Services;
using Academy2018_.NET_Homework4.Shared.DTOs;
using Academy2018_.NET_Homework4.Shared.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academy2018_.NET_Homework4.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Pilots")]
    public class PilotsController : Controller
    {
        private readonly IService<PilotDto> _pilotsService;

        public PilotsController(IService<PilotDto> pilotsService)
        {
            _pilotsService = pilotsService;
        }

        // GET: api/Pilots
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pilotsService.GetAll());
        }

        // GET: api/Pilots/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_pilotsService.GetById(id));
            }
            catch (NotExistException)
            {
                return NotFound();
            }
        }
        
        // POST: api/Pilots
        [HttpPost]
        public IActionResult Post([FromBody]PilotDto pilotDto)
        {
            try
            {
                var createdId = _pilotsService.Add(pilotDto);
                return CreatedAtAction("Get",
                    _pilotsService.GetById(createdId));
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
        
        // PUT: api/Pilots/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PilotDto pilotDto)
        {
            try
            {
                _pilotsService.Update(id, pilotDto);
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
                _pilotsService.Delete(id);
                return Ok();
            }
            catch (NotExistException)
            {
                return NotFound();
            }
        }
    }
}
