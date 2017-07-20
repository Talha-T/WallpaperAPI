using System;
using System.Threading.Tasks;
using TalhaT.WallpapersApi;

namespace ApiTest
{
    internal class Program
    {
        static void Main()
        {
            WallpaperApi.SetKey("z4oXaJzHiETLf0LtZntdeaUi9rSj4u2n");
            Task.Factory.StartNew(Run);
            Console.ReadKey();
        }

        static async void Run()
        {
            Console.Write("Request sent...");
            var response = WallpaperApi.GetArtistDetail(805555);
            // ReSharper disable once UnusedVariable
            var data = response.GetData();
        }
    }
}
