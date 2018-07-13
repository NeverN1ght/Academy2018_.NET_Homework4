using System;
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
    public class FlightsService: IService<FlightDto>
    {
        private readonly IRepository<Flight> _repository;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<FlightDto> _validator;

        public FlightsService(
            IRepository<Flight> repository, 
            IMapper mapper,
            AbstractValidator<FlightDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public IEnumerable<FlightDto> GetAll()
        {
            return _mapper.Map<IEnumerable<Flight>, IEnumerable<FlightDto>>(
                _repository.Get());
        }

        public FlightDto GetById(object id)
        {
            var response = _mapper.Map<Flight, FlightDto>(
                _repository.Get().FirstOrDefault(f => f.Number == (string)id));

            if (response == null)
            {
                throw new NotExistException();
            }

            return response;
        }

        public object Add(FlightDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            var validationResult = _validator.Validate(dto);

            if (validationResult.IsValid)
            {
                return _repository.Create(
                    _mapper.Map<FlightDto, Flight>(dto));
            }

            throw new ValidationException(validationResult.Errors);
        }

        public void Update(object id, FlightDto dto)
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
                    _repository.Update((Guid)id,
                        _mapper.Map<FlightDto, Flight>(dto));
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
                _repository.Delete((Guid)id);
            }
            else
            {
                throw new NotExistException();
            }
        }
    }
}
