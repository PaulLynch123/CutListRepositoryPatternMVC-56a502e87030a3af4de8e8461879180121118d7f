using CutList.DataAccess.Data;
using CutList.DataAccess.Data.Repository;
using CutList.DataAccess.Data.Repository.IRepository;
using CutList.Models;
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
        }//See
        
    }
}

