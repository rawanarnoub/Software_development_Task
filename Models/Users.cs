using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        
        public string OtherDetails { get; set; }
    }
}
