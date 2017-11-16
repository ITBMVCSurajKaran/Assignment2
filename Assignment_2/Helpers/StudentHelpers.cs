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

                using (var db = new MyLearnDBEntitiess())
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
        /// Update user into database
        /// </summary>
        /// <param name="result">Update user data</param>
        /// <returns>true/false</returns>
        //public bool UpdateUser(string UserName,string Email, int PhoneNumber )
        //{
        //    try
        //    {
        //        AspNetUser info = new AspNetUser();
        //        info.UserName = UserName;
        //        info.Email = Email;
        //        info.PhoneNumber = int.Parse(PhoneNumber.ToString());
        //        using (var db = new MyLearnDBEntities())
        //        {
        //            db.A.Add(UpdateUser);
        //            db.SaveChanges();
        //        }

        //        return true;

        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}

        /// <summary>
        /// call when student add course
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        public bool Add_Student_Course()
        {
            try
            {
                var courseId = "3E851245-056E-40BA-8767-5C662F0D0C86";
                var UserID = Guid.Parse(HttpContext.Current.User.Identity.GetUserId());
                using (var db = new MyLearnDBEntitiess())
                {
                    var existUser = db.CourseDetails.SingleOrDefault(x => x.UserId == UserID);
                    if (existUser.Id != null)
                    {
                        return true;
                    }
                }

                CourseDetail detail = new CourseDetail();

                detail.Id = Guid.NewGuid();
                detail.UserId = UserID;
                detail.DateAdded = DateTime.Now;
                detail.CourseId = Guid.Parse(courseId);
                detail.ProgressStatus = 0;
                detail.StatusTotal = 0;
                detail.LastAccessed = DateTime.Now;
                detail.DateCreated = DateTime.Now;
                detail.DateEdited = DateTime.Now;
                detail.IsEnable = true;
                detail.IsActive = true;

                using (var db = new MyLearnDBEntitiess())
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

                using (var db = new MyLearnDBEntitiess())
                {
                    var _result = db.CourseDetails.SingleOrDefault(b => b.Id == courseDetailId);
                    if (_result != null)
                    {
                        if (status > _result.ProgressStatus)
                        {
                            _result.ProgressStatus = status;
                        }
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

                using (var db = new MyLearnDBEntitiess())
                {
                    var _result = db.CourseDetails.SingleOrDefault(b => b.CourseId == courseDetailId && b.UserId == UserId);
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
                using (var db = new MyLearnDBEntitiess())
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
                using (var db = new MyLearnDBEntitiess())
                {
                    var UserId = Guid.Parse(HttpContext.Current.User.Identity.GetUserId());
                    student.StudentId = UserId;
                    student.StudentName = HttpContext.Current.User.Identity.Name;
                    student.StudentCourseDetail = db.CourseDetails.Where(b => b.UserId == UserId).ToList();
                    student.StudentQuizDetails = db.QuizDetails.Where(b => b.UserId == UserId).ToList().OrderByDescending(b => b.DateCreated).ToList();
                    student.StudentPreferenceMaster = db.UserPreferenceMasters.SingleOrDefault(b => b.UserID == UserId);
                    student.StudentGroupdetails = db.GroupDetails.Where(b => b.UserId == UserId).ToList();
                    student.Announcement = db.Announcements.Where(b => b.UserType == "Student" && b.IsEnable == true).ToList().OrderByDescending(x => x.DateCreated).ToList();
                    student.Get_Student_All_Groups = Get_Student_All_Groups();
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

        public UserPreferenceMaster UserPrefrence(string user_id)
        {
            var UserId = Guid.Parse(HttpContext.Current.User.Identity.GetUserId());
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["_MyLearnDBEntities"].ToString());
            var dbcommand = new SqlCommand();
            dbcommand.Connection = dbcon;
            dbcommand.CommandText = "select * from UserPreferenceMaster where UserID = @user_id";
            dbcommand.Parameters.AddWithValue("@user_id", SqlDbType.UniqueIdentifier).Value = user_id;
            dbcon.Open();
            var reader = dbcommand.ExecuteReader();
            var model = new UserPreferenceMaster();
            while (reader.Read())
            {
                var UserPrefrence = new UserPreferenceMaster();
                model.ThemeColor = reader["ThemeColor"].ToString();
                model.Font = reader["Font"].ToString();
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

        //public List<QuizDetail> GetQuizDetailsById(string user_id)
        //{
        //    var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["_MyLearnDBEntities"].ToString());
        //    var dbcommand = new SqlCommand();
        //    dbcommand.Connection = dbcon;
        //    dbcommand.CommandText = "select * from QuizDetail where UserId = @user_id";
        //    dbcon.Open();
        //    var model = new List<QuizDetail>();
        //    var reader = dbcommand.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        var details = new QuizDetail();
        //        details.Result = int.Parse(reader["Result"].ToString());
        //        details.TotalMarks = int.Parse(reader["TotalMarks"].ToString());

        //    }
        //    dbcon.Close();
        //    return model;
        //}

        public void UpdateUser(string user, string email, int number, string user_id)
        {
            using (var db = new MyLearnDBEntitiess())
            {
                var Ids = Guid.Parse(user_id);
                AspNetUser aspNetUser = new AspNetUser();
                aspNetUser = db.AspNetUsers.SingleOrDefault(x => x.Id == user_id);

                aspNetUser.UserName = user;
                aspNetUser.Email = email;
                aspNetUser.PhoneNumber = number.ToString();
                db.SaveChanges();
            }


            return;
        }

        public bool SaveUserPreff(string Color)
        {
            try
            {
                using (var db = new MyLearnDBEntitiess())
                {
                    var Id = Guid.Parse(HttpContext.Current.User.Identity.GetUserId());
                    var user = db.UserPreferenceMasters.SingleOrDefault(x => x.UserID == Id);
                    user.ThemeColor = Color;
                    db.SaveChanges();

                    return true;

                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// Get all Groups 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Join group for students
        /// </summary>
        /// <param name="GroupID"></param>
        public void JoinStudentGroup(Guid GroupID)
        {
            using (var db = new MyLearnDBEntitiess())
            {
                var UserId = Guid.Parse(HttpContext.Current.User.Identity.GetUserId());
                var x = db.GroupDetails.SingleOrDefault(v => v.UserId == UserId && v.GroupId == GroupID);
                if (x == null)
                {
                    GroupDetail group = new GroupDetail();
                    group.Id = Guid.NewGuid();
                    group.UserId = UserId;
                    group.GroupId = GroupID;
                    group.DateCreated = DateTime.Now;
                    group.DateEdited = DateTime.Now;
                    group.IsEnable = true;
                    group.IsActive = true;

                    db.GroupDetails.Add(group);
                    db.SaveChanges();
                }
                
            }

        }


        /// <summary>
        /// Get those groups where stduent joined already 
        /// </summary>
        /// <returns></returns>
        public List<GroupViewModel> Get_Student_All_Groups()
        {
            List<GroupViewModel> _return = new List<GroupViewModel>();
            try
            {
                var UserId = Guid.Parse(HttpContext.Current.User.Identity.GetUserId());

                using (var db = new MyLearnDBEntitiess())
                {
                    var a = (from x in db.GroupDetails
                             join y in db.GroupMasters on x.GroupId equals y.Id
                             where x.UserId == UserId
                             select new
                             {
                                 Id = x.Id,
                                 GroupName = y.GroupName
                             }).ToList();

                    foreach (var item in a)
                    {
                        GroupViewModel group = new GroupViewModel();
                        group.Id = item.Id;
                        group.GroupName = item.GroupName;
                        _return.Add(group);
                    }

                }
                return _return;
            }
            catch (Exception)
            {
                return _return;
            }

        }

    }
}