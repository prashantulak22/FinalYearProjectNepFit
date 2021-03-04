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
            CreateMap<ExerciseCreateDto, Exercise>().ReverseMap();
            CreateMap<NutritionPackageCreateDto, NutritionPackage>().ReverseMap();
            CreateMap<NutritionCreateDto, Nutrition>().ReverseMap();
            CreateMap<NutritionRoutineCreateDto, NutritionRoutine>().ReverseMap();
        }
    }
}
