using Olve.Results;

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
        var succeeded = result.TryPickValue(out var openRasterFile, out var problems);

        Assert.That(succeeded, Is.True, () => FormatProblems(problems!));

        if (openRasterFile is null)
        {
            Assert.Fail("openRasterFile was null");
            return;
        }

        Assert.Multiple(() =>
        {
            Assert.That(openRasterFile.Version, Is.EqualTo("0.0.0"));
            Assert.That(openRasterFile.Layers, Has.Count.EqualTo(4));
            Assert.That(openRasterFile.Groups, Has.Count.EqualTo(1));
            Assert.That(openRasterFile.Groups.Single().Name, Is.EqualTo("cities"));
            Assert.That(openRasterFile.Groups.Single().Layers, Has.Count.EqualTo(2));
        });
    }


    private static string FormatProblems(IEnumerable<ResultProblem> problems)
    {
        return string.Join(", ", problems.Select(x => x.ToDebugString()));
    }
}