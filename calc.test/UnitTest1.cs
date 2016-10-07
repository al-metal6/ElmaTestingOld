using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calc.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Sum()
        {
            var test = new Helper();
            int x = 20;
            int y = 10;
            var sum = test.Sum(x, y);

            Assert.IsTrue(sum == 30);
        }

        [TestMethod]
        public void Minus()
        {
            var test = new Calc.Helper();
            int x = 20;
            int y = 10;
            var sum = test.Minus(x, y);

            Assert.IsTrue(sum == 10);

            test = new Calc.Helper();
            x = 10;
            y = 10;
            sum = test.Minus(x, y);

            Assert.IsTrue(sum == 0);
        }

        [TestMethod]
        public void Divide()
        {
            var test = new Calc.Helper();
            int x = 20;
            int y = 10;
            var sum = test.Divide(x, y);

            Assert.IsTrue(sum == 2);
        }

        [TestMethod]
        public void DivideZero()
        {
            var test = new Calc.Helper();
            int x = 20;
            int y = 0;
            var sum = test.Divide(x, y);

            Assert.IsTrue(sum == 0);
        }

        [TestMethod]
        public void Multiply()
        {
            var test = new Calc.Helper();
            int x = 20;
            int y = 10;
            var sum = test.Multiply(x, y);

            Assert.IsTrue(sum == 200);
        }

        [TestMethod]
        public void Step()
        {
            var test = new Calc.Helper();
            int x = 2;
            int y = 2;
            var step = test.Step(x, y);

            Assert.IsTrue(step == 4);
        }

        [TestMethod]
        public void Step4()
        {
            var test = new Calc.Helper();
            int x = 4;
            int y = 4;
            var step = test.Step(x, y);

            Assert.IsTrue(step == 256);
        }
    }
}
