using CMSMaersk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSMaersk.DAL
{
    public class VesselRepository : Repository<Vessel>
    {
        public List<Vessel> GetVesselForDay(DayOfWeek day)
        {
            return DbSet.ToList().Where(vessel => vessel.Departure >= day).ToList();
        }

        public int GetTotalBaysOccupied(int vesselID)
        {
            int total = 0;
            List<Booking> bookings = DbSet.Find(vesselID).Bookings;
            bookings.ForEach(b => total += b.Item.TotalBays);
            return total;
        }
    }
}