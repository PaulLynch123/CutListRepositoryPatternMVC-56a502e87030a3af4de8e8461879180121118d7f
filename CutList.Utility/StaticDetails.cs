using System;
using System.Collections.Generic;
using System.Text;

namespace CutList.Utility
{
    public static class StaticDetails
    {
        //approval status
        public const string StatusSubmitted = "Submited";
        public const string StatusApproved = "Approved";
        public const string StatusRejected = "Rejected";

        //user roles
        public const string Admin = "Admin";
        public const string Management = "Management";

        //cutting
        public const int LessConductor = 42;
        public const int LessInsulator = 151;
        public const int LessHousing = 43;
        public const int LessIP3X = 50;

    }
}
