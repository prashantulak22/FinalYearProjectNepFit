using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NepFit.Repository.Entity
{

    [Serializable]
    [DataContract]
    public partial class ExerciseRoutine
    {
     /// <summary>
    /// We don't make constructor public and forcing to create object using <see cref="Create"/> method.
    /// But constructor can not be private since it's used by EntityFramework.
    /// Thats why we did it protected.
    /// </summary>
    public ExerciseRoutine()
    {

    }
        public static  ExerciseRoutine Create(
                        String name,
                        String description,
                        Int32 repetition,
                        Int32 sequence,
                        Int32 duration,
                        System.Guid exerciseId,
                        System.Guid exercisePackageId)
    {
        var @objectToReturn = new ExerciseRoutine
        {
          
            ExerciseRoutineId = Guid.NewGuid(),
            Name = name,
            Description = description,
            Repetition = repetition,
            Sequence = sequence,
            Duration = duration,
            ExerciseId = exerciseId,
            ExercisePackageId = exercisePackageId
        };

        return @objectToReturn;
    }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ExerciseRoutineId")]
        [DataMember]
        
        [Key, Column(Order = 0)]
        public  System.Guid ExerciseRoutineId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Name")]
        [DataMember]
        [Required]
        [StringLength(5000)]
        public  String Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Description")]
        [DataMember]
        [Required]
        [StringLength(5000)]
        public  String Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Repetition")]
        [DataMember]
        [Required]
        
        public  Int32 Repetition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Sequence")]
        [DataMember]
        [Required]
        
        public  Int32 Sequence { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Duration")]
        [DataMember]
        [Required]
        
        public  Int32 Duration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ExerciseId")]
        [DataMember]
        [Required]
        
        public  System.Guid ExerciseId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ExercisePackageId")]
        [DataMember]
        [Required]
        
        public  System.Guid ExercisePackageId { get; set; }

    }

}


