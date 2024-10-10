namespace WTP2024.DAL.Entity
{
    public class RoleDb
    {
        public RoleDb()
        {
            Users = new HashSet<UserDb>();
        }

        public int IdRole { get; set; }
        public string NameRole { get; set; } = null!;
        public virtual ICollection<UserDb> Users { get; set; }
    }
}
