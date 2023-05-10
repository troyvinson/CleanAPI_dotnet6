using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Employee
{
    [Column("EmployeeId")]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }

    public string Position { get; set; } = string.Empty;

    [ForeignKey(nameof(Company))]
    public int CompanyId { get; set; }
    public Company Company { get; set; }


    public override string ToString()
    {
        return "Employee " + Id;
    }

    protected bool Equals(Employee other)
    {
        return Id.Equals(other.Id);
    }

    public override bool Equals(object obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Employee)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

}
