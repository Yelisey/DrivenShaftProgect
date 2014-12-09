using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Mocks;
using Kompas6API5;
using Shaft;

namespace ShaftTestProject
{
    /// <summary>
    /// Summary description for Validate
    /// </summary>
    [TestFixture]
    public class Validate
    {
        public Validate()
        {
            
        }

        [Test]
        public void TestOutsideDiametr()
        {
            Manager manager = new Manager();
            DataContainerShaft.InformationAboutShaft drivenShaftSample =
               new DataContainerShaft.InformationAboutShaft(4004343, 200, 200, 35, 45, 34, 4, 300, 200, 4);
            Assert.That(() => manager.InitSceneForCreateShaft(drivenShaftSample), Throws.InnerException);
        }

        [Test]
        public void TestBaseDiametr()
        {
            Manager manager = new Manager();
            DataContainerShaft.InformationAboutShaft drivenShaftSample =
               new DataContainerShaft.InformationAboutShaft(400, 200343, 200, 35, 45, 34, 4, 300, 200, 4);
            Assert.That(() => manager.InitSceneForCreateShaft(drivenShaftSample), Throws.InnerException);
        }


        [Test]
        public void TestHeightOfGear()
        {
            Manager manager = new Manager();
            DataContainerShaft.InformationAboutShaft drivenShaftSample =
               new DataContainerShaft.InformationAboutShaft(400, 200, 2003434, 35, 45, 34, 4, 300, 200, 4);
            Assert.That(() => manager.InitSceneForCreateShaft(drivenShaftSample), Throws.InnerException);
        }

        [Test]
        public void TestRadiusWidthHole()
        {
            Manager manager = new Manager();
            DataContainerShaft.InformationAboutShaft drivenShaftSample =
               new DataContainerShaft.InformationAboutShaft(400, 200, 200, 3534343, 45, 34, 4, 300, 200, 4);
            Assert.That(() => manager.InitSceneForCreateShaft(drivenShaftSample), Throws.InnerException);
        }

        [Test]
        public void TestCountOfPoints()
        {
            Manager manager = new Manager();
            DataContainerShaft.InformationAboutShaft drivenShaftSample =
               new DataContainerShaft.InformationAboutShaft(400, 200, 200, 35, 4534343, 34, 4, 300, 200, 4);
            Assert.That(() => manager.InitSceneForCreateShaft(drivenShaftSample), Throws.InnerException);
        }

        [Test]
        public void TestRadiusOfPoints()
        {
            Manager manager = new Manager();
            DataContainerShaft.InformationAboutShaft drivenShaftSample =
               new DataContainerShaft.InformationAboutShaft(400, 200, 200, 35, 45, 343434, 4, 300, 200, 4);
            Assert.That(() => manager.InitSceneForCreateShaft(drivenShaftSample), Throws.InnerException);
        }

        [Test]
        public void TestCountOfHole()
        {
            Manager manager = new Manager();
            DataContainerShaft.InformationAboutShaft drivenShaftSample =
               new DataContainerShaft.InformationAboutShaft(400, 200, 200, 35, 45, 34, 434343, 300, 200, 4);
            Assert.That(() => manager.InitSceneForCreateShaft(drivenShaftSample), Throws.InnerException);
        }


        [Test]
        public void TestHeightOfShaft()
        {
            Manager manager = new Manager();
            DataContainerShaft.InformationAboutShaft drivenShaftSample =
               new DataContainerShaft.InformationAboutShaft(400, 200, 200, 35, 45, 34, 4, 30034343, 200, 4);
            Assert.That(() => manager.InitSceneForCreateShaft(drivenShaftSample), Throws.InnerException);
        }

        [Test]
        public void TestHeightOfSecondShaft()
        {
            Manager manager = new Manager();
            DataContainerShaft.InformationAboutShaft drivenShaftSample =
               new DataContainerShaft.InformationAboutShaft(400, 200, 200, 35, 45, 34, 4, 300, 20034343, 4);
            Assert.That(() => manager.InitSceneForCreateShaft(drivenShaftSample), Throws.InnerException);
        }

        [Test]
        public void TestDepthOfPoints()
        {
            Manager manager = new Manager();
            DataContainerShaft.InformationAboutShaft drivenShaftSample =
               new DataContainerShaft.InformationAboutShaft(400, 200, 200, 35, 45, 34, 4, 300, 200, 4434343);
            Assert.That(() => manager.InitSceneForCreateShaft(drivenShaftSample), Throws.InnerException);
        }

    }
}
