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
    [Route("api/Flights")]
    public class FlightsController : Controller
    {
        private readonly IService<FlightDto> _flightsService;

        public FlightsController(IService<FlightDto> flightsService)
        {
            _flightsService = flightsService;
        }

        // GET: api/Flights
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_flightsService.GetAll());
        }

        // GET: api/Flights/5
        [HttpGet("{number}")]
        public IActionResult Get(Guid number)
        {
            try
            {
                return Ok(_flightsService.GetById(number));
            }
            catch (NotExistException)
            {
                return NotFound();
            }
        }
        
        // POST: api/Flights
        [HttpPost]
        public IActionResult Post([FromBody]FlightDto dto)
        {
            try
            {
                var createdNumber = _flightsService.Add(dto);
                return CreatedAtAction("Get",
                    _flightsService.GetById(createdNumber));
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
        
        // PUT: api/Flights/5
        [HttpPut("{number}")]
        public IActionResult Put(Guid number, [FromBody] FlightDto dto)
        {
            try
            {
                _flightsService.Update(number, dto);
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
        [HttpDelete("{number}")]
        public IActionResult Delete(Guid number)
        {
            try
            {
                _flightsService.Delete(number);
                return Ok();
            }
            catch (NotExistException)
            {
                return NotFound();
            }
        }
    }
}
