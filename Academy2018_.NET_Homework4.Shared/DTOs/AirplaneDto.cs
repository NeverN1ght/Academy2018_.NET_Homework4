using System;
using Academy2018_.NET_Homework4.Infrastructure.Models;

namespace Academy2018_.NET_Homework4.Shared.DTOs
{
    public class AirplaneDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AirplaneType Type { get; set; }

        public DateTime ReleaseDate { get; set; }

        public TimeSpan ExploitationTerm { get; set; }
    }
}
