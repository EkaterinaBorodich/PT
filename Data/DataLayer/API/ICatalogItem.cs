namespace Data.DataLayer.API
{
    public interface ICatalogItem
    {
        int ItemId { get; }
        string Description { get; set; }
    }
}