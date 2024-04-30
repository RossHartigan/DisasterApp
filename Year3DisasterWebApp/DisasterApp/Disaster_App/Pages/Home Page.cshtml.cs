using Disaster_App.Data;
using Disaster_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Disaster_App.Pages
{
    public class Home_PageModel : PageModel
    {
        private readonly DisasterContext _context;
        private readonly ILogger<RegisterModel> _logger;

        public Home_PageModel(DisasterContext context, ILogger<RegisterModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<MonetaryDonations> MoneyDonations { get; set; }
        public List<GoodsDonations> GoodsDonations { get; set; }
        public List<Disaster> Disaster { get; set; }

        public void OnGet()
        {
            _logger.LogInformation("Testing home page");

            MoneyDonations = _context.MonetaryDonations.ToList();
            GoodsDonations = _context.GoodsDonations.ToList();
            Disaster = _context.Disaster.ToList();

        }
    }
}
