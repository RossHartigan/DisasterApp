using Disaster_App.Data;
using Disaster_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using Microsoft.Extensions.Primitives;

namespace Disaster_App.Pages
{
    public class DonationPageModel : PageModel
    {
        private readonly DisasterContext _context;
        private readonly ILogger<DonationPageModel> _logger;
        private readonly IConfiguration _configuration;

        public DonationPageModel(DisasterContext context, ILogger<DonationPageModel> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult OnPostCaptureMonetaryDonation()
        {
            _logger.LogInformation("money donation");

            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            var moneyDate = Request.Form["moneyDate"];
            var moneyAmount = int.Parse(Request.Form["moneyAmount"]);
            var name = Request.Form["name"];


            if (name == "")
            {
                name = "Anonymous";
            }

            List<MonetaryDonations> moneyDonation = _context.MonetaryDonations.ToList();

            var money = new MonetaryDonations
            {
                DonarName = name,
                DonationDate = moneyDate,
                DonationAmount = moneyAmount

            };

            _context.MonetaryDonations.Add(money);
            _context.SaveChanges();               
            
            return Page();
        }

        public IActionResult OnPostCaptureGoodsDonation()
        {
            _logger.LogInformation("goods donation");

            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            var goodsDate = Request.Form["goodsDate"];
            var goodsAmount = int.Parse(Request.Form["goodsAmount"]);
            var category = Request.Form["category"];
            var itemDescription = Request.Form["itemDescription"];
            var donarName = Request.Form["donarName"];

            _logger.LogInformation(donarName);
            _logger.LogInformation(category);

            if (donarName.Count == 0 || string.IsNullOrEmpty(donarName[0]))
            {
                donarName = "Anonymous";
            }

            _logger.LogInformation(donarName);

            List<GoodsDonations> goodsDonation = _context.GoodsDonations.ToList();

            var goods = new GoodsDonations
            {
                DonationDate = goodsDate,
                DonarName = donarName,
                NumberOfItems = goodsAmount,
                Category = category.ToString(),
                ItemDescription = itemDescription

            };          

            _context.GoodsDonations.Add(goods);
            _context.SaveChanges();

            return Page();
        }
    }
}
