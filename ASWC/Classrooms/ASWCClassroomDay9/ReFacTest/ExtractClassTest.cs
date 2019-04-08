using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReFac.Simple.ExtractClass.After;

namespace ReFacTest
{
    [TestClass]
    public class ExtractClassTest
    {
        private ReFac.Simple.ExtractClass.Before.Person _beforePerson;
        private ReFac.Simple.ExtractClass.After.Person _afterPerson;


        [TestMethod]
        public void Test_ExtractClass_ReFac_Case1()
        {
            string privateNo = "12345678";
            string workNo = "+3487654321";
            _beforePerson = new ReFac.Simple.ExtractClass.Before.Person("Jim", privateNo, workNo);

            PhoneNo privatePhoneNo = new PhoneNo(privateNo);
            PhoneNo workPhoneNo = new PhoneNo(workNo);
            _afterPerson = new ReFac.Simple.ExtractClass.After.Person("Jim", privatePhoneNo, workPhoneNo);

            Assert.AreEqual(_beforePerson.PrivatePhoneNo, _afterPerson.PrivatePhoneNo);
            Assert.AreEqual(_beforePerson.WorkPhoneNo, _afterPerson.WorkPhoneNo);
        }

        [TestMethod]
        public void Test_ExtractClass_ReFac_Case2()
        {
            string privateNo = "1234567"; // NB: INVALID
            string workNo = "+3487654321";

            Assert.ThrowsException<ArgumentException>(() =>
            {
                _beforePerson = new ReFac.Simple.ExtractClass.Before.Person("Jim", privateNo, workNo);
            });

            Assert.ThrowsException<ArgumentException>(() =>
            {
                PhoneNo privatePhoneNo = new PhoneNo(privateNo);
                PhoneNo workPhoneNo = new PhoneNo(workNo);
                _afterPerson = new ReFac.Simple.ExtractClass.After.Person("Jim", privatePhoneNo, workPhoneNo);
            });
        }

        [TestMethod]
        public void Test_ExtractClass_ReFac_Case3()
        {
            string privateNo = "12345678";
            string workNo = "-3487654321"; // NB: INVALID

            Assert.ThrowsException<ArgumentException>(() =>
            {
                _beforePerson = new ReFac.Simple.ExtractClass.Before.Person("Jim", privateNo, workNo);
            });

            Assert.ThrowsException<ArgumentException>(() =>
            {
                PhoneNo privatePhoneNo = new PhoneNo(privateNo);
                PhoneNo workPhoneNo = new PhoneNo(workNo);
                _afterPerson = new ReFac.Simple.ExtractClass.After.Person("Jim", privatePhoneNo, workPhoneNo);
            });
        }
    }
}