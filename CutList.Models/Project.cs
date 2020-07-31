using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CutList.Models
{
    public class Project
    {
        //need to get Project ID from another database
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectId { get; set; }

        [Required]
        public string ProjectName { get; set; }             
        [Required]
        public string ClientName { get; set; }              //can become a list of clients
        [Required(ErrorMessage = "Please select a lead engineer")]
        public ApplicationUser LeadEngineer { get; set; }   //create ApplicationUser from IdentityUser


        //navigation
        public int WON { get; set; }
        public ICollection<WorkOrder> WorkOrder { get; set; }
        

    }
}
