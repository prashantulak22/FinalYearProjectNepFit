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
        [DisplayName("Sequence")]
        [DataMember]
        [Required]
        
        public Int32 Sequence { get; set; }

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
        [DisplayName("ExerciseId")]
        [DataMember]
        [Required]
        
        public System.Guid ExerciseId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ExercisePackageId")]
        [DataMember]
        [Required]
        
        public System.Guid ExercisePackageId { get; set; }


    }
}
