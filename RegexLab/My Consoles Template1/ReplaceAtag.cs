namespace My_Consoles_Template1
{
    using System;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var rx = new Regex(@"<a.*?href=([""].+?[""])>(.+?)<\/a>");
            
            var result = rx.Replace(text,
                @"[URL href=$1]$2[/URL]");

            Console.WriteLine(result);
        }
    }
}
