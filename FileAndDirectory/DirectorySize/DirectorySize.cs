namespace DirectorySize
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    class DirectorySize
    {
        static void Main(string[] args)
        {
            DirectoryInfo dr = new DirectoryInfo(@"D:\Projects\VS2015\Projects\SoftUniExam\FileAndDirectory\DirectorySize\Resources\05. Folder Size\TestFolder");

            var dirInfo = dr.EnumerateFiles();

            double size = dirInfo.Select(d => d.Length).Sum();
            File.WriteAllText("result.txt", (size / 1024 / 1024).ToString());

        }
    }
}
