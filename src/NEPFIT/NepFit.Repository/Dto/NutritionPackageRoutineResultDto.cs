using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace NepFit.Repository.Dto
{
    public class NutritionPackageRoutineResultDto
    {

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NutritionPackageRoutineId")]
        [DataMember]
        
        public System.Guid NutritionPackageRoutineId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NutritionPackageId")]
        [DataMember]
        [Required]
        
        public System.Guid NutritionPackageId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NutritionRoutineId")]
        [DataMember]
        [Required]
        
        public System.Guid NutritionRoutineId { get; set; }

        public String NutritionPackageName { get; set; }
        public String NutritionTypeName { get; set; }
        public String NutritionRoutineName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Active")]
        [DataMember]
        
        public Boolean? Active { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("UpdatedBy")]
        [DataMember]
        
        public System.Guid? UpdatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("CreatedBy")]
        [DataMember]
        [Required]
        
        public System.Guid CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("DateUpdated")]
        [DataMember]
        
        public DateTime? DateUpdated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("DateCreated")]
        [DataMember]
        [Required]
        
        public DateTime DateCreated { get; set; }

        
    }
}
