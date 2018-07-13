using System;
using Academy2018_.NET_Homework4.Infrastructure.Abstractions;

namespace Academy2018_.NET_Homework4.Infrastructure.Models
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string FlightNumber { get; set; }
    }
}
