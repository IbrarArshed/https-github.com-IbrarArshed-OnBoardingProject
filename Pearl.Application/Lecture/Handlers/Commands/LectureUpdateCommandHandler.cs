using MediatR;
using Pearl.Core.Enumeration;
using Pearl.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pearl.Application.Lecture.Requests.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Pearl.Core.DTOs;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Pearl.Core.Model;
using Pearl.Application.Lecture.Requests.Commands;

namespace Pearl.Application.Lecture.Handlers.Commands
{
    public class LectureUpdateCommandHandler : IRequestHandler<LectureUpdateCommand, LectureDTO>
    {
        private readonly IApplicationContext _context;
        public LectureUpdateCommandHandler(IApplicationContext _context)
        {
            this._context = _context;
        }
        public async Task<LectureDTO> Handle(LectureUpdateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var lecture = await _context.Lectures.Where(x => x.Id == command.Id).FirstOrDefaultAsync();
                lecture.Id = command.Id;
                lecture.SubjectId = command.SubjectId;
                lecture.LectureTheatreId = command.LectureTheatreId;
                lecture.DayOfWeek = command.DayOfWeek;
                lecture.StartTime = command.StartTime;
                lecture.DurationInMinutes = command.DurationInMinutes;

                _context.Lectures.Update(lecture);
                await _context.SaveChangesAsync();

                return ModelMapper(lecture);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static LectureDTO ModelMapper(Core.Model.Lecture lecture)
        {
            return new LectureDTO
            {
                Id = lecture.Id,
                SubjectId = lecture.SubjectId,
                LectureTheatreId = lecture.LectureTheatreId,
                DayOfWeek = lecture.DayOfWeek,
                StartTime = lecture.StartTime,
                DurationInMinutes = lecture.DurationInMinutes
            };
        }
    }
}

