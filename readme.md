Wallpapers API
 for C#
======

Wallpapers, categories, comments and more!

Powered by [LoL Wallpapers API](http://docs.lolwallpapers.apiary.io)

## Usage

Add using tag after install:
```csharp
using TalhaT.WallpapersApi;
```

Then, make sure you have set your key:
```csharp
WallpaperApi.SetKey("z4oXaJzHiETLf0...");
```

Get first page of wallpapers (20 wallpapers by default) :
```csharp
var wallpaper = await WallpaperApi.GetWallpapersAsync(); //asynchronously

var wallpaper = WallpaperApi.GetWallpapers(); //synchronously
```

Query examples:
```csharp
var wallpaper = await WallpaperApi.GetWallpapersAsync("limit=50", "page=10", "orderby=view_count", "check api documentation");
```

Darius wallpapers:
```csharp
var categories = await WallpaperApi.GetCategoriesAsync();
var darius = categories.GetData().First(x => x.Name == "darius");
var id = darius.Id;
var dariusWallpapers = await WallpaperApi.GetWallpapersAsync($"category_ID={id}");
```