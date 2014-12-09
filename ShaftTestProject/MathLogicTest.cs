using Shaft;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ShaftTestProject
{

    /// <summary>
    ///This is a test class for MathLogicTest and is intended
    ///to contain all MathLogicTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MathLogicTest
    {
        [TestMethod]
        public void GetCoordForSlotsTest()
        {
            var coordsOfSlot = MathLogic.GetCoordForSlots(70.0, 8.0, 3.0, 60, 6);
            var actualCountOfCoords = coordsOfSlot.Count;
            var epsilon = 0.001;
            Assert.AreEqual(actualCountOfCoords, 22);
           
        }
       
     }
 }



