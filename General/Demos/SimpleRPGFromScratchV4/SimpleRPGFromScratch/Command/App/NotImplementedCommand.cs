using System;
using SimpleRPGFromScratch.Command.Base;

namespace SimpleRPGFromScratch.Command.App
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