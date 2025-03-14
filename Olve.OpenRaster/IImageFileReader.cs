using Olve.Utilities.Types.Results;

namespace Olve.OpenRaster;

public interface IImageFileReader<TImage>
{
    Result<TImage> ReadImage(Stream stream);
}