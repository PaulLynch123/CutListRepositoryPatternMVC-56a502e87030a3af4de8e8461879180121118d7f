using CutList.Models;
using Microsoft.AspNetCore.Mvc.Rendering;               //selectList
using System;
using System.Collections.Generic;
using System.Text;

namespace CutList.DataAccess.Data.Repository.IRepository
{
    //putting my project model in the IRepository
    public interface IPartOrderRepository : IRepository<PartOrder>
    {
        //put in some extra methods (Update)
        //to update with object
        void Update(PartOrder partOrder);

        //want to render as selectList
        IEnumerable<SelectListItem> GetPartOrderListForDropDown();

        //MIGHT NEED THIS LATER
        ////update approval status only 
        //public void ChangePartOrderStatus(int orderNo, string approvalStatus);
    }
}
