using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Role : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    [ForeignKey(nameof(RoleType))]
    public int RoleTypeId { get; set; }
    public RoleType RoleType { get; set; }

}

