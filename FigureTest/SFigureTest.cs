namespace FigureTest
{
    /// <summary>
    /// ????????? ??? ???????? ?????? ? ???????? ????????
    /// </summary>
    public struct SFigureTest
    {
        public double[] Sides;
        public double CheckArea;

        public string CheckName;
        public int CheckWeight;
        public bool CheckRectangular;

        public void Deconstruct(out double[] sides, out double checkArea, out string checkName, out int checkWeight)
        {
            sides = Sides;
            checkArea = CheckArea;
            checkName = CheckName;
            checkWeight = CheckWeight;
        }
    }
}
