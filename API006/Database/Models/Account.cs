using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API006.Database.Models
{
    [Index(nameof(AccountNumber), IsUnique = true)]
    public class Account
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [StringLength(18)]
        public string AccountNumber { get; set; }

        [Precision(18, 2)] 
        public decimal Balance { get; set; } = 0;

        [ForeignKey("User")]
        [JsonIgnore]
        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        public List<Transaction> Transactions { get; set; } = new();
    }
}
