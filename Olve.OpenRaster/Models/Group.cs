using Olve.OpenRaster.Parsing;

namespace Olve.OpenRaster;

public class Group
{
    public required string Name { get; set; }

    public CompositeOperation CompositeOperation { get; set; } = CompositeOperation.SrcOver;
    public float Opacity { get; set; }
    public Visibility Visibility { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public List<Layer> Layers { get; set; } = [];
}