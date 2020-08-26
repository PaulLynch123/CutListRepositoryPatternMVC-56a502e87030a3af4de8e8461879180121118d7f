using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Required(ErrorMessage = "Please select a Project 123")]
        public int ProjectId { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }             
        [Required]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }              //can become a list of clients

        [Required(ErrorMessage = "Please select a lead engineer")]
        [Display(Name ="Lead Engineer")]
        public string LeadEngineerString { get; set; }
        //public ApplicationUser LeadEngineer { get; set; }   //create ApplicationUser from IdentityUser


        //navigation
        //public int WON { get; set; }
        //public ICollection<WorkOrder> WorkOrders { get; set; }
        
        
    }
}
