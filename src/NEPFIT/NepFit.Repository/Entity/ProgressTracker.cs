using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NepFit.Repository.Entity
{

    [Serializable]
    [DataContract]
    [Table("ProgressTracker", Schema="dbo")]
    public partial class ProgressTracker
    {
     /// <summary>
    /// We don't make constructor public and forcing to create object using <see cref="Create"/> method.
    /// But constructor can not be private since it's used by EntityFramework.
    /// Thats why we did it protected.
    /// </summary>
    public ProgressTracker()
    {

    }
        public static  ProgressTracker Create(
                        Decimal newHeight,
                        Decimal newBodyMass,
                        Decimal newChestSize,
                        Decimal newArmSize,
                        Decimal newForearmSize,
                        Decimal newWristSize,
                        Decimal newNeckSize,
                        Decimal newUpperAbs,
                        Decimal newLowerAbs,
                        Decimal newHipSize,
                        Decimal newWaistSize,
                        Decimal newThighSize,
                        Decimal newCalveSize,
                        System.Guid userId,
                        DateTime dateCreated)
    {
        var @objectToReturn = new ProgressTracker
        {
          

            NewHeight = newHeight,
            NewBodyMass = newBodyMass,
            NewChestSize = newChestSize,
            NewArmSize = newArmSize,
            NewForearmSize = newForearmSize,
            NewWristSize = newWristSize,
            NewNeckSize = newNeckSize,
            NewUpperAbs = newUpperAbs,
            NewLowerAbs = newLowerAbs,
            NewHipSize = newHipSize,
            NewWaistSize = newWaistSize,
            NewThighSize = newThighSize,
            NewCalveSize = newCalveSize,
            UserId = userId,
            DateCreated = dateCreated
        };

        return @objectToReturn;
    }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ProgressTrackerId")]
        [DataMember]
        [Key, Column(Order = 0)]
        public  Int32 ProgressTrackerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewHeight")]
        [DataMember]
        [Required]
        
        public  Decimal NewHeight { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewBodyMass")]
        [DataMember]
        [Required]
        
        public  Decimal NewBodyMass { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewChestSize")]
        [DataMember]
        [Required]
        
        public  Decimal NewChestSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewArmSize")]
        [DataMember]
        [Required]
        
        public  Decimal NewArmSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewForearmSize")]
        [DataMember]
        [Required]
        
        public  Decimal NewForearmSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewWristSize")]
        [DataMember]
        [Required]
        
        public  Decimal NewWristSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewNeckSize")]
        [DataMember]
        [Required]
        
        public  Decimal NewNeckSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewUpperAbs")]
        [DataMember]
        [Required]
        
        public  Decimal NewUpperAbs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewLowerAbs")]
        [DataMember]
        [Required]
        
        public  Decimal NewLowerAbs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewHipSize")]
        [DataMember]
        [Required]
        
        public  Decimal NewHipSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewWaistSize")]
        [DataMember]
        [Required]
        
        public  Decimal NewWaistSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewThighSize")]
        [DataMember]
        [Required]
        
        public  Decimal NewThighSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("NewCalveSize")]
        [DataMember]
        [Required]
        
        public  Decimal NewCalveSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("UserId")]
        [DataMember]
        [Required]
        
        public  System.Guid UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("DateCreated")]
        [DataMember]
        [Required]
        
        public  DateTime DateCreated { get; set; }

    }

}


