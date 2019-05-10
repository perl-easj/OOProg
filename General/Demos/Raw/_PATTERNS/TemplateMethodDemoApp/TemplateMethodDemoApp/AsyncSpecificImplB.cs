using System;

namespace TemplateMethodDemoApp
{
    public class AsyncSpecificImplB : AsyncBaseImpl
    {
        public AsyncSpecificImplB(UtilLib utilLib) : base(utilLib)
        {
        }

        public override void MethodAStep1()
        {
            // Specific implementation
            Console.WriteLine("Did step 1 (version B)");
            _utilLib.UtilLibC();
        }

        public override void MethodAStep3()
        {
            // Specific implementation
            Console.WriteLine("Did step 3 (version B)");
            _utilLib.UtilLibB();
        }
    }
}