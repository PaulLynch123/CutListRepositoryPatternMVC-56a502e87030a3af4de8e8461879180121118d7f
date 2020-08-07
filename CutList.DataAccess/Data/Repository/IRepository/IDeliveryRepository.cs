using CutList.Models;
using Microsoft.AspNetCore.Mvc.Rendering;               //selectList
using System;
using System.Collections.Generic;
using System.Text;

namespace CutList.DataAccess.Data.Repository.IRepository
{
    //putting my project model in the IRepository
    public interface IDeliveryRepository : IRepository<DeliveryDetail>
    {
        //put in some extra methods (Update)
        //to update with object
        void Update(DeliveryDetail deliveryDetail);

        //want to render as selectList
        IEnumerable<SelectListItem> GetDeliveryDetailListForDropDown();

    }
}
