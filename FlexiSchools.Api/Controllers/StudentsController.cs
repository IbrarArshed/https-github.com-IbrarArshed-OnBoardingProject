﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlexiSchools.Application.Lecture.Requests.Commands;
using FlexiSchools.Application.Lecture.Requests.Queries;
using FlexiSchools.Application.LectureTheatre.Requests.Commands;
using FlexiSchools.Application.LectureTheatre.Requests.Queries;
using FlexiSchools.Application.Students.Requests.Commands;
using FlexiSchools.Core.DTOs;
using FlexiSchools.Core.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FlexiSchools.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Students()
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
        public async Task<IActionResult> Students(int id)
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
        public async Task<IActionResult> Students([FromBody] StudentDTO std)
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
        public async Task<IActionResult> UpdateStudents([FromBody] StudentDTO std)
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
