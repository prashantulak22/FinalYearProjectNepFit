using System;
using System.Collections.Generic;
using System.Text;

namespace NepFit.Repository.Entity
{
    class NutritionPackage
    {
        public Guid NutritionPackageId { get; set; }
        public String Name { get; set; }

        public String Description { get; set; }
    }
}
