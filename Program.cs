using System;
using System.Threading;

namespace Console_Thread 
{
    
    //Отличия в многозадачности на основе процессов и потоков могут быть сведены к
    //следующему: многозадачность на основе процессов организуется для параллельного
    //выполнения программ, а многозадачность на основе потоков — для параллельного
     //выполнения отдельных частей одной программы.

    //При организации
    //многозадачности на основе потоков у каждого процесса должен быть по крайней мере
    //один поток, хотя их может быть и больше.Это означает, что в одной программе
    //одновременно могут решаться две задачи и больше.Например, текст может
    //форматироваться в редакторе текста одновременно с его выводом на печать, при условии, что оба
    //эти действия выполняются в двух отдельных потоках.

    internal class Program
    {

        public int Count;
        public Thread Thrd = null; //класс Thread для многопоточной обработки



        public Program(string s)
        {
            Count = 0;
            Thrd = new Thread(this.Start2);
            Thrd.Name = s;  
            Thrd.Start();   
                
        }

        public void  Start2()
        {
            
            Console.WriteLine("метод Start2" + Thrd.Name);
           
            int y = 20;
            do
            {
                this.Count++;
                Console.WriteLine(Thrd.Name +" считает  от"+ Count + " до " + y);
                //Этот метод обусловливает приостановление того потока, из которого он был вызван, 
                //на определенный период времени, указываемый в миллисекундах. Когда
                //приостанавливается один поток, может выполняться другой. 
                Thread.Sleep(1000);

            } while (y > Count);
            Console.WriteLine("Поток метода Start2 завершен " + Thrd.Name);

        }


        static void Main(string[] args)
        {

            Console.WriteLine("Основной поток");

            Program program = new Program(" поток номер 1");
            Program program2 = new Program("поток  номер 2");
            Program program3 = new Program("поток номер 3");

            do
            {
                Console.WriteLine("Код основного потока");
                //высвобождает время для других потоков
                Thread.Sleep(1000);

            } while (program.Count < 10 && program2.Count < 10 && program3.Count <10);


            Console.WriteLine("Код  основного потока завершен(Main)");
        }
    }
}



//ThreadStart start = delegate
//{
//    Console.WriteLine("делегат ThreadStart");
//    int x = 0;
//    int y = 20;
//    do
//    {
//        x++;
//        Console.WriteLine("Поток делегата ThreadStart " + x + " " + y);
//        //Этот метод обусловливает приостановление того потока, из которого он был вызван, 
//        //на определенный период времени, указываемый в миллисекундах. Когда
//        //приостанавливается один поток, может выполняться другой. 
//        Thread.Sleep(1000);

//    } while (y > x);
//    Console.WriteLine("Поток делегата ThreadStart завершен");

//};
////Сделаем поток  для делегата
//Thread thread = new Thread(start);
//// Запуск
//thread.Start();

//int x = 0;
//int y = 10;
//do
//{
//    x++;
//    Console.WriteLine("Код в Main " + x + " " + y);
//    Thread.Sleep(2000);
//} while (y > x);