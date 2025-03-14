using Olve.Utilities.Types.Results;

namespace Olve.OpenRaster;

/// <summary>
/// Reads an image file from a stream.
/// </summary>
/// <typeparam name="TImage">The type of image to read.</typeparam>
public interface IImageFileReader<TImage>
{
    /// <summary>
    /// Reads an image file from a stream.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <returns>The image read from the stream.</returns>
    Result<TImage> ReadImage(Stream stream);
}