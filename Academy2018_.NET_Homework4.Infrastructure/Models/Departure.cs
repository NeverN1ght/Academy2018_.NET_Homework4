using System;
using Academy2018_.NET_Homework4.Infrastructure.Abstractions;

namespace Academy2018_.NET_Homework4.Infrastructure.Models
{
    public class Departure : IEntity
    {
        public int Id { get; set; }

        public string FlightNumber { get; set; }

        public DateTime DepartureTime { get; set; }

        public Crew Crew { get; set; }

        public Airplane Airplane { get; set; }
    }
}
