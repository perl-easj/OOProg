using System;

namespace SimpleRPGFromScratch.Command
{
    public class NotImplementedCommand : CommandBase
    {
        private string _desc;

        public NotImplementedCommand(string desc)
        {
            _desc = desc;
        }

        protected override void Execute()
        {
            throw new NotImplementedException($"Not implemented yet: {_desc}");
        }
    }
}