using Shaft;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ShaftTestProject
{
    
    
    /// <summary>
    ///This is a test class for SpecificationData_InformationForSpecificationTest and is intended
    ///to contain all SpecificationData_InformationForSpecificationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SpecificationData_InformationForSpecificationTest
    {

        /// <summary>
        ///A test for InformationForSpecification Constructor
        ///</summary>
        [TestMethod()]
        public void SpecificationData_InformationForSpecificationConstructorTest()
        {
            string docParam = "Чертеж"; // TODO: Initialize to an appropriate value
            string docName = "Сборка"; // TODO: Initialize to an appropriate value
            string detParam = "Ведомый вал"; // TODO: Initialize to an appropriate value
            string detName = "Вал"; // TODO: Initialize to an appropriate value
            string developName = "Ошлоков Е.В."; // TODO: Initialize to an appropriate value
            string masterName = "Калентьев А.А"; // TODO: Initialize to an appropriate value
            string dateOfCreate = "03-12-2014"; // TODO: Initialize to an appropriate value
            string dateOfControl = "03-12-2014"; // TODO: Initialize to an appropriate value
            DataOfSpecification.InformationAboutSpecification target = new DataOfSpecification.InformationAboutSpecification(docParam,docName,detParam,detName,developName,masterName,dateOfCreate, dateOfControl);
            Assert.AreEqual(target.DocParam, "Чертеж");
        }
    }
}
