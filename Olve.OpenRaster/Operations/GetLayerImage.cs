using System.IO.Compression;
using Olve.OpenRaster.Parsing;
using Olve.Utilities.Operations;
using Olve.Utilities.Types.Results;

namespace Olve.OpenRaster;

public class GetLayerImage<TImage> : IOperation<GetLayerImage<TImage>.Request, GetLayerImage<TImage>.Response>
{
    public record Request(string Path, string ImageSource, IImageFileReader<TImage> ImageFileReader);
    public record Response(TImage Image);

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