using Microsoft.VisualBasic;
using System;
using System.Net;
using System.Threading;

public class HTTPGetExample
{
    public static void SendRequest(string url)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.GetResponse();
            Console.WriteLine(DateAndTime.Now + "查询成功");
            
        }
catch (Exception ex)
        {
            Console.WriteLine(DateAndTime.Now + "查询失败");
            Console.WriteLine(ex);

        }
    }

    static void Main(string[] args)
    {
        string url = "https://hqshi.cn/api/post?from=Miniprogram&user=MzXk&nickname=xxxxxxx&platform=default&expire=900";
        Timer timer = new Timer((state) => SendRequest(url), null, TimeSpan.Zero, TimeSpan.FromSeconds(930));
        Console.WriteLine(DateAndTime.Now + "开始运行");
        Console.ReadLine();
    }
}
