using System;
using System.Collections.Generic;
using Academy2018_.NET_Homework4.Infrastructure.Models;

namespace Academy2018_.NET_Homework4.Shared.DTOs
{
    public class FlightDto
    {
        public string Number { get; set; }

        public string DeparturePoint { get; set; }

        public string DestinationPoint { get; set; }

        public DateTime ArrivalTime { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
