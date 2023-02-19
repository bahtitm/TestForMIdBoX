using System;
using System.Collections.Generic;
using FigureLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FigureTest
{
    [TestClass]
    public class CircleTest
    {
        double Delta = 0.0001;

        [TestMethod]
        public void circleConstructor()
        {
            Circle testCircle = new Circle();
            Assert.AreEqual(testCircle.ToString(), "circle");

            Circle testCircleWithValue = new Circle(5);
            Assert.AreEqual(testCircleWithValue.ToString(), "circle");

            Circle testCircleWithArray = new Circle(new double[] { 5 });
            Assert.AreEqual(testCircleWithArray.ToString(), "circle");
        }

        [TestMethod]
        public void circleException()
        {
            try
            {
                Circle testCircleNotACircle = new Circle(-5);
                Assert.Fail("An exception should have been throw");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Radius cannot be assigned as negative value");
            }
        }

        [TestMethod]
        public void circleAreaTest()
        {
            List<SFigureTest> circleList = new List<SFigureTest>();

            circleList.Add(new SFigureTest() { Sides = new double[] { 5 }, CheckArea = 78.539816 });
            circleList.Add(new SFigureTest() { Sides = new double[] { 2 }, CheckArea = 12.566371 });
            circleList.Add(new SFigureTest() { Sides = new double[] { 7 }, CheckArea = 153.93804 });

            circleList.ForEach(delegate (SFigureTest circle)
            {
                var (sides, checkArea, checkName, checkWeight) = circle;
                double result = Circle.GetArea(sides);
                Assert.AreEqual(result, checkArea, Delta, String.Format("Circle with radius '{0}'", sides[0]));
            });
        }

        [TestMethod]
        public void circleAreayObjectTest()
        {
            List<SFigureTest> circleList = new List<SFigureTest>();

            circleList.Add(new SFigureTest() { Sides = new double[] { 5 }, CheckArea = 78.539816 });
            circleList.Add(new SFigureTest() { Sides = new double[] { 2 }, CheckArea = 12.566371 });
            circleList.Add(new SFigureTest() { Sides = new double[] { 7 }, CheckArea = 153.93804 });

            circleList.ForEach(delegate (SFigureTest circle)
            {
                var (sides, checkArea, checkName, checkWeight) = circle;
                Circle circleTest = new Circle(sides);
                Assert.AreEqual(circleTest.Area, checkArea, Delta, String.Format("Circle with radius '{0}'", sides[0]));
            });
        }        
       
    }
}
