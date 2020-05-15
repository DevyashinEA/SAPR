using System;
using HangarModel;
using NUnit.Framework;

namespace Hangar.UnitTests
{
    [TestFixture]
    public class SoilUnitTests
    {
        private Soil _soil;

        [SetUp]
        public void InitContact()
        {
            _soil = new Soil();
            _soil.SoilTypes = 0;
            _soil.Size = 1;
        }

        [Test(Description = "Проверка высоты ангара")]
        public void TestSoilTypestSet_CorrectValue()
        {
            const SoilTypes actual = 0;
            var expected = _soil.SoilTypes;
            Assert.AreEqual(actual, expected,
                "Проверка на правильные значения");
        }

        [Test(Description = "Проверка высоты ангара")]
        public void TestSizeSet_CorrectValue()
        {
            const double actual = 1;
            var expected = _soil.Size;
            Assert.AreEqual(actual, expected,
                "Проверка на правильные значения");
        }

        [Test(Description = "Проверка высоты ангара")]
        public void TestLoadSet_CorrectValue()
        {
            const double actual = 5;
            var expected = _soil.Load;
            Assert.AreEqual(actual, expected,
                "Проверка на правильные значения");
        }

        [TestCase(-1, "Исключение, если число меньше граничных значений",
            TestName = "Присвоение меньшего числа - Высота ангара")]
        [TestCase(8, "Исключение, если число больше граничных значений",
            TestName = "Присвоение большего числа - Высота ангара")]
        public void TestSizetSet_ArgumentException(int wrongParam, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _soil.Size = wrongParam; },
                message);
        }
    }
}
