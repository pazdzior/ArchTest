using StoreManager.Services.Models;

namespace StoreManager.Services;

public interface IArticleService
{
    public List<ArticleServiceModel> GetArticles();
}