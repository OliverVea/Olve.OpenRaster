# Olve.OpenRaster

[![NuGet](https://img.shields.io/nuget/v/Olve.OpenRaster?logo=nuget)](https://www.nuget.org/packages/Olve.OpenRaster)[![GitHub](https://img.shields.io/github/license/OliverVea/Olve.OpenRaster)](LICENSE)![LOC](https://img.shields.io/endpoint?url=https%3A%2F%2Fghloc.vercel.app%2Fapi%2FOliverVea%2FOlve.OpenRaster%2Fbadge)![NuGet Downloads](https://img.shields.io/nuget/dt/Olve.OpenRaster)

The purpose of this library is to provide simple read-only access to `.ora`, or [OpenRaster](https://www.openraster.org/), files, with a simple native C# library with minimal dependencies, in fact, `Olve.Utilities` and `OneOf` are the only dependencies of this project.

## Installation

Simply run the following command to add a dependency for the nuget package to your project:

```bash
dotnet add Olve.OpenRaster
```

## Usage

This package only contains two operations:

- **ReadOpenRasterFile** opens a `.ora` file, reads the metadata from `mimetype` and `stack.xml` and returns the data in an easily-consumable class structure.

- **GetLayerImage** takes a layer image source string and reads the image with a provided `IImageFileReader`. 

Currently, no default implementations of `IImageFileReader` have been added to the library, you will have to convert the byte stream to an image file yourself, but the `.ora` structure is handily abstracted away, so you will most likely only need to parse a `.png` file yourself.

## Future

I want to expand this in the future with:

1. Reading all content. Currently the following is not supported:
    - Thumbnail images
    - Merged image
1. Writing operations to both stack and all images.
