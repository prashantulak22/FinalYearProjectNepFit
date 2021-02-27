using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NepFit.Repository.Dto
{
    public class ProgressTrackerResultDto
    {

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ProgressTrackerId")]
        [DataMember]
        public Int32 ProgressTrackerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewHeight")]
        [DataMember]
        [Required]
        
        public Decimal NewHeight { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewBodyMass")]
        [DataMember]
        [Required]
        
        public Decimal NewBodyMass { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewChestSize")]
        [DataMember]
        [Required]
        
        public Decimal NewChestSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewArmSize")]
        [DataMember]
        [Required]
        
        public Decimal NewArmSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewForearmSize")]
        [DataMember]
        [Required]
        
        public Decimal NewForearmSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewWristSize")]
        [DataMember]
        [Required]
        
        public Decimal NewWristSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewNeckSize")]
        [DataMember]
        [Required]
        
        public Decimal NewNeckSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewUpperAbs")]
        [DataMember]
        [Required]
        
        public Decimal NewUpperAbs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewLowerAbs")]
        [DataMember]
        [Required]
        
        public Decimal NewLowerAbs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewHipSize")]
        [DataMember]
        [Required]
        
        public Decimal NewHipSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewWaistSize")]
        [DataMember]
        [Required]
        
        public Decimal NewWaistSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewThighSize")]
        [DataMember]
        [Required]
        
        public Decimal NewThighSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewCalveSize")]
        [DataMember]
        [Required]
        
        public Decimal NewCalveSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("UserId")]
        [DataMember]
        [Required]
        
        public System.Guid UserId { get; set; }

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
        [DisplayName("CreatedBy")]
        [DataMember]
        public String CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("UpdatedBy")]
        [DataMember]
        
        public String UpdatedBy { get; set; }
    }
}