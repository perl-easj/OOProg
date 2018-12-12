using System.Collections.Generic;
using System.Linq;

namespace Part2
{
    public class WizardRepository
    {
        private Dictionary<string, Wizard> _wizards;

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
            }
        }

        public Wizard Read(string name)
        {
            return _wizards.ContainsKey(name) ? _wizards[name] : null;
        }

        public void Remove(Wizard aWizard)
        {
            _wizards.Remove(aWizard.Name);
        }
    }
}