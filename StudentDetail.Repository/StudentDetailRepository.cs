using Microsoft.VisualBasic;
using StudentDetail.Core.IRepository;
using StudentDetail.Core.Model;
using StudentDetail.Entity;

namespace StudentDetail.Repository
{
    public class StudentDetailRepository: IStudentDetailRepository
    { 
         public Student_Data_ManagementContext context;
    public StudentDetailRepository(Student_Data_ManagementContext context)
    {
        this.context = context;
    }
        #region CreateEntry and updateDetails
        public void CreateMethod(StudentInfo studentInfo)
        {
            using (Student_Data_ManagementContext entity = new Student_Data_ManagementContext())
            {
                if (studentInfo != null)
                {
                    if (studentInfo.StudentId == 0)
                    {
                        Student_Info info = new Student_Info();
                        info.Student_FirstName = studentInfo.StudentFirstName;
                        info.Student_LastName = studentInfo.StudentLastName;
                        info.Student_Gender = studentInfo.StudentGender;
                        info.Student_Location = studentInfo.StudentLocation;
                        info.Student_Age = studentInfo.StudentAge;
                        info.Student_Department = studentInfo.StudentDepartment;
                        info.Student_Class = studentInfo.StudentClass;
                        info.Year_Of_Joining = studentInfo.YearOfJoining;
                        entity.Add(info);
                        entity.SaveChanges();
                    }
                    else
                    {
                        var info = entity.Student_Info.Where(i => i.Student_Id == studentInfo.StudentId).SingleOrDefault();
                        if (info != null)
                        {
                            info.Student_FirstName = studentInfo.StudentFirstName;
                            info.Student_LastName = studentInfo.StudentLastName;
                            info.Student_Gender = studentInfo.StudentGender;
                            info.Student_Location = studentInfo.StudentLocation;
                            info.Student_Age = studentInfo.StudentAge;
                            info.Student_Department = studentInfo.StudentDepartment;
                            info.Student_Class = studentInfo.StudentClass;
                            info.Year_Of_Joining =studentInfo.YearOfJoining;
                            info.Updated_Time_Stamp = DateTime.Now;
                            entity.SaveChanges();
                        }
                    }
                }
            }
        }
        #endregion

        #region ReadDetails
        public List<StudentInfo> ReadMethod()
        {
            using (Student_Data_ManagementContext entities = new Student_Data_ManagementContext())
            {
                List<StudentInfo> studentInfos = new List<StudentInfo>();
                var details = entities.Student_Info.Where(i => i.Is_Deleted == false).ToList();
                foreach (var info in details)
                {
                    StudentInfo data = new StudentInfo();
                    data.StudentId = info.Student_Id;
                    data.StudentFirstName = info.Student_FirstName;
                    data.StudentLastName = info.Student_LastName;
                    data.StudentGender = info.Student_Gender;
                    if (info.Student_Location != null)
                    {
                        data.StudentLocation = info.Student_Location;
                    }
                    else
                    {
                        data.StudentLocation = "-";
                    }
                    data.StudentDepartment = info.Student_Department;
                    data.StudentClass = info.Student_Class;
                    data.StudentAge = info.Student_Age;
                    if (info.Student_Location != null)
                    {
                        data.YearOfJoining = info.Year_Of_Joining;
                    }
                    else
                    {
                        data.YearOfJoining = "-";
                    }
                    studentInfos.Add(data);
                }
                return studentInfos;
            }
        }
        #endregion

        #region Assign Details
        //get details according to id 
        public StudentInfo UpdateMethod(int studentId)
        {
            using (Student_Data_ManagementContext entity = new Student_Data_ManagementContext())
            {
                var info = entity.Student_Info.Where(i => i.Student_Id == studentId).SingleOrDefault();
                StudentInfo data = new StudentInfo();
                data.StudentId = info.Student_Id;
                data.StudentFirstName = info.Student_FirstName;
                data.StudentLastName = info.Student_LastName;
                data.StudentGender = info.Student_Gender;
                data.StudentLocation = info.Student_Location;
                data.StudentDepartment = info.Student_Department;
                data.StudentClass = info.Student_Class;
                data.StudentAge = info.Student_Age;
                data.YearOfJoining = info.Year_Of_Joining;
                return data;
            }
        }
        #endregion

        #region DeleteDetails
        public void DeleteMethod(int studentId)
        {
            using (Student_Data_ManagementContext entity = new Student_Data_ManagementContext())
            {
                var info = entity.Student_Info.Where(i => i.Student_Id == studentId).SingleOrDefault();
                if (info != null)
                {
                    info.Is_Deleted = true;
                    entity.SaveChanges();
                }
            }
        }
        #endregion
    }
}