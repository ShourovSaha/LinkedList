using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncApp
{
    class Program
    {
        public delegate decimal CalculatePower(decimal n);
        static CalculatePower _calculatePower = Power;
        static void Main(string[] args)
        {
            decimal result = _calculatePower.Invoke(2);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static decimal Power(decimal num)
        {
            return num * num;
        }

    }
}
