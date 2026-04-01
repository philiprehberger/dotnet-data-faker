using Xunit;
using Philiprehberger.DataFaker;

namespace Philiprehberger.DataFaker.Tests;

public class FakerBuilderTests
{
    [Fact]
    public void Build_PopulatesStringProperties()
    {
        var person = FakerBuilder.Build<TestPerson>();
        Assert.False(string.IsNullOrWhiteSpace(person.FirstName));
        Assert.False(string.IsNullOrWhiteSpace(person.LastName));
        Assert.False(string.IsNullOrWhiteSpace(person.Description));
    }

    [Fact]
    public void Build_EmailProperty_ContainsAtSign()
    {
        var person = FakerBuilder.Build<TestPerson>();
        Assert.Contains("@", person.Email);
    }

    [Fact]
    public void Build_FirstNameProperty_ReturnsNameLikeValue()
    {
        var person = FakerBuilder.Build<TestPerson>();
        Assert.False(string.IsNullOrWhiteSpace(person.FirstName));
        Assert.DoesNotContain(" ", person.FirstName);
    }

    [Fact]
    public void Build_PopulatesIntProperty()
    {
        var person = FakerBuilder.Build<TestPerson>();
        Assert.InRange(person.Age, 1, 1000);
    }

    [Fact]
    public void Build_PopulatesBoolProperty()
    {
        var results = Enumerable.Range(0, 50).Select(_ => FakerBuilder.Build<TestPerson>().IsActive).ToList();
        Assert.Contains(true, results);
        Assert.Contains(false, results);
    }

    [Fact]
    public void Build_PopulatesDateTimeProperty()
    {
        var person = FakerBuilder.Build<TestPerson>();
        Assert.True(person.CreatedAt > DateTime.MinValue);
        Assert.True(person.CreatedAt <= DateTime.Now);
    }

    [Fact]
    public void Build_PopulatesGuidProperty()
    {
        var person = FakerBuilder.Build<TestPerson>();
        Assert.NotEqual(Guid.Empty, person.Id);
    }

    public class TestPerson
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Description { get; set; } = "";
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
