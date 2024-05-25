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
using FlexiSchools.Core.Model;
using FlexiSchools.Application.Lecture.Requests.Commands;

namespace FlexiSchools.Application.Lecture.Handlers.Commands
{
    public class LectureInsertCommandHandler : IRequestHandler<LectureInsertCommand, int>
    {
        private readonly IApplicationContext _context;
        public LectureInsertCommandHandler(IApplicationContext _context)
        {
            this._context = _context;
        }
        public async Task<int> Handle(LectureInsertCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var lecture = new FlexiSchools.Core.Model.Lecture();
                lecture.Id = command.Id;
                lecture.SubjectId = command.SubjectId;
                lecture.LectureTheatreId = command.LectureTheatreId;
                lecture.DayOfWeek = command.DayOfWeek;
                lecture.StartTime = command.StartTime;
                lecture.DurationInMinutes = command.DurationInMinutes;


                _context.Lectures.Add(lecture);
                await _context.SaveChangesAsync();

                return lecture.Id;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}

