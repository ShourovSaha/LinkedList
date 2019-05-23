using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncApp
{
    class Program
    {
        //public delegate decimal CalculatePower(decimal n);
        //static CalculatePower _calculatePower = Power;
        static void Main(string[] args)
        {
            //decimal result = _calculatePower.Invoke(2);
            //CalculatePower _calculatePower = new CalculatePower(
            //                                    delegate(decimal num) 
            //                                    {
            //                                        return num * num;
            //                                    });

            //CalculatePower _calculatePower = x => x * x;
            Func<decimal, decimal> _calculatePower = x => x * x;
            decimal result = _calculatePower(2);
            Console.WriteLine(result);

            Action<string> _myAction = str =>
            {
                Console.WriteLine(str);
            };
            _myAction("This is Action type delegate");
            Console.ReadKey();
        }

        //public static decimal Power(decimal num)
        //{
        //    return num * num;
        //}

    }
}
