using System;
using SimpleRPGFromScratch.Command.Base;
using SimpleRPGFromScratch.Model.App;

namespace SimpleRPGFromScratch.Command.App
{
    // TODO - Kommentarer
    public class ReferenceChangeCommand<T> : CommandBase
    {
        protected int? _referrerId;
        protected Action<T> _changeReference;


        public ReferenceChangeCommand(Action<T> changeReference)
        {
            _referrerId = null;
            _changeReference = changeReference;
        }

        public void SetReferrerId(int? id)
        {
            _referrerId = id;
        }

        protected override bool CanExecute()
        {
            return _referrerId != null;
        }

        protected override void Execute()
        {
            if (_referrerId != null)
            {
                T obj = DomainModel.GetCatalog<T>().Read(_referrerId.Value);
                _changeReference(obj);
                DomainModel.GetCatalog<T>().Update(_referrerId.Value, obj);
            }
        }
    }
}