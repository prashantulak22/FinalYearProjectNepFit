using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NepFit.Repository.Entity
{

    [Serializable]
    [DataContract]
    [Table("NepFitUser", Schema="dbo")]
    public partial class NepFitUser
    {
     /// <summary>
    /// We don't make constructor public and forcing to create object using <see cref="Create"/> method.
    /// But constructor can not be private since it's used by EntityFramework.
    /// Thats why we did it protected.
    /// </summary>
    public NepFitUser()
    {

    }
        public static  NepFitUser Create(
                        String firstName,
                        String lastName,
                        DateTime dateOfBirth,
                        String gender,
                        String experienceLevel,
                        String foodCategory,
                        Boolean isAdmin,
                        System.Guid createdBy,
                        DateTime dateCreated,
                        System.Guid exerciseNutritionPackageId,
                        Boolean? active= null,
                        System.Guid? updatedBy= null,
                        DateTime? dateUpdated= null)
    {
        var @objectToReturn = new NepFitUser
        {
          
            UserId = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dateOfBirth,
            Gender = gender,
            ExperienceLevel = experienceLevel,
            FoodCategory = foodCategory,
            IsAdmin = isAdmin,
            Active = active,
            UpdatedBy = updatedBy,
            CreatedBy = createdBy,
            DateUpdated = dateUpdated,
            DateCreated = dateCreated,
            ExerciseNutritionPackageId = exerciseNutritionPackageId
        };

        return @objectToReturn;
    }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("UserId")]
        [DataMember]
        
        [Key, Column(Order = 0)]
        public  System.Guid UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("FirstName")]
        [DataMember]
        [Required]
        [StringLength(50)]
        public  String FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("LastName")]
        [DataMember]
        [Required]
        [StringLength(50)]
        public  String LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("DateOfBirth")]
        [DataMember]
        [Required]
        
        public  DateTime DateOfBirth { get; set; }

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
        [DisplayName("FoodCategory")]
        [DataMember]
        [Required]
        [StringLength(1)]
        public String FoodCategory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("IsAdmin")]
        [DataMember]
        [Required]
        
        public  Boolean IsAdmin { get; set; }

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
        [DisplayName("ExerciseNutritionPackageId")]
        [DataMember]
        [Required]
        
        public  System.Guid ExerciseNutritionPackageId { get; set; }

    }

}


