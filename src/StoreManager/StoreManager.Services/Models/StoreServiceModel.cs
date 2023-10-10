using StoreManager.Repository.Models;

namespace StoreManager.Services.Models;

public class StoreServiceModel : IServiceModel
{
    public StoreServiceModel(string name)
    {
        Name = name;
    }

    public StoreServiceModel(Store store)
    {
        Id = store.Id;
        Name = store.Name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
}