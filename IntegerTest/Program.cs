using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            long num = 9999999999999999;
            BigInt a = new BigInt(num);

            long num2 = 0;
            BigInt b = new BigInt(num2);


            Console.WriteLine(num + num2);
        }
    }
}
