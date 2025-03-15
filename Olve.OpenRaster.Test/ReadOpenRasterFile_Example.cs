using Olve.Utilities.Types.Results;

namespace Olve.OpenRaster.Test;

public static class ReadOpenRasterFile_Example
{
    public static void ReadOpenRasterFile()
    {
        ReadOpenRasterFile operation = new();
        ReadOpenRasterFile.Request request = new("map_1.ora");

        var result = operation.Execute(request);
        if (!result.TryPickValue(out var openRasterFile, out var problems))
        {
            problems.Prepend(new ResultProblem("could not read OpenRaster file '{0}'", request.FilePath));

            foreach (var problem in problems)
            {
                Console.WriteLine(problem.ToDebugString());
            }

            return;
        }

        Console.WriteLine($"Successfully read OpenRaster file '{request.FilePath}' with {openRasterFile.Layers.Count} layers and {openRasterFile.Groups.Count} groups");
    }
}