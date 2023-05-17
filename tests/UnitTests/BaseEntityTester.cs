using Domain.Entities;
using NUnit.Framework;

namespace UnitTests;

public class ConcreteEntity : BaseEntity
{
}

public class BaseEntityTests
{
    private ConcreteEntity _entity;

    [SetUp]
    public void Setup()
    {
        _entity = new ConcreteEntity();
    }

    [Test]
    public void Id_WhenSet_StoresCorrectValue()
    {
        var id = Guid.NewGuid();
        _entity.Id = id;

        Assert.That(_entity.Id, Is.EqualTo(id));
    }

    [Test]
    public void CreatedDate_WhenSet_StoresCorrectValue()
    {
        var date = DateTimeOffset.UtcNow;
        _entity.CreatedDate = date;

        Assert.That(_entity.CreatedDate, Is.EqualTo(date));
    }

    [Test]
    public void UpdatedDate_WhenSet_StoresCorrectValue()
    {
        var date = DateTimeOffset.UtcNow;
        _entity.UpdatedDate = date;

        Assert.That(_entity.UpdatedDate, Is.EqualTo(date));
    }

    [Test]
    public void IsEnabled_WhenSet_StoresCorrectValue()
    {
        _entity.IsEnabled = true;

        Assert.That(_entity.IsEnabled, Is.True);
    }

    [Test]
    public void IsDeleted_WhenSet_StoresCorrectValue()
    {
        _entity.IsDeleted = true;

        Assert.That(_entity.IsDeleted, Is.True);
    }
}
