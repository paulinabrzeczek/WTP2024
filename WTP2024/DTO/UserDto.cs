using System.ComponentModel.DataAnnotations;

namespace WTP2024.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Passwordhash { get; set; } = null!;
        public int RoleId { get; set; }

    }
}
