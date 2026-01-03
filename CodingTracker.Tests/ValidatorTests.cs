using CodingTracker.Niasua.UserInput;

namespace CodingTracker.Tests;

public class ValidatorTests
{
    [Theory]
    [InlineData("24-10-2004 00:00", true)] // valid
    [InlineData("24/10/2004", false)] // invalid
    [InlineData("Just letters", false)] // invalid
    [InlineData("32-10-2004 00:00", false)] // invalid
    public void IsValidDateTime_FormatIsCorrect_ReturnsTrue(string input, bool expected)
    {
        // Arrange
        string dateTimeFormat = "dd-MM-yyyy HH:mm";

        // Act  
        var result = Validator.IsValidDateTime(input, dateTimeFormat, out DateTime date);

        // Assert
        Assert.Equal(expected, result);
    }
}