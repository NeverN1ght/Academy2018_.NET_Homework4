using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework4.Core.Abstractions;
using Academy2018_.NET_Homework4.Infrastructure.Abstractions;
using Academy2018_.NET_Homework4.Infrastructure.Models;
using Academy2018_.NET_Homework4.Shared.DTOs;
using Academy2018_.NET_Homework4.Shared.Exceptions;
using AutoMapper;
using FluentValidation;

namespace Academy2018_.NET_Homework4.Core.Services
{
    public class CrewsService: IService<CrewDto>
    {
        private readonly IRepository<Crew> _repository;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<CrewDto> _validator;

        public CrewsService(
            IRepository<Crew> repository, 
            IMapper mapper,
            AbstractValidator<CrewDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public IEnumerable<CrewDto> GetAll()
        {
            return _mapper.Map<IEnumerable<Crew>, IEnumerable<CrewDto>>(
                _repository.Get());
        }

        public CrewDto GetById(object id)
        {
            var response = _mapper.Map<Crew, CrewDto>(
                _repository.Get().FirstOrDefault(c => c.Id == (int)id));

            if (response == null)
            {
                throw new NotExistException();
            }

            return response;
        }

        public object Add(CrewDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            var validationResult = _validator.Validate(dto);

            if (validationResult.IsValid)
            {
                return _repository.Create(
                    _mapper.Map<CrewDto, Crew>(dto));
            }

            throw new ValidationException(validationResult.Errors);
        }

        public void Update(object id, CrewDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            if (_repository.IsExist(id))
            {
                var validationResult = _validator.Validate(dto);

                if (validationResult.IsValid)
                {
                    _repository.Update((int)id,
                        _mapper.Map<CrewDto, Crew>(dto));
                }
                else
                {
                    throw new ValidationException(validationResult.Errors);
                }
            }
            else
            {
                throw new NotExistException();
            }
        }

        public void Delete(object id)
        {
            if (_repository.IsExist(id))
            {
                _repository.Delete((int)id);
            }
            else
            {
                throw new NotExistException();
            }
        }
    }
}
