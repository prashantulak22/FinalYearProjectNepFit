using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NepFit.Repository.Dto
{
    public class BodyMetricsCreateDto 
    {

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
        [DisplayName("ChestSize")]
        [DataMember]
        [Required]
        
        public Decimal ChestSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ArmSize")]
        [DataMember]
        [Required]
        
        public Decimal ArmSize { get; set; }

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
        [DisplayName("WristSize")]
        [DataMember]
        [Required]
        
        public Decimal WristSize { get; set; }

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
        [DisplayName("UpperAbs")]
        [DataMember]
        [Required]
        
        public Decimal UpperAbs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("LowerAbs")]
        [DataMember]
        [Required]
        
        public Decimal LowerAbs { get; set; }

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
        [DisplayName("WaistSize")]
        [DataMember]
        [Required]
        
        public Decimal WaistSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ThighSize")]
        [DataMember]
        [Required]
        
        public Decimal ThighSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("CalveSize")]
        [DataMember]
        [Required]
        
        public Decimal CalveSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("UserId")]
        [DataMember]
        [Required]
        
        public System.Guid UserId { get; set; }


    }
}
