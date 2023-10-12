using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // 读取in.txt和tar.txt的内容
        string[] inLines = File.ReadAllLines("zh.txt");
        string[] tarLines = File.ReadAllLines("en.txt");

        if (inLines.Length != tarLines.Length)
        {
            Console.WriteLine("in.txt和tar.txt行数不匹配。");
            return;
        }

        // 读取Lua源文件内容
        string luaSource = File.ReadAllText("sch.lua");

        // 使用正则表达式查找双引号内的字符串
        string result = Regex.Replace(luaSource, "\"(.*?)\"", match =>
        {
            string contentInsideQuotes = match.Groups[1].Value;
            int index = Array.IndexOf(inLines, contentInsideQuotes);

            if (index != -1)
            {
                return "\"" + tarLines[index] + "\"";
            }
            else
            {
                return match.Value; // 未找到匹配，保留原始字符串
            }
        });

        // 写入替换后的Lua源文件
        File.WriteAllText("ensch.lua", result);

        Console.WriteLine("替换完成。");
    }
}
