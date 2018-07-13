using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework4.Infrastructure.Abstractions;
using Academy2018_.NET_Homework4.Infrastructure.Data;
using Academy2018_.NET_Homework4.Infrastructure.Models;

namespace Academy2018_.NET_Homework4.Infrastructure.Repositories
{
    public class PilotsRepository: IRepository<Pilot>
    {
        private readonly DataSource _dataSource;

        public PilotsRepository(DataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<Pilot> Get()
        {
            return _dataSource.Pilots;
        }

        public object Create(Pilot entity)
        {
            entity.Id = _dataSource.Pilots.Max(p => p.Id) + 1;
            _dataSource.Pilots.Add(entity);

            return entity.Id;
        }

        public void Update(object id, Pilot entity)
        {
            Delete(id);
            entity.Id = (int)id;
            _dataSource.Pilots.Add(entity);
        }

        public void Delete(object id)
        {
            var entity = _dataSource.Pilots.Find(p => p.Id == (int)id);
            Delete(entity);
        }

        public void Delete(Pilot entity)
        {
            _dataSource.Pilots.Remove(entity);
        }

        public bool IsExist(object id)
        {
            return _dataSource.Pilots.FirstOrDefault(p => p.Id == (int) id) != null;
        }
    }
}
