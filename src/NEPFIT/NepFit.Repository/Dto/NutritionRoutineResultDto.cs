﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NepFit.Repository.Dto
{
    public class NutritionRoutineResultDto
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
        [DisplayName("Description_")]
        [DataMember]
        [Required]
        [StringLength(5000)]
        public String Description_ { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("HowToPrepare")]
        [DataMember]
        [Required]
        [StringLength(2147483647)]
        public String HowToPrepare { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NutritionId")]
        [DataMember]
        [Required]

        public System.Guid NutritionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NutritionPackageId")]
        [DataMember]
        [Required]

        public System.Guid NutritionPackageId { get; set; }

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
