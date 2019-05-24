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

            Action<string> _myAction = str => Console.WriteLine(str);
            _myAction("This is Action type delegate");

            Predicate<string> _myPredicate = str => str.Length > 5;
            bool result2 = _myPredicate("Sho");
            Console.WriteLine(result2);


            Predicate<Student> IsAGradeStudentExist = x => x.Grade >= 4.00;

            List<Student> students = new List<Student>
            {
                new Student{Roll = 2, Name = "Max", Grade = 3.75},
                new Student {Roll = 5, Name = "Sid", Grade = 4.5},
                new Student {Roll = 5, Name = "Joo", Grade = 4.5}
            };
            Console.WriteLine("Student Name: " + students.Find(IsAGradeStudentExist).Name);
            

            Console.ReadKey();
        }

        //public static decimal Power(decimal num)
        //{
        //    return num * num;
        //}

    }

    public class Student
    {
        public int Roll { get; set; }
        public string Name { get; set; }
        public double Grade { get; set; }
    }
}
