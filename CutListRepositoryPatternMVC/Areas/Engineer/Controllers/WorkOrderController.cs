using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CutList.DataAccess.Data.Repository.IRepository;
using CutList.Models;
using CutList.Models.ViewModels;
using CutList.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CutListRepositoryPatternMVC.Areas.Engineer.Controllers
{
    //only accessable via login
    //[Authorize]
    //url path / folder
    [Area("Engineer")]
    public class WorkOrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        //binding the viewModel automatically for the class
        [BindProperty]
        public WorkOrderViewModel WorkOrderVM { get; set; }


        public WorkOrderController(IUnitOfWork unitOfWork)
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
            //create viewmodel to pass info
            //removed the WorkOrderViewModel as is Binded already for the whole class an created above
            WorkOrderVM = new WorkOrderViewModel()
            {
                WorkOrder = new WorkOrder(),
                ProjectsList = _unitOfWork.Project.GetProjectListForDropDown(),
            };

            //editing workOrder
            if(id != null)
            {
                //retrieve workOrder from database
                WorkOrderVM.WorkOrder = _unitOfWork.WorkOrder.Get(id.GetValueOrDefault());     //used as it is nullable <T> or value of id
            }
            
            //id is not correct
            if (WorkOrderVM.WorkOrder == null)
            {
                //DECIDE WHERE TO GO WHEN NOT FOUND
                return NotFound();
            }
            return View(WorkOrderVM);
        }//Upsert

        [HttpPost]
        //to prevent malicious data being sent to the database. treats tampered validation token as spam request
        [ValidateAntiForgeryToken]
        //nO NEED TO PASS WorkOrderVM as is binded for the class
        public IActionResult Upsert()
        {
            //EDIT THIS METHOD
           
            if (ModelState.IsValid)
            {
                //check if insert
                if (WorkOrderVM.WorkOrder.WorkOrderId == 0)
                {
                    _unitOfWork.WorkOrder.Add(WorkOrderVM.WorkOrder);
                }
                else//is update
                {
                    //retrieve workOrder from database
                    WorkOrderVM.WorkOrder = _unitOfWork.WorkOrder.Get(WorkOrderVM.WorkOrder.WorkOrderId);
                    _unitOfWork.WorkOrder.Update(WorkOrderVM.WorkOrder);
                }

                _unitOfWork.Save();
                //use nameof with redirects where possible to ensure it exists
                return RedirectToAction(nameof(Index));
            }
            return View(WorkOrderVM.WorkOrder);
        }//Upsert POST


        #region API calls ---------

        [HttpGet]
        public IActionResult GetAll()
        {
            //pass the Json object
            //use the GetAll method in the Interface
            return Json(new { data = _unitOfWork.WorkOrder.GetAll() });

            //stored procedure accessed via stored procedure repositary
            //use returnList method<returning job type> (pass stored rocedure name, no more parameteres)
            //return Json(new { data = _unitOfWork.SP_Call.ReturnList<Job>(StaticDetails.cutStoredProcedure_GetAllJob, null) });
        }//GetAll

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objectFromDb = _unitOfWork.WorkOrder.Get(id);
            if (objectFromDb == null)
            {
                //when success equals false the error message below is shown
                return Json(new { success = false, message = "An Error has occured when deleting" });
            }
            //put to the database
            _unitOfWork.WorkOrder.Remove(objectFromDb);
            _unitOfWork.Save();
            //when success equals true the completed message below is shown
            return Json(new { success = true, message = "Delete successful" });
        }//Delete

        #endregion
    }
}

