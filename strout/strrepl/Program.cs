using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main()
    {
        Console.WriteLine("Instructions:Place zh.txt, target_lang.txt and sch.lua in the same directory as this program, make sure zh.txt and target_lang.txt have the same number of lines and correspond to each other, press any key to start the replacement of strings.");
        Console.ReadLine();

        string[] requiredFiles = { "zh.txt", "target_lang.txt", "sch.lua" };
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

        int fileerrcount = 0;
        foreach (string file in requiredFiles)
        {
            if (!File.Exists(Path.Combine(currentDirectory, file)))
            {
                fileerrcount++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"File {file} not found.");
            }
        }
        if (fileerrcount > 0)
        {
            Console.WriteLine("About to Exit...");
            Console.ReadLine();
            System.Environment.Exit(0);
        }

        string[] inLines = File.ReadAllLines("zh.txt");
        string[] tarLines = File.ReadAllLines("target_lang.txt");

        if (inLines.Length != tarLines.Length)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("zh.txt and target_lang.txt do not have the same number of lines. About to Exit...");
            Console.WriteLine($"The former has {inLines.Length} lines, and the latter has {tarLines.Length} lines.");
            Console.ReadLine();
            System.Environment.Exit(0);
        }

        // 读取Lua源文件内容
        string luaSource = File.ReadAllText("sch.lua");
        int replcount = 0;
        // 使用正则表达式查找双引号内的字符串
        string result = Regex.Replace(luaSource, "\"(.*?)\"", match =>
        {
            string contentInsideQuotes = match.Groups[1].Value;
            int index = Array.IndexOf(inLines, contentInsideQuotes);

            if (index != -1)
            {
                replcount++;
                return "\"" + tarLines[index] + "\"";
            }
            else
            {
                return match.Value; // 未找到匹配，保留原始字符串
            }
        });

        // 写入替换后的Lua源文件
        File.WriteAllText("output.lua", result);
        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine($"{replcount} strings have been replaced. output.lua has been created in the same directory");
        Console.ReadLine();
    }
}
