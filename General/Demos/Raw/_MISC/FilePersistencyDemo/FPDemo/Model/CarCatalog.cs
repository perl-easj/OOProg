using System.Collections.Generic;
using Demo.FilePersistence;

namespace Demo.Model
{
    public class CarCatalog
    {
        private List<Car> _data;
        private FileSource<Car> _dataSource;

        public CarCatalog()
        {
            _data = new List<Car>();
            _dataSource = new FileSource<Car>(new FileStringPersistence(), new JSONConverter<Car>());
        }

        public List<Car> All
        {
            get { return _data; }
        }

        public void Create(Car c)
        {
            _data.Add(c);
        }

        public async void Load()
        {
            _data = await _dataSource.Load();
        }

        public async void Save()
        {
            await _dataSource.Save(_data);
        }
    }
}