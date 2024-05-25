using MediatR;
using FlexiSchools.Core.DTOs;
using FlexiSchools.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Application.Subjects.Requests.Queries
{
    public class SubjectQuery : IRequest<List<SubjectDTO>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
