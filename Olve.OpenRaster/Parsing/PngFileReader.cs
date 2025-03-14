using System.IO.Compression;
using Olve.Utilities.Types.Results;

namespace Olve.OpenRaster.Parsing;

internal static class ImageFileReader
{
    public static Result<TImage> ReadImageFile<TImage>(ZipArchive zipArchive, string imageSource, IImageFileReader<TImage> imageFileReader)
    {
        var file = zipArchive.GetEntry(imageSource);
        if (file == null)
        {
            return new ResultProblem("file '{0}' was not found in the .ora file", imageSource);
        }

        using var stream = file.Open();

        if (imageFileReader.ReadImage(stream).TryPickProblems(out var problems, out var image))
        {
            problems.Prepend(new ResultProblem("could not read image file '{0}'", imageSource));
            return problems;
        }

        return image;
    }
}