using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NepFit.Repository.Dto
{
    public class NutritionPackageResultDto
    {

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NutritionPackageId")]
        [DataMember]
        
        public System.Guid NutritionPackageId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Name")]
        [DataMember]
        [Required]
        [StringLength(5000)]
        public String Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Description")]
        [DataMember]
        [Required]
        [StringLength(5000)]
        public String Description { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }


    }
}
