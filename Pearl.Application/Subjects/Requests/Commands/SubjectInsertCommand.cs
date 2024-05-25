using MediatR;
using Pearl.Core.DTOs;
using Pearl.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pearl.Application.Lecture.Requests.Commands
{
    public class SubjectInsertCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
