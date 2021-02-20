using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NepFit.Repository.Entity
{

    [Serializable]
    [DataContract]
    public partial class NutritionPackage
    {
     /// <summary>
    /// We don't make constructor public and forcing to create object using <see cref="Create"/> method.
    /// But constructor can not be private since it's used by EntityFramework.
    /// Thats why we did it protected.
    /// </summary>
    public NutritionPackage()
    {

    }
        public static  NutritionPackage Create(
                        String name,
                        String description)
    {
        var @objectToReturn = new NutritionPackage
        {
          
            NutritionPackageId = Guid.NewGuid(),
            Name = name,
            Description = description
        };

        return @objectToReturn;
    }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NutritionPackageId")]
        [DataMember]
        
        [Key, Column(Order = 0)]
        public  System.Guid NutritionPackageId { get; set; }

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

    }

}


