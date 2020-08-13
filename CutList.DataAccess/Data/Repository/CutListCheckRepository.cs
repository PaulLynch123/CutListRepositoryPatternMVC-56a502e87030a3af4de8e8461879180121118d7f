using CutList.DataAccess.Data.Repository.IRepository;
using CutList.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CutList.DataAccess.Data.Repository
{
    public class CutListCheckRepository : Repository<CutListCheck>, ICutListCheckRepository        //MAKE NOTES ON THIS
    {
        //need database object
        private readonly ApplicationDbContext _db;

        //constructor to retrieve the database object
        public CutListCheckRepository(ApplicationDbContext db) : base(db)        //exspecting parameter in constructor can now retrieve from implementing base(db)
        {
            _db = db;
        }

        //to populate my dropdown
        //public IEnumerable<SelectListItem> GetCutListCheckListForDropDown()
        //{
        //    return _db.Project.Select(c => new SelectListItem()
        //    {
        //        Text = c..ToString() + " - " + p.ProjectName,
        //        Value = p.ProjectId.ToString()
        //    });
        //}

        public void Update(CutListCheck CutListCheck)
        {
            var objectFromDb = _db.CutListChecks.FirstOrDefault(c => c.CutListCheckId == CutListCheck.CutListCheckId);

            objectFromDb.DateEntered = CutListCheck.DateEntered;
            objectFromDb.Bend = CutListCheck.Bend;
            objectFromDb.Weld = CutListCheck.Weld;
            objectFromDb.Paint = CutListCheck.Paint;
            //check WorkOrder to show task option
            objectFromDb.Tinned = CutListCheck.Tinned;
            objectFromDb.Wrapped = CutListCheck.Wrapped;
            objectFromDb.MouldCut = CutListCheck.MouldCut;
            objectFromDb.Pour = CutListCheck.Pour;
            objectFromDb.Assy = CutListCheck.Assy;

            _db.SaveChanges();

        }
    }
}
