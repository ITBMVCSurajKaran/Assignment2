﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_2.Models
{
    public class StudentViewModel
    {
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }

        public List<CourseDetail> StudentCourseDetail { get; set; }

        public List<QuizDetail> StudentQuizDetails { get; set; }
        public int MyProperty { get; set; }
        public UserPreferenceMaster StudentPreferenceMaster { get; set; }
        public List<GroupDetail> StudentGroupdetails { get; set; }     
        public StudentDetailModel StudentDetailModel { get; set; }
        public List<Announcement> Announcement { get; set; }
        public UserPreferenceMaster UserPrefrence { get; set; }
        public List<GroupViewModel> Get_Student_All_Groups { get; set; }
        public List<GroupMaster> Get_All_Groups { get; set; }

    }
}