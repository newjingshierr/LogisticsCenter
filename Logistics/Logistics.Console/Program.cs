using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(CData.Num);///A  
            //Console.WriteLine(CData.Num);///B             
            //Console.ReadLine();
            // SimpleClass.print();
            // Log4net.Error("ddd");

            Log4net.Error("111");
        }
    }


    public class SimpleClass
    {
        public static int c = 1;
        // Static constructor
        static SimpleClass()
        {
            int a = 1;
            c = 2;
            //
        }

        public static void print()
        {
            int a = 1;
            var d = c + 1;
        }
    }
}
