using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo file = new DirectoryInfo(@"C:\testfiles");
            file.Create();//создаем новый каталог
            file.CreateSubdirectory("Data");// созданм подкаталог
            file.CreateSubdirectory("Object");
            Console.WriteLine("FullName: {0}", file.FullName);
            Console.WriteLine("Name: {0}", file.Name);
            Console.WriteLine("Parent: {0}", file.Parent);
            Console.WriteLine("Creation : {0}", file.CreationTime);
            Console.WriteLine("Attributes: {0}", file.Attributes);
            Console.WriteLine("Root: {0}", file.Root);
            FileInfo[] files = file.GetFiles("*.doc", SearchOption.AllDirectories);// отбор в список файлов по критерию
            Console.WriteLine("Found {0} documents", files.Length);
            // Выводим файлы:
            foreach (FileInfo f in files)
            {
                Console.WriteLine("Filename: {0}", f.Name);
                Console.WriteLine("Size: {0}", f.Length);
                Console.WriteLine("Attributes: {0}", f.Attributes);
            }
            //------------------------- Классы Directory и Drivelnfo. Получение списка дисков
            Console.WriteLine("Ваши диски:");
            string[] drives = Directory.GetLogicalDrives();
            //Метод GetLogicalDrives() не информативен. Он просто сообщает буквы логических дисков, при этом невозможно понять, где какой диск.
            foreach (string s in drives)
                Console.WriteLine("{0}", s);
            //Если нужно получить больше информации о дисках, нужно использовать тип Drivelnfo:
            DriveInfo[] drvs = DriveInfo.GetDrives();
            foreach (DriveInfo d in drvs)
            {
                Console.WriteLine("Диск: {0} Type {1}", d.Name,d.DriveType);
                if(d.IsReady)
                {
                    Console.WriteLine("Свободно: {0} ", d.TotalFreeSpace);
                    Console.WriteLine("Файловая система: {0}", d.DriveFormat);
                    Console.WriteLine("Метка: {0}", d.VolumeLabel);
                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }
    }
}
