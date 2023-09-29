using Microsoft.VisualBasic;
using System;
using System.Net;
using System.IO;
using System.Threading;


public class SendHTTPGet
{
    public static int time1 = 900;
    public static int time2 = 930;
    public static void SendRequest(string url)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                // 读取响应内容
                string json = sr.ReadToEnd();
                Console.WriteLine(DateAndTime.Now + "发送请求成功，" + time2 + "秒后进行下一次查询");
                Console.WriteLine(json);
            }

            // 关闭响应对象
            response.Close();

            
        }
catch (Exception ex)
        {
            Console.WriteLine(DateAndTime.Now + "请求失败,"+ time2 + "秒后重试");
            Console.WriteLine(ex);

        }
    }

    static void Main(string[] args)
    {
        string user1, user2;
        Console.WriteLine("始终保持自己在洛圣都Express的数据是新的");

        Console.WriteLine("1.请输入查询者ID(可不填直接回车)：");
        string inputs = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(inputs))
        {
            user1 = inputs;
        }
        else
        {
            user1 = "D3Fn68K7S";
            Console.WriteLine("未检测到输入，将使用预置值");

        }
        Console.WriteLine("2.请输入目标SC用户名(必填,不区分大小写)：");
        user2 = Console.ReadLine();
        Console.WriteLine("3.请输入查询间隔(s),直接回车则默认使用930s：");
        string input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            time2 = int.Parse(input);
        }
        else
        {
            Console.WriteLine("未检测到输入，将使用默认值");
        }
        string url = "https://hqshi.cn/api/post?from=Miniprogram&user="+ user1 +"MzXk&nickname="+user2+"&platform=default&expire="+ time1;
        Timer timer = new Timer((state) => SendRequest(url), null, TimeSpan.Zero, TimeSpan.FromSeconds(time2));
        Console.WriteLine(DateAndTime.Now + "开始运行");
        Console.ReadLine();
    }
}
