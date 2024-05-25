using MediatR;
using Pearl.Core.DTOs;
using Pearl.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pearl.Application.LectureTheatre.Requests.Commands
{
    public class StudentUpdateCommand : IRequest<StudentDTO>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
