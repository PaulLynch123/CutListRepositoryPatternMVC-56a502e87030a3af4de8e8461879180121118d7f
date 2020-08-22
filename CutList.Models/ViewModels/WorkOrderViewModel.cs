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

        //list of projects
        public IEnumerable<SelectListItem> ProjectsList { get; set; }

        //to select the data and have version list of previous dates entered
        [Display(Name = "Completion Date")]
        public IEnumerable<SelectListItem> VersionDatesList { get; set; }
    }
}
