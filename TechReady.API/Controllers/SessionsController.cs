using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using TechReady.API.Models;

namespace TechReady.API.Controllers
{
    public class SessionsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Session> Get()
        {
            List<Session> sessions = new List<Session>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Sessions"].ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Sessions", conn))
                {
                    DataSet ds = new DataSet();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(ds);

                    sessions = (from DataRow row in ds.Tables[0].Rows

                                select new Session
                                {
                                    Day = row["Day"].ToString(),
                                    Date = DateTime.Parse(row["Date"].ToString()),
                                    StartTime = getDate(row["Date"].ToString(), row["Start Time"].ToString()),
                                    EndTime = getDate(row["Date"].ToString(), row["End Time"].ToString()),
                                    Code = row["Code"].ToString(),
                                    Title = row["Title"].ToString(),
                                    Room = row["Room"].ToString(),
                                    PrimarySpeaker = row["Primary Speaker s"].ToString(),
                                    PrimaryTrack = row["Primary Track"].ToString(),
                                    VirtualTrack = row["Virtual Track"].ToString()
                                }).ToList();
                }
            }

            return sessions;
        }

        private DateTime getDate(string sessionDate, string startTime)
        {
            DateTime myDate;

            var tempDate = DateTime.Parse(sessionDate);

            myDate = DateTime.Parse(string.Format("{0}/{1}/{2}, {3}", tempDate.Month, tempDate.Day, tempDate.Year, startTime));

            return myDate;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}