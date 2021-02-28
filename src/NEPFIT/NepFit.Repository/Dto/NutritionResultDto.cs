using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NepFit.Repository.Dto
{
    class NutritionResultDto
    {
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NutritionId")]
        [DataMember]

        public System.Guid NutritionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("MealOne")]
        [DataMember]
        [Required]
        [StringLength(2147483647)]
        public String MealOne { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("MealTwo")]
        [DataMember]
        [Required]
        [StringLength(2147483647)]
        public String MealTwo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("MealThree")]
        [DataMember]
        [Required]
        [StringLength(2147483647)]
        public String MealThree { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("MealFour")]
        [DataMember]
        [Required]
        [StringLength(2147483647)]
        public String MealFour { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("MealFive")]
        [DataMember]
        [Required]
        [StringLength(2147483647)]
        public String MealFive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("MealSix")]
        [DataMember]
        [Required]
        [StringLength(2147483647)]
        public String MealSix { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("CreatedBy")]
        [DataMember]
        public String CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("UpdatedBy")]
        [DataMember]

        public String UpdatedBy { get; set; }
    }
}
