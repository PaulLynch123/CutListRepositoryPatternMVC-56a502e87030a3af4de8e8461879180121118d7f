using CutList.DataAccess.Data.Repository.IRepository;
using CutList.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CutList.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        //database access
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            Project = new ProjectRepository(_db);
            WorkOrder = new WorkOrderRepository(_db);

            VersionDate = new VersionDateRepository(_db);

            //Job = new JobRepository(_db);
            ////create the repository object for each model accessing database
            //Frequency = new FrequencyRepository(_db);
            //Service = new ServiceRepository(_db);
            //OrderHeader = new OrderHeaderRepository(_db);
            //OrderDetails = new OrderDetailsRepository(_db);
            ////user
            //User = new UserRepository(_db);
            ////stored procedure
            //SP_Call = new SP_Call(_db);

        }

        public IProjectRepository Project { get; private set; }         //can only be set here
        public IWorkOrderRepository WorkOrder { get; private set; }

        public IWorkOrderRepository VersionDate { get; private set; }

        //public IJobRepository Job { get; private set; }         //can only be set here
        //public IFrequencyRepository Frequency { get; private set; }
        //public IServiceRepository Service { get; private set; }
        //public IOrderHeaderRepository OrderHeader { get; private set; }
        //public IOrderDetailsRepository OrderDetails { get; private set; }
        //user
        //public IUserRepository User { get; private set; }

        ////stored procedure
        //public ISP_Call SP_Call { get; private set; }


        //release the allocated resources for this context
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
