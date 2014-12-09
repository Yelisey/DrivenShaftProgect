using Shaft;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Kompas6API5;

namespace ShaftTestProject
{
    /// <summary>
    ///This is a test class for MainShaftTest and is intended
    ///to contain all MainShaftTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MainShaftTest
    {
        /// <summary>
        ///A test for MainShaft Constructor
        ///</summary>
        [TestMethod()]
        public void MainShaftConstructorTest1()
        {
            ksDocument3D document3D = null; // TODO: Initialize to an appropriate value
            KompasObject kompas = null; // TODO: Initialize to an appropriate value
            DataContainerShaft.InformationAboutShaft drivenShaftSample = 
                new DataContainerShaft.InformationAboutShaft(400, 200, 200, 35, 45, 34, 4, 300, 200, 4); // TODO: Initialize to an appropriate value
            ShaftCreator target = new ShaftCreator(document3D, kompas, drivenShaftSample);
            Assert.AreEqual(drivenShaftSample.OutsideDiameter, 400);
            Assert.AreEqual(drivenShaftSample.BaseDiameter, 200);
            Assert.AreEqual(drivenShaftSample.HeightOfGear, 200);
            Assert.AreEqual(drivenShaftSample.WidthHole, 35);
            Assert.AreEqual(drivenShaftSample.CountOfPoints, 45);
            Assert.AreEqual(drivenShaftSample.RadiusOfPoints, 34);
            Assert.AreEqual(drivenShaftSample.CountOfHole, 4);
            Assert.AreEqual(drivenShaftSample.HeightOfShaft, 300);
            Assert.AreEqual(drivenShaftSample.HeightOfSecondShaft, 200);
            Assert.AreEqual(drivenShaftSample.DepthOfPoints, 4);
        }

        [TestMethod()]
        public void OutsideDiametrTest()
        {
            DataContainerShaft.InformationAboutShaft drivenShaftSample = new DataContainerShaft.InformationAboutShaft(); // TODO: Initialize to an appropriate value
            drivenShaftSample.OutsideDiameter = 500;
            Assert.AreEqual(drivenShaftSample.OutsideDiameter, 500);
        }
    }
}
