namespace StoreManager.Repository.Models;

public class Article
{
    public Article(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
    
    public Guid Id { get; init; }
    public string Name { get; set; }
}