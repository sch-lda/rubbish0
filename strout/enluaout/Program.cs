using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string luaFileName = "C:\\Users\\SongCH\\Downloads\\ensch.lua"; // 替换为你的Lua文件路径
        string outputFileName = "C:\\Users\\SongCH\\Downloads\\ensch.lua.txt"; // 替换为输出文件名

        try
        {
            string luaCode = File.ReadAllText(luaFileName);
            string[] keywords = { "log", "button", "gui", "checkbox" };
            string pattern = "\"(.*?)\""; // 匹配双引号内的内容

            MatchCollection matches = Regex.Matches(luaCode, pattern);
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                foreach (Match match in matches)
                {
                    string line = GetLineContainingMatch(luaCode, match);
                    if (ContainsAnyKeyword(line, keywords) && !IsWhiteSpaceOrPercent(match.Groups[1].Value))
                    {
                        writer.WriteLine(match.Groups[1].Value);
                    }
                }
            }

            Console.WriteLine("提取完成，字符串已导出到 " + outputFileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("发生错误: " + ex.Message);
        }
    }

    static string GetLineContainingMatch(string text, Match match)
    {
        int index = text.IndexOf(match.Value);
        if (index >= 0)
        {
            int lineStart = text.LastIndexOf('\n', index) + 1;
            int lineEnd = text.IndexOf('\n', index);
            if (lineEnd < 0)
            {
                lineEnd = text.Length;
            }
            return text.Substring(lineStart, lineEnd - lineStart);
        }
        return string.Empty;
    }

    static bool ContainsAnyKeyword(string line, string[] keywords)
    {
        foreach (string keyword in keywords)
        {
            if (line.Contains(keyword))
            {
                return true;
            }
        }
        return false;
    }

    static bool ContainsChineseCharacters(string value)
    {
        return Regex.IsMatch(value, @"[\u4e00-\u9fa5]");
    }

    static bool IsWhiteSpaceOrPercent(string value)
    {
        return string.IsNullOrWhiteSpace(value) || value.Trim() == "%" || value.Equals("sch lua") || value.Contains("MATTOTALFORFACTORY");
    }
}
