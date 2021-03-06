﻿using System;
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
    [Route("api/Departures")]
    public class DeparturesController : Controller
    {
        private readonly IService<DepartureDto> _departureService;

        public DeparturesController(IService<DepartureDto> departureService)
        {
            _departureService = departureService;
        }

        // GET: api/Departures
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_departureService.GetAll());
        }

        // GET: api/Departures/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_departureService.GetById(id));
            }
            catch (NotExistException)
            {
                return NotFound();
            }          
        }
        
        // POST: api/Departures
        [HttpPost]
        public IActionResult Post([FromBody]DepartureDto dto)
        {
            try
            {
                var createdId = _departureService.Add(dto);
                return CreatedAtAction("Get",
                    _departureService.GetById(createdId));
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
        
        // PUT: api/Departures/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]DepartureDto dto)
        {
            try
            {
                _departureService.Update(id, dto);
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

        // DELETE: api/Departures/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _departureService.Delete(id);
                return NoContent();
            }
            catch (NotExistException)
            {
                return NotFound();
            }
        }
    }
}
