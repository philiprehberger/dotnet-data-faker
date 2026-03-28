using Xunit;
using Philiprehberger.DataFaker;

namespace Philiprehberger.DataFaker.Tests;

public class FakerInternetTests
{
    [Fact]
    public void Url_ReturnsValidHttpOrHttpsUrl()
    {
        var url = FakerInternet.Url();
        Assert.True(url.StartsWith("http://", StringComparison.Ordinal) ||
                    url.StartsWith("https://", StringComparison.Ordinal));
        Assert.Contains(".", url);
    }

    [Fact]
    public void DomainName_ContainsTld()
    {
        var domain = FakerInternet.DomainName();
        Assert.Contains(".", domain);
        Assert.DoesNotContain(" ", domain);
    }

    [Fact]
    public void IPv4_ReturnsFourOctets()
    {
        var ip = FakerInternet.IPv4();
        var parts = ip.Split('.');
        Assert.Equal(4, parts.Length);
        foreach (var part in parts)
        {
            Assert.True(int.TryParse(part, out var value));
            Assert.InRange(value, 0, 255);
        }
    }

    [Fact]
    public void IPv6_ReturnsEightGroups()
    {
        var ip = FakerInternet.IPv6();
        var groups = ip.Split(':');
        Assert.Equal(8, groups.Length);
        foreach (var group in groups)
        {
            Assert.Equal(4, group.Length);
        }
    }

    [Fact]
    public void MacAddress_ReturnsSixOctets()
    {
        var mac = FakerInternet.MacAddress();
        var octets = mac.Split(':');
        Assert.Equal(6, octets.Length);
        foreach (var octet in octets)
        {
            Assert.Equal(2, octet.Length);
        }
    }

    [Fact]
    public void UserAgent_ReturnsNonEmptyString()
    {
        var ua = FakerInternet.UserAgent();
        Assert.False(string.IsNullOrWhiteSpace(ua));
        Assert.Contains("Mozilla", ua);
    }

    [Fact]
    public void Slug_ContainsHyphens()
    {
        var slug = FakerInternet.Slug();
        Assert.Contains("-", slug);
        Assert.DoesNotContain(" ", slug);
    }
}
