using System;
using System.Collections.Generic;
using AutoMapper;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository;
using NepFit.Repository.Repository.Interface;

namespace NepFit.BL
{
    public class ExerciseRoutineService : IExerciseRoutineService
    {
        private readonly IExerciseRoutineRepository _exerciseRoutineRepository;
        private readonly IMapper _mapper;

        public ExerciseRoutineService(IExerciseRoutineRepository ExerciseRoutineRepository, IMapper mapper)
        {
            _exerciseRoutineRepository = ExerciseRoutineRepository;
            _mapper = mapper;
        }

        public int Add(ExerciseRoutineCreateDto inputDto)
        {
            inputDto.DateCreated = DateTime.Now;
            inputDto.DateUpdated = DateTime.Now;
            inputDto.UpdatedBy = inputDto.CreatedBy;
            inputDto.Active = true;
            return _exerciseRoutineRepository.Add(_mapper.Map<ExerciseRoutine>(inputDto));
        }

        public bool Update(ExerciseRoutineUpdateDto input)
        {
            var original = _exerciseRoutineRepository.GetById(input.ExerciseRoutineId);
            original.DateUpdated = DateTime.Now;
            _mapper.Map(input, original);
            _exerciseRoutineRepository.Update(original);
            return true;
        }

        public IEnumerable<ExerciseRoutineResultDto> GetAll()
        {
            return
                _mapper.Map<IEnumerable<ExerciseRoutineResultDto>>(
                _exerciseRoutineRepository.GetAll());
        }

        public bool Delete(ExerciseRoutineUpdateDto input)
        {
            var deleteObj = _mapper.Map<ExerciseRoutine>(input);
            deleteObj.DateUpdated = DateTime.Now;
            return _exerciseRoutineRepository.Delete(deleteObj);
        }
    }
}
