using System;
using System.Collections.Generic;
using System.Text;

namespace NepFit.Repository.Entity
{
    class NutritionRoutine
    {
        public Guid NutritionRoutineId { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public String HowToPrepare { get; set; }

        public Guid NutritionId { get; set; }

        public Guid NutritionPackageId { get; set; }

    }
}
