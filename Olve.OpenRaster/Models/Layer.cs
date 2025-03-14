namespace Olve.OpenRaster;

/// <summary>
/// Represents a layer in an Open Raster file.
/// See <a href="https://www.openraster.org/baseline/layer-stack-spec.html#layer-element">Open Raster Layer Element</a>.
/// </summary>
public class Layer
{
    /// <summary>
    /// The name of the layer.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The source of the layer.
    /// </summary>
    public required string Source { get; set; }

    /// <summary>
    /// The width of the layer.
    /// </summary>
    public CompositeOperation CompositeOperation { get; set; } = CompositeOperation.SrcOver;

    /// <summary>
    /// The opacity of the layer.
    /// </summary>
    public float Opacity { get; set; } = 1.0f;

    /// <summary>
    /// The visibility of the layer.
    /// </summary>
    public bool Visible { get; set; } = true;

    /// <summary>
    /// The X position of the layer.
    /// </summary>
    public int X { get; set; } = 0;

    /// <summary>
    /// The Y position of the layer.
    /// </summary>
    public int Y { get; set; } = 0;

    /// <summary>
    /// The groups (stacks) that the layer belongs to.
    /// </summary>
    public List<Group> Groups { get; set; } = [];
}