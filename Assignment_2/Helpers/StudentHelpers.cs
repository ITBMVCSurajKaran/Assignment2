using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Assignment_2.Helpers
{
    public class StudentHelpers
    {
        /// <summary>
        /// Save Student quiz result in database
        /// </summary>
        /// <param name="result">quiz result</param>
        /// <returns>true/false</returns>
        public bool SaveQuizResult(int result,int TotalMarks)
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

    }
}