using System;
using HangarModel;
using NUnit.Framework;

namespace Hangar.UnitTests
{
    [TestFixture]
    public class HangarUnitTests
    {
        private HangarParam _hangarParam;

        [SetUp]
        public void InitContact()
        {
            _hangarParam = new HangarParam();
            _hangarParam.HangarHeight = 8;
            _hangarParam.HangarWidth = 4;
            _hangarParam.HangarLength = 14;
            _hangarParam.WallHeight = 0.3;
            _hangarParam.GateHeight = 3;
            _hangarParam.GateWidth = 2;
        }

        [Test(Description = "Проверка высоты ангара")]
        public void TestHangarHeightSet_CorrectValue()
        {
            const int actual = 8;
            var expected = _hangarParam.HangarHeight;
            Assert.AreEqual(actual, expected,
                "Проверка на правильные значения");
        }
        [Test(Description = "Проверка ширины ангара")]
        public void TestHangarWidthSet_CorrectValue()
        {
            const int actual = 4;
            var expected = _hangarParam.HangarWidth;
            Assert.AreEqual(actual, expected,
                "Проверка на правильные значения");
        }
        [Test(Description = "Проверка длины ангара")]
        public void TestHangarLengthSet_CorrectValue()
        {
            const int actual = 14;
            var expected = _hangarParam.HangarLength;
            Assert.AreEqual(actual, expected,
                "Проверка на правильные значения");
        }
        [Test(Description = "Проверка высоты стены")]
        public void TestWallHeightSet_CorrectValue()
        {
            const double actual = 0.3;
            var expected = _hangarParam.WallHeight;
            Assert.AreEqual(actual, expected,
                "Проверка на правильные значения");
        }
        [Test(Description = "Проверка высоты ворот")]
        public void TestGateHeightSet_CorrectValue()
        {
            const int actual = 3;
            var expected = _hangarParam.GateHeight;
            Assert.AreEqual(actual, expected,
                "Проверка на правильные значения");
        }
        [Test(Description = "Проверка ширины ворот")]
        public void TestGateWidthSet_CorrectValue()
        {
            const int actual = 2;
            var expected = _hangarParam.GateWidth;
            Assert.AreEqual(actual, expected,
                "Проверка на правильные значения");
        }
        [TestCase(0, "Исключение, если число меньше граничных значений",
            TestName = "Присвоение меньшего числа - Высота ангара")]
        [TestCase(1000, "Исключение, если число больше граничных значений",
            TestName = "Присвоение большего числа - Высота ангара")]
        public void TestHangarHeightSet_ArgumentException(int wrongParam, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _hangarParam.HangarHeight = wrongParam; },
                message);
        }
        [TestCase(0, "Исключение, если число меньше граничных значений",
            TestName = "Присвоение меньшего числа - Ширина ангара")]
        [TestCase(1000, "Исключение, если число больше граничных значений",
            TestName = "Присвоение большего числа - Ширина ангара")]
        public void TestHangarWidthSet_ArgumentException(int wrongParam, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _hangarParam.HangarWidth = wrongParam; },
                message);
        }
        [TestCase(0, "Исключение, если число меньше граничных значений",
            TestName = "Присвоение меньшего числа - Длина ангара")]
        [TestCase(1000, "Исключение, если число больше граничных значений",
            TestName = "Присвоение большего числа - Длина ангара")]
        public void TestHangarLengthSet_ArgumentException(int wrongParam, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _hangarParam.HangarLength = wrongParam; },
                message);
        }
        [TestCase(0, "Исключение, если число меньше граничных значений",
            TestName = "Присвоение меньшего числа - Высота стены")]
        [TestCase(1000, "Исключение, если число больше граничных значений",
            TestName = "Присвоение большего числа - Высота стены")]
        public void TestWallHeighttSet_ArgumentException(int wrongParam, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _hangarParam.WallHeight = wrongParam; },
                message);
        }
        [TestCase(0, "Исключение, если число меньше граничных значений",
            TestName = "Присвоение меньшего числа - Высота ворот")]
        [TestCase(1000, "Исключение, если число больше граничных значений",
            TestName = "Присвоение большего числа - Высота ворот")]
        public void TestGateHeightSet_ArgumentException(int wrongParam, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _hangarParam.GateHeight = wrongParam; },
                message);
        }
        [TestCase(0, "Исключение, если число меньше граничных значений",
            TestName = "Присвоение меньшего числа - Ширина ворот")]
        [TestCase(1000, "Исключение, если число больше граничных значений",
            TestName = "Присвоение большего числа - Ширина ворот")]
        public void TestGateWidthSet_ArgumentException(int wrongParam, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _hangarParam.GateWidth = wrongParam; },
                message);
        }
    }
}
