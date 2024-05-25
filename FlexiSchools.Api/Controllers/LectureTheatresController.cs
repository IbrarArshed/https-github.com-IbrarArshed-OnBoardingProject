using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlexiSchools.Application.Lecture.Requests.Commands;
using FlexiSchools.Application.Lecture.Requests.Queries;
using FlexiSchools.Application.LectureTheatre.Requests.Commands;
using FlexiSchools.Application.LectureTheatre.Requests.Queries;
using FlexiSchools.Core.DTOs;
using FlexiSchools.Core.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FlexiSchools.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectureTheatresController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LectureTheatresController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> LectureTheatres()
        {
            try
            {
                var lectureResponse = await _mediator.Send(new LectureTheatreQuery());
                return Ok(lectureResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> LectureTheatres(int id)
        {
            try
            {
                var lectureResponse = await _mediator.Send(new LectureTheatreQuery { Id= id });
                return Ok(lectureResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> LectureTheatres([FromBody] LectureTheatreDTO lecture)
        {
            try
            {
                LectureTheatreInsertCommand command = new LectureTheatreInsertCommand
                {
                    Id = lecture.Id,
                    Name = lecture.Name,
                    Capacity = lecture.Capacity
                };
                var lectureResponse = await _mediator.Send(command);
                return Ok(lectureResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateLectureTheatres([FromBody] LectureTheatreDTO lecture)
        {
            try
            {
                LectureTheatreUpdateCommand command = new LectureTheatreUpdateCommand
                {
                    Id = lecture.Id,
                    Name = lecture.Name,
                    Capacity = lecture.Capacity
                };
                var lectureResponse = await _mediator.Send(command);
                return Ok(lectureResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
