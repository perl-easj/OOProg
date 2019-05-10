using System;

namespace TemplateMethodDemoApp
{
    public abstract class AsyncBaseImpl : AsyncLib
    {
        protected UtilLib _utilLib;

        protected AsyncBaseImpl(UtilLib utilLib)
        {
            _utilLib = utilLib;
        }

        public override void AsyncMethodA()
        {
            MethodAStep1();
            MethodAStep2();
            MethodAStep3();
            MethodAStep4();

            Console.WriteLine();
        }

        public abstract void MethodAStep1();

        public virtual void MethodAStep2()
        {
            // General implmentation
            Console.WriteLine("Did step 2");
            _utilLib.UtilLibA();
        }

        public abstract void MethodAStep3();

        public virtual void MethodAStep4()
        {
            // General implmentation
            Console.WriteLine("Did step 4");
            _utilLib.UtilLibC();
        }
    }
}