using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CutList.Models.ViewModels
{
    public class WorkOrderViewModel
    {
        public WorkOrder WorkOrder { get; set; }

        //list of projects
        public IEnumerable<SelectListItem> ProjectsList { get; set; }
    }
}
