using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleShop;

namespace SimpleShopUnitTest
{
    [TestClass]
    public class SimpleShopTest
    {
        private Tester _tester;
        private List<string> _expected;

        public SimpleShopTest()
        {
            _tester = new Tester();
            _expected = new List<string>();
            InitExpected(_expected);
        }

        [TestMethod]
        public void TestInvoice0()
        {
            TestInvoice(0);
        }

        [TestMethod]
        public void TestInvoice1()
        {
            TestInvoice(1);
        }

        [TestMethod]
        public void TestInvoice2()
        {
            TestInvoice(2);
        }

        [TestMethod]
        public void TestInvoice3()
        {
            TestInvoice(3);
        }

        private void TestInvoice(int index)
        {
            string invoice = _tester.TestCase(index);
            Assert.AreEqual(_expected[index], invoice);
        }

        private void InitExpected(List<string> expected)
        {
            expected.Add("Email sent to anne@mail.dk:\n" +
                         "---------------------------------------\n" +
                         "Invoice to anne@mail.dk for 93 kr.\n" +
                         "2 x Wine @ 45 kr. :   90 kr.\n" +
                         "1 x Apple @ 3 kr. :   3 kr.\n\n");

            expected.Add("Email sent to bent_benthin@waoo.dk:\n" +
                         "---------------------------------------\n" +
                         "Invoice to bent_benthin@waoo.dk for 135 kr.\n" +
                         "3 x Beer @ 8 kr. :   24 kr.\n" +
                         "1 x Wine @ 45 kr. :   45 kr.\n" +
                         "2 x Apple @ 3 kr. :   6 kr.\n" +
                         "1 x T-Shirt @ 60 kr. :   60 kr.\n\n");

            expected.Add("Email sent to carina_32@mail.dk:\n" +
                         "---------------------------------------\n" +
                         "Invoice to carina_32@mail.dk for 173 kr.\n" +
                         "2 x Cheese @ 25 kr. :   50 kr.\n" +
                         "1 x Apple @ 3 kr. :   3 kr.\n" +
                         "2 x T-Shirt @ 60 kr. :   120 kr.\n\n");

            expected.Add("Email sent to bent_benthin@waoo.dk:\n" +
                         "---------------------------------------\n" +
                         "Invoice to bent_benthin@waoo.dk for 138 kr.\n" +
                         "6 x Beer @ 8 kr. :   48 kr.\n" +
                         "2 x Wine @ 45 kr. :   90 kr.\n\n");
        }
    }
}
