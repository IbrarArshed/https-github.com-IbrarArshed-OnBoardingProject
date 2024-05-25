using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlexiSchools.Application.Lecture.Requests.Commands;
using FlexiSchools.Application.Lecture.Requests.Queries;
using FlexiSchools.Core.DTOs;
using FlexiSchools.Core.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FlexiSchools.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LecturesController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Lectures()
        {
            try
            {
                var lectureResponse = await _mediator.Send(new LectureQuery());
                return Ok(lectureResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> Lectures(int id)
        {
            try
            {
                var lectureResponse = await _mediator.Send(new LectureQuery { Id= id });
                return Ok(lectureResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Lectures([FromBody] LectureDTO lecture)
        {
            try
            {
                LectureInsertCommand command = new LectureInsertCommand
                {
                    Id = lecture.Id,
                    SubjectId = lecture.SubjectId,
                    LectureTheatreId = lecture.LectureTheatreId,
                    DayOfWeek = lecture.DayOfWeek,
                    StartTime = lecture.StartTime,
                    DurationInMinutes = lecture.DurationInMinutes
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
        public async Task<IActionResult> UpdateLectures([FromBody] LectureDTO lecture)
        {
            try
            {
                LectureUpdateCommand command = new LectureUpdateCommand
                {
                    Id = lecture.Id,
                    SubjectId = lecture.SubjectId,
                    LectureTheatreId = lecture.LectureTheatreId,
                    DayOfWeek = lecture.DayOfWeek,
                    StartTime = lecture.StartTime,
                    DurationInMinutes = lecture.DurationInMinutes
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
