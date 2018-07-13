using System;
using Academy2018_.NET_Homework4.Infrastructure.Abstractions;

namespace Academy2018_.NET_Homework4.Infrastructure.Models
{
    public class Airplane: IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AirplaneType Type { get; set; }

        public DateTime ReleaseDate { get; set; }

        public TimeSpan ExploitationTerm { get; set; }
    }
}
