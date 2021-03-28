using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NepFit.Repository.Dto
{
    public class UserExerciseNutritionResultDto
    {
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("UserExerciseNutritionId")]
        [DataMember]

        public System.Guid UserExerciseNutritionId { get; set; }

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
        [DisplayName("UserId")]
        [DataMember]
        public System.Guid UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ExerciseNutritionPackageId")]
        [DataMember]
        [Required]

        public System.Guid ExerciseNutritionPackageId { get; set; }

        public String NepFitUserName {get; set;}

        public String ExercisePackageName { get; set; }


       
    }
}
