using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NepFit.Repository.Dto
{
    public class ProgressTrackerChartResultDto
    {
 

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
        [DisplayName("DateCreated")]
        [DataMember]
        [Required]
        
        public DateTime DateCreated { get; set; }

 
    }
}