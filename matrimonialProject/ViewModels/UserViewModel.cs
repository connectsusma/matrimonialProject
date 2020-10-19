using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matrimonialProject.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
         public int Age { get; set; }

        private DateAndTime birthDate;

        public DateAndTime GetBirthDate()
        {
            return birthDate;
        }

        public void SetBirthDate(DateAndTime value)
        {
            birthDate = value;
        }

        public Gender Gender { get; set; }
        public string Caste { get; set; }
        public string Occupation { get; set; }
        public Double Salary { get; set; }

        public MaritialStatus MaritialStatus { get; set; }

        public Religion Religion { get; set; }
        public string ImagePath { get; set; }

    }
}
