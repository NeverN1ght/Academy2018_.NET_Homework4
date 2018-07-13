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
    public class TicketsService: IService<TicketDto>
    {
        private readonly IRepository<Ticket> _repository;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<TicketDto> _validator;

        public TicketsService(
            IRepository<Ticket> repository, 
            IMapper mapper,
            AbstractValidator<TicketDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public IEnumerable<TicketDto> GetAll()
        {
            return _mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDto>>(
                _repository.Get());
        }

        public TicketDto GetById(object id)
        {
            var response = _mapper.Map<Ticket, TicketDto>(
                _repository.Get().FirstOrDefault(t => t.Id == (int)id));

            if (response == null)
            {
                throw new NotExistException();
            }

            return response;
        }

        public object Add(TicketDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            var validationResult = _validator.Validate(dto);

            if (validationResult.IsValid)
            {
                return _repository.Create(
                    _mapper.Map<TicketDto, Ticket>(dto));
            }

            throw new ValidationException(validationResult.Errors);
        }

        public void Update(object id, TicketDto dto)
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
                        _mapper.Map<TicketDto, Ticket>(dto));
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
