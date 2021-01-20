using System;
using System.Collections.Generic;

namespace SeedData
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Location> Locations = new List<Location>()
            {
                new Location(){LocationId = 1, Name= "Kitchen"},
                new Location(){LocationId = 2, Name= "Living Room"},
                new Location(){LocationId = 3, Name= "BedRoom"},
            };

            //establish random to help randomize occurences/hour/minute/seconds
            Random rando = new Random();

            //Set up current date
            DateTime nowDate = DateTime.Now;

            //Go 6 months back
            DateTime pastDate = nowDate.AddMonths(-6);

            List<Event> events = new List<Event>();

            while(pastDate<nowDate)
            {
                var eventNumber = rando.Next(0,6);

                SortedList<DateTime, Event> eventsOfTheDay = new SortedList<DateTime, Event>();

                for(int i=0; i < eventNumber; i++)
                {
                    int hour = rando.Next(0,24);
                    int minute = rando.Next(0,60);
                    int second = rando.Next(0,60);

                    int randoLocation = rando.Next(0,Locations.Count);

                    DateTime eventTime = new DateTime( pastDate.Year, pastDate.Month, pastDate.Day, hour, minute, second);

                    Event evt = new Event {TimeStamp = eventTime, Location = Locations[randoLocation], LocationId = Locations[randoLocation].LocationId, Flagged = false};

                    eventsOfTheDay.Add(eventTime, evt);

                }

                foreach(var dailyEvent in eventsOfTheDay)
                {
                    events.Add(dailyEvent.Value);
                }

                pastDate = pastDate.AddDays(1);
            }

            foreach(Event evt in events)
            {
                Console.WriteLine(evt.TimeStamp +" "+  evt.Location.Name);
            }

        }
    }
}
