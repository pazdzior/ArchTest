using StoreManager.Repository.Models;

namespace StoreManager.Services.Models;

public class FreezerServiceModel : IServiceModel
{
    public FreezerServiceModel(string name)
    {
        Name = name;
    }

    public FreezerServiceModel(Freezer freezer)
    {
        Id = freezer.Id;
        Name = freezer.Name;
    }
    
    public Guid Id { get; set; }
    public string Name { get; set; }
}