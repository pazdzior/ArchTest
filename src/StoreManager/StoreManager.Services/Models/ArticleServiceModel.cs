using StoreManager.Repository.Models;

namespace StoreManager.Services.Models;

public class ArticleServiceModel : IServiceModel
{
    public ArticleServiceModel(Article article)
    {
        Id = article.Id;
        Name = article.Name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
}