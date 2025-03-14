using System.IO.Compression;
using Olve.OpenRaster.Parsing;
using Olve.Utilities.Operations;
using Olve.Utilities.Types.Results;

namespace Olve.OpenRaster;

public class ReadOpenRasterFile : IOperation<ReadOpenRasterFile.Request, ReadOpenRasterFile.Response>
{
    public record Request(string Path);

    public record Response(Request Request, string MimeType, StackFileContent StackFile);

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

        return new Response(request, mimeType, stack);
    }
}