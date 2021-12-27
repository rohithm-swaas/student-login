using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRFStudentLogin.Models
{
    public class UserDB
    {
        string cs = ConfigurationManager.ConnectionStrings["SQLMVCConnectionString"].ConnectionString;
        public List<UserModel> ListAll()
        {
            List<UserModel> lst = new List<UserModel>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("sp_getdetails", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new UserModel
                    {
                        id = Convert.ToInt32(rdr["id"]),
                        username = Convert.ToString(rdr["username"]),
                        positionName = Convert.ToString(rdr["positionName"]),
                        Vacancy_for = Convert.ToString(rdr["vacancyName"]),
                        Territotry = Convert.ToString(rdr["Territotry"])
                        

                    });
                }
                return lst;
            }
        }
            public int Update(MRFModel emp)
            {
                int i;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("Sp_Update", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@id", emp.id);
                    com.Parameters.AddWithValue("@positionName", emp.PositionName);
                    com.Parameters.AddWithValue("@CreatedDate", emp.CreatedDate);
                    com.Parameters.AddWithValue("@PositionFilledBefore", emp.PositionFilledBefore);
                    com.Parameters.AddWithValue("@VacancyFor", emp.VacancyFor);
                    com.Parameters.AddWithValue("@VacancyType", emp.VacancyType);
                    com.Parameters.AddWithValue("@Territotry", emp.Territotry);
                    com.Parameters.AddWithValue("@DivisionName", emp.DivisionName);
                    com.Parameters.AddWithValue("@MinExp", emp.MinExp);
                    com.Parameters.AddWithValue("@MaxExp", emp.MaxExp);
                    com.Parameters.AddWithValue("@MinCTCPerAnnum", emp.MinCTCPerAnnum);
                    com.Parameters.AddWithValue("@MaxCTCPerAnnum", emp.MaxCTCPerAnnum);
                    com.Parameters.AddWithValue("@AdditionalRequirement", emp.AdditionalRequirement);
                  

                    i = com.ExecuteNonQuery();
                }
                return i;
            }

         
            public int Delete(int id)
            {
                int i;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("sp_delete", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@id", id);
                    i = com.ExecuteNonQuery();
                }
                return i;
            }
        public List<MRFModel> prefilling()
        {
            List<MRFModel> lst = new List<MRFModel>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("sp_getdetails", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new MRFModel
                    {
                        id = Convert.ToInt32(rdr["id"]),
                        PositionName = Convert.ToString(rdr["positionName"]),
                        Created_by = Convert.ToString(rdr["CreatedBy"]),
                        CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]),
                        PositionFilledBefore = Convert.ToDateTime(rdr["Positionfilledbefore"]),
                        VacancyFor = Convert.ToInt32(rdr["VacancyFor"]),
                        VacancyType = Convert.ToInt32(rdr["vacancyType"]),
                        Territotry = Convert.ToString(rdr["Territotry"]),
                        DivisionName = Convert.ToString(rdr["DivisionName"]),
                        MinExp = Convert.ToInt32(rdr["MinExp"]),
                        MaxExp = Convert.ToInt32(rdr["MaxExp"]),
                        MinCTCPerAnnum = Convert.ToInt32(rdr["MinCTCPerAnnum"]),
                        MaxCTCPerAnnum = Convert.ToInt32(rdr["MaxCTCPerAnnum"]),
                        AdditionalRequirement = Convert.ToString(rdr["AdditionalRequirement"])
                  

                    });
                }
                return lst;
            }
        }

    }
}