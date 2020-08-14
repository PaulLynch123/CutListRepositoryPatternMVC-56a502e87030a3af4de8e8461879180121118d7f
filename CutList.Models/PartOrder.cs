using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using static CutList.Utility.CutListEnums;

namespace CutList.Models
{
    public class PartOrder
    {
        //this is the individual part for this Work Order
        [Key]
        public int PartOrderId { get; set; }

        //public int PartId { get; set; }
        [Required(ErrorMessage ="You have to enter the {0} the busbar is made from")]
        [Display(Name = "Busbar Material")]
        public Material Material{ get; set; }

        [Display(Name = "Bar Stack")]
        public Stack Stack { get; set; }

        [Required]
        [Range(1,20, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Quantity { get; set; }

        [Display(Name = "Earth Warning")]
        public bool EarthWarning { get; set; }
        [Display(Name = "Earth Size")]
        public int EarthSize { get; set; }          //must be more than Amps in WorkOrder

        [DisplayFormat(NullDisplayText = "No colour")]
        [Display(Name = "JS Cover Colour")]
        public CoverColour? JSCoverColour { get; set; }         //null is better so I can check if null later
        [DisplayFormat(NullDisplayText = "No colour")]
        [Display(Name = "JSP Cover Colour")]
        public CoverColour? JSPCoverColour { get; set; }         //null is better so I can check if null later


        //Sizes
        [Display(Name ="iMPB Lenght")]
        public int ImpbLenght { get; set; }
        [Display(Name = "Conductor cut size")]
        public int Conductor { get; set; }
        [Display(Name = "Insulator cut size")]
        public int Insulator { get; set; }
        [Display(Name = "Housing cut size")]
        public int Housing { get; set; }
        [Display(Name = "IP3X cut size")]
        public int Ip3X { get; set; }


        //---------------Foreign Keys and Navigation--------------------
        public int WorkOrderId { get; set; }
        //[ForeignKey("WorkOrderId")]
        public WorkOrder WorkOrder { get; set; }

        //PartOrder
        //public int CutListCheckId { get; set; }
        //[ForeignKey("CutListCheckId")]
        public CutListCheck CutListCheck { get; set; }

        //public ICollection<VersionDate> VersionDate { get; set; }
    }
}
