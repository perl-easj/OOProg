using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReFacTest
{
    [TestClass]
    public class ExtractMethodTest
    {
        private ReFac.Simple.ExtractMethod.Before.Transform _beforeTransform;
        private ReFac.Simple.ExtractMethod.After.Transform _afterTransform;

        public ExtractMethodTest()
        {
            _beforeTransform = new ReFac.Simple.ExtractMethod.Before.Transform();
            _afterTransform = new ReFac.Simple.ExtractMethod.After.Transform();
        }

        [TestMethod]
        public void Test_ExtractMethod_ReFac_Case1()
        {
            Tuple<int, int, int> resultBefore = _beforeTransform.TransformNumbers(12, 45, 33);
            Tuple<int, int, int> resultAfter = _afterTransform.TransformNumbers(12, 45, 33);

            Assert.AreEqual(resultBefore, resultAfter);
        }
    }
}
