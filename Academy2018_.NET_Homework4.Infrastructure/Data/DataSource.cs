using System;
using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework4.Infrastructure.Models;

namespace Academy2018_.NET_Homework4.Infrastructure.Data
{
    public class DataSource
    {
        public List<Pilot> Pilots { get; set; }

        public List<Stewardesse> Stewardesses { get; set; }

        public List<Crew> Crews { get; set; }

        public List<AirplaneType> AirplaneTypes { get; set; }

        public List<Airplane> Airplanes { get; set; }

        public List<Flight> Flights { get; set; }

        public List<Ticket> Tickets { get; set; }

        public List<Departure> Departures { get; set; }

        public DataSource()
        {
            #region Pilots initializing                      

            Pilots = new List<Pilot>();

            Pilots.Add(new Pilot {
                Id = 1,
                FirstName = "Petro",
                LastName = "Chernov",
                Birthdate = new DateTime(1990, 2, 5),
                Experience = 5
            });
            Pilots.Add(new Pilot {
                Id = 2,
                FirstName = "Alex",
                LastName = "Yaschenko",
                Birthdate = new DateTime(1983, 6, 28),
                Experience = 3
            });
            Pilots.Add(new Pilot {
                Id = 3,
                FirstName = "Ivan",
                LastName = "Golub",
                Birthdate = new DateTime(1993, 12, 31),
                Experience = 1
            });
            Pilots.Add(new Pilot {
                Id = 4,
                FirstName = "Anrew",
                LastName = "Novikov",
                Birthdate = new DateTime(1975, 8, 14),
                Experience = 8
            });

            #endregion

            #region Stewardesses initializing

            Stewardesses = new List<Stewardesse>();

            Stewardesses.Add(new Stewardesse {
                Id = 1,
                FirstName = "Natalia",
                LastName = "Korobko",
                Birthdate = new DateTime(1986, 5, 21)
            });
            Stewardesses.Add(new Stewardesse {
                Id = 2,
                FirstName = "Olha",
                LastName = "Bilyk",
                Birthdate = new DateTime(1979, 6, 27)
            });
            Stewardesses.Add(new Stewardesse {
                Id = 3,
                FirstName = "Nina",
                LastName = "Ivanova",
                Birthdate = new DateTime(1995, 9, 17)
            });
            Stewardesses.Add(new Stewardesse {
                Id = 4,
                FirstName = "Viktoria",
                LastName = "Petrova",
                Birthdate = new DateTime(1997, 7, 17)
            });
            Stewardesses.Add(new Stewardesse {
                Id = 5,
                FirstName = "Daria",
                LastName = "Kolomiets",
                Birthdate = new DateTime(1991, 3, 13)
            });
            Stewardesses.Add(new Stewardesse {
                Id = 6,
                FirstName = "Maria",
                LastName = "Bondarenko",
                Birthdate = new DateTime(1994, 10, 5)
            });
            Stewardesses.Add(new Stewardesse {
                Id = 7,
                FirstName = "Anastasia",
                LastName = "Golovko",
                Birthdate = new DateTime(1989, 12, 25)
            });

            #endregion

            #region Crews initializing

            Crews = new List<Crew>();

            Crews.Add(new Crew {
                Id = 1,
                Pilot = Pilots.Find(p => p.Id == 1),
                Stewardesses = new List<Stewardesse> {
                    Stewardesses.Find(s => s.Id == 1)
                }
            });
            Crews.Add(new Crew {
                Id = 2,
                Pilot = Pilots.Find(p => p.Id == 2),
                Stewardesses = new List<Stewardesse> {
                    Stewardesses.Find(s => s.Id == 2),
                    Stewardesses.Find(s => s.Id == 3)
                }
            });
            Crews.Add(new Crew {
                Id = 3,
                Pilot = Pilots.Find(p => p.Id == 3),
                Stewardesses = new List<Stewardesse> {
                    Stewardesses.Find(s => s.Id == 4),
                    Stewardesses.Find(s => s.Id == 5),
                    Stewardesses.Find(s => s.Id == 6)
                }
            });

            #endregion

            #region AirplaneTypes initializing

            AirplaneTypes = new List<AirplaneType>();

            AirplaneTypes.Add(new AirplaneType {
                Id = 1,
                AirplaneModel = "Typolev Ty-134",
                CarryingCapacity = 47000,
                SeatsCount = 96
            });
            AirplaneTypes.Add(new AirplaneType {
                Id = 2,
                AirplaneModel = "Typolev Ty-154",
                CarryingCapacity = 52000,
                SeatsCount = 158
            });
            AirplaneTypes.Add(new AirplaneType {
                Id = 3,
                AirplaneModel = "Sukhoi SuperJet-100",
                CarryingCapacity = 45900,
                SeatsCount = 86
            });
            AirplaneTypes.Add(new AirplaneType {
                Id = 4,
                AirplaneModel = "Illyushin IL-62",
                CarryingCapacity = 280300,
                SeatsCount = 198
            });
            AirplaneTypes.Add(new AirplaneType {
                Id = 5,
                AirplaneModel = "Airbus A310",
                CarryingCapacity = 164000,
                SeatsCount = 183
            });

            #endregion

            #region Airplanes initializing

            Airplanes = new List<Airplane>();

            Airplanes.Add(new Airplane {
                Id = 1,
                Name = "A. Dayneka",
                Type = AirplaneTypes.Find(t => t.Id == 1),
                ExploitationTerm = new TimeSpan(1000, 0, 0, 0),
                ReleaseDate = new DateTime(1985, 5, 21)
            });
            Airplanes.Add(new Airplane {
                Id = 2,
                Name = "Manchester United",
                Type = AirplaneTypes.Find(t => t.Id == 2),
                ExploitationTerm = new TimeSpan(1200, 0, 0, 0),
                ReleaseDate = new DateTime(1990, 7, 12)
            });
            Airplanes.Add(new Airplane {
                Id = 3,
                Name = "Retro",
                Type = AirplaneTypes.Find(t => t.Id == 4),
                ExploitationTerm = new TimeSpan(900, 0, 0, 0),
                ReleaseDate = new DateTime(1980, 12, 11)
            });
            Airplanes.Add(new Airplane {
                Id = 4,
                Name = "SKYTEAM",
                Type = AirplaneTypes.Find(t => t.Id == 5),
                ExploitationTerm = new TimeSpan(700, 0, 0, 0),
                ReleaseDate = new DateTime(1989, 2, 27)
            });
            #endregion

            #region Tickets initializing

            Tickets = new List<Ticket>();

            var flightNumbers = new List<string>
            {
                "DY-2891",
                "AC-3948",
                "KO-8712"
            };

            Tickets = new List<Ticket>();
            for (int i = 0; i < 35; i++)
            {
                Tickets.Add(new Ticket {
                    Id = i,
                    FlightNumber = flightNumbers[0],
                    Price = 200m
                });
                Tickets.Add(new Ticket {
                    Id = i + 35,
                    FlightNumber = flightNumbers[0],
                    Price = 400m
                });
                Tickets.Add(new Ticket {
                    Id = i + 70,
                    FlightNumber = flightNumbers[0],
                    Price = 600m
                });
                Tickets.Add(new Ticket {
                    Id = i + 105,
                    FlightNumber = flightNumbers[1],
                    Price = 100m
                });
                Tickets.Add(new Ticket {
                    Id = i + 140,
                    FlightNumber = flightNumbers[1],
                    Price = 150m
                });
                Tickets.Add(new Ticket {
                    Id = i + 175,
                    FlightNumber = flightNumbers[1],
                    Price = 450m
                });
                Tickets.Add(new Ticket {
                    Id = i + 210,
                    FlightNumber = flightNumbers[2],
                    Price = 600m
                });
                Tickets.Add(new Ticket {
                    Id = i + 245,
                    FlightNumber = flightNumbers[2],
                    Price = 1200m
                });
                Tickets.Add(new Ticket {
                    Id = i + 280,
                    FlightNumber = flightNumbers[2],
                    Price = 2000m
                });
            }

            #endregion

            #region Flights initializing

            Flights = new List<Flight>();

            Flights.Add(new Flight {
                Number = flightNumbers[0],
                ArrivalTime = new DateTime(2018, 07, 12, 12, 24, 0),
                DeparturePoint = "Borispol, Ukraine",
                DestinationPoint = "New York, USA",
                Tickets = Tickets
                    .Select(t => t)
                    .Where(t => t.FlightNumber == flightNumbers[0])
                    .ToList()
            });
            Flights.Add(new Flight {
                Number = flightNumbers[1],
                ArrivalTime = new DateTime(2018, 08, 15, 14, 12, 0),
                DeparturePoint = "Borispol, Ukraine",
                DestinationPoint = "Moscow, Russia",
                Tickets = Tickets
                    .Select(t => t)
                    .Where(t => t.FlightNumber == flightNumbers[1])
                    .ToList()
            });
            Flights.Add(new Flight {
                Number = flightNumbers[2],
                ArrivalTime = new DateTime(2018, 10, 5, 20, 21, 0),
                DeparturePoint = "Borispol, Ukraine",
                DestinationPoint = "Katowice, Poland",
                Tickets = Tickets
                    .Select(t => t)
                    .Where(t => t.FlightNumber == flightNumbers[2])
                    .ToList()
            });

            #endregion

            #region Departures initializing

            Departures = new List<Departure>();

            Departures.Add(new Departure {
                Id = 1,
                FlightNumber = flightNumbers[0],
                Airplane = Airplanes.Find(p => p.Id == 1),
                Crew = Crews.Find(c => c.Id == 1),
                DepartureTime = new DateTime(2018, 10, 21, 20, 22, 0)
            });
            Departures.Add(new Departure {
                Id = 2,
                FlightNumber = flightNumbers[1],
                Airplane = Airplanes.Find(p => p.Id == 2),
                Crew = Crews.Find(c => c.Id == 2),
                DepartureTime = new DateTime(2018, 9, 22, 20, 22, 0)
            });
            Departures.Add(new Departure {
                Id = 3,
                FlightNumber = flightNumbers[1],
                Airplane = Airplanes.Find(p => p.Id == 2),
                Crew = Crews.Find(c => c.Id == 2),
                DepartureTime = new DateTime(2018, 9, 23, 20, 22, 0)
            });
            Departures.Add(new Departure {
                Id = 4,
                FlightNumber = flightNumbers[2],
                Airplane = Airplanes.Find(p => p.Id == 3),
                Crew = Crews.Find(c => c.Id == 3),
                DepartureTime = new DateTime(2018, 8, 15, 20, 22, 0)
            });
            Departures.Add(new Departure {
                Id = 5,
                FlightNumber = flightNumbers[2],
                Airplane = Airplanes.Find(p => p.Id == 4),
                Crew = Crews.Find(c => c.Id == 3),
                DepartureTime = new DateTime(2018, 8, 17, 20, 22, 0)
            });
            #endregion
        }
    }
}
