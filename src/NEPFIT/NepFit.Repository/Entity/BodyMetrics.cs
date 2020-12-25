using System;

namespace NepFit.Repository.Entity
{
    public class BodyMetrics
    {
        public decimal Height{ get; set; }

        public decimal BodyMass { get; set; }

        public decimal ChestSize { get; set; }

        public decimal ArmSize { get; set; }

        public decimal ForearmSize { get; set; }

        public decimal WristSize { get; set; }

        public decimal NeckSize { get; set; }
        public decimal UpperAbs { get; set; }

        public decimal LowerAbs { get; set; }

        public decimal HipSize { get; set; }

        public decimal WaistSize { get; set; }

        public decimal ThighSize { get; set; }

        public decimal CalveSize { get; set; }
    }
}
ExerciseId ,
	ExercisePackageId,
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT[FK_UserIdBodyMetrics] FOREIGN KEY ([UserId]) REFERENCES[NepFitUser]([UserId])
)