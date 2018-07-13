using System;
using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework4.Infrastructure.Abstractions;
using Academy2018_.NET_Homework4.Infrastructure.Data;
using Academy2018_.NET_Homework4.Infrastructure.Models;

namespace Academy2018_.NET_Homework4.Infrastructure.Repositories
{
    public class FlightsRepository: IRepository<Flight>
    {
        private readonly DataSource _dataSource;

        public FlightsRepository(DataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<Flight> Get()
        {
            return _dataSource.Flights;
        }

        public object Create(Flight entity)
        {
            _dataSource.Flights.Add(entity);

            return entity.Number;
        }

        public void Update(object id, Flight entity)
        {
            Delete(id);
            entity.Number = (string)id;
            _dataSource.Flights.Add(entity);
        }

        public void Delete(object id)
        {
            var entity = _dataSource.Flights.Find(f => f.Number == (string)id);
            Delete(entity);
        }

        public void Delete(Flight entity)
        {
            _dataSource.Flights.Remove(entity);
        }

        public bool IsExist(object id)
        {
            return _dataSource.Flights.FirstOrDefault(f => f.Number == (string) id) != null;
        }
    }
}
