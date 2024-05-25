using FlexiSchools.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Core.DTOs
{
    public class StudentDTO : BaseNonAuditable
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<SubjectDTO> EnrolledSubjects { get; private set; }

        public StudentDTO()
        {
            EnrolledSubjects = new List<SubjectDTO>();
        }
    }
}
