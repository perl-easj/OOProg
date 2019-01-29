using System;
using System.Collections.Generic;
using System.Linq;

namespace Part3
{
    public class WizardRepository
    {
        private Dictionary<string, Wizard> _wizards;
        public event Action<string, string> RepositoryChanged;

        public WizardRepository()
        {
            _wizards = new Dictionary<string, Wizard>();
        }

        public List<Wizard> AllWizards
        {
            get { return _wizards.Values.ToList(); }
        }

        public void Insert(Wizard aWizard)
        {
            if (!_wizards.ContainsKey(aWizard.Name))
            {
                _wizards.Add(aWizard.Name, aWizard);
                OnRepositoryChanged("Insert", aWizard.Name);
            }
        }

        public Wizard Read(string name)
        {
            return _wizards.ContainsKey(name) ? _wizards[name] : null;
        }

        public List<Wizard> ReadWhere()
        {
            return AllWizards; // TODO - this is wrong...
        }

        public void Remove(Wizard aWizard)
        {
            _wizards.Remove(aWizard.Name);
            OnRepositoryChanged("Remove", aWizard.Name);
        }

        protected virtual void OnRepositoryChanged(string operation, string name)
        {
            RepositoryChanged?.Invoke(operation, name);
        }
    }
}