namespace Olve.OpenRaster;

/// <summary>
/// Represents the content of an Open Raster file.
/// See <a href="https://www.openraster.org/baseline/layer-stack-spec.html">Open Raster Stack File</a>.
/// </summary>
public class StackFileContent
{
    /// <summary>
    /// The version of the Open Raster file.
    /// </summary>
    public required string Version { get; set; }

    /// <summary>
    /// The width and height of the Open Raster file.
    /// </summary>
    public required int Width { get; set; }

    /// <summary>
    /// The width and height of the Open Raster file.
    /// </summary>
    public required int Height { get; set; }

    /// <summary>
    /// The horizontal resolution of the Open Raster file.
    /// </summary>
    public int XResolution { get; set; } = 72;


    /// <summary>
    /// The vertical resolution of the Open Raster file.
    /// </summary>
    public int YResolution { get; set; } = 72;

    /// <summary>
    /// The layers in the Open Raster file.
    /// </summary>
    public List<Layer> Layers { get; set; } = [];

    /// <summary>
    /// The groups in the Open Raster file.
    /// </summary>
    public List<Group> Groups { get; set; } = [];
}