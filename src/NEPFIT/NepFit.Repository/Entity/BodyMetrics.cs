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
        public static  BodyMetrics Create(
                        Decimal height,
                        Decimal bodyMass,
                        Decimal chestSize,
                        Decimal armSize,
                        Decimal forearmSize,
                        Decimal wristSize,
                        Decimal neckSize,
                        Decimal upperAbs,
                        Decimal lowerAbs,
                        Decimal hipSize,
                        Decimal waistSize,
                        Decimal thighSize,
                        Decimal calveSize,
                        System.Guid userId)
    {
        var @objectToReturn = new BodyMetrics
        {
          
            Height = height,
            BodyMass = bodyMass,
            ChestSize = chestSize,
            ArmSize = armSize,
            ForearmSize = forearmSize,
            WristSize = wristSize,
            NeckSize = neckSize,
            UpperAbs = upperAbs,
            LowerAbs = lowerAbs,
            HipSize = hipSize,
            WaistSize = waistSize,
            ThighSize = thighSize,
            CalveSize = calveSize,
            UserId = userId
        };

        return @objectToReturn;
    }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Height")]
        [DataMember]
        [Required]
        
        public  Decimal Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("BodyMass")]
        [DataMember]
        [Required]
        
        public  Decimal BodyMass { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ChestSize")]
        [DataMember]
        [Required]
        
        public  Decimal ChestSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ArmSize")]
        [DataMember]
        [Required]
        
        public  Decimal ArmSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ForearmSize")]
        [DataMember]
        [Required]
        
        public  Decimal ForearmSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("WristSize")]
        [DataMember]
        [Required]
        
        public  Decimal WristSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NeckSize")]
        [DataMember]
        [Required]
        
        public  Decimal NeckSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("UpperAbs")]
        [DataMember]
        [Required]
        
        public  Decimal UpperAbs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("LowerAbs")]
        [DataMember]
        [Required]
        
        public  Decimal LowerAbs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("HipSize")]
        [DataMember]
        [Required]
        
        public  Decimal HipSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("WaistSize")]
        [DataMember]
        [Required]
        
        public  Decimal WaistSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ThighSize")]
        [DataMember]
        [Required]
        
        public  Decimal ThighSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("CalveSize")]
        [DataMember]
        [Required]
        
        public  Decimal CalveSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("UserId")]
        [DataMember]
        [Required]
        
        public  System.Guid UserId { get; set; }

    }

}


