using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API006.Database.Models
{
    [Index(nameof(Username), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string PasswordHash { get; set; }

        public virtual List<Account> Accounts { get; set; } = new ();
    }
}
