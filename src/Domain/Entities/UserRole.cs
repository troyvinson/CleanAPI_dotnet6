using Domain.Interfaces;

namespace Domain.Entities
{
    public class UserRole : BaseEntity, ISoftDeletable
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
    }
}
