using StudentDetail.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDetail.Core.IService
{
    public interface IStudentDetailService
    {
        void CreateMethod(StudentInfo studentInfo);
        List<StudentInfo> ReadMethod();
        StudentInfo UpdateMethod(int studentId);
        void DeleteMethod(int studentId);
    }
}
