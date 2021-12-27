using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRFStudentLogin.Models
{
    public class StudentDB
    {
        string cs = ConfigurationManager.ConnectionStrings["SQLMVCConnectionString"].ConnectionString;
        public int UpdateLoginStatus(StudentModel std)
        {
            try
            {
                int i;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("user", con);
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.AddWithValue("@userid", std.userid);
                    com.Parameters.AddWithValue("@Password", std.password);
                    i = (Int32)com.ExecuteScalar();
                }
                return i;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}