namespace Olve.OpenRaster;

public class StackFileContent
{
    public required string Version { get; set; }

    public required int Width { get; set; }
    public required int Height { get; set; }

    public int XResolution { get; set; } = 72;
    public int YResolution { get; set; } = 72;

    public List<Layer> Layers { get; set; } = [];
    public List<Group> Groups { get; set; } = [];
}