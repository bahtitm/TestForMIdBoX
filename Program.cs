using System;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AreaCircle(6).ToString());
            Console.WriteLine(AreaTriangle(3,4,5).ToString());
            Console.WriteLine(IsRightTriangle(3, 4, 5).ToString());
        }
        static double AreaCircle(double radius )
        {            
            return  Math.PI*Math.Pow(radius,2);
        }
        static double AreaTriangle(double a, double b, double c)
        {
            var p=(a+b+c)/2;
            var S=Math.Sqrt(p*(p-a)*(p-b)*(p-c));
            return S;
        }
        static bool IsRightTriangle(double a, double b, double c)
        {
            if ((a * a + b * b == c * c) || (a * a + c * c == b * b) || (c * c + b * b == a * a))
                return true;
            return false;
        }
    }
}
