﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pearl.Application.Lecture.Requests.Commands;
using Pearl.Application.Lecture.Requests.Queries;
using Pearl.Application.LectureTheatre.Requests.Commands;
using Pearl.Application.LectureTheatre.Requests.Queries;
using Pearl.Application.Students.Requests.Commands;
using Pearl.Core.DTOs;
using Pearl.Core.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Pearl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SubjectsController(IMediator mediator)
        {                
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Subjects()
        {
            try
            {
                var stdResponse = await _mediator.Send(new StudentQuery());
                return Ok(stdResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> Subjects(int id)
        {
            try
            {
                var stdResponse = await _mediator.Send(new StudentQuery { Id= id });
                return Ok(stdResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Subjects([FromBody] StudentDTO std)
        {
            try
            {
                StudentInsertCommand command = new StudentInsertCommand
                {
                    Id = std.Id,
                    FullName = std.FullName,
                    
                };
                var stdResponse = await _mediator.Send(command);
                return Ok(stdResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateSubjects([FromBody] StudentDTO std)
        {
            try
            {
                StudentUpdateCommand command = new StudentUpdateCommand
                {
                    Id = std.Id,
                    FullName = std.FullName
                };
                var stdResponse = await _mediator.Send(command);
                return Ok(stdResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
