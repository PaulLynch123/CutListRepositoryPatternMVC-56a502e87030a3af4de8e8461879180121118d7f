using System;
using System.Collections.Generic;
using System.Text;

namespace CutList.Models
{
    class CutList
    {
        [Key]
        public int CutListId { get; set; }

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


    }
}
