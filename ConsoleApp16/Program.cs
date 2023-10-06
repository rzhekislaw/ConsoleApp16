namespace ns
{
    class tClass
    {
        public static void Main()
        {
            var availableDisks = Directory.GetLogicalDrives();

            for (int i = 0; i < availableDisks.Count(); i++)
            {
                availableDisks[i] = availableDisks[i].TrimEnd('\\');
            }

            Console.WriteLine("Select disk:");
            Console.WriteLine();

            foreach (var availableDisk in availableDisks)
            {
                Console.WriteLine(availableDisk);
            }

            Console.WriteLine();

            var selectedDisk = Console.ReadLine();

            if (!availableDisks.Contains(selectedDisk))
            {
                Console.WriteLine("GG");
                return;
            }

            var path = selectedDisk;
            var disk = false;

            while (true)
            {
                Console.Clear();

                if (availableDisks.Contains(path))
                {
                    disk = true;
                    Console.WriteLine("Disk reached");
                }
                else
                {
                    disk = false;
                }

                var directories = Directory.GetDirectories(path);

                foreach (var directory in directories)
                {
                    Console.WriteLine(directory);
                }
                
                Console.WriteLine();
                Console.WriteLine("Enter foldername to navigate, \'q\' to exit, \'b\' to go back, \'f\' to get files, \'nfile\' to create new file, \'nfolder\' to create new folder:");
                Console.WriteLine();

                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                if (input == "b")
                {
                    if (disk)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Drillng down impossible");
                        Console.ReadLine();
                        continue;
                    }
                    path = path.Substring(0, path.LastIndexOf("\\"));
                    continue;
                }
                if (input == "f")
                {
                    var files = Directory.GetFiles(path);
                    Console.Clear();
                    foreach (var file in files)
                    {
                        Console.WriteLine(file);
                    }
                    Console.ReadLine();
                    continue;
                }
                if (input == "nfile")
                {
                    Console.Clear();
                    Console.WriteLine("Enter name:");
                    var name = Console.ReadLine();
                    Console.WriteLine("Enter extention:");
                    var ext = Console.ReadLine();

                    var filePath = Path.Combine(path, name + "." + ext);
                    File.WriteAllText(filePath, null);

                    Console.WriteLine();
                    Console.WriteLine(name + "." + ext + " created successfully");
                    Console.ReadLine();
                    continue;
                }
                if (input == "nfolder")
                {
                    Console.Clear();
                    Console.WriteLine("Enter name:");
                    var name = Console.ReadLine();

                    Directory.CreateDirectory(Path.Combine(path, name));

                    Console.WriteLine();
                    Console.WriteLine("Folder created successfully");
                    Console.ReadLine();
                    continue;
                }
                var oldPath = path;
                path += $"\\{input}";
                if (oldPath + "\\" == path && !disk)
                {
                    path = oldPath;
                }
            }
        }
    }
}