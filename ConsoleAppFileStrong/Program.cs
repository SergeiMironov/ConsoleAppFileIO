using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFileStrong
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Классы Stream и FileStream На данный момент вы знаете, как открыть и создать файл, 
            но как прочитать из него информацию? Как сохранить информацию в файл? Методы класса
            File хороши, но они подходят только в самых простых случаях. При работе с текстовыми 
            файлами их вполне достаточно, а вот при работе с двоичными файлами методов 
            ReadAllBytes() и WriteAllBytes() будет маловато.
            Класс FileStream предоставляет реализацию абстрактного члена Stream для
            потоковой работы с файлами. Это элементарный поток, и он может запи­
            сывать или читать только один байт или массив байтов. Однако програм­
            мисты редко используют FileStream непосредственно, гораздо чаще они ис­
            пользуют оболочки потоков, облегчающие работу с текстовыми данными
            или типами .NET. Но в целях иллюстрации мы рассмотрим возможности
            синхронного чтения/записи типа FileStream */

            //Использование типа FileStream
            //Получаем объект типа FileStream
            using (FileStream fStream = File.Open(@"C:\temp\test.dat",FileMode.Create))
            {
            // Кодируем строку в виде массива байтов
            string txt = "Test!";
                byte[] txtByteArray = Encoding.Default.GetBytes(txt);
                // Записываем массив в файл
            fStream.Write(txtByteArray, 0, txtByteArray.Length);
            //Сбрасываем position
            fStream.Position = 0;
            // Читаем из файла и выводим на консоль
            byte[] bytesFromFile = new byte[txtByteArray.Length];
                for(int i = 0; i < txtByteArray.Length; i++)
            {
                    bytesFromFile[i] = (byte)fStream.ReadByte();
                    Console.Write(bytesFromFile[i]);
            }
                Console.WriteLine();
            // Декодируем сообщение и выводим.
            Console.Write("Декодированное сообщение: " );
                Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
            }

            /*Пример показывает не только наполнение файла тестовыми данными, но
и демонстрирует основной недостаток при работе с типом FileStream: вам
необходимо выполнять низкоуровневое кодирование и декодирование ин­
формации, которую вы записываете и которую вы читаете.Это очень не­
удобно.Но иногда ситуация этого требует.Например, когда нужно записать
поток байтов в область памяти(используется класс MemoryStream) или в
сетевое соединение(класс NetworkStream из пространства имен System.
Net.Sockets).*/








        }
    }
}
