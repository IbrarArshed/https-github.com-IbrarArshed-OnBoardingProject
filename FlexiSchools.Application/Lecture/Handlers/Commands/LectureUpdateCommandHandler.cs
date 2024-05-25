using MediatR;
using FlexiSchools.Core.Enumeration;
using FlexiSchools.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlexiSchools.Application.Lecture.Requests.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using FlexiSchools.Core.DTOs;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using FlexiSchools.Core.Entities;
using FlexiSchools.Application.Lecture.Requests.Commands;

namespace FlexiSchools.Application.Lecture.Handlers.Commands
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

        private static LectureDTO ModelMapper(Core.Entities.Lecture lecture)
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

