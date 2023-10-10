namespace StoreManager.Repository.Models;


public class ArticleStoreShelfCapacity
{
    public ArticleStoreShelfCapacity(Guid storeId, Guid articleId, int capacity)
    {
        StoreId = storeId;
        ArticleId = articleId;
        Capacity = capacity;
    }

    public Guid StoreId { get; set; }
    public Guid ArticleId { get; set; }
    public int Capacity { get; set; }
}