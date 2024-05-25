﻿using MediatR;
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
using Pearl.Application.LectureTheatre.Requests.Commands;

namespace Pearl.Application.LectureTheatre.Handlers.Commands
{
    public class LectureTheatreUpdateCommandHandler : IRequestHandler<LectureTheatreUpdateCommand, LectureTheatreDTO>
    {
        private readonly IApplicationContext _context;
        public LectureTheatreUpdateCommandHandler(IApplicationContext _context)
        {
            this._context = _context;
        }
        public async Task<LectureTheatreDTO> Handle(LectureTheatreUpdateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var lecture = await _context.LectureTheatres.Where(x => x.Id == command.Id).FirstOrDefaultAsync();
                lecture.Id = command.Id;
                lecture.Name = command.Name;
                lecture.Capacity = command.Capacity;
                _context.LectureTheatres.Update(lecture);
                await _context.SaveChangesAsync();

                return ModelMapper(lecture);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static LectureTheatreDTO ModelMapper(Core.Model.LectureTheatre lecture)
        {
            return new LectureTheatreDTO
            {
                Id = lecture.Id,
                Name = lecture.Name,
                Capacity = lecture.Capacity
            };
        }
    }
}

