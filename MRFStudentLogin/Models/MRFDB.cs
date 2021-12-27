using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRFStudentLogin.Models
{
    public class MRFDB
    {
         string cs = ConfigurationManager.ConnectionStrings["SQLMVCConnectionString"].ConnectionString;
        public List<MRFModel> ListAll()
        {
            List<MRFModel> lst = new List<MRFModel>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Login", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new MRFModel
                    {
                        id = Convert.ToInt32(rdr["id"]),
                        PositionName = rdr["PositionName"].ToString(),
                        Created_by = rdr["CreatedBy"].ToString(),
                        CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]),
                        PositionFilledBefore = Convert.ToDateTime(rdr["Positionfilledbefore"]),
                        Vacancy_for = rdr["VacancyName"].ToString(),
                        Vacancy_Type = rdr["VacancyType"].ToString(),
                        Territotry = rdr["Territotry"].ToString(),
                        DivisionName = rdr["DivisionName"].ToString(),
                        MinExp = Convert.ToInt32(rdr["MinExp"]),
                        MaxExp = Convert.ToInt32(rdr["MaxExp"]),
                        MinCTCPerAnnum = Convert.ToInt32(rdr["MinCTCperAnnum"]),
                        MaxCTCPerAnnum = Convert.ToInt32(rdr["MaxCTCperAnnum"]),
                        AdditionalRequirement = rdr["AdditionalRequirement"].ToString(),
                        Status = Convert.ToInt32(rdr["Status"]),
                        Sta_tus = Convert.ToString(rdr["StatusName"])

                    });
                }
                return lst;
            }
        }



        public int Add(MRFModel MRF)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("insertDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", MRF.id);
                com.Parameters.AddWithValue("@PositionName", MRF.PositionName);
                com.Parameters.AddWithValue("@CreatedBy", MRF.Created_by);
                com.Parameters.AddWithValue("@CreatedDate", MRF.CreatedDate);
                com.Parameters.AddWithValue("@PositionFilledBefore", MRF.PositionFilledBefore);
                com.Parameters.AddWithValue("@VacancyFor", MRF.VacancyFor);
                com.Parameters.AddWithValue("@VacancyType", MRF.VacancyType);
                com.Parameters.AddWithValue("@Territotry", MRF.Territotry);
                com.Parameters.AddWithValue("@DivisionName", MRF.DivisionName);
                com.Parameters.AddWithValue("@MinExp", MRF.MinExp);
                com.Parameters.AddWithValue("@MaxExp", MRF.MaxExp);
                com.Parameters.AddWithValue("@MinCTCPerAnnum", MRF.MinCTCPerAnnum);
                com.Parameters.AddWithValue("@MaxCTCPerAnnum", MRF.MaxCTCPerAnnum);
                com.Parameters.AddWithValue("@AdditionalRequirement", MRF.AdditionalRequirement);
                com.Parameters.AddWithValue("@Status", MRF.Status);
                com.Parameters.AddWithValue("@username", MRF.Created_by);

                i = com.ExecuteNonQuery();
            }
            return i;
        }

       

    }
} 
