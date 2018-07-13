using System;
using Academy2018_.NET_Homework4.Infrastructure.Abstractions;

namespace Academy2018_.NET_Homework4.Infrastructure.Models
{
    public class Stewardesse : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
