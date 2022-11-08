using Microsoft.AspNetCore.Mvc;
using StudentDetail.Core.IService;
using StudentDetail.Core.Model;

namespace StudentDetailAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentDataAPIController : Controller
    {
        private readonly IStudentDetailService _studentDetail;
        public StudentDataAPIController(IStudentDetailService _studentDetail)
        {

            this._studentDetail = _studentDetail;
        }
        #region CreateEntry
        [HttpPost]
        public IActionResult CreateEntry(StudentInfo studentInfo)
        {
            _studentDetail.CreateMethod(studentInfo);
            return Ok(studentInfo);
        }
        #endregion

        #region ReadDetails
        [HttpGet]
        public IActionResult ReadDetails()
        {
            var info = _studentDetail.ReadMethod();
            return Ok(info);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult UpdateEntry(int studentId)
        {
            var info= _studentDetail.UpdateMethod(studentId);
            return Ok(info);
        }
        #endregion

        #region DeleteEntry
        [HttpDelete]
        public IActionResult DeleteEntry(int studentId)
        {
            _studentDetail.DeleteMethod(studentId);
            return Ok();
        }
        #endregion

       
}
}
