using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDetail.Core.Model
{
  public class StudentInfo
    {
        public int StudentId { get; set; }
        public string? StudentFirstName { get; set; }
        public string? StudentLastName { get; set; }
        public int StudentAge { get; set; }
        public string? StudentLocation { get; set; }
        public string? StudentGender { get; set; }
        public string? StudentClass { get; set; }
        public string? StudentDepartment { get; set; }
        public string? YearOfJoining { get; set; }
    }
}
