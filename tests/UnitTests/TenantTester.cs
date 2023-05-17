using Domain.Entities;
using NUnit.Framework;

namespace UnitTests;

internal class TenantTester
{
    private Tenant _tenant;

    [SetUp]
    public void Setup()
    {
        _tenant = new Tenant();
    }

    [Test]
    public void Id_WhenSet_StoresCorrectValue()
    {
        var id = Guid.NewGuid();
        _tenant.Id = id;

        Assert.That(_tenant.Id, Is.EqualTo(id));
    }

    [Test]
    public void Name_WhenSet_StoresCorrectValue()
    {
        var name = "Test Tenant";
        _tenant.Name = name;

        Assert.That(_tenant.Name, Is.EqualTo(name));
    }

    [Test]
    public void Members_WhenSet_StoresCorrectValue()
    {
        var members = new List<Member> { new Member() };
        _tenant.Members = members;

        Assert.That(_tenant.Members, Is.EqualTo(members));
    }
}
