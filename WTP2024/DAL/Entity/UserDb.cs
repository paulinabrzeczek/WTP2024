using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WTP2024.DAL.Entity
{
    public partial class UserDb
    {
        public UserDb()
        {
            Ratings = new HashSet<RatingDb>();
        }

        public int IdUser { get; set; }
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana.")]
        [StringLength(20, ErrorMessage = "Nazwa użytkownika musi miec przyznajmniej {3} znaki.", MinimumLength = 3)]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [StringLength(100, ErrorMessage = "Hasło musi mieć przynajmniej {2} znaków.", MinimumLength = 8)]
        public string Passwordhash { get; set; } = null!;
        public int IdRole { get; set; }

        public virtual RoleDb Role { get; set; } = null!;

        public virtual ICollection<RatingDb> Ratings { get; set; }
    }
}
