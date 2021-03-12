using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NepFit.Repository.Entity
{

    [Serializable]
    [DataContract]
    [Table("NutritionRoutine", Schema="dbo")]
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
                        String description,
                        String howToPrepare,
                        System.Guid createdBy,
                        DateTime dateCreated,
                        System.Guid nutritionTypeId,
                        Boolean? active= null,
                        System.Guid? updatedBy= null,
                        DateTime? dateUpdated= null)
    {
        var @objectToReturn = new NutritionRoutine
        {
          
            NutritionRoutineId = Guid.NewGuid(),
            Name = name,
            Description = description,
            HowToPrepare = howToPrepare,
            Active = active,
            UpdatedBy = updatedBy,
            CreatedBy = createdBy,
            DateUpdated = dateUpdated,
            DateCreated = dateCreated,
            NutritionTypeId = nutritionTypeId
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
        [DisplayName("Description")]
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
        [StringLength(5000)]
        public  String HowToPrepare { get; set; }

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
        [DisplayName("NutritionTypeId")]
        [DataMember]
        [Required]
        
        public  System.Guid NutritionTypeId { get; set; }

    }

}


