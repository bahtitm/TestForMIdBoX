using System;
using System.Collections.Generic;
using FigureLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FigureTest
{
    [TestClass]
    public class FigureFactoryTest
    {
        [TestMethod]
        public void FigureFactoryConstructortest()
        {
            IFigureFactory figureFactory = new FigureFactory();
            Assert.AreEqual(figureFactory.ToString(), "IFigureFactory");
        }

        [TestMethod]
        public void FigureCreateTest()
        {
            IFigure figureCircle = new Circle();
            Assert.AreEqual(figureCircle.ToString(), "circle");

            IFigure figureTriangle = new Triangle();
            Assert.AreEqual(figureTriangle.ToString(), "triangle");
        }

        [TestMethod]
        public void DifferentFigureCreateTest()
        {
            IFigureFactory figureFactory = new FigureFactory();
            Assert.AreEqual(figureFactory.ToString(), "IFigureFactory");

            IFigure figureCircle = figureFactory.CreateFigure(5);
            Assert.AreEqual(figureCircle.ToString(), "circle");

            IFigure figureTriangle = figureFactory.CreateFigure(5, 5, 5);
            Assert.AreEqual(figureTriangle.ToString(), "triangle");
        }

        [TestMethod]
        public void CreateFigureFromList()
        {
            List<SFigureTest> figureList = new List<SFigureTest>();
            IFigureFactory figureFactory = new FigureFactory();

            figureList.Add(new SFigureTest() { Sides = new double[] { 5 }, CheckName = "circle" });
            figureList.Add(new SFigureTest() { Sides = new double[] { 2 }, CheckName = "circle" });
            figureList.Add(new SFigureTest() { Sides = new double[] { 7 }, CheckName = "circle" });
            figureList.Add(new SFigureTest() { Sides = new double[] { 13, 5, 14 }, CheckName = "triangle" });
            figureList.Add(new SFigureTest() { Sides = new double[] { 5, 5, 5 }, CheckName = "triangle" });
            figureList.Add(new SFigureTest() { Sides = new double[] { 7, 3, 9 }, CheckName = "triangle" });

            figureList.ForEach(delegate (SFigureTest figure)
            {
                var (sides, checkArea, checkName, checkWeight) = figure;
                IFigure testFigure = figureFactory.CreateFigure(sides);
                Assert.AreEqual(testFigure.ToString(), checkName);
            });
        }

        [TestMethod]
        public void heckAreaFromList()
        {
            List<SFigureTest> figureList = new List<SFigureTest>();
            IFigureFactory figureFactory = new FigureFactory();

            figureList.Add(new SFigureTest() { Sides = new double[] { 5 }, CheckArea = 78.539816, CheckName = "circle" });
            figureList.Add(new SFigureTest() { Sides = new double[] { 2 }, CheckArea = 12.566371, CheckName = "circle" });
            figureList.Add(new SFigureTest() { Sides = new double[] { 7 }, CheckArea = 153.93804, CheckName = "circle" });
            figureList.Add(new SFigureTest() { Sides = new double[] { 13, 5, 14 }, CheckArea = 32.496154, CheckName = "triangle" });
            figureList.Add(new SFigureTest() { Sides = new double[] { 5, 5, 5 }, CheckArea = 10.825318, CheckName = "triangle" });
            figureList.Add(new SFigureTest() { Sides = new double[] { 7, 3, 9 }, CheckArea = 8.785642, CheckName = "triangle" });

            figureList.ForEach(delegate (SFigureTest figure)
            {
                var (sides, checkArea, checkName, checkWeight) = figure;
                IFigure testFigure = figureFactory.CreateFigure(sides);
                Assert.AreEqual(testFigure.Area, checkArea, 0.0001, "The area of circle should have been equal");
            });
        }

        [TestMethod]
        public void heckWithChgangeSidesList()
        {
            IFigureFactory figureFactory = new FigureFactory();

            IFigure testCircle = figureFactory.CreateFigure(1);
            Assert.AreEqual(testCircle.Area, 3.14159, 0.0001, "The area of circle should have been equal");

            testCircle.FigureSides = new double[] { 2 };
            Assert.AreEqual(testCircle.Area, 12.566371, 0.0001, "The area of circle should have been equal");
            Assert.AreEqual(testCircle.Type, "circle", "The name of object should have been equal");

            IFigure testTriangle = figureFactory.CreateFigure(7, 3, 9);
            Assert.AreEqual(testTriangle.Area, 8.785642, 0.0001, "The area of triangle should have been equal");

            testTriangle.FigureSides = new double[] { 13, 5, 14 };
            Assert.AreEqual(testTriangle.Area, 32.496154, 0.0001, "The area of triangle should have been equal");
            Assert.AreEqual(testTriangle.Type, "triangle", "The name of object should have been equal");
        }

       

        [TestMethod]
        public void RectangularCheckTest()
        {
            IFigureFactory figureFactory = new FigureFactory();

            IFigure circle = figureFactory.CreateFigure(12);
            Assert.AreEqual(circle.Rectangular(), false, "The circle not a rectangular figure");

            List<SFigureTest> figuresList = new List<SFigureTest>();

            figuresList.Add(new SFigureTest() { Sides = new double[] { 3, 4, 5 }, CheckRectangular = true });
            figuresList.Add(new SFigureTest() { Sides = new double[] { 12 }, CheckRectangular = false });
            figuresList.Add(new SFigureTest() { Sides = new double[] { 7, 11, 5 }, CheckRectangular = false });
            figuresList.Add(new SFigureTest() { Sides = new double[] { 5, 12, 13 }, CheckRectangular = true });
            figuresList.Add(new SFigureTest() { Sides = new double[] { 3 }, CheckRectangular = false });
            figuresList.Add(new SFigureTest() { Sides = new double[] { 27, 36, 45 }, CheckRectangular = true });
            figuresList.Add(new SFigureTest() { Sides = new double[] { 14, 15, 5 }, CheckRectangular = false });
            figuresList.Add(new SFigureTest() { Sides = new double[] { 7 }, CheckRectangular = false });

            figuresList.ForEach(delegate (SFigureTest figure)
            {
                double[] Sides = figure.Sides;
                string SidesFigure = "";

                foreach (var side in Sides)
                {
                    SidesFigure += side.ToString() + " ";
                }

                IFigure testFigure = figureFactory.CreateFigure(Sides);
                Assert.AreEqual(testFigure.Rectangular(), figure.CheckRectangular, String.Format("Rectangular status for parameter '{0}' is '{1}'", SidesFigure, figure.CheckRectangular));
            });
        }

        
    }
}
