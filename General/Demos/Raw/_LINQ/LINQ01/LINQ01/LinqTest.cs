using System.Collections.Generic;
using System.Linq;

namespace LINQ01
{
    public class LinqTest
    {
        private List<double> _numbers;
        private List<Buff> _buffs;

        public LinqTest()
        {
            _numbers = new List<double>();
            _numbers.Add(1.15);
            _numbers.Add(1.02);
            _numbers.Add(1.08);
            _numbers.Add(1.12);

            _buffs = new List<Buff>();
            _buffs.Add(new Buff("Adamantic Bones", 1.15));
            _buffs.Add(new Buff("Beneficial Aura", 1.08));
            _buffs.Add(new Buff("Crucifix of Hope", 1.12));
        }

        public double UseLINQ()
        {
            double accBuffFactor = 1.0;
            foreach (var buff in _buffs)
            {
                accBuffFactor = accBuffFactor * buff.Factor;
            }
            double percent = (accBuffFactor - 1.0) * 100.0;

            return _buffs.Aggregate
            (
                1.0, 
                (acc, buff) => acc * buff.Factor, 
                acc => (acc - 1.0) * 100.0
            );

        }
    }
}