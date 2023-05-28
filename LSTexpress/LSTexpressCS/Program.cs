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
        string user1, user2;
        Console.WriteLine("请输入查询者ID(可瞎填)：");
        user1 = Console.ReadLine();
        Console.WriteLine("请输入目标SC用户名(不区分大小写)：");
        user2 = Console.ReadLine();
        string url = "https://hqshi.cn/api/post?from=Miniprogram&user="+ user1 +"MzXk&nickname="+user2+"&platform=default&expire=900";
        Timer timer = new Timer((state) => SendRequest(url), null, TimeSpan.Zero, TimeSpan.FromSeconds(930));
        Console.WriteLine(DateAndTime.Now + "开始运行");
    }
}
