using Disaster_App.Data;
using Disaster_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace Disaster_App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DisasterContext _context;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IConfiguration _configuration;

        public IndexModel(DisasterContext context, ILogger<RegisterModel> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult OnPost()
        {
            _logger.LogInformation("Test");

            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            var username = Request.Form["username"];
            var password = Request.Form["password"];

            _logger.LogInformation(username);

            List<User> users = _context.Users.ToList();

            foreach (var x in users)
            {
                if(x.Username == username && x.Password == password) 
                {
                    _logger.LogInformation("Successfully Logged in!");
                    return RedirectToPage("/Home Page");
                }
                else if (x.Username == username && x.Password != password)
                {
                    _logger.LogInformation("Incorrect Password!");

                }
                else
                {
                    _logger.LogInformation("Incorrect Username & Password!");
                }
            }

            return Page();
        }
    }
}