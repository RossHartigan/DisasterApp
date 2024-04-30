using Disaster_App.Data;
using Disaster_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Disaster_App.Pages
{
    public class DisasterPageModel : PageModel
    {
        private readonly DisasterContext _context;
        private readonly ILogger<DisasterPageModel> _logger;
        private readonly IConfiguration _configuration;

        public DisasterPageModel(DisasterContext context, ILogger<DisasterPageModel> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult OnPostCaptureDisaster()
        {
            _logger.LogInformation("disaster");

            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            var startDate = Request.Form["startDate"];
            var endDate = Request.Form["endDate"];
            var disasterDescription = Request.Form["disasterDescription"];
            var disasterLocation = Request.Form["disasterLocation"];
            var aid = Request.Form["aid"];

            List<Disaster> newDisaster = _context.Disaster.ToList();

            var disaster = new Disaster
            {
                StartDate = startDate,
                EndDate = endDate,
                DisasterDescription = disasterDescription,
                DisasterLocation = disasterLocation,
                Aid = aid

            };

            _context.Disaster.Add(disaster);
            _context.SaveChanges();

            return Page();
        }
    }
}
