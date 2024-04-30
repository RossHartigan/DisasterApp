
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disaster_App.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }   
        public string Email { get; set; }   
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class MonetaryDonations
    {
        [Key]
        public int DonationId { get; set; }
        public string DonarName { get; set; }
        public string DonationDate { get; set; }
        public int DonationAmount { get; set; } 
    }

    public class GoodsDonations
    {
        [Key]
        public int GoodId { get; set; }
        public string DonarName { get; set; }
        public int NumberOfItems { get; set; }
        public string Category { get; set; }
        public string DonationDate { get; set; }
        public string ItemDescription { get; set; }
    }

    public class Disaster
    {
        [Key]
        public int DisasterId { get; set;}
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string DisasterDescription { get; set; }
        public string DisasterLocation { get; set; }
        public string Aid { get; set; }
    }

    public class Allocations
    {
        [Key]
        public int AllocationID { get; set; }
        public string AllocationType { get; set; }
        public int AllocationAmount { get; set; }
        public string? AllocationGood { get; set; }
        public string AllocatedDisaster { get; set; }
    }
}
