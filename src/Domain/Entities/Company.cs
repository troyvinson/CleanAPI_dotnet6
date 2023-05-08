using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Company
{
    [Column("CompanyId")]
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Country { get; set; }

    public ICollection<Employee>? Employees { get; set; }


    public override string ToString()
    {
        return "Company " + Id;
    }

    protected bool Equals(Company other)
    {
        return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Company)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
