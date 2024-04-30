using Disaster_App.Data;
using Disaster_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace Disaster_App.Services
{
    public class DisasterService
    {

        private readonly DisasterContext _context;

        public DisasterService(DisasterContext context)
        {
            _context = context;
        }

        public List<Disaster> GetDisasters()
        {
            return _context.Disaster.ToList();
        }

        public int GetTotalDonationAmount()
        {
            return _context.MonetaryDonations.Sum(donation => donation.DonationAmount);
        }

        public int GetTotalAllocationAmount()
        {
            return _context.Allocations.Sum(allocation => allocation.AllocationAmount);
        }

        public List<GoodsDonations> GetGoods()
        {
            return _context.GoodsDonations.ToList();
        }

    }
}
