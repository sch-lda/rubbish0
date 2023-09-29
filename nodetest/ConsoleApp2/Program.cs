using System;
using System.Diagnostics;
using System.IO;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        string[] urls = new string[] {
            "https://blog.host3650.live/https://github.com/CrazyZhang666/GTA5OnlineTools/releases/download/update/GTA5OnlineTools.exe",
            "https://ghdl.feizhuqwq.cf/https://github.com/CrazyZhang666/GTA5OnlineTools/releases/download/update/GTA5OnlineTools.exe",
            "https://slink.ltd/https://github.com/CrazyZhang666/GTA5OnlineTools/releases/download/update/GTA5OnlineTools.exe",
            "https://proxy.freecdn.ml/?url=https://github.com/CrazyZhang666/GTA5OnlineTools/releases/download/update/GTA5OnlineTools.exe",
            "https://download.fastgit.ixmu.net/CrazyZhang666/GTA5OnlineTools/releases/download/update/GTA5OnlineTools.exe",
            "https://ghproxy.com/https://github.com/CrazyZhang666/GTA5OnlineTools/releases/download/update/GTA5OnlineTools.exe",
            "https://kgithub.com/CrazyZhang666/GTA5OnlineTools/releases/download/update/GTA5OnlineTools.exe",
            "https://github.com/CrazyZhang666/GTA5OnlineTools/releases/download/update/GTA5OnlineTools.exe"
        };

        for (int i = 0; i < urls.Length; i++)
        {
            string name = GetName(i);
            Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] 开始下载 {name}...");
            Stopwatch sw = Stopwatch.StartNew();
            bool success = DownloadFile(urls[i], $"{name}.exe");
            sw.Stop();
            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] {name} 下载完成，用时 {sw.Elapsed.TotalSeconds:F2} 秒");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] {name} 下载失败，用时 {sw.Elapsed.TotalSeconds:F2} 秒");
                Console.ResetColor();
            }
        }
    }

    static bool DownloadFile(string url, string fileName)
    {
        try
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, fileName);
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] 下载失败：{ex.Message}");
            return false;
        }
    }

    static string GetName(int index)
    {
        switch (index)
        {
            case 0:
                return "自建cf反代";
            case 1:
                return "GitHub节点（美国2）";
            case 2:
                return "GitHub节点（美国3）";
            case 3:
                return "GitHub节点（美国4）";
            case 4:
                return "GitHub节点（日本）";
            case 5:
                return "GitHub节点（韩国）";
            case 6:
                return "GitHub节点（新加坡）";
            case 7:
                return "GitHub节点（原生）";
            default:
                return "";
        }
    }
}
