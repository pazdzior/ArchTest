namespace StoreManager.Repository.Models;

public class Freezer
{
    public Freezer(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
}