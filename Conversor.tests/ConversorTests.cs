
using LogsConversor.classes;

public class ConversorTests
{
    private readonly Conversor _conversor;

    public ConversorTests()
    {
        _conversor = new Conversor();
    }

    [Fact]
    public void returnParsedLogs()
    {
        // Arrange
        string[] logs = {
            "1024|200|HIT|\"GET /home\"|123",
            "2048|404|MISS|\"POST /login\"|321"
        };

        // Act
        List<string> result = _conversor.convertLogs(logs);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("GET 200 /home 1024 123 HIT", result[0]);
        Assert.Equal("POST 404 /login 2048 321 MISS", result[1]);
    }

    [Fact]
    public void emptyInput()
    {
        // Arrange
        string[] logs = { };

        // Act
        List<string> result = _conversor.convertLogs(logs);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void skipInvalidEntries()
    {
        // Arrange
        string[] logs = {
            "1024|200|HIT|\"GET /home\"|123",
            "INVALID LOG LINE",
            "2048|404|MISS|\"POST /login\"|321"
        };

        // Act
        List<string> result = _conversor.convertLogs(logs);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("GET 200 /home 1024 123 HIT", result[0]);
        Assert.Equal("POST 404 /login 2048 321 MISS", result[1]);
    }

  

   
}
