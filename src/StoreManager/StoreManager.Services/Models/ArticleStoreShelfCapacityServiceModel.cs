using StoreManager.Repository.Models;

namespace StoreManager.Services.Models;

public class ArticleStoreShelfCapacityServiceModel : IServiceModel
{
    public ArticleStoreShelfCapacityServiceModel(ArticleStoreShelfCapacity articleStoreShelfCapacity)
    {
        StoreId = articleStoreShelfCapacity.StoreId;
        ArticleId = articleStoreShelfCapacity.ArticleId;
        Capacity = articleStoreShelfCapacity.Capacity;
    }

    public Guid StoreId { get; set; }
    public Guid ArticleId { get; set; }
    public int Capacity { get; set; }
}