namespace FigureLibrary
{
    public interface IFigure
    {
        double Area { get; }

        string Type { get; }

        double[] FigureSides { get; set; }

        bool Rectangular();
    }
}
