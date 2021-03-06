using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
namespace NepFit.Repository.Entity { 

[Serializable]
[DataContract]
[Table("ExercisePackageRoutine", Schema = "dbo")]
public partial class ExercisePackageRoutine
{
    /// <summary>
    /// We don't make constructor public and forcing to create object using <see cref="Create"/> method.
    /// But constructor can not be private since it's used by EntityFramework.
    /// Thats why we did it protected.
    /// </summary>
    public ExercisePackageRoutine()
    {

    }
    public static ExercisePackageRoutine Create(
                    System.Guid exercisePackageId,
                    System.Guid exerciseRoutineId,
                    System.Guid createdBy,
                    DateTime dateCreated,
                    Boolean? active = null,
                    System.Guid? updatedBy = null,
                    DateTime? dateUpdated = null)
    {
        var @objectToReturn = new ExercisePackageRoutine
        {

            ExercisePackageRoutineId = Guid.NewGuid(),
            ExercisePackageId = exercisePackageId,
            ExerciseRoutineId = exerciseRoutineId,
            Active = active,
            UpdatedBy = updatedBy,
            CreatedBy = createdBy,
            DateUpdated = dateUpdated,
            DateCreated = dateCreated
        };

        return @objectToReturn;
    }

    /// <summary>
    /// 
    /// </summary>
    [DisplayName("ExercisePackageRoutineId")]
    [DataMember]

    [Key, Column(Order = 0)]
    public System.Guid ExercisePackageRoutineId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [DisplayName("ExercisePackageId")]
    [DataMember]
    [Required]

    public System.Guid ExercisePackageId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [DisplayName("ExerciseRoutineId")]
    [DataMember]
    [Required]

    public System.Guid ExerciseRoutineId { get; set; }

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

}

}
