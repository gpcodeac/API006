using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace API006.Database.Models
{
    [Index(nameof(AccountId), IsUnique = true)]
    public class Transaction
    {
        public int Id { get; set; }

        [Precision(18, 2)]
        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}
