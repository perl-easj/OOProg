using System;

namespace TemplateMethodDemoApp
{
    public class AsyncSpecificImplA : AsyncBaseImpl
    {
        public AsyncSpecificImplA(UtilLib utilLib) : base(utilLib)
        {
        }

        public override void MethodAStep1()
        {
            // Specific implementation
            Console.WriteLine("Did step 1 (version A)");
            _utilLib.UtilLibB();

        }

        public override void MethodAStep3()
        {
            // Specific implementation
            Console.WriteLine("Did step 3 (version A)");
            _utilLib.UtilLibA();
        }
    }
}