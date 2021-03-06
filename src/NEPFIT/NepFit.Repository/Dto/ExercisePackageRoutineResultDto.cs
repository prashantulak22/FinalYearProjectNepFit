using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace NepFit.Repository.Dto
{
    public class ExercisePackageRoutineResultDto
    {

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ExercisePackageRoutineId")]
        [DataMember]

        public System.Guid ExercisePackageRoutineId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ExercisePackageId")]
        [DataMember]
        [Required]

        public System.Guid ExercisePackageId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ExerciseRoutineId")]
        [DataMember]
        [Required]

        public System.Guid ExerciseRoutineId { get; set; }

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
