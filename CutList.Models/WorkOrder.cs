using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using static CutList.Utility.CutListEnums;

namespace CutList.Models
{
    public class WorkOrder
    {
        [Key]
        public int WON { get; set; }        //this will auto increment???

        [Required]
        public VersionDate RequiredDate { get; set; }
        ////Use this code in the controller to ensure date is after todays date
        // if (jobApplication.DOB > DateTime.Now)
        //ModelState.AddModelError(nameof(jobApplication.DOB), "Date of Birth cannot be in the future");


        public bool Approved { get; set; }          //if anything changes must go to unapproved again
        public ApplicationUser ApprovalEngineer { get; set; }
        public ApplicationUser CheckedByEngineer { get; set; }

        public string JobNotes { get; set; }

        public bool HeatSink { get; set; }

        public SilverLabel SilverLabel { get; set; }      //list to choose from with other as an option

        public PhaseLabel PhaseLabel { get; set; }          //this option populates colours of phase wiring (ENUM)

        public bool SpecialPhase { get; set; }

        //set automatically by Phase Label but if special then set by data entry selection
        public WireColours Neutral { get; set; }        //ENUM
        public WireColours L1 { get; set; }             //ENUM
        public WireColours L2 { get; set; }             //ENUM
        public WireColours L3 { get; set; }             //ENUM
        public WireColours Earth { get; set; }          //ENUM

        public bool Tinned { get; set; }

        public int BarAmps { get; set; }

        public AmpValues AmpValue { get; set; }        //ENUM


        //---------------Foreign Keys and Navigation--------------------
        public int ProjectId;
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        //PartOrder
        public int OrderNo { get; set; }
        [ForeignKey("OrderNo")]
        public ICollection<PartOrder> PartOrder { get; set; }

    }
}
