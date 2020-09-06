using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CutList.Models
{
    public class VersionDate
    {
        [Key]
        public int VersionDateId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date inputed")]
        public DateTime? DateEntered { get; set; }

        [Display(Name = "Current Version of Date")]
        public bool CurrentDate { get; set; }

        [Display(Name = "Employee signed in")]
        public string SignedIn { get; set; }
        //public ApplicationUser SignedIn { get; set; }   //create ApplicationUser from IdentityUser
        [Display(Name = "System Date/Time")]
        public DateTime SystemDateTime { get; set; }

        //---------Foreign keys and Navigation-----------

        
        public int? WorkOrderId { get; set; }

        //[ForeignKey("WorkOrderId")]
        public WorkOrder WorkOrder { get; set; }


        public int? CutListCheckId;
        //[ForeignKey("CutListCheckId")]
        public CutListCheck CutListCheck { get; set; }

        ////PartOrder
        //public int OrderNo { get; set; }
        //[ForeignKey("OrderNo")]
        //public PartOrder PartOrder { get; set; }



        //public int TaskId { get; set; }
        //[ForeignKey("TaskId")]
        //public Task Task { get; set; }

    }
}
