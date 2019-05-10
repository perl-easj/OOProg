using System;

namespace ObservableInt
{
    public class ObsInt
    {
        #region Instance fields
        private int _val;
        public event Action<int> ValueChanged; 
        #endregion

        #region Constructor
        public ObsInt(int val = 0)
        {
            _val = val;
        } 
        #endregion

        #region Value Property
        public int Value
        {
            get { return _val; }
            set
            {
                _val = value;
                OnValueChanged();
            }
        } 
        #endregion

        #region Overload of +
        public static ObsInt operator +(ObsInt v1, ObsInt v2)
        {
            return new ObsInt(v1.Value + v2.Value);
        }

        public static ObsInt operator +(ObsInt v1, int v2)
        {
            return new ObsInt(v1.Value + v2);
        }

        public static ObsInt operator +(int v1, ObsInt v2)
        {
            return v2 + v1;
        }
        #endregion

        #region Overload of -
        public static ObsInt operator -(ObsInt v1, ObsInt v2)
        {
            return new ObsInt(v1.Value - v2.Value);
        }

        public static ObsInt operator -(ObsInt v1, int v2)
        {
            return new ObsInt(v1.Value - v2);
        }

        public static ObsInt operator -(int v1, ObsInt v2)
        {
            return new ObsInt(v1 - v2.Value);
        }
        #endregion

        #region Overload of *
        public static ObsInt operator *(ObsInt v1, int v2)
        {
            return new ObsInt(v1.Value * v2);
        }

        public static ObsInt operator *(int v1, ObsInt v2)
        {
            return v2 * v1;
        }

        public static ObsInt operator *(ObsInt v1, ObsInt v2)
        {
            return v2 * v1.Value;
        }
        #endregion

        #region Implicit conversion
        public static implicit operator int(ObsInt v)
        {
            return v.Value;
        }

        public static implicit operator ObsInt(int v)
        {
            return new ObsInt(v);
        }
        #endregion

        #region Event Invoker
        protected virtual void OnValueChanged()
        {
            ValueChanged?.Invoke(_val);
        }
        #endregion

        #region ToString Override
        public override string ToString()
        {
            return $"{Value}";
        } 
        #endregion
    }
}