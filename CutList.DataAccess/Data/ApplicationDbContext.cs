using System;
using System.Collections.Generic;
using System.Text;
using CutList.Models;
//added extension to ClassLibrary
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

//edit namespace to current Project
namespace CutList.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //put models in DbSet to use in accessing database
        public DbSet<Project> Project { get; set; }
        public DbSet<WorkOrder> WorkOrder { get; set; }
        public DbSet<PartOrder> PartOrder { get; set; }
        public DbSet<CutListCheck> CutListCheck { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<DeliveryDetail> DeliveryDetail { get; set; }
        public DbSet<VersionDate> VersionDate { get; set; }

    }
}
