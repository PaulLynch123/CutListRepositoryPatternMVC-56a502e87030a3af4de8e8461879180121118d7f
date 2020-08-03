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
        public int DateId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateEntered { get; set; }

        public bool CurrentDate { get; set; }

        public string SignedIn { get; set; }
        //public ApplicationUser SignedIn { get; set; }   //create ApplicationUser from IdentityUser
        public DateTime SystemDateTime { get; set; }




        //---------Foreign keys and Navigation-----------

        //PartOrder
        public int WON { get; set; }
        [ForeignKey("WON")]
        public WorkOrder WorkOrder { get; set; }


        //public int CutListId;
        //[ForeignKey("CutListId")]
        //public CutListCheck CutListCheck { get; set; }

        ////PartOrder
        //public int OrderNo { get; set; }
        //[ForeignKey("OrderNo")]
        //public PartOrder PartOrder { get; set; }



        //public int TaskId { get; set; }
        //[ForeignKey("TaskId")]
        //public Task Task { get; set; }

    }
}
