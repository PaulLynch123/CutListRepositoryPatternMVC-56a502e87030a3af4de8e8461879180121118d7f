using CutList.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CutList.DataAccess.Initializer
{
    public class DbInitialiser : IDbInitialiser
    {

        private readonly ApplicationDbContext _db;

        //constructor
        public DbInitialiser(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Initialise()
        {
            //enter inital users to log in for first time

        }

        public void DevelopmentInitialise()
        {
            //delete the database and then create it again each time during development
            _db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();
        }
    }
}
