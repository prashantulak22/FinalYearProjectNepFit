using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NepFit.Repository.Dto
{
    public class ExercisePackageUpdateDto
    {

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ExercisePackageId")]
        [DataMember]

        public System.Guid ExercisePackageId { get; set; }

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
        [DisplayName("UpdatedBy")]
        [DataMember]

        public System.Guid? UpdatedBy { get; set; }

       

    }
}
