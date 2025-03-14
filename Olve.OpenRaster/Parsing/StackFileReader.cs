using System.IO.Compression;
using System.Xml.Linq;
using Olve.Utilities.Types.Results;

namespace Olve.OpenRaster.Parsing;

internal static class StackFileReader
{
    public static Result<StackFileContent> ReadStackXml(ZipArchive zipArchive)
    {
        var stackFile = zipArchive.GetEntry("stack.xml");
        if (stackFile == null)
        {
            return new ResultProblem("stack.xml was not found in the .ora file");
        }

        using var stream = stackFile.Open();
        using var reader = new StreamReader(stream);
        var xml = reader.ReadToEnd();

        var document = XDocument.Parse(xml);
        var root = document.Root;
        if (root == null)
        {
            return new ResultProblem("stack.xml is empty");
        }

        if (root.GetAttribute("version", "0.0.0").TryPickProblems(out var problems, out var version))
        {
            problems.Prepend(new ResultProblem("failed reading version from stack.xml"));
            return problems;
        }

        if (root.GetIntAttribute("w").TryPickProblems(out problems, out var width))
        {
            problems.Prepend(new ResultProblem("failed reading width from stack.xml"));
            return problems;
        }

        if (root.GetIntAttribute("h").TryPickProblems(out problems, out var height))
        {
            problems.Prepend(new ResultProblem("failed reading height from stack.xml"));
            return problems;
        }

        if (root.GetIntAttribute("xres", 72).TryPickProblems(out problems, out var xRes))
        {
            problems.Prepend(new ResultProblem("failed reading xres from stack.xml"));
            return problems;
        }

        if (root.GetIntAttribute("yres", 72).TryPickProblems(out problems, out var yRes))
        {
            problems.Prepend(new ResultProblem("failed reading yres from stack.xml"));
            return problems;
        }

        var rootStack = root.Element("stack");
        if (rootStack == null)
        {
            return new ResultProblem("root stack element is missing in stack.xml");
        }

        List<Group> groups = [];
        List<Layer> layers = [];

        var children = rootStack.Elements();
        var parseChildrenResult = StackElementParser.ParseStackElements(children, layers, groups);
        if (parseChildrenResult.TryPickProblems(out problems))
        {
            problems.Prepend(new ResultProblem("failed parsing stack in stack.xml"));
            return problems;
        }

        var stack = new StackFileContent
        {
            Version = version,
            Width = width,
            Height = height,
            XResolution = xRes,
            YResolution = yRes,
            Groups = groups,
            Layers = layers
        };

        return stack;
    }
}