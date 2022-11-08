using Microsoft.AspNetCore.Mvc;
using StudentDetail.Core.Model;

namespace StudentDetails.Controllers
{
    public class StudentDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        #region CreateEntry
        [HttpGet]
        public IActionResult CreateEntry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEntry(StudentInfo studentInfo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7240/api/StudentDataAPI/CreateEntry");
                var Posttask = client.PostAsJsonAsync(client.BaseAddress, studentInfo);
                Posttask.Wait();
                var result = Posttask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ReadDetails");
                }
            }
            return RedirectToAction("ReadDetails");
        }
        #endregion

        #region ReadDetails
        [HttpGet]
        public IActionResult ReadDetails()
        {
            IList<StudentInfo>? studentInfos = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7240/api/StudentDataAPI/ReadDetails");
                //HTTP GET
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<StudentInfo>>();
                    readTask.Wait();

                    studentInfos = readTask.Result;
                }
                List<StudentInfo> SortedList = studentInfos.OrderBy(o => o.StudentFirstName).ToList();
                return View(SortedList);
            }
        }
        #endregion

        #region AssignDetails
        [HttpGet]
        public IActionResult EditDetail(int studentId)
        {
            StudentInfo? studentData = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7240/api/StudentDataAPI/UpdateEntry?studentId=");
                //HTTP GET
                var responseTask = client.GetAsync(client.BaseAddress + studentId.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<StudentInfo>();
                    readTask.Wait();
                    studentData = readTask.Result;
                }
            }
            return View("CreateEntry", studentData);
        }
        #endregion

        #region DeleteEntry
        public IActionResult DeleteEntry(int studentId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7240/api/StudentDataAPI/DeleteEntry?studentId=");
                //HTTP GET
                var deleteTask = client.DeleteAsync(client.BaseAddress + studentId.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ReadDetails");
                }
            }
            return RedirectToAction("ReadDetails");
        }
        #endregion

    }
}
