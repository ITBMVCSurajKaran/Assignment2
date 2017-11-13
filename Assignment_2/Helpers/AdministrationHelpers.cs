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
                using (var db = new MyLearnDBEntitiess())
                {

                    student.StudentId = _studentId;
                    var studentdetail = db.AspNetUsers.SingleOrDefault(x => x.Id == _studentId.ToString());
                    student.StudentName = studentdetail.UserName;
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
                using (var db = new MyLearnDBEntitiess())
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

        public bool Add_Announcement(Announcement Model)
        {

            try
            {
                Model.DateCreated = DateTime.Now;
                Model.IsEnable = true;
                Model.IsActive = true;
                Model.Id = Guid.NewGuid();
                
                using(var db = new MyLearnDBEntitiess())
                {
                    db.Announcements.Add(Model);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}