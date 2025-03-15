using System.IO.Compression;
using Olve.OpenRaster.Parsing;
using Olve.Utilities.Operations;
using Olve.Utilities.Types.Results;

namespace Olve.OpenRaster;

/// <summary>
///     Loads and parses a layer into a specified type.
/// </summary>
/// <typeparam name="T">The type to parse the layer as.</typeparam>
public class ReadLayerAs<T> : IOperation<ReadLayerAs<T>.Request, T>
{
    /// <summary>
    ///     Request to load and parse a layer from an open raster file.
    /// </summary>
    /// <param name="Path">The path to the open raster file.</param>
    /// <param name="ImageSource">The source of the layer image to get.</param>
    /// <param name="LayerParser">The parsed used to parse the image data into the output type.</param>
    public record Request(string Path, string ImageSource, ILayerParser<T> LayerParser);

    /// <inheritdoc />
    public Result<T> Execute(Request request)
    {
        var path = Path.GetFullPath(request.Path);
        if (!File.Exists(path))
        {
            return new ResultProblem("no file was found with path '{0}'", path);
        }

        using var zipArchive = ZipFile.OpenRead(request.Path);

        if (LayerImageReader.ReadImageFile(zipArchive, request.ImageSource, request.LayerParser)
                .TryPickProblems(out var problems, out var data))
        {
            problems.Prepend(new ResultProblem("could not read layer '{0}' from open raster file '{1}'", request.ImageSource, request.Path));
            return problems;
        }

        return data;
    }
}