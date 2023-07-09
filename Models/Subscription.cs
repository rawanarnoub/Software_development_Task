using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string SubscriptionType { get; set; }
        public string OtherDetails { get; set; }
    }
}
