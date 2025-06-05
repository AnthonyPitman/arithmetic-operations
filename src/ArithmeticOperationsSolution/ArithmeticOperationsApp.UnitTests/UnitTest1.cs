namespace ArithmeticOperationsApp.UnitTests;

public class UnitTest1
{
    // TODO: add unit testing around Number.Add
    [Fact]
    public void Test1()
    {
        var result = Number.Add(new Number("1"), new Number("2"));
        Assert.Equal("3", result.ToString());
    }
}