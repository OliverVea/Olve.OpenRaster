using Olve.OpenRaster.Parsing;

namespace Olve.OpenRaster;

/// <summary>
/// A group of layers, also known as a stack element.
/// See <a href="https://www.openraster.org/baseline/layer-stack-spec.html#stack-element">Open Raster Stack Element</a>.
/// </summary>
public class Group
{
    /// <summary>
    /// The name of the group.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The composite operation of the group.
    /// </summary>
    public CompositeOperation CompositeOperation { get; set; } = CompositeOperation.SrcOver;

    /// <summary>
    /// The opacity of the group.
    /// </summary>
    public float Opacity { get; set; }

    /// <summary>
    /// The visibility of the group.
    /// </summary>
    public Visibility Visibility { get; set; }

    /// <summary>
    /// The X position of the group.
    /// </summary>
    [Obsolete("Deprecated since version 0.0.6: x and y attributes on stack elements are no longer allowed.")]
    public int X { get; set; }

    /// <summary>
    /// The Y position of the group.
    /// </summary>
    [Obsolete("Deprecated since version 0.0.6: x and y attributes on stack elements are no longer allowed.")]
    public int Y { get; set; }

    /// <summary>
    /// The layers belonging to the group.
    /// </summary>
    public List<Layer> Layers { get; set; } = [];
}