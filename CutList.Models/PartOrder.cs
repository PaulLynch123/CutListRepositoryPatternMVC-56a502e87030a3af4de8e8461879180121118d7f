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
        public int OrderNo { get; set; }

        //public int PartId { get; set; }
        [Required(ErrorMessage ="You have to enter the {0} the busbar is made from")]
        public Material Material{ get; set; }

        public Stack Stack { get; set; }

        [Required]
        [Range(1,20, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Quantity { get; set; }

        public bool EarthWarning { get; set; }
        public int EarthSize { get; set; }          //must be more than Amps in WorkOrder

        public CoverColour? JSCoverColour { get; set; }         //null is better so I can check if null later
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
        public int WON;
        [ForeignKey("WON")]
        public WorkOrder WorkOrder { get; set; }

        //PartOrder
        public int CutListId { get; set; }
        [ForeignKey("CutListId")]
        public CutList CutList { get; set; }
    }
}
