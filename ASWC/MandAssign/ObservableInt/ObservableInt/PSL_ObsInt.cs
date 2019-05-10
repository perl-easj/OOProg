
using System;

namespace ObservableInt
{
    public class PSL_ObsInt
    {
        private int _value;
        public event Action<int> ValueChanged;

        public PSL_ObsInt(int val = 0)
        {
            _value = val;
        }

        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnValueChanged(value);
            }
        }

        protected virtual void OnValueChanged(int obj)
        {
            ValueChanged?.Invoke(obj);
        }

        public static implicit operator int(PSL_ObsInt oi)
        {
            return oi.Value;
        }

        public static implicit operator PSL_ObsInt(int val)
        {
            return new PSL_ObsInt(val);
        }
    }
}