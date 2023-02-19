namespace FigureLibrary
{
    public class FigureFactory : IFigureFactory
    {
        public IFigure CreateFigure(double radius)
        {
            return new Circle(radius);
        }

        public IFigure CreateFigure(double sideA, double sideB, double sideC)
        {
            return new Triangle(sideA, sideB, sideC);
        }


        public IFigure CreateFigure(double[] sides)
        {
            switch (sides.Length)
            {
                case 1:
                    {
                        return new Circle(sides);
                    }
                case 3:
                    {
                        return new Triangle(sides);
                    }
                default:
                    {
                        return new Circle(sides);
                    }
            }
        }

        public override string ToString()
        {
            return "IFigureFactory";
        }
    }
}
