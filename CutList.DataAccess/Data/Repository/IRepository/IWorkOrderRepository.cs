﻿using CutList.Models;
using Microsoft.AspNetCore.Mvc.Rendering;               //selectList
using System;
using System.Collections.Generic;
using System.Text;

namespace CutList.DataAccess.Data.Repository.IRepository
{
    //putting my project model in the IRepository
    public interface IWorkOrderRepository : IRepository<WorkOrder>
    {
        //put in some extra methods (Update)
        //to update with object
        void Update(WorkOrder workOrder);

        //want to render as selectList
        IEnumerable<SelectListItem> GetWorkOrderListForDropDown();

        //update approval status only
        public void ChangeWorkOrderStatus(int wON, string approvalStatus);
    }
}