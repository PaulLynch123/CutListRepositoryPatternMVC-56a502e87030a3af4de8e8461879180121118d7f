using CutList.Models;
using Microsoft.AspNetCore.Mvc.Rendering;               //selectList
using System;
using System.Collections.Generic;
using System.Text;

namespace CutList.DataAccess.Data.Repository.IRepository
{
    //putting my project model in the IRepository
    public interface IVersionDateRepository : IRepository<VersionDate>
    {
        //put in some extra methods (Update)
        //to update with object
        //void Update(VersionDate versionDate);

        //want to render as selectList for version list filtered by workOrder number
        IEnumerable<SelectListItem> GetVersionDateByWorkOrderForDropDown();

    }
}
