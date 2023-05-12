using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DataTransferObjects;

public abstract record MemberForManipulationDto
{
    public string? Position { get; set; }
    public DateTime DateJoined { get; set; }
    public int UserId { get; set; }

}
