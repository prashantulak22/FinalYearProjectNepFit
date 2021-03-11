using AutoMapper;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;
using System;
using System.Collections.Generic;

namespace NepFit.BL
{
    public class ExercisePackageService : IExercisePackageService
    {
        private readonly IExercisePackageRepository _exercisePackageRepository;
        private readonly IMapper _mapper;

        public ExercisePackageService(IExercisePackageRepository exercisePackageRepository, IMapper mapper)
        {
            _exercisePackageRepository = exercisePackageRepository;
            _mapper = mapper;
        }

        public int Add(ExercisePackageCreateDto inputDto)
        {
            inputDto.DateCreated = DateTime.Now;
            inputDto.DateUpdated = DateTime.Now;
            inputDto.UpdatedBy = inputDto.CreatedBy;
            inputDto.Active = true;
            return _exercisePackageRepository.Add(_mapper.Map<ExercisePackage>(inputDto));
        }
        public bool Update(ExercisePackageUpdateDto input)
        {
            var original = _exercisePackageRepository.GetById(input.ExercisePackageId);
            original.DateUpdated = DateTime.Now;
            _mapper.Map(input, original);
            _exercisePackageRepository.Update(original);
            return true;
        }
        public IEnumerable<ExercisePackageResultDto> GetAll()
        {
            return
                _mapper.Map<IEnumerable<ExercisePackageResultDto>>(
                _exercisePackageRepository.GetAll());
        }
        public bool Delete(ExercisePackageUpdateDto input)
        {
            var deleteObj = _mapper.Map<ExercisePackage>(input);
            deleteObj.DateUpdated = DateTime.Now;
            return _exercisePackageRepository.Delete(deleteObj);
        }

        
    }
}
