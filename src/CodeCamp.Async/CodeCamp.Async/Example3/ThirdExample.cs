using System;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using Newtonsoft.Json;

namespace CodeCamp.Async.Example3
{
    public static class ThirdExample
    {
        public static void Execute()
        {
            ReadJsonAsync();
            //ExecuteApiAsync();
        }

        private static async void ReadJsonAsync()
        {
            var json = File.ReadAllText("data.json");
            var data = await JsonConvert.DeserializeObjectAsync<dynamic>(json);
            Console.WriteLine(data.Name);
        }

        private static async void ExecuteApiAsync()
        {
            const string url = "http://api.stackexchange.com/sites";

            var client = new HttpClient();
            using (var stream = await client.GetStreamAsync(url))
            {
                using (var zip = new GZipStream(stream, CompressionMode.Decompress))
                {
                    var buffer = new byte[4096];
                    using (var outStream = new MemoryStream())
                    {
                        int read;
                        while ((read = zip.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            await outStream.WriteAsync(buffer, 0, read);
                        }

                        var json = StreamToString(outStream);

                        var data = JsonConvert.DeserializeObject<dynamic>(json);

                        foreach (var q in data.items)
                        {
                            Console.WriteLine(q.name);
                        }
                    }
                }
            }
        }

        private static string StreamToString(MemoryStream stream)
        {
            stream.Position = 0;
            var sr = new StreamReader(stream);
            return sr.ReadToEnd();
        }
    }
}
