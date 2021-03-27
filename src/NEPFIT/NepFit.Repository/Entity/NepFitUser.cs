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
                        Int64 mobileNumber)
    {
        var @objectToReturn = new NepFitUser
        {
          
            UserId = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dateOfBirth,
            Gender = gender,
            MobileNumber = mobileNumber
        };

        return @objectToReturn;
    }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("UserId")]
        [DataMember]        
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
        [DisplayName("MobileNumber")]
        [DataMember]
        [Required]
        
        public  Int64 MobileNumber { get; set; }
        public DateTime DateUpdated { get; set; }
    }

}


