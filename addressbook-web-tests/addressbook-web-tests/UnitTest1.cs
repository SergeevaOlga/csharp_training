using WebAddressbookTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WebAddressbookTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodSquare()
        {
            Square s1 = new Square(5);
            Square s2 = new Square(10);
            Square s3 = s1;

            Assert.AreEqual(s1.Size, 5);
            Assert.AreEqual(s2.Size, 10);
            Assert.AreEqual(s3.Size, 5);

            s3.Size = 15;

            Assert.AreEqual(s1.Size, 15);

            s2.Colored = true;

            Assert.IsTrue(s2.Colored);
            Assert.IsFalse(s1.Colored);
            Assert.IsFalse(s3.Colored);
        }

        [TestMethod]
        public void TestMethodCircle()
        {
            Circle s1 = new Circle(5);
            Circle s2 = new Circle(10);
            Circle s3 = s1;

            Assert.AreEqual(s1.Radius, 5);
            Assert.AreEqual(s2.Radius, 10);
            Assert.AreEqual(s3.Radius, 5);

            s3.Radius = 15;

            Assert.AreEqual(s1.Radius, 15);

            s1.Colored = true;

            Assert.IsTrue(s1.Colored);
            Assert.IsTrue(s3.Colored);
            Assert.IsFalse(s2.Colored);
        }
    }
}
