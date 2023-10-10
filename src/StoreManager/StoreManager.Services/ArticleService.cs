using StoreManager.Repository;
using StoreManager.Services.Models;

namespace StoreManager.Services;

public class ArticleService : IArticleService, IService
{
    private readonly IStoreManagerRepository _storeManagerRepository;
    
    public ArticleService(IStoreManagerRepository storeManagerRepository)
    {
        _storeManagerRepository = storeManagerRepository;
    }
    public List<ArticleServiceModel> GetArticles()
    {
        var articles = _storeManagerRepository.GetArticles();
        return articles.Select(article => new ArticleServiceModel(article)).ToList();
    }
}