using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NepFit.Repository.Entity
{

    [Serializable]
    [DataContract]
    [Table("UserExerciseNutrition", Schema="dbo")]
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
                        System.Guid createdBy,
                        DateTime dateCreated,
                        System.Guid userId,
                        System.Guid exerciseNutritionPackageId,
                        Boolean? active= null,
                        System.Guid? updatedBy= null,
                        DateTime? dateUpdated= null)
    {
        var @objectToReturn = new UserExerciseNutrition
        {
          
            UserExerciseNutritionId = Guid.NewGuid(),
            Active = active,
            UpdatedBy = updatedBy,
            CreatedBy = createdBy,
            DateUpdated = dateUpdated,
            DateCreated = dateCreated,
            UserId = userId,
            ExerciseNutritionPackageId = exerciseNutritionPackageId
        };

        return @objectToReturn;
    }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("UserExerciseNutritionId")]
        [DataMember]
        
        [Key, Column(Order = 0)]
        public  System.Guid UserExerciseNutritionId { get; set; }

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
        [DisplayName("ExerciseNutritionPackageId")]
        [DataMember]
        [Required]
        
        public  System.Guid ExerciseNutritionPackageId { get; set; }

    }

}


