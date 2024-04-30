using Disaster_App.Data;
using Disaster_App.Models;
using Disaster_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Disaster_App.Pages
{
    public class AllocationPageModel : PageModel
    {
        private readonly DisasterContext _context;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IConfiguration _configuration;
        private readonly DisasterService _disasterService;

        public AllocationPageModel(DisasterContext context, ILogger<RegisterModel> logger, IConfiguration configuration, DisasterService disasterService)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
            _disasterService = disasterService;
        }

        public IActionResult OnPostCaptureMoneyAllocation()
        {
            _logger.LogInformation("money allocated");

            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            var disasterSelect = Request.Form["disasterSelect"];
            var allocationAmount = int.Parse(Request.Form["allocationAmount"]);

            _logger.LogInformation(disasterSelect + " " + allocationAmount.ToString());

            List<Allocations> moneyAllocation = _context.Allocations.ToList();

            var money = new Allocations
            {
                AllocationType = "Monetary",
                AllocationAmount = allocationAmount,
                AllocationGood = null,
                AllocatedDisaster = disasterSelect

            };

            _context.Allocations.Add(money);
            _context.SaveChanges();

            return Page();
        }

        public IActionResult OnPostCaptureGoodsAllocation()
        {
            _logger.LogInformation("goods allocated");

            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            var disasterSelect = Request.Form["disasterSelect"];
            var goodSelect = Request.Form["goodSelect"];

            _logger.LogInformation(disasterSelect + " " + goodSelect);

            List<Allocations> goodsAllocation = _context.Allocations.ToList();

            var good = new Allocations
            {
                AllocationType = "Goods",
                AllocationAmount = 0,
                AllocationGood = goodSelect,
                AllocatedDisaster = disasterSelect
            };

            _context.Allocations.Add(good); 
            _context.SaveChanges();

            return Page();
        }

        public IActionResult OnPostPurchaseGoods()
        {
            _logger.LogInformation("goods donation");

            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            var goodsDate = Request.Form["goodsDate"];
            var goodsAmount = int.Parse(Request.Form["goodsAmount"]);
            var category = Request.Form["category"];
            var itemDescription = Request.Form["itemDescription"];
            var donarName = "Purchased by Company";
            var disasterAllocation = Request.Form["disasterAllocation"];
            var goodsPrice = int.Parse(Request.Form["goodsPrice"]);

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

            List<Allocations> goodsPurchased = _context.Allocations.ToList();

            var good = new Allocations
            {
                AllocationType = "Goods Purchased",
                AllocationAmount = (goodsPrice),
                AllocationGood = itemDescription,
                AllocatedDisaster = disasterAllocation
            };

            _context.Allocations.Add(good);
            _context.SaveChanges();

            return Page();
        }

    }
}
