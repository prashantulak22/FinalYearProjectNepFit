using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NepFit.Repository.Entity
{

    [Serializable]
    [DataContract]
    public partial class Nutrition
    {
     /// <summary>
    /// We don't make constructor public and forcing to create object using <see cref="Create"/> method.
    /// But constructor can not be private since it's used by EntityFramework.
    /// Thats why we did it protected.
    /// </summary>
    public Nutrition()
    {

    }
        public static  Nutrition Create(
                        String mealOne,
                        String mealTwo,
                        String mealThree,
                        String mealFour,
                        String mealFive,
                        String mealSix)
    {
        var @objectToReturn = new Nutrition
        {
          
            NutritionId = Guid.NewGuid(),
            MealOne = mealOne,
            MealTwo = mealTwo,
            MealThree = mealThree,
            MealFour = mealFour,
            MealFive = mealFive,
            MealSix = mealSix
        };

        return @objectToReturn;
    }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NutritionId")]
        [DataMember]
        
        [Key, Column(Order = 0)]
        public  System.Guid NutritionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("MealOne")]
        [DataMember]
        [Required]
        [StringLength(2147483647)]
        public  String MealOne { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("MealTwo")]
        [DataMember]
        [Required]
        [StringLength(2147483647)]
        public  String MealTwo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("MealThree")]
        [DataMember]
        [Required]
        [StringLength(2147483647)]
        public  String MealThree { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("MealFour")]
        [DataMember]
        [Required]
        [StringLength(2147483647)]
        public  String MealFour { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("MealFive")]
        [DataMember]
        [Required]
        [StringLength(2147483647)]
        public  String MealFive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("MealSix")]
        [DataMember]
        [Required]
        [StringLength(2147483647)]
        public  String MealSix { get; set; }

    }

}


