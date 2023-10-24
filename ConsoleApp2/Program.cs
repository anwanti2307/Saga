using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class A
    {
        public string Pallindrome(string x)
        {
            //string x = "MALAYALAM";
            string y = new string(x.Reverse().ToArray());
            return y;
        }

        public string Pallindrom(string z)
        {
            string y = string.Empty;
            for  (int x =z.Length-1; x>=0; x--)
            {
                 y += z[x];
            }
            return y;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            //a.Pallindrome("MALAYALAM");
            Console.WriteLine(a.Pallindrome("ANWANTI"));
            Console.WriteLine(a.Pallindrom("ANWANTI"));
            Console.ReadLine(); 
        }
    }
}
