using System;
using System.Collections.Generic;
using AutoMapper;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.BL
{
    public class ExerciseNutritionPackageService : IExerciseNutritionPackageService
    {
        private readonly IExerciseNutritionPackageRepository _exerciseNutritionPackageRepository;
        private readonly IMapper _mapper;

        public ExerciseNutritionPackageService(IExerciseNutritionPackageRepository ExerciseNutritionPackageRepository, IMapper mapper)
        {
            _exerciseNutritionPackageRepository = ExerciseNutritionPackageRepository;
            _mapper = mapper;
        }

        public int Add(ExerciseNutritionPackageCreateDto inputDto)
        {
            inputDto.DateCreated = DateTime.Now;
            inputDto.DateUpdated = DateTime.Now;
            inputDto.UpdatedBy = inputDto.CreatedBy;
            inputDto.Active = true;
            return _exerciseNutritionPackageRepository.Add(_mapper.Map<ExerciseNutritionPackage>(inputDto));
        }

        public bool Update(ExerciseNutritionPackageUpdateDto input)
        {
            var original = _exerciseNutritionPackageRepository.GetById(input.ExerciseNutritionPackageId);
            original.DateUpdated = DateTime.Now;
            _mapper.Map(input, original);
            _exerciseNutritionPackageRepository.Update(original);
            return true;
        }

        public IEnumerable<ExerciseNutritionPackageResultDto> GetAll()
        {
            return
                
                _exerciseNutritionPackageRepository.GetAll();
        }

        public bool Delete(ExerciseNutritionPackageUpdateDto input)
        {
            var deleteObj = _mapper.Map<ExerciseNutritionPackage>(input);
            deleteObj.DateUpdated = DateTime.Now;
            return _exerciseNutritionPackageRepository.Delete(deleteObj);
        }
    }
}
