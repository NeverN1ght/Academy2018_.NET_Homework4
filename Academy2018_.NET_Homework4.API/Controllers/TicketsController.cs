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
    [Route("api/Tickets")]
    public class TicketsController : Controller
    {
        private readonly IService<TicketDto> _ticketsService;

        public TicketsController(IService<TicketDto> ticketsService)
        {
            _ticketsService = ticketsService;
        }

        // GET: api/Tickets
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ticketsService.GetAll());
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_ticketsService.GetById(id));
            }
            catch (NotExistException)
            {
                return NotFound();
            }
        }
        
        // POST: api/Tickets
        [HttpPost]
        public IActionResult Post([FromBody]TicketDto dto)
        {
            try
            {
                var createdId = _ticketsService.Add(dto);
                return CreatedAtAction("Get",
                    _ticketsService.GetById(createdId));
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
        
        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TicketDto dto)
        {
            try
            {
                _ticketsService.Update(id, dto);
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
                _ticketsService.Delete(id);
                return Ok();
            }
            catch (NotExistException)
            {
                return NotFound();
            }
        }
    }
}
