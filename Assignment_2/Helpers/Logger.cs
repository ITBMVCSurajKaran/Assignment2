using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Assignment_2.Models;

namespace Assignment_2.Helpers
{
    public class Logger
    {

        public void addEvent(string user_id, string eventType)
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MyLearnDBEntities"].ToString());
            var dbcommand = new SqlCommand("insert into app_events (user_id, event_date, event_type) values (@user_id, @event_date, @event_type)", dbcon);
           // dbcommand.Parameters.AddWithValue("@Id", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
            dbcommand.Parameters.AddWithValue("@user_id", SqlDbType.UniqueIdentifier).Value = user_id;
            dbcommand.Parameters.AddWithValue("@event_date", SqlDbType.DateTime).Value = DateTime.Now;
            dbcommand.Parameters.AddWithValue("@event_type", SqlDbType.VarChar).Value = eventType;
            dbcon.Open();
            var result = dbcommand.ExecuteNonQuery();
            dbcon.Close();
            return;
        }

        public List<AppEvent> getEvents()
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["userdata"].ToString());
            var dbcommand = new SqlCommand();
            dbcommand.Connection = dbcon;
            dbcommand.CommandText = "select * from app_events";
            dbcon.Open();
            var reader = dbcommand.ExecuteReader();
            var model = new List<AppEvent>();
            while (reader.Read())
            {
                var appEvent = new AppEvent();
                appEvent.user_id = reader["user_id"].ToString();
                appEvent.event_date = reader["event_date"].ToString();
                appEvent.event_type = reader["event_type"].ToString();
                model.Add(appEvent);
            }
            dbcon.Close();
            return model;
        }

        public List<AppEvent> getEventsById(string user_id)
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["userdata"].ToString());
            var dbcommand = new SqlCommand();
            dbcommand.Connection = dbcon;
            dbcommand.CommandText = "select * from app_events where user_id = @user_id";
            dbcommand.Parameters.AddWithValue("@user_id", SqlDbType.UniqueIdentifier).Value = user_id;
            dbcon.Open();
            var reader = dbcommand.ExecuteReader();
            var model = new List<AppEvent>();
            while (reader.Read())
            {
                var appEvent = new AppEvent();
                appEvent.user_id = reader["user_id"].ToString();
                appEvent.event_date = reader["event_date"].ToString();
                appEvent.event_type = reader["event_type"].ToString();
                model.Add(appEvent);
            }
            dbcon.Close();
            return model;
        }
    }
}