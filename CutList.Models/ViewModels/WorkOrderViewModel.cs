using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CutList.Models.ViewModels
{
    public class WorkOrderViewModel
    {
        public WorkOrder WorkOrder { get; set; }

        //to pass to version date object
        [Display(Name = "Date Completed 123")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        //can't use date range with JQuery 9Would need to disable jQuery date validation
        [DataType (DataType.Date)]
        public DateTime? VersionDate1 { get; set; }

        //list of projects
        public IEnumerable<SelectListItem> ProjectsList { get; set; }

        //to select the data and have version list of previous dates entered
        [Display(Name = "Completion Date")]
        public IEnumerable<SelectListItem> VersionDatesList { get; set; }
    }
}
