using Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class MemberRole : BaseEntity, ISoftDeletable
    {
        [Column("MemberRoleId")]
        public int Id { get; set; }
        public Member Member { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
    }
}
