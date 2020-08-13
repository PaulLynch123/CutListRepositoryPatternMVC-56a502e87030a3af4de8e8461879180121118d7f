using System;
using System.Collections.Generic;
using System.Text;

namespace CutList.DataAccess.Initializer
{
    public interface IDbInitialiser
    {
        //start and seed data
        void Initialise();
    }
}
