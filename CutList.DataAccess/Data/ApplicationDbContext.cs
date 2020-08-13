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
        public DbSet<Project> Projects { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<PartOrder> PartOrders { get; set; }
        public DbSet<CutListCheck> CutListChecks { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<DeliveryDetail> DeliveryDetails { get; set; }
        public DbSet<VersionDate> VersionDates { get; set; }

    }
}
