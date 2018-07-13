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
    [Route("api/Stewardesses")]
    public class StewardessesController : Controller
    {
        private readonly IService<StewardesseDto> _stewardessesService;

        public StewardessesController(IService<StewardesseDto> stewardessesService)
        {
            _stewardessesService = stewardessesService;
        }

        // GET: api/Stewardesses
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_stewardessesService.GetAll());
        }

        // GET: api/Stewardesses/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_stewardessesService.GetById(id));
            }
            catch (NotExistException)
            {
                return NotFound();
            }
        }
        
        // POST: api/Stewardesses
        [HttpPost]
        public IActionResult Post([FromBody]StewardesseDto dto)
        {
            try
            {
                var createdId = _stewardessesService.Add(dto);
                return CreatedAtAction("Get",
                    _stewardessesService.GetById(createdId));
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
        
        // PUT: api/Stewardesses/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]StewardesseDto dto)
        {
            try
            {
                _stewardessesService.Update(id, dto);
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
                _stewardessesService.Delete(id);
                return NoContent();
            }
            catch (NotExistException)
            {
                return NotFound();
            }
        }
    }
}
