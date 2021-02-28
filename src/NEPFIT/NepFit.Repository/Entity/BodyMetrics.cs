using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NepFit.Repository.Entity
{

    [Serializable]
    [DataContract]
    public partial class BodyMetrics
    {
     /// <summary>
    /// We don't make constructor public and forcing to create object using <see cref="Create"/> method.
    /// But constructor can not be private since it's used by EntityFramework.
    /// Thats why we did it protected.
    /// </summary>
    public BodyMetrics()
    {

    }
        public static BodyMetrics Create(
                       Decimal height,
                       Decimal bodyMass,
                       Decimal neckSize,
                       Decimal shoulderSize,
                       Decimal chestSize,
                       Decimal forearmSize,
                       Decimal rightBicepSize,
                       Decimal leftBicepSize,
                       Decimal upperAbsSize,
                       Decimal lowerAbsSize,
                       Decimal waistSize,
                       Decimal hipSize,
                       Decimal rightThighSize,
                       Decimal leftThighSize,
                       Decimal rightCalveSize,
                       Decimal leftCalveSize,
                       DateTime dateCreated)
        {
            var @objectToReturn = new BodyMetrics
            {

                Height = height,
                BodyMass = bodyMass,
                NeckSize = neckSize,
                ShoulderSize = shoulderSize,
                ChestSize = chestSize,
                ForearmSize = forearmSize,
                RightBicepSize = rightBicepSize,
                LeftBicepSize = leftBicepSize,
                UpperAbsSize = upperAbsSize,
                LowerAbsSize = lowerAbsSize,
                WaistSize = waistSize,
                HipSize = hipSize,
                RightThighSize = rightThighSize,
                LeftThighSize = leftThighSize,
                RightCalveSize = rightCalveSize,
                LeftCalveSize = leftCalveSize,
                DateCreated = dateCreated,
                UserId = Guid.NewGuid()
            };

            return @objectToReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Height")]
        [DataMember]
        [Required]

        public Decimal Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("BodyMass")]
        [DataMember]
        [Required]

        public Decimal BodyMass { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NeckSize")]
        [DataMember]
        [Required]

        public Decimal NeckSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ShoulderSize")]
        [DataMember]
        [Required]

        public Decimal ShoulderSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ChestSize")]
        [DataMember]
        [Required]

        public Decimal ChestSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ForearmSize")]
        [DataMember]
        [Required]

        public Decimal ForearmSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("RightBicepSize")]
        [DataMember]
        [Required]

        public Decimal RightBicepSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("LeftBicepSize")]
        [DataMember]
        [Required]

        public Decimal LeftBicepSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("UpperAbsSize")]
        [DataMember]
        [Required]

        public Decimal UpperAbsSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("LowerAbsSize")]
        [DataMember]
        [Required]

        public Decimal LowerAbsSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("WaistSize")]
        [DataMember]
        [Required]

        public Decimal WaistSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("HipSize")]
        [DataMember]
        [Required]

        public Decimal HipSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("RightThighSize")]
        [DataMember]
        [Required]

        public Decimal RightThighSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("LeftThighSize")]
        [DataMember]
        [Required]

        public Decimal LeftThighSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("RightCalveSize")]
        [DataMember]
        [Required]

        public Decimal RightCalveSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("LeftCalveSize")]
        [DataMember]
        [Required]

        public Decimal LeftCalveSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("DateCreated")]
        [DataMember]
        [Required]

        public DateTime DateCreated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("UserId")]
        [DataMember]
        [Required]
        
        public  System.Guid UserId { get; set; }

    }

}


