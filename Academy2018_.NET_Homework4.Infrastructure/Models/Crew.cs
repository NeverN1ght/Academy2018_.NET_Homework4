using System.Collections.Generic;
using Academy2018_.NET_Homework4.Infrastructure.Abstractions;

namespace Academy2018_.NET_Homework4.Infrastructure.Models
{
    public class Crew : IEntity
    {
        public int Id { get; set; }

        public Pilot Pilot { get; set; }

        public List<Stewardesse> Stewardesses { get; set; }
    }
}
