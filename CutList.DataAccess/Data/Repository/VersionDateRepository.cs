using CutList.DataAccess.Data.Repository.IRepository;
using CutList.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CutList.DataAccess.Data.Repository
{
    public class VersionDateRepository : Repository<VersionDate>, IVersionDateRepository        //MAKE NOTES ON THIS
    {
        //need database object
        private readonly ApplicationDbContext _db;

        //constructor to retrieve the database object
        public VersionDateRepository(ApplicationDbContext db) : base(db)        //exspecting parameter in constructor can now retrieve from implementing base(db)
        {
            _db = db;
        }

        //to populate my dropdown for version of dates with WorkOrderId
        public IEnumerable<SelectListItem> GetVersionDateByWorkOrderForDropDown(int? foreignId)
        {
            return _db.VersionDates.Where(vd1 => vd1.WorkOrderId == foreignId).Select(vd => new SelectListItem()
            {
                Text = vd.VersionDateId.ToString() + " - " + vd.CurrentDate,
                Value = vd.VersionDateId.ToString()
            });
        }


        
        //public void Update(Project project)
        //{
        //    var objectFromDb = _db.Project.FirstOrDefault(p => p.ProjectId == project.ProjectId);

        //    objectFromDb.ProjectName = project.ProjectName;
        //    objectFromDb.ClientName = project.ClientName;
        //    objectFromDb.LeadEngineer = project.LeadEngineer;

        //    _db.SaveChanges();

        //}
    }
}
