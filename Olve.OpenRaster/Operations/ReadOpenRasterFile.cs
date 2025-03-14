using System.IO.Compression;
using Olve.OpenRaster.Parsing;
using Olve.Utilities.Operations;
using Olve.Utilities.Types.Results;

namespace Olve.OpenRaster;

/// <summary>
/// Reads an open raster file.
/// </summary>
public class ReadOpenRasterFile : IOperation<ReadOpenRasterFile.Request, ReadOpenRasterFile.Response>
{
    /// <summary>
    /// Represents the request to read an open raster file.
    /// </summary>
    /// <param name="Path">The path to the open raster file.</param>
    public record Request(string Path);

    /// <summary>
    /// Represents the response to reading an open raster file.
    /// </summary>
    /// <param name="MimeType">The mimetype of the open raster file.</param>
    /// <param name="StackFile">The stack file read from the open raster file.</param>
    public record Response(string MimeType, StackFileContent StackFile);

    /// <inheritdoc />
    public Result<Response> Execute(Request request)
    {
        var path = Path.GetFullPath(request.Path);
        if (!File.Exists(path))
        {
            return new ResultProblem("no file was found with path '{0}'", path);
        }

        using var zipFolder = ZipFile.OpenRead(request.Path);

        if (MimeTypeReader.ReadMimetype(zipFolder).TryPickProblems(out var problems, out var mimeType))
        {
            problems.Prepend(new ResultProblem("failed reading mimetype"));
            return problems;
        }

        if (StackFileReader.ReadStackXml(zipFolder).TryPickProblems(out problems, out var stack))
        {
            problems.Prepend(new ResultProblem("failed reading stack.xml"));
            return problems;
        }

        return new Response(mimeType, stack);
    }
}