using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.Core;

namespace Logistics.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var reslt = IdWorker.GetID();

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
