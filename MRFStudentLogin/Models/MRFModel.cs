using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRFStudentLogin.Models
{
    public class MRFModel
    {
        public int id { get; set; }
        public string PositionName { get; set; }
        public int Createdby { get; set; }
        public string Created_by { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime PositionFilledBefore { get; set; }
        public int VacancyFor { get; set; }
        public string Vacancy_for { get; set; }
        public int VacancyType { get; set; }
        public string Vacancy_Type { get; set; }
        public string Territotry { get; set; }
        public string DivisionName { get; set; }
        public int MinExp { get; set; }
        public int MaxExp { get; set; }
        public int MinCTCPerAnnum { get; set; }
        public int MaxCTCPerAnnum { get; set; }
        public string AdditionalRequirement { get; set; }

        public string Sta_tus { get; set; }
        public int Status { get; set; }
    }
}