using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.Core;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;
using System.Net;
using Logistics_Busniess;
using Logistics.Common;

namespace Logistics.Console
{
    [Serializable]
    public class AA {
        public int a;
    }


  public  class Program
    {
        static void Main(string[] args)
        {
          //  var result = SMSHelper.send();
          
          // var userNo =  RuleManger.SetCurrentNo(901992431992573952, "user");
          //  var oderNo = RuleManger.SetCurrentNo(901992431992573952, "order");
          //MemcachedClientConfiguration config = new MemcachedClientConfiguration();
          //config.Servers.Add(new IPEndPoint(IPAddress.Loopback, 11211));
          //config.Protocol = MemcachedProtocol.Binary;
          //config.Authentication.Type = typeof(PlainTextAuthenticator);
          //config.Authentication.Parameters["userName"] = "demo";
          //config.Authentication.Parameters["password"] = "demo";

            //var mc = new MemcachedClient(config);

            //for (var i = 0; i < 100; i++)
            //    mc.Store(StoreMode.Set, "Hello", "World");
            // MemcachedHelper.Instance().SetValue("11", "22", "44");
            //AA aa = new AA();
            //aa.a = 2;

            //MemcachedHelper.Instance().SetValue("33", "22", aa);
            // var obj = MemcachedHelper.Instance().GetValue("33", "22");




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
