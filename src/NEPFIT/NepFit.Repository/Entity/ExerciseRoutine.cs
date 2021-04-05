using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NepFit.Repository.Entity
{

    [Serializable]
    [DataContract]
    [Table("ExerciseRoutine", Schema="dbo")]
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
                        Int32 duration,
                        String gender,
                        String experienceLevel,
                        System.Guid exerciseTypeId,
                        System.Guid createdBy,
                        DateTime dateCreated,
                        Boolean? active= null,
                        System.Guid? updatedBy= null,
                        DateTime? dateUpdated= null)
    {
        var @objectToReturn = new ExerciseRoutine
        {
          
            ExerciseRoutineId = Guid.NewGuid(),
            Name = name,
            Description = description,
            Repetition = repetition,
            Duration = duration,
            Gender = gender,
            ExperienceLevel = experienceLevel,
            ExerciseTypeId = exerciseTypeId,
            Active = active,
            UpdatedBy = updatedBy,
            CreatedBy = createdBy,
            DateUpdated = dateUpdated,
            DateCreated = dateCreated
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
        [DisplayName("Duration")]
        [DataMember]
        [Required]
        
        public  Int32 Duration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Gender")]
        [DataMember]
        [Required]
        [StringLength(1)]
        public  String Gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ExperienceLevel")]
        [DataMember]
        [Required]
        [StringLength(1)]
        public  String ExperienceLevel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ExerciseTypeId")]
        [DataMember]
        [Required]
        
        public  System.Guid ExerciseTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Active")]
        [DataMember]
        
        public  Boolean? Active { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("UpdatedBy")]
        [DataMember]
        
        public  System.Guid? UpdatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("CreatedBy")]
        [DataMember]
        [Required]
        
        public  System.Guid CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("DateUpdated")]
        [DataMember]
        
        public  DateTime? DateUpdated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("DateCreated")]
        [DataMember]
        [Required]
        
        public  DateTime DateCreated { get; set; }

    }

}


