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
    [Route("api/Crews")]
    public class CrewsController : Controller
    {
        private readonly IService<CrewDto> _crewsService;

        public CrewsController(IService<CrewDto> crewsService)
        {
            _crewsService = crewsService;
        }

        // GET: api/Crews
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_crewsService.GetAll());
        }

        // GET: api/Crews/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_crewsService.GetById(id));
            }
            catch (NotExistException)
            {
                return NotFound();
            }
        }
        
        // POST: api/Crews
        [HttpPost]
        public IActionResult Post([FromBody]CrewDto dto)
        {
            try
            {
                var createdId = _crewsService.Add(dto);
                return CreatedAtAction("Get",
                    _crewsService.GetById(createdId));
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
        
        // PUT: api/Crews/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CrewDto dto)
        {
            try
            {
                _crewsService.Update(id, dto);
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
                _crewsService.Delete(id);
                return NoContent();
            }
            catch (NotExistException)
            {
                return NotFound();
            }
        }
    }
}
