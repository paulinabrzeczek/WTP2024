using System.ComponentModel.DataAnnotations;

namespace WTP2024.DAL.Entity
{
    public class RoleDb
    {
        public int Id { get; set; }
        public string NameRole { get; set; } = null!;
        public virtual ICollection<UserDb> Users { get; set; }
    }
}
