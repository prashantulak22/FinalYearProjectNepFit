using System;
using System.Collections.Generic;
using AutoMapper;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository;

namespace NepFit.BL
{
    public class ExerciseTypeService : IExerciseTypeService
    {
        private readonly ExerciseTypeRepository _exerciseTypeRepository;
        private readonly IMapper _mapper;

        public ExerciseTypeService(ExerciseTypeRepository exerciseTypeRepository, IMapper mapper)
        {
            _exerciseTypeRepository = exerciseTypeRepository;
            _mapper = mapper;
        }

        public int Add(ExerciseTypeCreateDto inputDto)
        {
            return _exerciseTypeRepository.Add(_mapper.Map<ExerciseType>(inputDto));
        }

        public bool Update(ExerciseTypeUpdateDto input)
        {
            _exerciseTypeRepository.Update(_mapper.Map<ExerciseType>(input));
            return true;
        }

        public IEnumerable<ExerciseTypeResultDto> GetAll()
        {
            return
                _mapper.Map<IEnumerable<ExerciseTypeResultDto>>(
                _exerciseTypeRepository.GetAll());
        }

        public bool Delete(Guid id)
        {
            return _exerciseTypeRepository.Delete(id);
        }
    }
}
