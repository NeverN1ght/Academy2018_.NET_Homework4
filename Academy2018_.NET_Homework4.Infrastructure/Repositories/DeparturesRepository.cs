using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework4.Infrastructure.Abstractions;
using Academy2018_.NET_Homework4.Infrastructure.Data;
using Academy2018_.NET_Homework4.Infrastructure.Models;

namespace Academy2018_.NET_Homework4.Infrastructure.Repositories
{
    public class DeparturesRepository: IRepository<Departure>
    {
        private readonly DataSource _dataSource;

        public DeparturesRepository(DataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<Departure> Get()
        {
            return _dataSource.Departures;
        }

        public object Create(Departure entity)
        {
            entity.Id = _dataSource.Departures.Max(d => d.Id) + 1;
            _dataSource.Departures.Add(entity);

            return entity.Id;
        }

        public void Update(object id, Departure entity)
        {
            Delete(id);
            entity.Id = (int)id;
            _dataSource.Departures.Add(entity);
        }

        public void Delete(object id)
        {
            var entity = _dataSource.Departures.Find(d => d.Id == (int) id);
            Delete(entity);
        }

        public void Delete(Departure entity)
        {
            _dataSource.Departures.Remove(entity);
        }

        public bool IsExist(object id)
        {
            return _dataSource.Departures.FirstOrDefault(d => d.Id == (int) id) != null;
        }
    }
}
