using System.Windows.Input;

namespace GenericsDemo01
{
    public class ViewModel
    {
        public Catalog<OrderData, Order, string> _orderCatalog;
        // public Catalog<Kunde, int> _kundeCatalog;
        private DeleteCommand<string, ViewModel> _deleteCommand;

        private Order _selectedOrder;

        public ViewModel()
        {
            _orderCatalog = new Catalog<OrderData, Order, string>(new OrderFactory());
            // _kundeCatalog = new Catalog<Kunde, int>();
            _deleteCommand = new DeleteCommand<string, ViewModel>(_orderCatalog, this);
        }

        public void InsertOrder()
        {
            OrderData od = new OrderData("12", "02-02-2016", "Bent");

            // Where does data come from?

            _orderCatalog.Create(od);
        }

        public ICommand DeletetionCommand
        {
            get { return _deleteCommand; }
        }

        public Order SelectedOrder
        {
            get { return _selectedOrder; }
            set { _selectedOrder = value; }
        }
    }
}