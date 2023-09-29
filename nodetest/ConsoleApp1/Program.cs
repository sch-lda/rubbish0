using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string[] urls = new string[]
        {
      "https://blog.host3650.live/https://raw.githubusercontent.com/CrazyZhang666/GTA5OnlineLua/main/Kiddion/AliceLua.zip",
      "https://ghproxy.net/https://raw.githubusercontent.com/CrazyZhang666/GTA5OnlineLua/main/Kiddion/AliceLua.zip",
      "https://gcore.jsdelivr.net/gh/CrazyZhang666/GTA5OnlineLua@main/Kiddion/AliceLua.zip",
      "https://jsdelivr.b-cdn.net/gh/CrazyZhang666/GTA5OnlineLua@main/Kiddion/AliceLua.zip",
      "https://github.moeyy.xyz/https://raw.githubusercontent.com/CrazyZhang666/GTA5OnlineLua/main/Kiddion/AliceLua.zip",
      "https://raw.githubusercontent.com/CrazyZhang666/GTA5OnlineLua/main/Kiddion/AliceLua.zip"
        };

        using (HttpClient httpClient = new HttpClient())
        {
            Console.WriteLine("Lua下载节点测试");

            for (int i = 0; i < urls.Length; i++)
            {
                Console.WriteLine($"节点{i + 1}开始下载：{urls[i]}");

                Stopwatch stopwatch = Stopwatch.StartNew();

                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(urls[i]);

                    if (response.IsSuccessStatusCode)
                    {
                        byte[] data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes($"Node{i + 1}_AliceLua.zip", data);

                        stopwatch.Stop();
                        Console.ForegroundColor = ConsoleColor.Green; 
                        Console.WriteLine($"节点{i + 1}下载完成，耗时: {stopwatch.Elapsed.TotalSeconds:F2}秒");
                        Console.ResetColor(); 
                    }
                    else
                    {
                        stopwatch.Stop();
                        Console.ForegroundColor = ConsoleColor.Red; 
                        Console.WriteLine($"节点{i + 1}下载失败，耗时: {stopwatch.Elapsed.TotalSeconds:F2}秒，HTTP状态码: {response.StatusCode}");
                        Console.ResetColor(); 
                    }
                }
                catch (Exception ex)
                {
                    stopwatch.Stop();
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.WriteLine($"节点{i + 1}下载失败，耗时: {stopwatch.Elapsed.TotalSeconds:F2}秒，错误信息: {ex.Message}");
                    Console.ResetColor(); 
                }
            }

            Console.ReadLine();
        }

    }
}
