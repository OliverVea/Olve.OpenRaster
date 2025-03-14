using Olve.Utilities.Types.Results;

namespace Olve.OpenRaster;

public readonly record struct CompositeOperation(
   string Key,
   BlendingFunction BlendingFunction,
   CompositingOperator CompositingOperator)
{
   public static CompositeOperation SrcOver => new("svg:src-over", BlendingFunction.Normal, CompositingOperator.SourceOver);
   public static CompositeOperation Multiply => new("svg:multiply", BlendingFunction.Multiply, CompositingOperator.SourceOver);
   public static CompositeOperation Screen => new("svg:screen", BlendingFunction.Screen, CompositingOperator.SourceOver);
   public static CompositeOperation Overlay => new("svg:overlay", BlendingFunction.Overlay, CompositingOperator.SourceOver);
   public static CompositeOperation Darken => new("svg:darken", BlendingFunction.Darken, CompositingOperator.SourceOver);
   public static CompositeOperation Lighten => new("svg:lighten", BlendingFunction.Lighten, CompositingOperator.SourceOver);
   public static CompositeOperation ColorDodge => new("svg:color-dodge", BlendingFunction.ColorDodge, CompositingOperator.SourceOver);
   public static CompositeOperation ColorBurn => new("svg:color-burn", BlendingFunction.ColorBurn, CompositingOperator.SourceOver);
   public static CompositeOperation HardLight => new("svg:hard-light", BlendingFunction.HardLight, CompositingOperator.SourceOver);
   public static CompositeOperation SoftLight => new("svg:soft-light", BlendingFunction.SoftLight, CompositingOperator.SourceOver);
   public static CompositeOperation Difference => new("svg:difference", BlendingFunction.Difference, CompositingOperator.SourceOver);
   public static CompositeOperation Color => new("svg:color", BlendingFunction.Color, CompositingOperator.SourceOver);
   public static CompositeOperation Luminosity => new("svg:luminosity", BlendingFunction.Luminosity, CompositingOperator.SourceOver);
   public static CompositeOperation Hue => new("svg:hue", BlendingFunction.Hue, CompositingOperator.SourceOver);
   public static CompositeOperation Saturation => new("svg:saturation", BlendingFunction.Saturation, CompositingOperator.SourceOver);
   public static CompositeOperation Plus => new("svg:plus", BlendingFunction.Normal, CompositingOperator.Lighter);
   public static CompositeOperation DestinationIn => new("svg:dst-in", BlendingFunction.Normal, CompositingOperator.DestinationIn);
   public static CompositeOperation DestinationOut => new("svg:dst-out", BlendingFunction.Normal, CompositingOperator.DestinationOut);
   public static CompositeOperation SourceAtop => new("svg:src-atop", BlendingFunction.Normal, CompositingOperator.SourceAtop);
   public static CompositeOperation DestinationAtop => new("svg:dst-atop", BlendingFunction.Normal, CompositingOperator.DestinationAtop);

   public static Result<CompositeOperation> FromKey(string key)
   {
      return key switch
      {
         "svg:src-over" => SrcOver,
         "svg:multiply" => Multiply,
         "svg:screen" => Screen,
         "svg:overlay" => Overlay,
         "svg:darken" => Darken,
         "svg:lighten" => Lighten,
         "svg:color-dodge" => ColorDodge,
         "svg:color-burn" => ColorBurn,
         "svg:hard-light" => HardLight,
         "svg:soft-light" => SoftLight,
         "svg:difference" => Difference,
         "svg:color" => Color,
         "svg:luminosity" => Luminosity,
         "svg:hue" => Hue,
         "svg:saturation" => Saturation,
         "svg:plus" => Plus,
         "svg:dst-in" => DestinationIn,
         "svg:dst-out" => DestinationOut,
         "svg:src-atop" => SourceAtop,
         "svg:dst-atop" => DestinationAtop,
         _ => new ResultProblem("unknown composite operation key: {0}", key)
      };
   }
}