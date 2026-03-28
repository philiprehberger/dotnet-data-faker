using Xunit;
using Philiprehberger.DataFaker;

namespace Philiprehberger.DataFaker.Tests;

public class FakerTests
{
    [Fact]
    public void PickWeighted_ReturnsItemFromList()
    {
        var items = new List<(string item, double weight)>
        {
            ("a", 1.0),
            ("b", 2.0),
            ("c", 3.0)
        };

        var result = Faker.PickWeighted(items);
        Assert.Contains(result, new[] { "a", "b", "c" });
    }

    [Fact]
    public void PickWeighted_ThrowsOnEmptyList()
    {
        var items = new List<(string item, double weight)>();
        Assert.Throws<ArgumentException>(() => Faker.PickWeighted(items));
    }

    [Fact]
    public void PickWeighted_ThrowsOnZeroTotalWeight()
    {
        var items = new List<(string item, double weight)>
        {
            ("a", 0.0),
            ("b", 0.0)
        };

        Assert.Throws<ArgumentException>(() => Faker.PickWeighted(items));
    }

    [Fact]
    public void PickWeighted_FavorsHigherWeight()
    {
        var items = new List<(string item, double weight)>
        {
            ("rare", 0.001),
            ("common", 1000.0)
        };

        var results = Enumerable.Range(0, 100).Select(_ => Faker.PickWeighted(items)).ToList();
        var commonCount = results.Count(r => r == "common");
        Assert.True(commonCount > 80, $"Expected mostly 'common', got {commonCount}/100.");
    }

    [Fact]
    public void List_ExactCount_ReturnsCorrectNumberOfItems()
    {
        var list = Faker.List(5, () => Faker.Name());
        Assert.Equal(5, list.Count);
        Assert.All(list, item => Assert.False(string.IsNullOrWhiteSpace(item)));
    }

    [Fact]
    public void List_MinMax_ReturnsCountInRange()
    {
        var list = Faker.List(3, 7, () => Faker.Between(1, 100));
        Assert.InRange(list.Count, 3, 7);
        Assert.All(list, item => Assert.InRange(item, 1, 100));
    }

    [Fact]
    public void List_ZeroCount_ReturnsEmptyList()
    {
        var list = Faker.List(0, () => Faker.Name());
        Assert.Empty(list);
    }
}
