namespace RudycommerceLibrary.Entities.Products
{
    public interface ILocalizedProduct
    {
        string Description { get; set; }
        int LanguageID { get; set; }
        string Name { get; set; }
        int ProductID { get; set; }

        bool IsNew();
    }
}