using CMSMaersk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSMaersk.DAL
{
    public class ContainerInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ContainerContext>
    {
        protected override void Seed(ContainerContext context)
        {
            var vessels = new List<Vessel>()
            {
                new Vessel(){Name="MS Antenor", Route="Hanseatic trade", Departure=DayOfWeek.Sunday, Arrival=DayOfWeek.Wednesday, TotalBays=65},
                new Vessel(){Name="USS Aludra", Route="Amber Road", Departure=DayOfWeek.Sunday, Arrival=DayOfWeek.Tuesday, TotalBays=90},
                new Vessel(){Name="MV Delight", Route="Wagonway Route", Departure=DayOfWeek.Sunday, Arrival=DayOfWeek.Monday, TotalBays=120},
                new Vessel(){Name="SS Fatima", Route="Trans-Saharan trade", Departure=DayOfWeek.Sunday, Arrival=DayOfWeek.Wednesday, TotalBays=85},
                new Vessel(){Name="Hansa Carrier", Route="Silk Road", Departure=DayOfWeek.Sunday, Arrival=DayOfWeek.Friday, TotalBays=95},
                new Vessel(){Name= "Atlantic Sail", Route="Volga trade route", Departure=DayOfWeek.Monday, Arrival=DayOfWeek.Thursday, TotalBays=100},
                new Vessel(){Name= "Celtic Ambassador", Route="Intracoastal Waterway", Departure=DayOfWeek.Monday, Arrival=DayOfWeek.Thursday, TotalBays=90},
                new Vessel(){Name= "CGM Titus", Route="Cape Route", Departure=DayOfWeek.Monday, Arrival=DayOfWeek.Thursday, TotalBays=85},
                new Vessel(){Name= "CMA Fjord", Route="Northwest Passage", Departure=DayOfWeek.Monday, Arrival=DayOfWeek.Thursday, TotalBays=200},
                new Vessel(){Name= "Ever Pride", Route="Penang Strait", Departure=DayOfWeek.Monday, Arrival=DayOfWeek.Thursday, TotalBays=120},
                new Vessel(){Name= "Halifax", Route="Pirate Round", Departure=DayOfWeek.Tuesday, Arrival=DayOfWeek.Friday, TotalBays=150},
                new Vessel(){Name= "New Orleans Express", Route="Transpolar Sea Route", Departure=DayOfWeek.Tuesday, Arrival=DayOfWeek.Monday, TotalBays=80},
                new Vessel(){Name= "Spirit of Skywalker", Route="Spanish Main", Departure=DayOfWeek.Tuesday, Arrival=DayOfWeek.Friday, TotalBays=200},
                new Vessel(){Name= "LT Cortesia", Route="Incense Route", Departure=DayOfWeek.Tuesday, Arrival=DayOfWeek.Friday, TotalBays=90},
                new Vessel(){Name= "Astron", Route="Panama Canal", Departure=DayOfWeek.Wednesday, Arrival=DayOfWeek.Friday, TotalBays=150},
                new Vessel(){Name= "MCP Altona", Route="Rhine Water Way", Departure=DayOfWeek.Wednesday, Arrival=DayOfWeek.Thursday, TotalBays=40},
                new Vessel(){Name= "MT Haven", Route="Lawrence Sea Way", Departure=DayOfWeek.Wednesday, Arrival=DayOfWeek.Sunday, TotalBays=75},
                new Vessel(){Name= "SS Mayaguez", Route="North Atlantic Route", Departure=DayOfWeek.Wednesday, Arrival=DayOfWeek.Monday, TotalBays=100},
                new Vessel(){Name= "Maritime Jewel", Route="Tea Route", Departure=DayOfWeek.Wednesday, Arrival=DayOfWeek.Tuesday, TotalBays=80},
                new Vessel(){Name= "Biruinţa", Route="Salt Route", Departure=DayOfWeek.Thursday, Arrival=DayOfWeek.Tuesday, TotalBays=80},
                new Vessel(){Name= "Osaka Express", Route="Trans-Saharan Trade Route", Departure=DayOfWeek.Thursday, Arrival=DayOfWeek.Sunday, TotalBays=50},
                new Vessel(){Name= "Truelove", Route=" Tin Route", Departure=DayOfWeek.Thursday, Arrival=DayOfWeek.Monday, TotalBays=60},
                new Vessel(){Name= "Exxon Valdez", Route="Baltic Sea Canal", Departure=DayOfWeek.Thursday, Arrival=DayOfWeek.Sunday, TotalBays=75},
                new Vessel(){Name= "Aranui 3", Route="Rhine-Main-Danube Canal", Departure=DayOfWeek.Friday, Arrival=DayOfWeek.Sunday, TotalBays=55},
                new Vessel(){Name= "LNG Tanker", Route="Suez Canal", Departure=DayOfWeek.Friday, Arrival=DayOfWeek.Monday, TotalBays=120},
                new Vessel(){Name= "Altmark", Route="Volga-Don Canal", Departure=DayOfWeek.Friday, Arrival=DayOfWeek.Thursday, TotalBays=80},
                new Vessel(){Name= "Amoco Cadiz", Route="Kiel Canal", Departure=DayOfWeek.Friday, Arrival=DayOfWeek.Wednesday, TotalBays=45},
                new Vessel(){Name= "Akebono Maru", Route="Houston Ship Canal", Departure=DayOfWeek.Friday, Arrival=DayOfWeek.Sunday, TotalBays=200},
                new Vessel(){Name= "MV Ancylus", Route="Houston Ship Canal", Departure=DayOfWeek.Saturday, Arrival=DayOfWeek.Sunday, TotalBays=60},
                new Vessel(){Name= "Axel Mærsk", Route="Panama Canal", Departure=DayOfWeek.Saturday, Arrival=DayOfWeek.Monday, TotalBays=90},
                new Vessel(){Name= "SS Desabla", Route="Houston Ship Canal", Departure=DayOfWeek.Saturday, Arrival=DayOfWeek.Tuesday, TotalBays=60},
                new Vessel(){Name= "Histria Azure", Route="Danube-Black Sea Canal", Departure=DayOfWeek.Saturday, Arrival=DayOfWeek.Wednesday, TotalBays=70},
            };

            vessels.ForEach(vessel => context.Vessels.Add(vessel));
            context.SaveChanges();
            context.Admins.Add(new Admin() { Username = "admin", Password = "admin" });
            context.SaveChanges();
        }

    }
}