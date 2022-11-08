using StudentDetail.Core.IRepository;
using StudentDetail.Core.IService;
using StudentDetail.Core.Model;
using StudentDetail.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDetail.Service
{
    public class StudentDetailService: IStudentDetailService
    {
        private readonly IStudentDetailRepository studentEntry;
        public StudentDetailService(IStudentDetailRepository studentDetail)
        {
            studentEntry = studentDetail;
        }
        #region Create
        public void CreateMethod(StudentInfo studentInfo)
        {
            studentEntry.CreateMethod(studentInfo);
        }
        #endregion

        #region Read
        public List<StudentInfo> ReadMethod()
        {
            return studentEntry.ReadMethod();
        }
        #endregion

        #region Update
        public StudentInfo UpdateMethod(int studentId)
        {
            return studentEntry.UpdateMethod(studentId);
        }
        #endregion

        #region Delete
        public void DeleteMethod(int studentId)
        {
            studentEntry.DeleteMethod(studentId);
        }
        #endregion
    }
}
