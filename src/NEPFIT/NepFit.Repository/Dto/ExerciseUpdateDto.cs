using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NepFit.Repository.Dto
{
    public class ExerciseUpdateDto  
    {

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ExerciseId")]
        [DataMember]
        
        public System.Guid ExerciseId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ChestExercise")]
        [DataMember]
        [Required]
        [StringLength(1)]
        public String ChestExercise { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("BackExercise")]
        [DataMember]
        [Required]
        [StringLength(1)]
        public String BackExercise { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ShoulderExercise")]
        [DataMember]
        [Required]
        [StringLength(1)]
        public String ShoulderExercise { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("BicepExercise")]
        [DataMember]
        [Required]
        [StringLength(1)]
        public String BicepExercise { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("TricepExercise")]
        [DataMember]
        [Required]
        [StringLength(1)]
        public String TricepExercise { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("LegExercise")]
        [DataMember]
        [Required]
        [StringLength(1)]
        public String LegExercise { get; set; }

    }
}
