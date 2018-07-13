using System.Collections.Generic;
using Academy2018_.NET_Homework4.Infrastructure.Models;

namespace Academy2018_.NET_Homework4.Shared.DTOs
{
    public class CrewDto
    {
        public int Id { get; set; }

        public Pilot Pilot { get; set; }

        public List<Stewardesse> Stewardesses { get; set; }
    }
}
