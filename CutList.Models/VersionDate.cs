using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CutList.Models
{
    class VersionDate
    {
        [Key]
        public int DateId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateEntered { get; set; }

        public bool CurrentDate { get; set; }

        public ApplicationUser SignedIn { get; set; }   //create ApplicationUser from IdentityUser
        public DateTime SystemDateTime { get; set; }




        //---------Foreign keys and Navigation-----------
        public int CutListId;
        [ForeignKey("CutListId")]
        public CutList CutList { get; set; }

        //PartOrder
        public int TaskId { get; set; }
        [ForeignKey("TaskId")]
        public Task Task { get; set; }

    }
}
