using System;
using System.Collections.Generic;
using System.Text;

namespace NepFit.Repository.Entity
{
    class NepFitUser
    {
        public Guid UserId { get; set; }
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public DateTime DateOfBirth{ get; set; }

        public String Gender { get; set; }

        public long MobileNumber{ get; set; }





    }
}
