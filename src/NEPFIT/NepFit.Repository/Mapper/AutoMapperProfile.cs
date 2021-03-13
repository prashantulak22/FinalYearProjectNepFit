using AutoMapper;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;

namespace NepFit.Repository.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BodyMetricsCreateDto, BodyMetrics>().ReverseMap();
            CreateMap<ProgressTrackerResultDto, ProgressTracker>().ReverseMap();
            CreateMap<ProgressTrackerChartResultDto, ProgressTracker>().ReverseMap();
            
            CreateMap<ExerciseTypeCreateDto, ExerciseType>().ReverseMap();
            CreateMap<ExerciseTypeUpdateDto, ExerciseType>().ReverseMap();
            CreateMap<ExerciseTypeResultDto, ExerciseType>().ReverseMap();

            CreateMap<ExercisePackageCreateDto, ExercisePackage>().ReverseMap();
            CreateMap<ExercisePackageUpdateDto, ExercisePackage>().ReverseMap();
            CreateMap<ExercisePackageResultDto, ExercisePackage>().ReverseMap();

            CreateMap<ExerciseRoutineCreateDto, ExerciseRoutine>().ReverseMap();
            CreateMap<ExerciseRoutineUpdateDto, ExerciseRoutine>().ReverseMap();
            CreateMap<ExerciseRoutineResultDto, ExerciseRoutine>().ReverseMap();

            CreateMap<ExercisePackageRoutineCreateDto, ExercisePackageRoutine>().ReverseMap();
            CreateMap<ExercisePackageRoutineUpdateDto, ExercisePackageRoutine>().ReverseMap();
            CreateMap<ExercisePackageRoutineResultDto, ExercisePackageRoutine>().ReverseMap();

            CreateMap<NutritionTypeCreateDto, NutritionType>().ReverseMap();
            CreateMap<NutritionTypeUpdateDto, NutritionType>().ReverseMap();
            CreateMap<NutritionTypeResultDto, NutritionType>().ReverseMap();

            CreateMap<NutritionPackageCreateDto, NutritionPackage>().ReverseMap();
            CreateMap<NutritionPackageUpdateDto, NutritionPackage>().ReverseMap();
            CreateMap<NutritionPackageResultDto, NutritionPackage>().ReverseMap();

            CreateMap<NutritionRoutineCreateDto, NutritionRoutine>().ReverseMap();
            CreateMap<NutritionRoutineUpdateDto, NutritionRoutine>().ReverseMap();
            CreateMap<NutritionRoutineResultDto, NutritionRoutine>().ReverseMap();

            CreateMap<NutritionPackageRoutineCreateDto, NutritionPackageRoutine>().ReverseMap();
            CreateMap<NutritionPackageRoutineUpdateDto, NutritionPackageRoutine>().ReverseMap();
            CreateMap<NutritionPackageRoutineResultDto, NutritionPackageRoutine>().ReverseMap();
        }
    }
}
