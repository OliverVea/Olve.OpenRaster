using Olve.Utilities.Types.Results;

namespace Olve.OpenRaster;

/// <summary>
///     Interface for parsing a layer from a stream.
/// </summary>
/// <typeparam name="T">The type the layer is read as.</typeparam>
public interface ILayerParser<T>
{
    /// <summary>
    ///     Parses a layer from a stream.
    /// </summary>
    /// <param name="stream">The stream containing raw byte data from the layer file.</param>
    /// <returns>The parsed layer.</returns>
    Result<T> ParseLayer(Stream stream);
}