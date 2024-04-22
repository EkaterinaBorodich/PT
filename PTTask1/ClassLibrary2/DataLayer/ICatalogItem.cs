namespace BusinessProcessLibrary.Data
{
    public interface ICatalogItem
    {
        int ItemId { get; }
        string Description { get; set; }
    }
}