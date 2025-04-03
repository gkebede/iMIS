using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Student
     {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string MemberId { get; set; } = Guid.NewGuid().ToString();
        public DateTime BirthDay { get; set; }
        public int PhoneNumber { get; set; }
        public required string Email { get; set; }
        public string? FormFile { get; set; }

        [Display(Name = "Preferred pronoun")]
        public PreferredPronoun? Pronoun { get; set; }
       [Display(Name = "Status At The Time Of Application")]
        public Status? Status { get; set; }
        [Display(Name = "University you are attending")]
        public string UniversityAttending { get; set; }

        public Student()
        {
        }


    }

    public enum PreferredPronoun
    {
        He,
        She,
        They,
        Other
    }

    public enum Status
    {
        BSW1styearStudent,
        BSW2ndYearStudent,
        BSW3rdYearStudent,
        BSW4thYearStudent,
        AdvancedStandingMSWStudent,
        MSWStudent1stYear,
        MSWStudent2ndYear,
        MSWStudent3rdYear,
        PhDStudent,
        Other
    }
}
