using System.IO.Compression;
using Olve.OpenRaster.Parsing;
using Olve.Utilities.Operations;
using Olve.Utilities.Types.Results;

namespace Olve.OpenRaster;

/// <summary>
/// Gets a layer image from an open raster file.
/// </summary>
/// <typeparam name="TImage">The type of image to read.</typeparam>
public class GetLayerImage<TImage> : IOperation<GetLayerImage<TImage>.Request, GetLayerImage<TImage>.Response>
{
    /// <summary>
    /// Represents the request to get a layer image from an open raster file.
    /// </summary>
    /// <param name="Path">The path to the open raster file.</param>
    /// <param name="ImageSource">The source of the image to get.</param>
    /// <param name="ImageFileReader">The reader to use to read the image.</param>
    public record Request(string Path, string ImageSource, IImageFileReader<TImage> ImageFileReader);

    /// <summary>
    /// Represents the response to getting a layer image from an open raster file.
    /// </summary>
    /// <param name="Image">The image read from the open raster file.</param>
    public record Response(TImage Image);

    /// <inheritdoc />
    public Result<Response> Execute(Request request)
    {
        var path = Path.GetFullPath(request.Path);
        if (!File.Exists(path))
        {
            return new ResultProblem("no file was found with path '{0}'", path);
        }

        using var zipArchive = ZipFile.OpenRead(request.Path);

        if (ImageFileReader.ReadImageFile(zipArchive, request.ImageSource, request.ImageFileReader)
                .TryPickProblems(out var problems, out var image))
        {
            problems.Prepend(new ResultProblem("could not read layer image '{0}' from open raster file '{1}'", request.ImageSource, request.Path));
            return problems;
        }

        return new Response(image);
    }
}