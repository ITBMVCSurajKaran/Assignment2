using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Assignment_2.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Assignment_2.Helpers
{
    public class StudentHelpers
    {
        /// <summary>
        /// Save Student quiz result in database
        /// </summary>
        /// <param name="result">quiz result</param>
        /// <returns>true/false</returns>
        public bool SaveQuizResult(int result, int TotalMarks)
        {
            try
            {
                QuizDetail quizDetail = new QuizDetail();
                quizDetail.Id = Guid.NewGuid();
                quizDetail.UserId = Guid.Parse(HttpContext.Current.User.Identity.GetUserId());
                quizDetail.QuizId = Guid.NewGuid();
                quizDetail.Result = result;
                quizDetail.TotalMarks = TotalMarks;
                quizDetail.Status = true;
                quizDetail.DateCreated = DateTime.Now;
                quizDetail.IsActive = true;

                using (var db = new MyLearnDBEntities())
                {
                    db.QuizDetails.Add(quizDetail);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// call when student add course
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        public bool Add_Student_Course(string userId, string CourseId)
        {
            try
            {
                CourseDetail detail = new CourseDetail();

                detail.Id = Guid.NewGuid();
                detail.UserId = Guid.Parse(HttpContext.Current.User.Identity.GetUserId());
                detail.DateAdded = DateTime.Now;
                detail.CourseId = Guid.Parse(CourseId);
                detail.ProgressStatus = 0;
                detail.StatusTotal = 0;
                detail.LastAccessed = DateTime.Now;
                detail.DateCreated = DateTime.Now;
                detail.DateEdited = DateTime.Now;
                detail.IsEnable = true;
                detail.IsActive = true;

                using (var db = new MyLearnDBEntities())
                {
                    db.CourseDetails.Add(detail);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        /// <summary>
        /// Call when course status change for student 
        /// </summary>
        /// <param name="courseDetailId"></param>
        /// <param name="status"></param>
        public bool Update_Student_Course_Status(Guid courseDetailId, int status)
        {
            try
            {
                var UserId = Guid.Parse(HttpContext.Current.User.Identity.GetUserId());

                using (var db = new MyLearnDBEntities())
                {
                    var _result = db.CourseDetails.SingleOrDefault(b => b.Id == courseDetailId);
                    if (_result != null)
                    {
                        _result.ProgressStatus = status;
                        _result.LastAccessed = DateTime.Now;
                        _result.DateEdited = DateTime.Now;

                        db.SaveChanges();


                    }
                }
                return true;

            }
            catch (Exception)
            {
                return false;

            }

        }

        /// <summary>
        /// Call when user use Editor Activity
        /// </summary>
        /// <param name="courseDetailId"></param>
        /// <returns></returns>
        public bool Update_Student_Course_Activity(Guid courseDetailId)
        {
            try
            {
                var UserId = Guid.Parse(HttpContext.Current.User.Identity.GetUserId());

                using (var db = new MyLearnDBEntities())
                {
                    var _result = db.CourseDetails.SingleOrDefault(b => b.Id == courseDetailId);
                    if (_result != null)
                    {
                        _result.StatusTotal = _result.StatusTotal + 1;
                        _result.LastAccessed = DateTime.Now;
                        _result.DateEdited = DateTime.Now;

                        db.SaveChanges();


                    }
                }
                return true;

            }
            catch (Exception)
            {
                return false;

            }

        }

        /// <summary>
        /// when student come again to course.
        /// </summary>
        /// <param name="CourseID"></param>
        /// <returns></returns>
        public CourseDetail Get_CourseDetail_ByUserID(Guid CourseID)
        {
            CourseDetail _return = new CourseDetail();
            try
            {
                var UserId = Guid.Parse(HttpContext.Current.User.Identity.GetUserId());
                using (var db = new MyLearnDBEntities())
                {
                    _return = db.CourseDetails.SingleOrDefault(b => b.CourseId == CourseID && b.UserId == UserId);
                }

                return _return;
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// Student My profile 
        /// </summary>
        /// <returns></returns>
        public StudentViewModel Get_All_data_Student()
        {
            StudentViewModel student = new StudentViewModel();
            try
            {
                using (var db = new MyLearnDBEntities())
                {
                    var UserId = Guid.Parse(HttpContext.Current.User.Identity.GetUserId());
                    student.StudentId = UserId;
                    student.StudentName = HttpContext.Current.User.Identity.Name;
                    student.StudentCourseDetail = db.CourseDetails.Where(b => b.UserId == UserId).ToList();
                    student.StudentQuizDetails = db.QuizDetails.Where(b => b.UserId == UserId).ToList();
                    student.StudentPreferenceMaster = db.UserPreferenceMasters.SingleOrDefault(b => b.UserID == UserId);
                    student.StudentGroupdetails = db.GroupDetails.Where(b => b.UserId == UserId).ToList();
                    student.Announcement = db.Announcements.Where(b => b.UserType == "Student" && b.IsEnable == true).ToList();
                }
            }
            catch (Exception)
            {


            }
            return student;
        }
        /// <summary>
        /// Get student personal details
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
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
                model.Email = reader["Email"].ToString();
                model.PhoneNumber = reader["PhoneNumber"].ToString();
            }
            dbcon.Close();
            return model;
        }
        public List<AnnouncementViewModel> Get_announcemnets()
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["_MyLearnDBEntities"].ToString());
            var dbcommand = new SqlCommand();
            dbcommand.Connection = dbcon;
            dbcommand.CommandText = "select top 2 * from Announcement";
            dbcon.Open();
            var reader = dbcommand.ExecuteReader();
            var model = new List<AnnouncementViewModel>();
            while (reader.Read())
            {
                var item = new AnnouncementViewModel();

                item.Title = reader["Title"].ToString();
                item.Message = reader["Message"].ToString();
                item.DateCreated = reader["DateCreated"].ToString();
                model.Add(item);
            }
            dbcon.Close();
            return model;
        }








        //public class DetailAnnouncment
        //{
        //    public StudentDetailModel StudentDetailModel { get; set; }
        //    public Announcement Announcement { get; set; }

        //}
    }
}