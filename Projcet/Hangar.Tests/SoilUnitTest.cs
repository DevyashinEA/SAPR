using System;
using Hangar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangar.Tests
{
    [TestClass]
    public class SoilTests
    {
        Soil soil = new Soil();
        [TestMethod]
        public void Size()
        {
            double expected = 3.2;

            soil.Size = 3.2;
            double actual = soil.Size;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SoilTypes()
        {
            SoilTypes expected = 0;

            soil.SoilTypes = 0;
            SoilTypes actual = soil.SoilTypes;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Load()
        {
            double expected = 5;

            soil.SoilTypes = 0;
            double actual = soil.Load;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SizeEx()
        {
            soil.Size = 15;
            double actual = soil.Size;
        }
    }
}
