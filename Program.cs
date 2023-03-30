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
            DateTime dateTime = DateTime.Now;
          
            Console.WriteLine("начат метод Start2 " + Thrd.Name +" "+ dateTime+" "+ dateTime.Millisecond);
           
            int y = 4;
            do
            {
                DateTime dateTime2 = DateTime.Now;
                this.Count++;
                Console.WriteLine(Thrd.Name +" счет: "+ Count + " считаем до: " + y + " время исполнения "+ dateTime2+" "+ dateTime2.Millisecond);
                //Этот метод обусловливает приостановление того потока, из которого он был вызван, 
                //на определенный период времени, указываемый в миллисекундах. Когда
                //приостанавливается один поток, может выполняться другой. 
                Thread.Sleep(2000);

            } while (y > Count);
            DateTime dateTime3 = DateTime.Now;
            Console.WriteLine("Поток " + Thrd.Name+ " метода Start2 завершен " + dateTime3+" "+ dateTime3.Millisecond);

        }


        static void Main(string[] args)
        {
            //многозадачность на основе потоков - код делется на части на потоки
            DateTime dateTime = DateTime.Now;
            Console.WriteLine("Основной поток № " + Thread.CurrentThread.ManagedThreadId +" начат " + dateTime +" "+ dateTime.Millisecond);


            Program program = new Program("поток № 1");
            Program program2 = new Program("поток № 2");
            Program program3 = new Program("поток № 3");


            //Thread thread = new Thread(delegate (object o)
            //{
            //    for (int i = 0; i < (int)o; i++)
            //    {
            //        Thread.Sleep(2000);
            //        DateTime dateTime4 = DateTime.Now;
            //        if (i == 3)
            //        {

            //            Console.WriteLine(dateTime4+" "+ dateTime4.Millisecond + " thread2");
            //        }



            //        Console.WriteLine("поток thread " + dateTime4 + " " + dateTime4.Millisecond );
            //    }
               


            //});

            //thread.Start(4); 









            do
            {
                DateTime dateTime5 = DateTime.Now;
                
                Console.WriteLine("Код основного потока № " + Thread.CurrentThread.ManagedThreadId + " " + dateTime  + "  " + dateTime5.Millisecond);
                //высвобождает время для других потоков
                Thread.Sleep(2000);

            } while (program.Thrd.IsAlive && program2.Thrd.IsAlive && program3.Thrd.IsAlive);



            program.Thrd.Join();
            program2.Thrd.Join();
            program3.Thrd.Join();
            //thread.Join();

            DateTime dateTime2 = DateTime.Now;
            Console.WriteLine("Код  основного потока завершен(Main) " + dateTime2 + " " + dateTime2.Millisecond );
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