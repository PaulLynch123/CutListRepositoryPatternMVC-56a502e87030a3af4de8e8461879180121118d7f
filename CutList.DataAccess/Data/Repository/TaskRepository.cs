using CutList.DataAccess.Data.Repository.IRepository;
using CutList.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CutList.DataAccess.Data.Repository
{
    public class TaskRepository : Repository<Task>, ITaskRepository        //MAKE NOTES ON THIS
    {
        //need database object
        private readonly ApplicationDbContext _db;

        //constructor to retrieve the database object
        public TaskRepository(ApplicationDbContext db) : base(db)        //exspecting parameter in constructor can now retrieve from implementing base(db)
        {
            _db = db;
        }

        //to populate my dropdown
        public IEnumerable<SelectListItem> GetTaskListForDropDown()
        {
            return _db.Task.Select(t => new SelectListItem()
            {
                Text = t.TaskName.ToString() + " - " + t.TaskId,
                Value = t.TaskId.ToString()
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
