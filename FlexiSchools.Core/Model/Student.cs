using FlexiSchools.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Core.Model
{
    public class Student : BaseNonAuditable
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<Subject> EnrolledSubjects { get; private set; }

        public Student()
        {
            EnrolledSubjects = new List<Subject>();
        }
    }
}
