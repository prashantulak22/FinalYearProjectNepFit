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
    public class UserNotesService : IUserNotesService
    {
        private readonly IUserNotesRepository _userNotesRepository;
        private readonly IMapper _mapper;

        public UserNotesService(IUserNotesRepository userNotesRepository, IMapper mapper)
        {
            _userNotesRepository = userNotesRepository;
            _mapper = mapper;
        }

        public int Add(UserNotesCreateDto inputDto)
        {
            inputDto.DateCreated = DateTime.Now;
            inputDto.DateUpdated = DateTime.Now;
            inputDto.UpdatedBy = inputDto.CreatedBy;
            inputDto.Active = true;
            return _userNotesRepository.Add(_mapper.Map<UserNotes>(inputDto));
            
        }

        public bool Update(UserNotesUpdateDto input)
        {
            var original = _userNotesRepository.GetById(input.UserNotesId);
            original.DateUpdated = DateTime.Now;
            _mapper.Map(input, original);
            _userNotesRepository.Update(original);
            return true;
        }

        public IEnumerable<UserNotesResultDto> GetAll()
        {
            return
                _mapper.Map<IEnumerable<UserNotesResultDto>>(
                _userNotesRepository.GetAll());

        }


        public IEnumerable<UserNotesResultDto> GetByUserId(Guid userId)
        {
            return
            _mapper.Map<IEnumerable<UserNotesResultDto>>(
            _userNotesRepository.GetByUserId(userId));
        }

        public bool Delete(UserNotesUpdateDto input)
        {
            var deleteObj = _mapper.Map<UserNotes>(input);
            deleteObj.DateUpdated = DateTime.Now;
            return _userNotesRepository.Delete(deleteObj);
        }
    }
}
