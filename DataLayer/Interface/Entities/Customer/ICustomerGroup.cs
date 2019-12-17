namespace DataLayer.Interface.Entities.Customer
{
    public interface ICustomerGroup : IHasGuid
    {
        string Name { get; set; }
        bool Status { get; set; }
        string Notice { get; set; }
    }
}
