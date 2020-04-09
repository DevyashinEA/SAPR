using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangar.Tests
{
    [TestClass]
    public class HangarTests
    {
        HangarParam hangarParam = new HangarParam();
        [TestMethod]
        public void HangarWidth()
        {
            double expected = 5.1;

            hangarParam.HangarWidth = 5.1;
            double actual = hangarParam.HangarWidth;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void HangarLength()
        {
            double expected = 5.1;

            hangarParam.HangarLength = 5.1;
            double actual = hangarParam.HangarLength;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void HangarHeight()
        {
            double expected = 5.1;

            hangarParam.HangarHeight = 5.1;
            double actual = hangarParam.HangarHeight;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GateHeight()
        {
            double expected = 5.1;

            hangarParam.HangarHeight = 6;
            hangarParam.GateHeight = 5.1;
            double actual = hangarParam.GateHeight;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GateWidth()
        {
            double expected = 2.5;

            hangarParam.HangarWidth = 6;
            hangarParam.GateWidth = 2.5;
            double actual = hangarParam.GateWidth;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WallHeight()
        {
            double expected = 0.2;

            hangarParam.WallHeight = 0.2;
            double actual = hangarParam.WallHeight;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WallHeightEx()
        {
            hangarParam.WallHeight = 0.4;
            double actual = hangarParam.WallHeight;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void HangarWidthEx()
        {
            hangarParam.WallHeight = 15;
            double actual = hangarParam.WallHeight;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void HangarLengthEx()
        {
            hangarParam.WallHeight =41;
            double actual = hangarParam.WallHeight;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void HangarHeightEx()
        {
            hangarParam.WallHeight = 11;
            double actual = hangarParam.WallHeight;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GateHeightEx()
        {
                hangarParam.HangarHeight = 6;
                hangarParam.GateHeight = 7;
                double actual = hangarParam.GateHeight;
            }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GateWidthEx()
        {
                hangarParam.HangarWidth = 6;
                hangarParam.GateWidth = 0.2;
            double actual = hangarParam.WallHeight;
        }

    }
}
