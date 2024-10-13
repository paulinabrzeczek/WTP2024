using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WTP2024.DAL.Entity
{
    public class UserDb
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana.")]
        [StringLength(20, ErrorMessage = "Nazwa użytkownika musi miec przyznajmniej {3} znaki.", MinimumLength = 3)]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [StringLength(100, ErrorMessage = "Hasło musi mieć przynajmniej {2} znaków.", MinimumLength = 8)]
        public string Passwordhash { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual RoleDb Role { get; set; } = null!;
        public virtual ICollection<RatingDb> Ratings { get; set; }
    }
}
