using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework4.Infrastructure.Abstractions;
using Academy2018_.NET_Homework4.Infrastructure.Data;
using Academy2018_.NET_Homework4.Infrastructure.Models;

namespace Academy2018_.NET_Homework4.Infrastructure.Repositories
{
    public class StewardessesRepository: IRepository<Stewardesse>
    {
        private readonly DataSource _dataSource;

        public StewardessesRepository(DataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<Stewardesse> Get()
        {
            return _dataSource.Stewardesses;
        }

        public object Create(Stewardesse entity)
        {
            entity.Id = _dataSource.Stewardesses.Max(s => s.Id) + 1;
            _dataSource.Stewardesses.Add(entity);

            return entity.Id;
        }

        public void Update(object id, Stewardesse entity)
        {
            Delete(id);
            entity.Id = (int)id;
            _dataSource.Stewardesses.Add(entity);
        }

        public void Delete(object id)
        {
            var entity = _dataSource.Stewardesses.Find(p => p.Id == (int)id);
            Delete(entity);
        }

        public void Delete(Stewardesse entity)
        {
            _dataSource.Stewardesses.Remove(entity);
        }

        public bool IsExist(object id)
        {
            return _dataSource.Stewardesses.FirstOrDefault(s => s.Id == (int) id) != null;
        }
    }
}
