using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API006.Database.Models
{
    [Index(nameof(AccountNumber), IsUnique = true)]
    public class Account
    {
        public int Id { get; set; }

        [StringLength(18)]
        public string AccountNumber { get; set; }

        [Precision(18, 2)] 
        public decimal Balance { get; set; } = 0;

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        public List<Transaction> Transactions { get; set; } = new();
    }
}
