using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NepFit.Repository.Dto
{
    public class NutritionRoutineUpdateDto  
    {

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NutritionRoutineId")]
        [DataMember]
        
        public System.Guid NutritionRoutineId { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("HowToPrepare")]
        [DataMember]
        [Required]
        [StringLength(5000)]
        public String HowToPrepare { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Active")]
        [DataMember]
        
        public Boolean? Active { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("UpdatedBy")]
        [DataMember]
        
        public System.Guid? UpdatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("CreatedBy")]
        [DataMember]
        [Required]
        
        public System.Guid CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("DateUpdated")]
        [DataMember]
        
        public DateTime? DateUpdated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("DateCreated")]
        [DataMember]
        [Required]
        
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NutritionTypeId")]
        [DataMember]
        [Required]
        
        public System.Guid NutritionTypeId { get; set; }

    }
}
