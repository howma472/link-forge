using LinkForge.Application.Validators;
using Xunit;

namespace LinkForge.Tests;

public class UrlValidatorTests
{
    [Fact]
    public void Should_Return_True_For_Valid_Url()
    {
        var url = "https://google.com";

        var result = UrlValidator.IsValid(url);

        Assert.True(result);
    }

    [Fact]
    public void Should_Return_False_For_Invalid_Url()
    {
        var url = "invalid-url";

        var result = UrlValidator.IsValid(url);

        Assert.False(result);
    }
}