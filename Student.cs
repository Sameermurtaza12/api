using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;

namespace Assignment5Task1
{
    public class Student
    {
        public string student_name { get; set; }
        public string student_address { get; set; }
        public string student_contact { get; set; }
        public int student_age { get; set; }
        public int student_id { get; set; }

        [WebMethod]
        public List<Student> GetStudentList()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            List<Student> studenttList = new List<Student>();
            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("spGetStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Student student = new Student();
                    student.student_id = Convert.ToInt32(rdr["student_id"]);
                    student.student_age = Convert.ToInt32(rdr["student_age"]);
                    student.student_contact = rdr["student_contact"].ToString();
                    student.student_address = rdr["student_address"].ToString();
                    student.student_name = rdr["student_name"].ToString();
                    studenttList.Add(student);
                }

            }
            return studenttList;

        }
      
    }
}