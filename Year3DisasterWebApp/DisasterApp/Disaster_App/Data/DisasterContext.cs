using Disaster_App.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disaster_App.Data
{

    public class DisasterContext : DbContext
    {
        public DisasterContext(DbContextOptions<DisasterContext> options) : base(options) { }
        public DbSet<Disaster> Disaster { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GoodsDonations> GoodsDonations { get; set; }
        public DbSet<MonetaryDonations> MonetaryDonations { get; set; }
        public DbSet<Allocations> Allocations { get; set; }
    }

}
