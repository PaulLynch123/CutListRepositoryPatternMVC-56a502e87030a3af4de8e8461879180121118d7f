using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CutList.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Display(Name = "Task Name")]
        public string TaskName { get; set; }

        [Display(Name ="Employee who comleted task")]
        public string EmployeeChoosen { get; set; }
        //public ApplicationUser EmployeeChoosen { get; set; }

        //auto
        //public VersionDate RequiredDate { get; set; }
        [Display(Name = "Employee who was signed in")]
        public string SignedIn { get; set; }
        //public ApplicationUser SignedIn { get; set; }   //create ApplicationUser from IdentityUser
        //auto
        [Display(Name = "Date/Time box was checked")]
        public DateTime CheckedDateTime { get; set; }


    }
}
