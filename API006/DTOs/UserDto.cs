using System.Drawing;
using API006.Database.Models;

namespace API006.DTOs
{
    public class UserDto
    {
        public string Username { get; set; }

        public string PasswordHash { get; set; }
        // Include other relevant properties but exclude sensitive data like passwords.


        public User ConvertToUser()
        {
            User user = new()
            {
                Username = Username,
                PasswordHash = PasswordHash
            };
            return user;
        }
    }


}
