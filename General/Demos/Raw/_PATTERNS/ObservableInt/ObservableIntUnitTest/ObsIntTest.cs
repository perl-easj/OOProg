using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObservableInt;

namespace ObservableIntUnitTest
{
    [TestClass]
    public class ObsIntTest
    {
        [TestMethod]
        public void Test_Create_Default()
        {
            ObsInt oiA = new ObsInt();

            Assert.AreEqual(0, oiA.Value);
        }

        [TestMethod]
        public void Test_Create_WithValue()
        {
            ObsInt oiA = new ObsInt(12);

            Assert.AreEqual(12, oiA.Value);
        }

        [TestMethod]
        public void Test_Assign_WithValue()
        {
            ObsInt oiA = new ObsInt(10);
            Assert.AreEqual(10, oiA.Value);

            oiA.Value = 22;
            Assert.AreEqual(22, oiA.Value);
        }

        [TestMethod]
        public void Test_Add_ObsInt_ObsInt()
        {
            ObsInt oiA = new ObsInt(10);
            ObsInt oiB = new ObsInt(24);

            ObsInt oiC = oiA + oiB;
            Assert.AreEqual(34, oiC.Value);
        }

        [TestMethod]
        public void Test_Add_ObsInt_Int()
        {
            ObsInt oiA = new ObsInt(10);
            int b = 24;

            ObsInt oiC = oiA + b;
            Assert.AreEqual(34, oiC.Value);
        }

        [TestMethod]
        public void Test_Add_Int_ObsInt()
        {
            int a = 10;
            ObsInt oiB = new ObsInt(24);

            ObsInt oiC = a + oiB;
            Assert.AreEqual(34, oiC.Value);
        }

        [TestMethod]
        public void Test_Sub_ObsInt_ObsInt()
        {
            ObsInt oiA = new ObsInt(32);
            ObsInt oiB = new ObsInt(15);

            ObsInt oiC = oiA - oiB;
            Assert.AreEqual(17, oiC.Value);
        }

        [TestMethod]
        public void Test_Sub_ObsInt_Int()
        {
            ObsInt oiA = new ObsInt(32);
            int b = 15;

            ObsInt oiC = oiA - b;
            Assert.AreEqual(17, oiC.Value);
        }

        [TestMethod]
        public void Test_Sub_Int_ObsInt()
        {
            int a = 32;
            ObsInt oiB = new ObsInt(15);

            ObsInt oiC = a - oiB;
            Assert.AreEqual(17, oiC.Value);
        }

        [TestMethod]
        public void Test_Mult_ObsInt_ObsInt()
        {
            ObsInt oiA = new ObsInt(12);
            ObsInt oiB = new ObsInt(17);

            ObsInt oiC = oiA * oiB;
            Assert.AreEqual(204, oiC.Value);
        }

        [TestMethod]
        public void Test_Mult_ObsInt_Int()
        {
            ObsInt oiA = new ObsInt(12);
            int b = 17;

            ObsInt oiC = oiA * b;
            Assert.AreEqual(204, oiC.Value);
        }

        [TestMethod]
        public void Test_Mult_Int_ObsInt()
        {
            int a = 12;
            ObsInt oiB = new ObsInt(17);

            ObsInt oiC = a * oiB;
            Assert.AreEqual(204, oiC.Value);
        }

        [TestMethod]
        public void Test_Conv_ToInt()
        {
            ObsInt oiA = new ObsInt(17);
            int a = oiA;

            Assert.AreEqual(oiA.Value, a);
        }

        [TestMethod]
        public void Test_Conv_ToObsInt()
        {
            int a = 17;
            ObsInt oiA = a;
            
            Assert.AreEqual(oiA.Value, a);
        }

        [TestMethod]
        public void Test_Subscribe_OneSub_SubCreate()
        {
            ObserverA obsA = new ObserverA();
            Assert.AreEqual(obsA.InitialState, obsA.State);
        }

        [TestMethod]
        public void Test_Subscribe_OneSub_SubCreateAndSubscribe()
        {
            ObsInt oiA = new ObsInt(17);
            ObserverA obsA = new ObserverA();
            Assert.AreEqual(obsA.InitialState, obsA.State);

            oiA.Value = 22;
            Assert.AreEqual(obsA.InitialState, obsA.State);

            oiA.ValueChanged += obsA.MethodA;
            Assert.AreEqual(obsA.InitialState, obsA.State);
        }

        [TestMethod]
        public void Test_Subscribe_OneSub_Complete()
        {
            ObsInt oiA = new ObsInt(17);
            ObserverA obsA = new ObserverA();
            Assert.AreEqual(obsA.InitialState, obsA.State);

            oiA.Value = 22;
            Assert.AreEqual(obsA.InitialState, obsA.State);

            oiA.ValueChanged += obsA.MethodA;
            oiA.Value = 35;
            Assert.AreNotEqual(obsA.InitialState, obsA.State);
            Assert.AreNotEqual($"Value was updated to 22", obsA.State);
            Assert.AreEqual($"Value was updated to 35", obsA.State);
        }

        [TestMethod]
        public void Test_Subscribe_TwoSub_Complete()
        {
            ObsInt oiA = new ObsInt(17);
            ObserverA obsA = new ObserverA();
            ObserverB obsB = new ObserverB();
            Assert.AreEqual(obsA.InitialState, obsA.State);
            Assert.AreEqual(obsB.InitialState, obsB.State);

            oiA.ValueChanged += obsA.MethodA;
            oiA.ValueChanged += obsB.MethodB;
            oiA.Value = 35;
            Assert.AreEqual($"Value was updated to 35", obsA.State);
            Assert.AreEqual($"Value is now 35", obsB.State);
        }

        [TestMethod]
        public void Test_ToString()
        {
            ObsInt oiA = new ObsInt(17);
            Assert.AreEqual("17", oiA.ToString());
        }
    }
}
