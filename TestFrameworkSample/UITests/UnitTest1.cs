using NUnit.Framework;
using System;
using TestFrameworkSample.Utils;

namespace TestFrameworkSample
{
    public class Tests : BasicTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine(Username);
            Console.WriteLine(Password);
            Assert.Pass();
        }
    }
}