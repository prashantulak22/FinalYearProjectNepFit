using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NepFit.Repository.Dto
{
    public class ExerciseRoutineCreateDto
    {

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Name")]
        [DataMember]
        [Required]
        [StringLength(5000)]
        public String Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Description")]
        [DataMember]
        [Required]
        [StringLength(5000)]
        public String Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Repetition")]
        [DataMember]
        [Required]

        public Int32 Repetition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Duration")]
        [DataMember]
        [Required]

        public Int32 Duration { get; set; }

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
        [DisplayName("ExerciseTypeId")]
        [DataMember]
        [Required]

        public System.Guid ExerciseTypeId { get; set; }

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
