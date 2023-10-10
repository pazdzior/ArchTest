using StoreManager.Repository.Models;


namespace StoreManager.Repository;

public interface IStoreManagerRepository
{
    public List<Article> GetArticles();
    public List<Store> GetStores();
    public List<Freezer> GetFreezers();
}