using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NepFit.Repository.Entity
{

    [Serializable]
    [DataContract]
    [Table("BodyMetrics", Schema="dbo")]
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
                        Decimal neckSize,
                        Decimal shoulderSize,
                        Decimal chestSize,
                        Decimal upperAbsSize,
                        Decimal lowerAbsSize,
                        Decimal hipSize,
                        Decimal rightBicepSize,
                        Decimal leftBicepSize,
                        Decimal foreArmSize,
                        Decimal waistSize,
                        Decimal rightThighSize,
                        Decimal leftThighSize,
                        Decimal rightCalveSize,
                        Decimal leftCalveSize,
                        DateTime dateCreated,
                        System.Guid userId)
    {
        var @objectToReturn = new BodyMetrics
        {
          
            Height = height,
            BodyMass = bodyMass,
            NeckSize = neckSize,
            ShoulderSize = shoulderSize,
            ChestSize = chestSize,
            UpperAbsSize = upperAbsSize,
            LowerAbsSize = lowerAbsSize,
            HipSize = hipSize,
            RightBicepSize = rightBicepSize,
            LeftBicepSize = leftBicepSize,
            ForeArmSize = foreArmSize,
            WaistSize = waistSize,
            RightThighSize = rightThighSize,
            LeftThighSize = leftThighSize,
            RightCalveSize = rightCalveSize,
            LeftCalveSize = leftCalveSize,
            DateCreated = dateCreated,
            UserId = userId,
            BodyMetricsId = Guid.NewGuid()
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
        [DisplayName("NeckSize")]
        [DataMember]
        [Required]
        
        public  Decimal NeckSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ShoulderSize")]
        [DataMember]
        [Required]
        
        public  Decimal ShoulderSize { get; set; }

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
        [DisplayName("UpperAbsSize")]
        [DataMember]
        [Required]
        
        public  Decimal UpperAbsSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("LowerAbsSize")]
        [DataMember]
        [Required]
        
        public  Decimal LowerAbsSize { get; set; }

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
        [DisplayName("RightBicepSize")]
        [DataMember]
        [Required]
        
        public  Decimal RightBicepSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("LeftBicepSize")]
        [DataMember]
        [Required]
        
        public  Decimal LeftBicepSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ForeArmSize")]
        [DataMember]
        [Required]
        
        public  Decimal ForeArmSize { get; set; }

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
        [DisplayName("RightThighSize")]
        [DataMember]
        [Required]
        
        public  Decimal RightThighSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("LeftThighSize")]
        [DataMember]
        [Required]
        
        public  Decimal LeftThighSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("RightCalveSize")]
        [DataMember]
        [Required]
        
        public  Decimal RightCalveSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("LeftCalveSize")]
        [DataMember]
        [Required]
        
        public  Decimal LeftCalveSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("DateCreated")]
        [DataMember]
        [Required]
        
        public  DateTime DateCreated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("UserId")]
        [DataMember]
        [Required]
        
        public  System.Guid UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("BodyMetricsId")]
        [DataMember]
        
        [Key, Column(Order = 0)]
        public  System.Guid BodyMetricsId { get; set; }

    }

}


