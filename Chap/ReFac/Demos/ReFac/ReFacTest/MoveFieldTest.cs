using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReFacTest
{
    [TestClass]
    public class MoveFieldTest
    {
        private ReFac.Simple.MoveField.Before.BankAccount _beforeBA;
        private ReFac.Simple.MoveField.Before.AccountType _beforeAT;

        private ReFac.Simple.MoveField.After.BankAccount _afterBA;
        private ReFac.Simple.MoveField.After.AccountType _afterAT;

        public MoveFieldTest()
        {
            _beforeAT = new ReFac.Simple.MoveField.Before.AccountType("Normal");
            _beforeBA = new ReFac.Simple.MoveField.Before.BankAccount(1000, 2.5, _beforeAT);

            _afterAT = new ReFac.Simple.MoveField.After.AccountType("Normal", 2.5);
            _afterBA = new ReFac.Simple.MoveField.After.BankAccount(1000, _afterAT);
        }

        [TestMethod]
        public void Test_MoveField_ReFac_Case1()
        {
            _beforeBA.AddInterest();
            _afterBA.AddInterest();

            Assert.AreEqual(_beforeBA.Balance, _afterBA.Balance, 0.001);
        }
    }
}