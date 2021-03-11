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
            CreateMap<ExercisePackageCreateDto, ExercisePackage>().ReverseMap();
            CreateMap<ExerciseRoutineCreateDto, ExerciseRoutine>().ReverseMap();
           

            CreateMap<ExerciseTypeCreateDto, ExerciseType>().ReverseMap();
            CreateMap<ExerciseTypeUpdateDto, ExerciseType>().ReverseMap();
            CreateMap<ExerciseTypeResultDto, ExerciseType>().ReverseMap();

            CreateMap<NutritionTypeCreateDto, ExerciseType>().ReverseMap();
            CreateMap<NutritionTypeUpdateDto, ExerciseType>().ReverseMap();
            CreateMap<NutritionTypeResultDto, ExerciseType>().ReverseMap();
        }
    }
}
