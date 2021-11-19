using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CutList.Models
{
    public class CutListCheck
    {
        [Key]
        public int CutListCheckId { get; set; }

        //possible auto
        //public VersionDate DateNeeded { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateEntered { get; set; }

        //marking that each task of the busbar prep is complete by factory worker
        public bool Bend { get; set; }
        public bool Weld { get; set; }
        public bool Paint { get; set; }
        public bool Tinned { get; set; }
        public bool Wrapped { get; set; }
        [Display(Name = "Mould Cut")]
        public bool MouldCut { get; set; }
        public bool Pour { get; set; }
        public bool Assy { get; set; }

        //based on entry of WorkOrder and PartOrder
        /*
        public Task Bend { get; set; }
        public Task Weld { get; set; }
        public Task Paint { get; set; }
        public Task Tinned { get; set; }
        public Task Wrapped { get; set; }
        [Display(Name = "Mould Cut")]
        public Task MouldCut { get; set; }
        public Task Pour { get; set; }
        public Task Assy { get; set; }
        */

        //---------foreign keys and navigation---------------

        public int PartOrderId { get; set; }
        //[ForeignKey("PartOrderId")]
        public PartOrder PartOrder { get; set; }


        //public ICollection<Task> Task { get; set; }
        public ICollection<VersionDate> VersionDates { get; set; }
    }
}
