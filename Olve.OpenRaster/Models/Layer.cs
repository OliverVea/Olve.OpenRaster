namespace Olve.OpenRaster;

public class Layer
{
    public required string Name { get; set; }
    public required string Source { get; set; }

    public CompositeOperation CompositeOperation { get; set; } = CompositeOperation.SrcOver;
    public float Opacity { get; set; } = 1.0f;
    public bool Visible { get; set; } = true;
    public int X { get; set; } = 0;
    public int Y { get; set; } = 0;
    public List<Group> Groups { get; set; } = [];
}