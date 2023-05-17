using Domain.Entities;
using NUnit.Framework;

namespace UnitTests;

public class MemberTests
{
    private Member _member;

    [SetUp]
    public void Setup()
    {
        _member = new Member();
    }

    [Test]
    public void Position_WhenSet_StoresCorrectValue()
    {
        var position = "Manager";
        _member.Position = position;

        Assert.That(_member.Position, Is.EqualTo(position));
    }

    [Test]
    public void DateJoined_WhenSet_StoresCorrectValue()
    {
        var dateJoined = DateTime.UtcNow;
        _member.DateJoined = dateJoined;

        Assert.That(_member.DateJoined, Is.EqualTo(dateJoined));
    }

    [Test]
    public void TenantId_WhenSet_StoresCorrectValue()
    {
        var tenantId = Guid.NewGuid();
        _member.TenantId = tenantId;

        Assert.That(_member.TenantId, Is.EqualTo(tenantId));
    }

    [Test]
    public void UserId_WhenSet_StoresCorrectValue()
    {
        var userId = "user1";
        _member.UserId = userId;

        Assert.That(_member.UserId, Is.EqualTo(userId));
    }

}
