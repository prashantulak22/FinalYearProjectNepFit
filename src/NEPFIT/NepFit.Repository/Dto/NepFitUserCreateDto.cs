using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NepFit.Repository.Dto
{
    public class NepFitUserCreateDto 
    {

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("FirstName")]
        [DataMember]
        [Required]
        [StringLength(50)]
        public String FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("LastName")]
        [DataMember]
        [Required]
        [StringLength(50)]
        public String LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("DateOfBirth")]
        [DataMember]
        [Required]
        
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Gender")]
        [DataMember]
        [Required]
        [StringLength(1)]
        public String Gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ExperienceLevel")]
        [DataMember]
        [Required]
        [StringLength(1)]
        public String ExperienceLevel { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [DisplayName("FoodCategory")]
        [DataMember]
        [Required]
        [StringLength(1)]
        public String FoodCategory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("IsAdmin")]
        [DataMember]
        [Required]
        
        public Boolean IsAdmin { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ExerciseNutritionPackageId")]
        [DataMember]
        [Required]
        
        public System.Guid ExerciseNutritionPackageId { get; set; }


    }
}
