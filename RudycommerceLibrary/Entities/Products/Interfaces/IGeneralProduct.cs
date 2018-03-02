namespace RudycommerceLibrary.Entities.Products
{
    public interface IGeneralProduct
    {
        int AvailableStock { get; set; }
        int CurrentStock { get; set; }
        int InitialStock { get; set; }
        int IronStock { get; set; }
        bool IsActive { get; set; }
        int MaximumStock { get; set; }
        int ProductID { get; set; }
        decimal UnitPrice { get; set; }

        bool IsNew();
    }
}