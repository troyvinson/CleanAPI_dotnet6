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



}
