using Domain.Entities;
using NUnit.Framework;

namespace UnitTests;

internal class UserTester
{
    private User _user;

    [SetUp]
    public void Setup()
    {
        _user = new User();
    }

    [Test]
    public void FirstName_WhenSet_StoresCorrectValue()
    {
        var firstName = "John";
        _user.FirstName = firstName;

        Assert.That(_user.FirstName, Is.EqualTo(firstName));
    }

    [Test]
    public void LastName_WhenSet_StoresCorrectValue()
    {
        var lastName = "Doe";
        _user.LastName = lastName;

        Assert.That(_user.LastName, Is.EqualTo(lastName));
    }

    [Test]
    public void GetFullName_ReturnsCorrectValue()
    {
        var firstName = "John";
        var lastName = "Doe";

        _user.FirstName = firstName;
        _user.LastName = lastName;

        Assert.That(_user.GetFullName(), Is.EqualTo($"{firstName} {lastName}"));
    }

    [Test]
    public void GetFullName_WithExtraSpaces_ReturnsTrimmedValue()
    {
        var firstName = "  John  ";
        var lastName = "  Doe  ";

        _user.FirstName = firstName;
        _user.LastName = lastName;

        Assert.That(_user.GetFullName(), Is.EqualTo($"{firstName.Trim()} {lastName.Trim()}"));
    }
}
