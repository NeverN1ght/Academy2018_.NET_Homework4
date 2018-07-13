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
    public class AirplanesService: IService<AirplaneDto>
    {
        private readonly IRepository<Airplane> _repository;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<AirplaneDto> _validator;

        public AirplanesService(
            IRepository<Airplane> repository, 
            IMapper mapper,
            AbstractValidator<AirplaneDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public IEnumerable<AirplaneDto> GetAll()
        {
            return _mapper.Map<IEnumerable<Airplane>, IEnumerable<AirplaneDto>>(
                _repository.Get());
        }

        public AirplaneDto GetById(object id)
        {
            var response = _mapper.Map<Airplane, AirplaneDto>(
                _repository.Get().FirstOrDefault(a => a.Id == (int)id));

            if (response == null)
            {
                throw new NotExistException();
            }

            return response;
        }

        public object Add(AirplaneDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            var validationResult = _validator.Validate(dto);

            if (validationResult.IsValid)
            {
                return _repository.Create(
                    _mapper.Map<AirplaneDto, Airplane>(dto));
            }

            throw new ValidationException(validationResult.Errors);
        }

        public void Update(object id, AirplaneDto dto)
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
                        _mapper.Map<AirplaneDto, Airplane>(dto));
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
