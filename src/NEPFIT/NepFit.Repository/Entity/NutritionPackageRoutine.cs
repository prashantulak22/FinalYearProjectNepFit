using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NepFit.Repository.Dto
{

    [Serializable]
    [DataContract]
    [Table("NutritionPackageRoutine", Schema="dbo")]
    public partial class NutritionPackageRoutine
    {
     /// <summary>
    /// We don't make constructor public and forcing to create object using <see cref="Create"/> method.
    /// But constructor can not be private since it's used by EntityFramework.
    /// Thats why we did it protected.
    /// </summary>
    public NutritionPackageRoutine()
    {

    }
        public static  NutritionPackageRoutine Create(
                        System.Guid nutritionPackageId,
                        System.Guid nutritionRoutineId,
                        System.Guid createdBy,
                        DateTime dateCreated,
                        Boolean? active= null,
                        System.Guid? updatedBy= null,
                        DateTime? dateUpdated= null)
    {
        var @objectToReturn = new NutritionPackageRoutine
        {
          
            NutritionPackageRoutineId = Guid.NewGuid(),
            NutritionPackageId = nutritionPackageId,
            NutritionRoutineId = nutritionRoutineId,
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
        [DisplayName("NutritionPackageRoutineId")]
        [DataMember]
        
        [Key, Column(Order = 0)]
        public  System.Guid NutritionPackageRoutineId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NutritionPackageId")]
        [DataMember]
        [Required]
        
        public  System.Guid NutritionPackageId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NutritionRoutineId")]
        [DataMember]
        [Required]
        
        public  System.Guid NutritionRoutineId { get; set; }

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


