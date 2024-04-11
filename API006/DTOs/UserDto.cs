using System.Drawing;
using API006.Database.Models;
using System.Text.Json.Serialization;

namespace API006.DTOs
{
    public class UserDto
    {
        public string Username { get; set; }

        
        public string PasswordHash { get; set; }
        

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
