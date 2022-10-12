using System.Diagnostics;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace peachme_cli {
    public class Program {

        public class KissmeResponse
        {
            public string Image { get; set; }
        }
        
        public static async Task<int> Main(params string[] args)
        {
            var usage = "peachme [-h|--help] <file>";
            string filePath = null;
            foreach (var str in args)
            {
                if (str is "-h" or "--help")
                {
                    Console.WriteLine(usage);
                    return 0;
                }
                filePath = str;
                break;
            }

            if (filePath is null)
            {
                Console.WriteLine(@$"{usage}

Missing file arg");
                return 1;
            }
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"file {filePath} doesn't exist!");
                return 1;
            }

            var request = new
            {
                image = Convert.ToBase64String(await File.ReadAllBytesAsync(filePath))
            };
            var response = await new HttpClient().PostAsync(
                "http://api.peachme.io:8090/kissme",
                new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json")
            );
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException("pas de chance");

            var imageResponse = await response.Content.ReadFromJsonAsync<KissmeResponse>();
            await File.WriteAllBytesAsync("/tmp/output.png", Convert.FromBase64String(imageResponse.Image.Split(",")[1]));
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "/usr/bin/open",
                Arguments = "/tmp/output.png"
            };
            var process = new Process
            {
                StartInfo = processStartInfo
            };
            process.Start();
            
            return 0;
        }
    }
}
