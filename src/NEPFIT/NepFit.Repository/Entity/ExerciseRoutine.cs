using System;
using System.Collections.Generic;
using System.Text;

namespace NepFit.Repository.Entity
{
    class ExerciseRoutine
    {
        public Guid ExerciseRoutineId { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public long Repetition { get; set; }

        public long Sequence { get; set; }
        public long Duration { get; set; }

        public Guid ExerciseId { get; set; }
        public Guid ExercisePackageId { get; set; }





    }
}
