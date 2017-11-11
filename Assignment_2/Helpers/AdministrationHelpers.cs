using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment_2.Models;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Assignment_2.Helpers
{
    public class AdministrationHelpers
    {
        private ApplicationDbContext context;

        public AdministrationHelpers()
        {
            context = new ApplicationDbContext();
        }

        public List<ApplicationUser> GetAllStudents()
        {
            List<ApplicationUser> students = new List<ApplicationUser>();
            try
            {
                var role = context.Roles.SingleOrDefault(m => m.Name == "Student");
                students = context.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id)).ToList();
            }
            catch (Exception)
            {


            }
            return students;
        }

        public StudentViewModel Get_Student_Report(Guid _studentId)
        {
            StudentViewModel student = new StudentViewModel();
            try
            {
                using (var db = new MyLearnDBEntities())
                {

                    student.StudentId = _studentId;
                    student.StudentName = HttpContext.Current.User.Identity.Name;
                    student.StudentCourseDetail = db.CourseDetails.Where(b => b.UserId == _studentId).ToList();
                    student.StudentQuizDetails = db.QuizDetails.Where(b => b.UserId == _studentId).ToList();
                    student.StudentPreferenceMaster = db.UserPreferenceMasters.SingleOrDefault(b => b.UserID == _studentId);
                    student.StudentGroupdetails = db.GroupDetails.Where(b => b.UserId == _studentId).ToList();
                }
            }
            catch (Exception)
            {


            }
            return student;
        }

        public List<GroupMaster> Get_All_Groups()
        {
            List<GroupMaster> list = new List<GroupMaster>();
            try
            {
                using (var db = new MyLearnDBEntities())
                {
                    list = db.GroupMasters.ToList();
                }
            }
            catch (Exception)
            {


            }
            return list;
        }
        public StudentDetailModel get_Student_ById(string user_id)
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["_MyLearnDBEntities"].ToString());
            var dbcommand = new SqlCommand();
            dbcommand.Connection = dbcon;
            dbcommand.CommandText = "select * from AspNetUsers where id = @user_id";
            dbcommand.Parameters.AddWithValue("@user_id", SqlDbType.UniqueIdentifier).Value = user_id;
            dbcon.Open();
            var reader = dbcommand.ExecuteReader();
            var model = new StudentDetailModel();
            while (reader.Read())
            {
                model.StudentId = reader["Id"].ToString();
                model.StudentName = reader["UserName"].ToString();
            }
            dbcon.Close();
            return model;
        }

        //public CourseDetail getdata(Guid ids, int status)
        //{

        //    CourseDetail cd = new CourseDetail();
        //    using (var db = new MyLearnDBEntities())
        //    {

        //        var a = (from x in db.CourseDetails
        //                 join y in db.CourseMasters on x.UserId equals y.Id
        //                 where x.Id == ids
        //                 && x.ProgressStatus == status
        //                 select new
        //                 {
        //                     idm = x.Id,
        //                     status = x.ProgressStatus
        //                 }).ToList().Where(x => x.idm == Guid.Empty).Take(10).Sum(10);
        //    }
        //    return cd;
        //}
    }
}