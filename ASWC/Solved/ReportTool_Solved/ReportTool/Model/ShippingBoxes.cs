using System.Collections.Generic;
using ReportTool.DomainClasses;

namespace ReportTool.Model
{
    /// <summary>
    /// The ShippingBoxes class can store a set of ShippingBox objects.
    /// It has been written without any consideration for reusability...
    /// </summary>
    public class ShippingBoxes
    {
        #region Instance fields and Constructor
        private List<ShippingBox> _boxes;

        public ShippingBoxes()
        {
            _boxes = new List<ShippingBox>();
        }
        #endregion

        #region Methods
        public void AddOneBox(ShippingBox box)
        {
            _boxes.Add(box);
        }

        public int NumberOfBoxes()
        {
            return _boxes.Count;
        }

        public List<ShippingBox> AllBoxes()
        {
            return _boxes;
        }

        public int TotalVolumeInLiters()
        {
            int total = 0;
            for (int i = 0; i < _boxes.Count; i++)
            {
                total = total + _boxes[i].Volume;
            }
            return total / 1000;
        } 
        #endregion
    }
}