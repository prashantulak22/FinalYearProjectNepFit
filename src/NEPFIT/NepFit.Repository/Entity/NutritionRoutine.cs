using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NepFit.Repository.Entity
{

    [Serializable]
    [DataContract]
    public partial class NutritionRoutine
    {
     /// <summary>
    /// We don't make constructor public and forcing to create object using <see cref="Create"/> method.
    /// But constructor can not be private since it's used by EntityFramework.
    /// Thats why we did it protected.
    /// </summary>
    public NutritionRoutine()
    {

    }
        public static  NutritionRoutine Create(
                        String name,
                        String description ,
                        String howToPrepare,
                        System.Guid nutritionId,
                        System.Guid nutritionPackageId)
    {
        var @objectToReturn = new NutritionRoutine
        {
          
            NutritionRoutineId = Guid.NewGuid(),
            Name = name,
            Description  = description ,
            HowToPrepare = howToPrepare,
            NutritionId = nutritionId,
            NutritionPackageId = nutritionPackageId
        };

        return @objectToReturn;
    }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NutritionRoutineId")]
        [DataMember]
        
        [Key, Column(Order = 0)]
        public  System.Guid NutritionRoutineId { get; set; }

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
        [DisplayName("Description_")]
        [DataMember]
        [Required]
        [StringLength(5000)]
        public  String Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("HowToPrepare")]
        [DataMember]
        [Required]
        [StringLength(2147483647)]
        public  String HowToPrepare { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NutritionId")]
        [DataMember]
        [Required]
        
        public  System.Guid NutritionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NutritionPackageId")]
        [DataMember]
        [Required]
        
        public  System.Guid NutritionPackageId { get; set; }

    }

}


