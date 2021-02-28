using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NepFit.Repository.Dto
{
    public class BodyMetricsUpdateDto  
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
        
        public System.Guid UserId { get; set; }

    }
}
