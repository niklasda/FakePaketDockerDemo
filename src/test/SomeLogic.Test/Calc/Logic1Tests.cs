using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SomeLogic.Calc;

namespace SomeLogic.Test.Calc
{
    [TestFixture, Author("Niklas")]
    public class Logic1Tests
    {
        [Test]
        public void TestAdd()
        {
            var logic = new Logic1();
            var res = logic.Add(1, 1);

            Assert.AreEqual(2, res);
        }
    }
}
