using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using CutList.DataAccess.Data.Repository.IRepository;
using CutList.Models;
using CutList.Models.ViewModels;
using CutList.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static CutList.Utility.CutListEnums;

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

            //get version of the related date
            var versionDateQuery = _unitOfWork.VersionDate.GetAll(filter: vd => vd.WorkOrderId == id && vd.CurrentDate == false, orderBy: vd => vd.OrderBy(d => d.DateEntered));

            //create viewmodel to pass info
            //I removed the WorkOrderViewModel as is Binded already for the whole class an created above
            WorkOrderVM = new WorkOrderViewModel()
            {
                WorkOrder = new WorkOrder(),
                //using method in ProjectRepository to get
                ProjectsList = _unitOfWork.Project.GetProjectListForDropDown(),
                //get VersionDate details
                //VersionDatesList = _unitOfWork.VersionDate.GetVersionDateByWorkOrderForDropDown(id),
                //new select list with date from query above
                VersionDatesList = new SelectList(versionDateQuery,"VersionDateId", "DateEntered"),
            };

            //editing workOrder
            if(id != null)
            {
                //retrieve workOrder from database
                WorkOrderVM.WorkOrder = _unitOfWork.WorkOrder.Get(id.GetValueOrDefault());  //used as it is nullable <T> or value of id
                //pass entered date back to the form if any found
                //get current date
                var currentDateQuery = _unitOfWork.VersionDate.GetAll(filter: vd => vd.WorkOrderId == id && vd.CurrentDate == true);
                //check the list size
                var howMany = currentDateQuery.Count();
                if(howMany > 0)
                {
                    WorkOrderVM.VersionDate1 = currentDateQuery.FirstOrDefault().DateEntered;
                }//if
                
            }//if
            
            //id is not correct
            if (WorkOrderVM.WorkOrder == null)
            {
                //DECIDE WHERE TO GO WHEN NOT FOUND AND MESSAGE
                return NotFound();
            }//if
            return View(WorkOrderVM);
        }//Upsert

        [HttpPost]
        //to prevent malicious data being sent to the database. treats tampered validation token as spam request
        [ValidateAntiForgeryToken]
        //nO NEED TO PASS WorkOrderVM as is binded for the class
        public IActionResult Upsert()
        {
           //check if matches model
            if (ModelState.IsValid)
            {
                //update wireColours
                WorkOrderVM.WorkOrder = SetWireColoursFromPhaseLabel(WorkOrderVM.WorkOrder);

                //check if insert
                if (WorkOrderVM.WorkOrder.WorkOrderId == 0)
                {
                    //add WorkOrder
                    _unitOfWork.WorkOrder.Add(WorkOrderVM.WorkOrder);

                    //versionDate
                    //checked if it exists already
                    //get version of the related date
                    var currentVersionDateInDatabase = _unitOfWork.VersionDate.GetAll(filter: vd => vd.WorkOrderId == WorkOrderVM.WorkOrder.WorkOrderId && vd.CurrentDate == true);

                    var versionDate1 = new VersionDate
                    {
                        DateEntered = WorkOrderVM.VersionDate1
                    };
                    //add versionDate related to this
                    _unitOfWork.VersionDate.Add(versionDate1);
                }//if
                else//is update
                {
                    //update database with udate method in WorkOrderRepository
                    _unitOfWork.WorkOrder.Update(WorkOrderVM.WorkOrder);
                }//else

                _unitOfWork.Save();
                //use nameof with redirects where possible to ensure it exists
                return RedirectToAction(nameof(Index));
            }//if
            else
            {
                //need to fill list incase not valid
                WorkOrderVM.ProjectsList = _unitOfWork.Project.GetProjectListForDropDown();
                //return viewModel again
                return View(WorkOrderVM);
            }//else
            
        }//Upsert POST

        private WorkOrder SetWireColoursFromPhaseLabel(WorkOrder workOrder)
        {
            //if special phase wiring colours false the set else return as per form
            if (workOrder.SpecialPhase == false)
            {
                //else set as per code below depending on PhaseLabel tag
                if (workOrder.PhaseLabel == PhaseLabel.EuroStandard)
                {
                    //autoset to EuroStandard
                    workOrder.Neutral = WireColours.Blue;
                    workOrder.L1 = WireColours.Brown;
                    workOrder.L2 = WireColours.Black;
                    workOrder.L3 = WireColours.Grey;
                    workOrder.Earth = WireColours.YellowGreen;
                }//if

                if (workOrder.PhaseLabel == PhaseLabel.EuroAlternative)
                {
                    //autoset depending on 
                    workOrder.Neutral = WireColours.Blue;
                    workOrder.L1 = WireColours.Green;
                    workOrder.L2 = WireColours.Red;
                    workOrder.L3 = WireColours.Yellow;
                    workOrder.Earth = WireColours.YellowGreen;
                }//if

                if (workOrder.PhaseLabel == PhaseLabel.India)
                {
                    //autoset depending on 
                    workOrder.Neutral = WireColours.Black;
                    workOrder.L1 = WireColours.Red;
                    workOrder.L2 = WireColours.Yellow;
                    workOrder.L3 = WireColours.Blue;
                    workOrder.Earth = WireColours.Green;
                }//if

                if (workOrder.PhaseLabel == PhaseLabel.NorthAmerica)
                {
                    //autoset depending on 
                    workOrder.Neutral = WireColours.Grey;
                    workOrder.L1 = WireColours.Black;
                    workOrder.L2 = WireColours.Brown;
                    workOrder.L3 = WireColours.Blue;
                    workOrder.Earth = WireColours.Green;
                }//if

            }//if

            return workOrder;
        }


        #region API calls

        //[HttpGet]
        public IActionResult GetAll()
        {
            //pass the Json object
            //use the GetAll method in the Repository
            //include the project so I can show project ID in the table
            return Json(new { data = _unitOfWork.WorkOrder.GetAll(includeProperties: "Project") });
            
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

