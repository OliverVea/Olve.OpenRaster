using Olve.Utilities.Types.Results;

namespace Olve.OpenRaster.Test;

public class Tests
{
    [Test]
    public void ReadOpenRasterFile_OnValidOraFile_CorrectInformationIsLoaded()
    {
        // Arrange
        ReadOpenRasterFile operation = new();
        ReadOpenRasterFile.Request request = new("map_1.ora");

        // Act
        var result = operation.Execute(request);

        // Assert
        var succeeded = result.TryPickValue(out var response, out var problems);

        Assert.That(succeeded, Is.True, () => FormatProblems(problems!));

        if (response is null)
        {
            Assert.Fail("openRasterFile was null");
            return;
        }

        Assert.Multiple(() =>
        {
            Assert.That(response.MimeType, Is.EqualTo("image/openraster"));
            Assert.That(response.StackFile.Version, Is.EqualTo("0.0.0"));
            Assert.That(response.StackFile.Layers, Has.Count.EqualTo(4));
            Assert.That(response.StackFile.Groups, Has.Count.EqualTo(1));
            Assert.That(response.StackFile.Groups.Single().Name, Is.EqualTo("cities"));
            Assert.That(response.StackFile.Groups.Single().Layers, Has.Count.EqualTo(2));
        });
    }


    private static string FormatProblems(IEnumerable<ResultProblem> problems)
    {
        return string.Join(", ", problems.Select(x => x.ToDebugString()));
    }
}