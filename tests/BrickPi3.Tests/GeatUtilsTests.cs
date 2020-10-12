using BrickPi3.Utils;
using System;
using Xunit;

namespace BrickPi3.Tests
{
    public class GeatUtilsTests
    {
        [Theory]
        [InlineData(8, 16, 24, 40, 0.3)]
        [InlineData(40, 8, 24, 8, 15)]
        public void GearFactorResultTests(int gearOne, int gearTwo, int gearThree, int gearFour, double factor)
        {
            var gearFactor = new GearUtils(gearOne).Drive(gearTwo).Connect(gearThree).Drive(gearFour).GetFactor();
            Assert.Equal(factor, gearFactor);
        }
    }
}
