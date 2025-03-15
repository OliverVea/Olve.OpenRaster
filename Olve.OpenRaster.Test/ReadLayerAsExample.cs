using BigGustave;
using Olve.Utilities.Types.Results;

namespace Olve.OpenRaster.Test;

public static class ReadLayerAsExample
{
    public static void ReadLayerAsPng()
    {
        PngLayerParser pngLayerParser = new();
        
        ReadLayerAs<Png> readLayerAsPng = new();
        ReadLayerAs<Png>.Request request = new("map_1.ora", "data/002.png", pngLayerParser);
        
        var result = readLayerAsPng.Execute(request);
        if (!result.TryPickValue(out var png, out var problems))
        {
            problems.Prepend(new ResultProblem("could not read layer image"));
            
            foreach (var problem in problems)
            {
                Console.WriteLine(problem.ToDebugString());
            }

            return;
        }
        
        Console.WriteLine($"Successfully decoded {png.Width}x{png.Height} PNG image");
        return;
    }
}