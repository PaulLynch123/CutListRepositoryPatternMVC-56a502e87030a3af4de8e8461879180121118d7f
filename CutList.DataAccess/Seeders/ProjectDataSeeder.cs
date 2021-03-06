﻿using CutList.DataAccess.Data;
using CutList.DataAccess.Data.Repository;
using CutList.DataAccess.Data.Repository.IRepository;
using CutList.Models;
using CutList.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace CutList.DataAccess.Seeders
{
    public class ProjectDataSeeder : IProjectDataSeeder
    {
        private readonly ApplicationDbContext _db;

        public ProjectDataSeeder(ApplicationDbContext db)
        {
            _db = db;
        }

        //private readonly IUnitOfWork _unitOfWork;

        //public ProjectDataSeeder(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}


        public void Seed()
        {
            //Project project = new Project();
            
            for (int i=1; i<=5; i++)
            {
                //create project
                _db.Add(new Project
                {
                    ProjectName = "Project" + i.ToString(),
                    ClientName = "Client" + i.ToString(),
                    LeadEngineerString = "Lead Engineer" + i.ToString()
                }
                        );

            }//for
            _db.SaveChanges();

            for(int j=1; j<=7; j++)
            {
                var object1 = _db.Add(new WorkOrder
                {
                    ApprovalStatus = StaticDetails.StatusSubmitted,
                    ApprovalEngineerString = "Approval Engineer String" + j.ToString(),
                    CheckedByEngineerString = "Checked By Engineer" + j.ToString(),
                    JobNotes = "Job Notes with some more notes here" + j.ToString(),
                    HeatSink = false,
                    SilverLabel = CutListEnums.SilverLabel.SilverLabel1,
                    PhaseLabel = CutListEnums.PhaseLabel.EuroAlternative,
                    SpecialPhase = false,
                    //check if auto set when not via unitOfWork???
                    Tinned = true,
                    BarAmps = 1000,
                    AmpValue = CutListEnums.AmpValues.FourHundred,
                    //need to set dependent foreign key
                    //Half of projectId different
                    ProjectId = (0 == (j % 2)) ? 1 : 2

                }

                    ) ;
                

            }//for
                
            _db.SaveChanges();
        }//See
        
    }
}

