using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFileText
{
    class Program
    {
        /*public enum FileMode
        {
            CreateNew,
            Create,
            Open,
            OpenOrCreate,
            Truncate,
            Append
        }*/
        /*public enum FileAccess
        {
            Read,
            Write,
            ReadWrite
        }*/
        /*public enum FileShare
        {
            Delete,
            Inheritable,
            None,
            Read,
            ReadWrite,
            Write
        }*/

        static void Main(string[] args)
        {
            FileInfo myFile = new FileInfo(@"C:\testfiles\file.vdd");
            FileStream fs = myFile.Create();
            // производим какие-либо операции c fs
            // закрываем поток
            fs.Close();

            FileInfo mf = new FileInfo(@"C:\testfiles\file.vdd");
            FileStream fsTwo = mf.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);

            //Методы OpenRead() и OpenWrite() используются для создания потоков,
            //доступных только для чтения и только для записи.
            FileInfo f = new FileInfo(@"C:\testfiles\l.dat");
            using(FileStream ro = f.OpenRead())
            {
                // выполняем операции чтения из файла
            }
            FileInfo f2 = new FileInfo(@"C:\testfiles\2.dat");
            using(FileStream rw = f2.OpenWrite())
            {
                // записываем в файл
            }
            //Для работы с текстовыми файлами пригодятся методы OpenText(),
            //CreateText() и AppendText(). Первый метод возвращает экземпляр типа
            //StreamReader(в отличие от методов Create(), Ореп() и OpenRead / Write(),
            //которые возвращают тип FileStream).

            //Пример открытия текстового файла:
            FileInfo txt = new FileInfo(@"program.log");
            using (StreamReader txt_reader = txt.OpenText())
            {
                // Читаем данные из текстового файла
            }

            //Методы CreateText() и ApendText() возвращают объект типа StreamWriter.
            //Использовать эти методы можно так:
            FileInfo f3 = new FileInfo(@"C:\testfiles\l.txt");
            using (StreamWriter lw = f3.CreateText())
            {
                // Записываем данные в файл...
            }
            FileInfo f4 = new FileInfo(@"C:\testfiles\2.txt");
            using (StreamWriter swa = f4.AppendText())
            {
                // Добавляем данные в текстовый файл
            }
            
            
            /*Тип File поддерживает несколько полезных методов, которые пригодятся
            при работе с текстовыми файлами. Например, метод ReadAllLines() позволяет 
            открыть указанный файл и прочитать из него все строки - в результате
            будет возвращен массив строк.После того как все данные из файла прочи­таны, 
            файл будет закрыт.*/
        //Пример:
            string[] myFriends = {"Jane","Max","John"};
            // Записать все данные в файл
            File.WriteAllLines(@"С:\testfiles\friends.txt", myFriends);
            // Прочитать все обратно и вывести
            foreach (string friend in File. ReadAllLines(@"C:\testfiles\friends.txt"))
            {
                Console.WriteLine("{0}", friend);
            }

        }
    }
}
