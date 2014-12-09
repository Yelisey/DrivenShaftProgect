using Shaft;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Kompas6API5;

namespace ShaftTestProject
{
    /// <summary>
    ///This is a test class for SpecificationManagerTest and is intended
    ///to contain all SpecificationManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SpecificationManagerTest
    {
        /// <summary>
        ///A test for SpecificationManager Constructor
        ///</summary>
        [TestMethod()]
        public void SpecificationManagerConstructorTest()
        {
            KompasObject kompas = null; // TODO: Initialize to an appropriate value
            DataOfSpecification.InformationAboutSpecification data = new DataOfSpecification.InformationAboutSpecification("Чертеж", "Сборка",
                "Ведомый вал", "Вал", "Ошлоков Е.В.", "Калентьев А.А", "03-12-2014", "03-12-2014");
            SpecificationCreator target = new SpecificationCreator(kompas, data);
            Assert.AreEqual(data.DocParam, "Чертеж");
            Assert.AreEqual(data.DocName, "Сборка");
            Assert.AreEqual(data.DetParam, "Ведомый вал");
            Assert.AreEqual(data.DetName, "Вал");
            Assert.AreEqual(data.DevelopName, "Ошлоков Е.В.");
            Assert.AreEqual(data.MasterName, "Калентьев А.А");
            Assert.AreEqual(data.DateOfCreate, "03-12-2014");
            Assert.AreEqual(data.DateOfControl, "03-12-2014");
        }
    }
}
