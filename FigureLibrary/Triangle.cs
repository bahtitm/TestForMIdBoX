using System;
using System.Collections;

namespace FigureLibrary
{
    public class Triangle : IFigure
    {
        /// <summary>
        /// Значение площади фигуры
        /// </summary>
        private double area;

        /// <summary>
        /// Значение сторон фигуры
        /// </summary>
        private double[] figureSides;

        /// <summary>
        /// Тип фигуры
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Площадь треугольника
        /// </summary>
        public double Area
        {
            get { return area; }

        }

        /// <summary>
        /// Стороны фигуры double[]
        /// </summary>
        public double[] FigureSides
        {
            get { return figureSides; }
            set
            {
                double[] triangleSides = (double[])value.Clone();

                if (triangleSides != figureSides)
                {
                    if (TriangleValidate(triangleSides))
                    {
                        figureSides = triangleSides;
                        area = AreaCalculate(triangleSides);
                    }
                }
            }
        }

        /// <summary>
        /// Конструктор Triangle
        /// </summary>
        public Triangle() : this(0, 0, 0) { }

        /// <summary>
        /// Конструктор Triangle
        /// </summary>
        /// <param name="radius">значение радиуса double</param>
        public Triangle(double sideA, double sideB, double sideC) : this(new double[] { sideA, sideB, sideC }) { }

        /// <summary>
        /// Конструктор Triangle
        /// </summary>
        /// <param name="radius">значение радиуса double[]</param>
        public Triangle(double[] sides)
        {
            FigureSides = sides;
            Type = "triangle";
        }

        /// <summary>
        /// Площадь треугольника
        /// </summary>
        /// <param name="sideA">сторона A double</param>
        /// <param name="sideB">стоорна B double</param>
        /// <param name="sideC">сторона C double</param>
        /// <returns>площадь треугольника double</returns>
        public static double GetArea(double sideA, double sideB, double sideC)
        {
            return GetArea(new double[] { sideA, sideB, sideC });
        }

        /// <summary>
        /// Площадь треугольника
        /// </summary>
        /// <param name="sides">стороны треугольника double[]</param>
        /// <returns>площадь треугольника double</returns>
        public static double GetArea(double[] sides)
        {
            double[] triangleSedes = (double[])sides.Clone();

            if (TriangleValidate(triangleSedes))
            {
                return AreaCalculate(triangleSedes);
            }
            else
            {
                return 0;
            }
        }

        public bool Rectangular()
        {
            if (figureSides[2] == Math.Sqrt(Math.Pow(figureSides[0], 2) + Math.Pow(figureSides[1], 2)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Triangle triangle = (Triangle)obj;

                IStructuralEquatable testThis = figureSides;
                double[] testObj = triangle.figureSides;

                return testThis.Equals(testObj, StructuralComparisons.StructuralEqualityComparer);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Получить название фигуры
        /// </summary>
        /// <returns>название фигуры string</returns>
        public override string ToString()
        {
            return Type;
        }

        /// <summary>
        /// Расчет площади треугольника
        /// </summary>
        /// <param name="sides">список сторон треугольника List of double</param>
        /// <returns>площадь треугольника double</returns>
        private static double AreaCalculate(double[] sides)
        {
            double halfP = (sides[0] + sides[1] + sides[2]) / 2;
            return Math.Sqrt(halfP * (halfP - sides[0]) * (halfP - sides[1]) * (halfP - sides[2]));

        }

        /// <summary>
        /// Валидация треугольника. Фигура соответствует треугольнику если (в соответствии с контролем):
        /// - задано сторон не меньше 3
        /// - задано сторон не более 3
        /// - отдельные стороны не равны 0 и не меньше (исключение, если все стороны = 0 - для создания пустого объекта)
        /// - наибольшая сторона не больше суммы двух других
        /// </summary>
        /// <param name="radius">значение радиуса double</param>
        /// <returns>true - треугольник; исключение - при несоответствии</returns>
        private static bool TriangleValidate(double[] sides)
        {
            double sumOfSides = SitesSum(sides);
            SitesSort(sides);

            if (sides.Length < 3)
            {
                throw new Exception("Too few parameters for sides");
            }

            if (sides.Length > 3)
            {
                throw new Exception("Too many parameters for sides");
            }

            foreach (var side in sides)
            {
                if (side <= 0 & sumOfSides != 0)
                {
                    throw new Exception("One of the side has bad size (0 or negative)");
                }
            }

            if (sides[2] > sides[1] + sides[0] & sumOfSides != 0)
            {
                throw new Exception("One of the sides too long");
            }

            return true;
        }
        private static void SitesSort(double[] saites)
        {
            int left = 0;
            int right = saites.Length - 1;

            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    if (saites[i] > saites[i + 1])
                    {
                        double tempSwap = saites[i];
                        saites[i] = saites[i + 1];
                        saites[i + 1] = tempSwap;

                    }
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    if (saites[i - 1] > saites[i])
                    {
                        double tempSwap = saites[i];
                        saites[i] = saites[i + 1];
                        saites[i + 1] = tempSwap;
                    }
                }
                left++;
            }
        }

        private static double SitesSum(double[] sumArray)
        {
            double result = 0;
            foreach (var item in sumArray)
            {
                result += item;
            }

            return result;
        }
    }
}
