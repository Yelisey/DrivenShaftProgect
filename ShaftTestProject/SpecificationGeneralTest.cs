using Shaft;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Kompas6API5;

namespace ShaftTestProject
{
    
    
    /// <summary>
    ///This is a test class for SpecificationGeneralTest and is intended
    ///to contain all SpecificationGeneralTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SpecificationGeneralTest
    {

        /// <summary>
        ///A test for SpecificationGeneral Constructor
        ///</summary>
        [TestMethod()]
        public void SpecificationGeneralConstructorTest()
        {
            KompasObject kompas = null; // TODO: Initialize to an appropriate value
            DataOfSpecification.InformationAboutSpecification specData = new DataOfSpecification.InformationAboutSpecification("Чертеж", "Сборка",
                "Ведомый вал", "Вал", "Ошлоков Е.В.", "Калентьев А.А", "03-12-2014", "03-12-2014");
            SpecificationGeneral target = new SpecificationGeneral(kompas, specData);
            Assert.AreEqual(specData.DocName, "Сборка");
            Assert.AreEqual(specData.DocParam, "Чертеж");
            Assert.AreEqual(specData.DetName, "Вал");
            Assert.AreEqual(specData.DetParam, "Ведомый вал");
            Assert.AreEqual(specData.DevelopName, "Ошлоков Е.В.");
            Assert.AreEqual(specData.MasterName, "Калентьев А.А");
            Assert.AreEqual(specData.DateOfCreate, "03-12-2014");
            Assert.AreEqual(specData.DateOfControl, "03-12-2014");
        }
    }
}
