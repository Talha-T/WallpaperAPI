using System;

namespace TalhaT.WallpapersApi
{
    public class WallpaperApiException : Exception
    {
        public WallpaperApiException(string message) : base(message)
        {
        }
    }
}