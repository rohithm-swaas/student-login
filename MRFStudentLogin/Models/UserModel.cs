using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRFStudentLogin.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string positionName { get; set; }
        public int VacancyFor { get; set; }
        public string Vacancy_for { get; set; }
        public string Territotry { get; set; }



    }
}