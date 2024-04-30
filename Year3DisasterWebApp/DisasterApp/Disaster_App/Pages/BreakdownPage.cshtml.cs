using Disaster_App.Data;
using Disaster_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Configuration;

namespace Disaster_App.Pages
{
    public class BreakdownPageModel : PageModel
    {
        private readonly DisasterContext _context;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IConfiguration _configuration;

        public BreakdownPageModel(DisasterContext context, ILogger<RegisterModel> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public List<MonetaryDonations> money { get; set; }
        public List<GoodsDonations> goods { get; set; }
        public List<Allocations> allocations { get; set; }
        public List<Disaster> disasters { get; set; }

        public IActionResult OnGet()
        {

            loadMoney();
            loadGoods();
            loadAllocations();
            loadDisasters();
            return Page();
        }

        public void loadMoney()
        {
            money = _context.MonetaryDonations.ToList();
        }

        public void loadGoods()
        {
            goods = _context.GoodsDonations.ToList();
        }

        public void loadAllocations()
        {
            allocations = _context.Allocations.ToList();
        }

        public void loadDisasters()
        {
            disasters = _context.Disaster.ToList();
        }
    }
}
