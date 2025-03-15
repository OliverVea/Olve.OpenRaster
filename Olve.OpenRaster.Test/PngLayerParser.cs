using BigGustave;
using Olve.Utilities.Types.Results;

namespace Olve.OpenRaster.Test;

public class PngLayerParser : ILayerParser<Png>
{
    public Result<Png> ParseLayer(Stream stream)
    {
        return Png.Open(stream);
    }
}