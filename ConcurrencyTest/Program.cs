//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConcurrencyTest
//{
//    class Program
//    {
//        static  void Main(string[] args)
//        {
//            //Task.Factory.StartNew(NewMethod);
//            //Task.Factory.StartNew(NewMethod1);


//            Console.WriteLine("Write soimething...:");
//            //int result = Task Sum();
//            Console.WriteLine("Hello is : " + result);

//            Console.WriteLine("After...");

//            //string styr = Console.ReadLine();
//            //Console.WriteLine("Hello is : " + styr);
//            Console.ReadKey();
//        }

//        static int Sum()
//        {
//            Task.Delay(10000).Wait();
//            int num = 10;
//            return num;
//        }
        

//        private  static void NewMethod1()
//        {           
//            Task.Delay(10000).Wait();
//            Console.WriteLine("file 2");
//        }

//        private  static void NewMethod()
//        {          
//            Task.Delay(10000).Wait();
//            Console.WriteLine("file 1");
//        }
//    }
//}
