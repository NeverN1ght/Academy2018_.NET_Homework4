using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework4.Infrastructure.Abstractions;
using Academy2018_.NET_Homework4.Infrastructure.Data;
using Academy2018_.NET_Homework4.Infrastructure.Models;

namespace Academy2018_.NET_Homework4.Infrastructure.Repositories
{
    public class TicketsRepository: IRepository<Ticket>
    {
        private readonly DataSource _dataSource;

        public TicketsRepository(DataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<Ticket> Get()
        {
            return _dataSource.Tickets;
        }

        public object Create(Ticket entity)
        {
            entity.Id = _dataSource.Tickets.Max(t => t.Id) + 1;
            _dataSource.Tickets.Add(entity);

            return entity.Id;
        }

        public void Update(object id, Ticket entity)
        {
            Delete(id);
            entity.Id = (int)id;
            _dataSource.Tickets.Add(entity);
        }

        public void Delete(object id)
        {
            var entity = _dataSource.Tickets.Find(t => t.Id == (int)id);
            Delete(entity);
        }

        public void Delete(Ticket entity)
        {
            _dataSource.Tickets.Remove(entity);
        }

        public bool IsExist(object id)
        {
            return _dataSource.Tickets.FirstOrDefault(t => t.Id == (int) id) != null;         
        }
    }
}
