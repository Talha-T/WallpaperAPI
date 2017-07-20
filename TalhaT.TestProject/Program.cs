using System;
using System.Linq;
using System.Threading.Tasks;
using TalhaT.WallpapersApi;

namespace TalhaT.TestProject
{
    class Program
    {
        static void Main()
        {
            // Remember to set key first!!
            WallpaperApi.SetKey("z4oXaJzHiETLf0LtZntdeaUi9rSj4u2n");
            Task.Factory.StartNew(DoAsyncJob);
            Console.ReadKey();
        }

        private static async void DoAsyncJob()
        {
            Console.WriteLine("Request sent..");
            var categories = await WallpaperApi.GetCategoriesAsync();
            var darius = categories.GetData().First(x => x.Name == "darius");
            var id = darius.Id;
            var dariusWallpapers = await WallpaperApi.GetWallpapersAsync($"category_ID={id}");
        }
    }
}
