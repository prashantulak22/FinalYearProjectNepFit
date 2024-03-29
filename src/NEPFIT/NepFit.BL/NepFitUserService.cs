﻿using AutoMapper;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;
using System;
using System.Collections.Generic;


namespace NepFit.BL
{
    public class NepFitUserService : INepFitUserService
    {
        private readonly INepFitUserRepository _nepFitUserRepository;
        private readonly IMapper _mapper;

        public NepFitUserService(INepFitUserRepository nepFitUserRepository, IMapper mapper)
        {
            _nepFitUserRepository = nepFitUserRepository;
            _mapper = mapper;
        }

        public int Add(NepFitUserCreateDto inputDto)
        {
            if (GetByUserId(inputDto.CreatedBy) == null)
            {
                inputDto.DateCreated = DateTime.Now; 
                inputDto.DateUpdated = DateTime.Now;
                inputDto.UpdatedBy = inputDto.CreatedBy;
                inputDto.Active = true;
                return _nepFitUserRepository.Add(_mapper.Map<NepFitUser>(inputDto));

            }

            Update((_mapper.Map<NepFitUserUpdateDto>(inputDto)));
            return 1;

        }

        public bool Update(NepFitUserUpdateDto input)
        {
            var original = _nepFitUserRepository.GetByUserId(input.CreatedBy);
            original.DateUpdated = DateTime.Now;
            input.UserId = original.UserId;
            _mapper.Map(input, original);
            _nepFitUserRepository.Update(original);
            return true;
        }

        public IEnumerable<NepFitUserResultDto> GetAll()
        {
            return

                _nepFitUserRepository.GetAll();
        }

        public bool Delete(NepFitUserUpdateDto input)
        {
            var deleteObj = _mapper.Map<NepFitUser>(input);
            deleteObj.DateUpdated = DateTime.Now;
            return _nepFitUserRepository.Delete(deleteObj);
        }

        public NepFitUserResultDto GetByUserId(Guid id)
        {
            return
                _mapper.Map<NepFitUserResultDto>(
                    _nepFitUserRepository.GetByUserId(id));
        }
    }
}
