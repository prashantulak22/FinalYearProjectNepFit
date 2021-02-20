using System;
using System.Collections.Generic;
using System.Text;

namespace NepFit.Repository.Entity
{
    class ProgressTracker
    {
        public Guid UserId { get; set; }
        
        public decimal NewHeight { get; set; }

        public decimal NewBodyMass { get; set; }

        public decimal NewChestSize { get; set; }

        public decimal NewArmSize { get; set; }

        public decimal NewForearmSize { get; set; }

        public decimal NewWristSize { get; set; }

        public decimal NewNeckSize { get; set; }

        public decimal NewUpperAbs { get; set; }

        public decimal NewLowerAbs { get; set; }

        public decimal NewHipsize { get; set; }

        public decimal NewWaistSize { get; set; }

        public decimal NewThighSize { get; set; }

        public decimal NewCalveSize { get; set; }

    }
}
