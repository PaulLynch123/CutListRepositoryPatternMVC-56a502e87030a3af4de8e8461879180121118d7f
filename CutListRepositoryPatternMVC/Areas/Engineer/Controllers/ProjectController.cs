using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CutList.DataAccess.Data.Repository.IRepository;
using CutList.Models;
using CutList.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CutListRepositoryPatternMVC.Areas.Engineer.Controllers
{
    //only accessable via login
    //[Authorize]
    //url path / folder
    [Area("Engineer")]
    public class ProjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            //using dataTables
            return View();
        }//Index

        //insert or update
        public IActionResult Upsert(int? id)    //nullable
        {
            Project project = new Project();
            //if it is an insert function
            if (id == null)
            {
                //empty object
                return View(project);
            }
            project = _unitOfWork.Project.Get(id.GetValueOrDefault());     //used as it is nullable <T> or value of id
            //id is not correct
            if (project == null)
            {
                //DECIDE WHERE TO GO WHEN NOT FOUND
                return NotFound();
            }
            return View(project);
        }//Upsert

        [HttpPost]
        //to prevent malicious data being sent to the database. treats tampered validation token as spam request
        [ValidateAntiForgeryToken]
        //pass object in as parameter
        public IActionResult Upsert(Project project)
        {
            if (ModelState.IsValid)
            {
                //check if insert
                if (project.ProjectId == 0)
                {
                    _unitOfWork.Project.Add(project);
                }
                else
                //is update
                {
                    _unitOfWork.Project.Update(project);
                }

                _unitOfWork.Save();
                //use nameof with redirects where possible to ensure it exists
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }//Upsert POST


        #region API calls ---------

        [HttpGet]
        public IActionResult GetAll()
        {
            //pass the Json object
            //use the GetAll method in the Interface
            return Json(new { data = _unitOfWork.Project.GetAll() });

            //stored procedure accessed via stored procedure repositary
            //use returnList method<returning job type> (pass stored rocedure name, no more parameteres)
            //return Json(new { data = _unitOfWork.SP_Call.ReturnList<Job>(StaticDetails.cutStoredProcedure_GetAllJob, null) });
        }//GetAll

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objectFromDb = _unitOfWork.Project.Get(id);
            if (objectFromDb == null)
            {
                //when success equals false the error message below is shown
                return Json(new { success = false, message = "An Error has occured when deleting" });
            }
            //put to the database
            _unitOfWork.Project.Remove(objectFromDb);
            _unitOfWork.Save();
            //when success equals true the completed message below is shown
            return Json(new { success = true, message = "Delete successful" });
        }//Delete

        #endregion
    }
}

