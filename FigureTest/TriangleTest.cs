using System;
using System.Collections.Generic;
using FigureLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FigureTest
{
        [TestClass]
        public class TriangleTest
        {
            double Delta = 0.0001;

            [TestMethod]
            public void triangleConstructor()
            {
                Triangle testCircle = new Triangle();
                Assert.AreEqual(testCircle.ToString(), "triangle");

                Triangle testCircleWithValue = new Triangle(5, 5, 5);
                Assert.AreEqual(testCircleWithValue.ToString(), "triangle");

                Triangle testCircleWithArray = new Triangle(new double[] { 5, 5, 5 });
                Assert.AreEqual(testCircleWithArray.ToString(), "triangle");
            }

            [TestMethod]
            public void triangleException()
            {
                try
                {
                    Triangle testCircleNotACircle = new Triangle(5, 15, 55);
                    Assert.Fail("An exception should have been throw");
                }
                catch (Exception e)
                {
                    Assert.AreEqual(e.Message, "One of the sides too long");
                }

                try
                {
                    Triangle testCircleNotACircle = new Triangle(new double[] { 3, 4 });
                    Assert.Fail("An exception should have been throw");
                }
                catch (Exception e)
                {
                    Assert.AreEqual(e.Message, "Too few parameters for sides");
                }

                try
                {
                    Triangle testCircleNotACircle = new Triangle(new double[] { 3, 4, 7, 3 });
                    Assert.Fail("An exception should have been throw");
                }
                catch (Exception e)
                {
                    Assert.AreEqual(e.Message, "Too many parameters for sides");
                }

                try
                {
                    Triangle testCircleNotACircle = new Triangle(new double[] { 0, 4, 4 });
                    Assert.Fail("An exception should have been throw");
                }
                catch (Exception e)
                {
                    Assert.AreEqual(e.Message, "One of the side has bad size (0 or negative)");
                }

                try
                {
                    Triangle testCircleNotACircle = new Triangle(new double[] { -5, 4, 4 });
                    Assert.Fail("An exception should have been throw");
                }
                catch (Exception e)
                {
                    Assert.AreEqual(e.Message, "One of the side has bad size (0 or negative)");
                }
            }

            [TestMethod]
            public void TriangleGetArea()
            {
                List<SFigureTest> triangleList = new List<SFigureTest>();

                triangleList.Add(new SFigureTest() { Sides = new double[] { 13, 5, 14 }, CheckArea = 32.496154 });
                triangleList.Add(new SFigureTest() { Sides = new double[] { 5, 5, 5 }, CheckArea = 10.825318 });
                triangleList.Add(new SFigureTest() { Sides = new double[] { 7, 3, 9 }, CheckArea = 8.785642 });

                triangleList.ForEach(delegate (SFigureTest triangleTest)
                {
                    var (sides, checkArea, checkName, checkWeight) = triangleTest;
                    double result = Triangle.GetArea(sides);
                    Assert.AreEqual(result, checkArea, Delta, String.Format("Triangle with sides '{0}, {1}, {2}' ", sides[0], sides[1], sides[2]));
                });
            }


            [TestMethod]
            public void triangleLetsSides()
            {
                Triangle testTriangle = new Triangle();
                Assert.AreEqual(testTriangle.ToString(), "triangle");

                testTriangle.FigureSides = new double[] { 13, 5, 14 };
                Assert.AreEqual(testTriangle.Area, 32.496154, Delta, String.Format("Triangle with sides '{0}, {1}, {2}' ", 13, 5, 14));

               
            }

            [TestMethod]
            public void TriangleWorkWitObject()
            {
                List<SFigureTest> triangleList = new List<SFigureTest>();

                triangleList.Add(new SFigureTest() { Sides = new double[] { 13, 5, 14 }, CheckArea = 32.496154 });
                triangleList.Add(new SFigureTest() { Sides = new double[] { 5, 5, 5 }, CheckArea = 10.825318 });
                triangleList.Add(new SFigureTest() { Sides = new double[] { 7, 3, 9 }, CheckArea = 8.785642 });

                triangleList.ForEach(delegate (SFigureTest triangleTest)
                {
                    var (sides, checkArea, checkName, checkWeight) = triangleTest;
                    Triangle testTriangle = new Triangle(sides);
                    Assert.AreEqual(testTriangle.Area, checkArea, Delta, String.Format("Triangle with sides '{0}, {1}, {2}' ", sides[0], sides[1], sides[2]));
                });
            }

            

          
        }
    
}
