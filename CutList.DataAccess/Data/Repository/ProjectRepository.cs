using CutList.DataAccess.Data.Repository.IRepository;
using CutList.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CutList.DataAccess.Data.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository        //MAKE NOTES ON THIS
    {
        //need database object
        private readonly ApplicationDbContext _db;

        //constructor to retrieve the database object
        public ProjectRepository(ApplicationDbContext db) : base(db)        //exspecting parameter in constructor can now retrieve from implementing base(db)
        {
            _db = db;
        }

        //to populate my dropdown
        public IEnumerable<SelectListItem> GetProjectListForDropDown()
        {
            return _db.Project.Select(p => new SelectListItem()
            {
                Text = p.ProjectId.ToString() + " - " + p.ProjectName,
                Value = p.ProjectId.ToString()
            });
        }

        public void Update(Project project)
        {
            var objectFromDb = _db.Project.FirstOrDefault(p => p.ProjectId == project.ProjectId);

            objectFromDb.ProjectName = project.ProjectName;
            objectFromDb.ClientName = project.ClientName;
            objectFromDb.LeadEngineer = project.LeadEngineer;

            _db.SaveChanges();

        }
    }
}
