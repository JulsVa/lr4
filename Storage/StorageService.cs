using lab.Models;
namespace lab.Storage
{
    public class StorageService
    {
        private readonly IStorage<myData> _storage;
        public StorageService(IStorage<myData> storage)
        {
            _storage = storage;
        }

        public string GetStorageType()
        {
            return _storage.StorageType;
        }

        public int GetNumberOfItems()
        {
            return _storage.All.Count;
        }
    }
}
