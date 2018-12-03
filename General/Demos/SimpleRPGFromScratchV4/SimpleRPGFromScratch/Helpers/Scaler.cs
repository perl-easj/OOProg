using System;
using System.Collections.Generic;

namespace SimpleRPGFromScratch.Helpers
{
    // TODO - Kommentarer
    public class Scaler<T>
    {
        private List<T> _scale;
        private Func<T, T, bool> _lessFunc;

        public Scaler(List<T> scale, Func<T, T, bool> lessFunc)
        {
            _scale = scale;
            _lessFunc = lessFunc;
        }

        public virtual T ScaleToValue(int index)
        {
            if (index >= _scale.Count)
            {
                throw new ArgumentException("ScaleToValue: Index out of range");
            }

            return _scale[index];
        }

        public virtual int ValueToScale(T value)
        {
            int index = 0;

            while (_lessFunc(_scale[index], value) && index < _scale.Count - 1)
            {
                index++;
            }

            return index;
        }
    }
}