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

            CreateMap<NutritionTypeCreateDto, NutritionType>().ReverseMap();
            CreateMap<NutritionTypeUpdateDto, NutritionType>().ReverseMap();
            CreateMap<NutritionTypeResultDto, NutritionType>().ReverseMap();
        }
    }
}
