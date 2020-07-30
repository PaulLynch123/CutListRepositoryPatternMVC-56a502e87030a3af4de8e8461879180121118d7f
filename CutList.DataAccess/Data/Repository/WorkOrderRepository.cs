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
            return _db.WorkOrder.Select(w => new SelectListItem()
            {
                Text = w.WON.ToString(),
                Value = w.WON.ToString()
            });
        }

        public void Update(WorkOrder workOrder)
        {
            var objectFromDb = _db.WorkOrder.FirstOrDefault(w => w.WON == workOrder.WON);

            objectFromDb.WON = workOrder.ProjectId;
            //make a new versionDate object???
            objectFromDb.RequiredDate = workOrder.RequiredDate;
            //from ApplicationUser
            //objectFromDb.ApprovalEngineer = workOrder.ApprovalEngineer;
            //objectFromDb.CheckedByEngineer = workOrder.CheckedByEngineer;

            objectFromDb.JobNotes = workOrder.JobNotes;
            objectFromDb.HeatSink = workOrder.HeatSink;
            objectFromDb.SilverLabel = workOrder.SilverLabel;
            objectFromDb.PhaseLabel = workOrder.PhaseLabel;
            objectFromDb.SpecialPhase = workOrder.SpecialPhase;

            //if special phase wiring colours then set as per form
            if (workOrder.SpecialPhase == false)
            {
                objectFromDb.Neutral = workOrder.Neutral;
                objectFromDb.L1 = workOrder.L1;
                objectFromDb.L2 = workOrder.L2;
                objectFromDb.L3 = workOrder.L3;
                objectFromDb.Earth = workOrder.Earth;
            }//if
            else
            {
                //else set as per code below depending on PhaseLabel tag
                if(workOrder.PhaseLabel == Utility.CutListEnums.PhaseLabel.EuroStandard)
                {
                    //autoset to EuroStandard
                    objectFromDb.Neutral = Utility.CutListEnums.WireColours.Blue;
                    objectFromDb.L1 = Utility.CutListEnums.WireColours.Brown;
                    objectFromDb.L2 = Utility.CutListEnums.WireColours.Black;
                    objectFromDb.L3 = Utility.CutListEnums.WireColours.Grey;
                    objectFromDb.Earth = Utility.CutListEnums.WireColours.YellowGreen;
                }//if

                if (workOrder.PhaseLabel == Utility.CutListEnums.PhaseLabel.EuroAlternative)
                {
                    //autoset depending on 
                    objectFromDb.Neutral = Utility.CutListEnums.WireColours.Blue;
                    objectFromDb.L1 = Utility.CutListEnums.WireColours.Green;
                    objectFromDb.L2 = Utility.CutListEnums.WireColours.Red;
                    objectFromDb.L3 = Utility.CutListEnums.WireColours.Yellow;
                    objectFromDb.Earth = Utility.CutListEnums.WireColours.YellowGreen;
                }//if

                if (workOrder.PhaseLabel == Utility.CutListEnums.PhaseLabel.India)
                {
                    //autoset depending on 
                    objectFromDb.Neutral = Utility.CutListEnums.WireColours.Black;
                    objectFromDb.L1 = Utility.CutListEnums.WireColours.Red;
                    objectFromDb.L2 = Utility.CutListEnums.WireColours.Yellow;
                    objectFromDb.L3 = Utility.CutListEnums.WireColours.Blue;
                    objectFromDb.Earth = Utility.CutListEnums.WireColours.Green;
                }//if

                if (workOrder.PhaseLabel == Utility.CutListEnums.PhaseLabel.NorthAmerica)
                {
                    //autoset depending on 
                    objectFromDb.Neutral = Utility.CutListEnums.WireColours.Grey;
                    objectFromDb.L1 = Utility.CutListEnums.WireColours.Black;
                    objectFromDb.L2 = Utility.CutListEnums.WireColours.Brown;
                    objectFromDb.L3 = Utility.CutListEnums.WireColours.Blue;
                    objectFromDb.Earth = Utility.CutListEnums.WireColours.Green;
                }//if
                
            }//else
            
            objectFromDb.Tinned = workOrder.Tinned;
            //IF TINNED UPDATE DELIVERY???
            objectFromDb.BarAmps = workOrder.BarAmps;
            objectFromDb.AmpValue = workOrder.AmpValue;

            _db.SaveChanges();
        }//update()

        //use to change status only
        public void ChangeWorkOrderStatus(int wON, string approvalStatus)
        {
            //aproval status will come from string options in Utility.StaticDetails
            var orderFromDb = _db.WorkOrder.FirstOrDefault(w => w.WON == wON);
            orderFromDb.ApprovalStatus = approvalStatus;
            //MIGHT BE ABLE TO SET PERSOn WITH THIS
            //objectFromDb.ApprovalEngineer = (ClaimsIdentity)this.ApplicationUser.Identity;
            
            _db.SaveChanges();
        }
    }
}
