using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Files
{
    class Files
    {
        class File
        {
            public string Root { get; set; }
            public string Folder { get; set; }
            public string Name { get; set; }
            public string Extension { get; set; }
            public string Size { get; set; }

            public File(string root, string folder, string name, string extension, string size)
            {
                Root = root;
                Folder = folder;
                Name = name;
                Extension = extension;
                Size = size;
            }
        }

        static List<File> files = new List<File>();

        static void Main()
        {
            var numberOfFiles = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfFiles; i++)
            {
                ReadInput();
            }

            var search = Console.ReadLine().Split();
            var searchExtension = search[0];
            var inRoot = search[2];

            var isFound = files.Any(f => f.Extension == searchExtension)
                && files.Where(f => f.Extension == searchExtension).Any(f => f.Root == inRoot);

            if (isFound)
            {
                var searchedFiles = files.Where(f => f.Extension == searchExtension)
                    .Where(f => f.Root == inRoot)
                    .OrderByDescending(f => f.Size)
                    .ThenBy(f => f.Name)
                    .Distinct();

                foreach (var file in searchedFiles)
                {
                    Console.WriteLine("{0}.{1} - {2} KB", file.Name, file.Extension, file.Size);
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        private static void ReadInput()
        {
            var input = Console.ReadLine().Split(';');
            var size = input[1];

            var filePath = input[0].Split('\\').Select(s => s.Trim()).ToArray();

            var root = filePath[0];
            var folder = string.Join("\\", filePath.Skip(1).Take(filePath.Length - 2));

            var fileName = filePath[filePath.Length - 1];
            var lastDotIndex = Array.LastIndexOf(fileName.ToCharArray(), '.');
            var name = (string.Join("", fileName.Take(lastDotIndex))).Trim();
            var extension = string.Join("", fileName.Skip(lastDotIndex + 1));

            var file = new File(root, folder, name, extension, size);

            bool isFoundSame = files.Where(f => f.Extension == extension).Where(f => f.Name == name).Where(f => f.Root == root).Any(f => f.Folder == folder);
            if (isFoundSame)
            {
                files.Find(f => f.Extension == extension && f.Name == name && f.Folder == folder && f.Root == root).Size
                    = size;
            }
            else
            {
                files.Add(file);
            }
        }
    }
}