using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NepFit.Repository.Entity
{

    [Serializable]
    [DataContract]    
    public partial class Exercise
    {
     /// <summary>
    /// We don't make constructor public and forcing to create object using <see cref="Create"/> method.
    /// But constructor can not be private since it's used by EntityFramework.
    /// Thats why we did it protected.
    /// </summary>
    public Exercise()
    {

    }
        public static  Exercise Create(
                        String chestExercise,
                        String backExercise,
                        String shoulderExercise,
                        String bicepExercise,
                        String tricepExercise,
                        String legExercise)
    {
        var @objectToReturn = new Exercise
        {
          
            ExerciseId = Guid.NewGuid(),
            ChestExercise = chestExercise,
            BackExercise = backExercise,
            ShoulderExercise = shoulderExercise,
            BicepExercise = bicepExercise,
            TricepExercise = tricepExercise,
            LegExercise = legExercise
        };

        return @objectToReturn;
    }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ExerciseId")]
        [DataMember]
        
        [Key, Column(Order = 0)]
        public  System.Guid ExerciseId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ChestExercise")]
        [DataMember]
        [Required]
        [StringLength(1)]
        public  String ChestExercise { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("BackExercise")]
        [DataMember]
        [Required]
        [StringLength(1)]
        public  String BackExercise { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ShoulderExercise")]
        [DataMember]
        [Required]
        [StringLength(1)]
        public  String ShoulderExercise { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("BicepExercise")]
        [DataMember]
        [Required]
        [StringLength(1)]
        public  String BicepExercise { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("TricepExercise")]
        [DataMember]
        [Required]
        [StringLength(1)]
        public  String TricepExercise { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("LegExercise")]
        [DataMember]
        [Required]
        [StringLength(1)]
        public  String LegExercise { get; set; }

    }

}


