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

        //based on entry of JobParts and PartOrder
        public Task Bend { get; set; }
        public Task Weld { get; set; }
        public Task Paint { get; set; }
        public Task Tinned { get; set; }
        public Task Wrapped { get; set; }
        public Task MouldCut { get; set; }
        public Task Pour { get; set; }
        public Task Assy { get; set; }


        //---------foreign keys and navigation---------------

        public int OrderNo;
        [ForeignKey("OrderNo")]
        public PartOrder PartOrder { get; set; }


        //public ICollection<Task> Task { get; set; }
        //public ICollection<VersionDate> VersionDate { get; set; }
    }
}
