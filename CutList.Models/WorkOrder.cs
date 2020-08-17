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
        public int WorkOrderId { get; set; }        //this will auto increment???

        //[Required]
        //public VersionDate RequiredDate { get; set; }
        ////Use this code in the controller to ensure date is after todays date
        // if (jobApplication.DOB > DateTime.Now)
        //ModelState.AddModelError(nameof(jobApplication.DOB), "Date of Birth cannot be in the future");

        [Display(Name = "Approval Status")]
        public string ApprovalStatus { get; set; }          //if anything changes must go to unapproved / pending

        [Display(Name = "Approval Engineer")]
        public string ApprovalEngineerString { get; set; }
        //public ApplicationUser ApprovalEngineer { get; set; }

        [Display(Name = "Checked by")]
        public string CheckedByEngineerString { get; set; }
        //public ApplicationUser CheckedByEngineer { get; set; }

        [Display(Name = "Job Notes")]
        public string JobNotes { get; set; }

        [Display(Name = "Heat Sink")]
        public bool HeatSink { get; set; }

        [Display(Name = "Silver Label")]
        public SilverLabel SilverLabel { get; set; }      //list to choose from with other as an option

        [Display(Name = "Phase Label")]
        public PhaseLabel PhaseLabel { get; set; }          //this option populates colours of phase wiring (ENUM)

        [Display(Name = "Special Phase")]
        public bool SpecialPhase { get; set; }

        //set automatically by Phase Label but if special then set by data entry selection
        [Display(Name = "Neutral Colour")]
        public WireColours Neutral { get; set; }        //ENUM
        [Display(Name = "L1 Colour")]
        public WireColours L1 { get; set; }             //ENUM
        [Display(Name = "L2 Colour")]
        public WireColours L2 { get; set; }             //ENUM
        [Display(Name = "L3 Colour")]
        public WireColours L3 { get; set; }             //ENUM
        [Display(Name = "Earth Colour")]
        public WireColours Earth { get; set; }          //ENUM

        [Display(Name = "Tinned")]
        public bool Tinned { get; set; }

        [Display(Name = "Total Bar Amps")]
        public int BarAmps { get; set; }

        [Display(Name = "Section Breaker Amps")]
        public AmpValues AmpValue { get; set; }        //ENUM


        //---------------Foreign Keys and Navigation--------------------
        [Required]
        public int ProjectId { get; set; }
        //[ForeignKey("ProjectId")]
        public Project Project { get; set; }

        //PartOrder
        //public int OrderNo { get; set; }
        //[ForeignKey("OrderNo")]
        public ICollection<PartOrder> PartOrders { get; set; }

        public ICollection<VersionDate> VersionDates { get; set; }

    }
}
