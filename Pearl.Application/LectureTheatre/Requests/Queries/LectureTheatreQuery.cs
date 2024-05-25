using MediatR;
using Pearl.Core.DTOs;
using Pearl.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pearl.Application.LectureTheatre.Requests.Queries
{
    public class LectureTheatreQuery : IRequest<List<LectureTheatreDTO>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
