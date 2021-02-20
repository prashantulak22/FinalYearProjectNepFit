using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NepFit.Repository.Entity
{

    [Serializable]
    [DataContract]
    public partial class UserExerciseNutrition
    {
     /// <summary>
    /// We don't make constructor public and forcing to create object using <see cref="Create"/> method.
    /// But constructor can not be private since it's used by EntityFramework.
    /// Thats why we did it protected.
    /// </summary>
    public UserExerciseNutrition()
    {

    }
        public static  UserExerciseNutrition Create(
                        System.Guid userId,
                        System.Guid exerciseId,
                        System.Guid nutritionId)
    {
        var @objectToReturn = new UserExerciseNutrition
        {
          
            UserId = userId,
            ExerciseId = exerciseId,
            NutritionId = nutritionId
        };

        return @objectToReturn;
    }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("UserId")]
        [DataMember]
        [Required]
        
        public  System.Guid UserId { get; set; }

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
        [DisplayName("NutritionId")]
        [DataMember]
        [Required]
        
        public  System.Guid NutritionId { get; set; }

    }

}


