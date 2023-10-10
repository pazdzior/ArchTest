using StoreManager.Repository.Models;

namespace StoreManager.Repository;

public class StoreManagerRepository : IStoreManagerRepository
{
    private List<Article> _articles = new()
    {
        new Article("Milk"),
        new Article("Cheese"),
        new Article("Pasta")
    };
    private List<Freezer> _freezers = new()
    {
        new Freezer("IceCream"),
        new Freezer("Meet"),
        new Freezer("Pizza")
    };
    private List<Store> _stores = new()
    {
        new Store("Store1"),
        new Store("Store2"),
        new Store("Store3")
    };

    public List<Article> GetArticles()
    {
        return _articles;
    }

    public List<Store> GetStores()
    {
        return _stores;
    }

    public List<Freezer> GetFreezers()
    {
        return _freezers;
    }

}