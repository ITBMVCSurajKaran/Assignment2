﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Assignment_2.Helpers
{
    public class CommonHelpers
    {
        /// <summary>
        /// Add new Long data
        /// </summary>
        /// <param name="_userId"></param>
        public void Add_Log(string _userId)
        {
            UserLog userlog = new UserLog();
            userlog.Id = Guid.NewGuid();
            userlog.UserID = _userId;
            userlog.Login = null;
            userlog.Quiz = null;

            using (var db = new MyLearnDBEntities())
            {
                db.UserLogs.Add(userlog);
                db.SaveChanges();
            }
        }

        public void AddLog_Login(string _userId)
        {
            using(var db = new MyLearnDBEntities())
            {
                var _result = db.UserLogs.SingleOrDefault(b => b.UserID == _userId);
                if(_result != null)
                {
                    _result.Login = DateTime.Now;
                    db.SaveChanges();
                }
            }
        }

        public void AddLog_Quiz(string _userId)
        {
            using (var db = new MyLearnDBEntities())
            {
                var _result = db.UserLogs.SingleOrDefault(b => b.UserID == _userId);
                if (_result != null)
                {
                    _result.Quiz = DateTime.Now;
                    db.SaveChanges();
                }
            }
        }

    }
}