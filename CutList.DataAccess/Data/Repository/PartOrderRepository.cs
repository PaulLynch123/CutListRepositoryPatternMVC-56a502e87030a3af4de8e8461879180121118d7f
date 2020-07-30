﻿using CutList.DataAccess.Data.Repository.IRepository;
using CutList.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CutList.DataAccess.Data.Repository
{
    public class PartOrderRepository : Repository<PartOrder>, IPartOrderRepository        //MAKE NOTES ON THIS
    {
        //need database object
        private readonly ApplicationDbContext _db;

        //constructor to retrieve the database object
        public PartOrderRepository(ApplicationDbContext db) : base(db)        //exspecting parameter in constructor can now retrieve from implementing base(db)
        {
            _db = db;
        }

        //to populate my dropdown
        public IEnumerable<SelectListItem> GetPartOrderListForDropDown()
        {
            return _db.PartOrder.Select(p => new SelectListItem()
            {
                Text = p.OrderNo.ToString(),
                Value = p.OrderNo.ToString()
            });
        }

        public void Update(PartOrder partOrder)
        {
            //get partOrder from database that matches form OrderNo
            var objectFromDb = _db.PartOrder.FirstOrDefault(p => p.OrderNo == partOrder.OrderNo);
            //update each change
            objectFromDb.Material = partOrder.Material;
            objectFromDb.Stack = partOrder.Stack;

            objectFromDb.Quantity = partOrder.Quantity;

            objectFromDb.EarthWarning = partOrder.EarthWarning;
            objectFromDb.EarthSize = partOrder.EarthSize;

            objectFromDb.JSCoverColour = partOrder.JSCoverColour;
            objectFromDb.JSPCoverColour = partOrder.JSPCoverColour;

            //if iMPB lenght is changed then recalculate other lenghts
            if(objectFromDb.ImpbLenght != partOrder.ImpbLenght)
            {
                objectFromDb.ImpbLenght = partOrder.ImpbLenght;
                //set other lenghts
                objectFromDb.Conductor = partOrder.ImpbLenght - 42;
                objectFromDb.Insulator = partOrder.ImpbLenght - 42 - 151;
                objectFromDb.Housing = partOrder.ImpbLenght - 42 - 151 - 43;
                objectFromDb.Ip3X = partOrder.ImpbLenght - 42 - 151 - 43 - 50;
            }//if
            

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