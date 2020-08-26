using CutList.DataAccess.Data.Repository.IRepository;
using CutList.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CutList.DataAccess.Data.Repository
{
    public class WorkOrderRepository : Repository<WorkOrder>, IWorkOrderRepository        //MAKE NOTES ON THIS
    {
        //need database object
        private readonly ApplicationDbContext _db;

        //constructor to retrieve the database object
        public WorkOrderRepository(ApplicationDbContext db) : base(db)        //exspecting parameter in constructor can now retrieve from implementing base(db)
        {
            _db = db;
        }

        //to populate my dropdown
        public IEnumerable<SelectListItem> GetWorkOrderListForDropDown()
        {
            return _db.WorkOrders.Select(w => new SelectListItem()
            {
                Text = w.WorkOrderId.ToString(),
                Value = w.WorkOrderId.ToString()
            });
        }

        public void Update(WorkOrder workOrder)
        {
            var objectFromDb = _db.WorkOrders.FirstOrDefault(w => w.WorkOrderId == workOrder.WorkOrderId);

            //make a new versionDate object???
            //objectFromDb.RequiredDate = workOrder.RequiredDate;
            //from ApplicationUser
            //objectFromDb.ApprovalEngineer = workOrder.ApprovalEngineer;
            //objectFromDb.CheckedByEngineer = workOrder.CheckedByEngineer;

            //update the project ID
            objectFromDb.ProjectId = workOrder.ProjectId;

            objectFromDb.JobNotes = workOrder.JobNotes;
            objectFromDb.HeatSink = workOrder.HeatSink;
            objectFromDb.SilverLabel = workOrder.SilverLabel;
            objectFromDb.PhaseLabel = workOrder.PhaseLabel;
            objectFromDb.SpecialPhase = workOrder.SpecialPhase;

            objectFromDb.Neutral = workOrder.Neutral;
            objectFromDb.L1 = workOrder.L1;
            objectFromDb.L2 = workOrder.L2;
            objectFromDb.L3 = workOrder.L3;
            objectFromDb.Earth = workOrder.Earth;

            objectFromDb.Tinned = workOrder.Tinned;
            //IF TINNED UPDATE DELIVERY???
            objectFromDb.BarAmps = workOrder.BarAmps;
            objectFromDb.AmpValue = workOrder.AmpValue;

            _db.SaveChanges();
        }//update()

        //use to change status only
        public void ChangeWorkOrderStatus(int workOrderId, string approvalStatus)
        {
            //aproval status will come from string options in Utility.StaticDetails
            var orderFromDb = _db.WorkOrders.FirstOrDefault(w => w.WorkOrderId == workOrderId);
            orderFromDb.ApprovalStatus = approvalStatus;
            //MIGHT BE ABLE TO SET PERSOn WITH THIS
            //objectFromDb.ApprovalEngineer = (ClaimsIdentity)this.ApplicationUser.Identity;
            
            _db.SaveChanges();
        }


    }
}
