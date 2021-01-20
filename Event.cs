using System;
using System.Collections.Generic;
using System.Text;

namespace SeedData
{
    class Event
    {
                public int EventId {get; set;}
                public DateTime TimeStamp {get; set;}
                public bool Flagged {get; set;}
                //Foreign Key for Location
                public int LocationId{get; set;}
                //navigation
                public Location Location {get; set;}

    }

}