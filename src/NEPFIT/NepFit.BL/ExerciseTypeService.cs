using System;
using System.Collections.Generic;
using AutoMapper;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.BL
{
    public class ExerciseTypeService : IExerciseTypeService
    {
        private readonly IExerciseTypeRepository _exerciseTypeRepository;
        private readonly IMapper _mapper;

        public ExerciseTypeService(IExerciseTypeRepository exerciseTypeRepository, IMapper mapper)
        {
            _exerciseTypeRepository = exerciseTypeRepository;
            _mapper = mapper;
        }

        public int Add(ExerciseTypeCreateDto inputDto)
        {
            inputDto.DateCreated = DateTime.Now;
            inputDto.DateUpdated = DateTime.Now;
            inputDto.UpdatedBy = inputDto.CreatedBy;
            inputDto.Active = true;
            return _exerciseTypeRepository.Add(_mapper.Map<ExerciseType>(inputDto));
        }

        public bool Update(ExerciseTypeUpdateDto input)
        {
            var original = _exerciseTypeRepository.GetById(input.ExerciseTypeId);
            original.DateUpdated = DateTime.Now;
            _mapper.Map(input, original);
            _exerciseTypeRepository.Update(original);
            return true;
        }

        public IEnumerable<ExerciseTypeResultDto> GetAll()
        {
            return
                _mapper.Map<IEnumerable<ExerciseTypeResultDto>>(
                _exerciseTypeRepository.GetAll());
        }

        public bool Delete(ExerciseTypeUpdateDto input)
        {
            var deleteObj = _mapper.Map<ExerciseType>(input);
            deleteObj.DateUpdated = DateTime.Now;
            return _exerciseTypeRepository.Delete(deleteObj);
        }
    }
}
