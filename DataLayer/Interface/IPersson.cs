using System;

namespace DataLayer.Interface
{
    public interface IPersson:IHasGuid
    {
        Guid Guid { get; set; }
        string DateSabt { get; set; }
        string Code { get; set; }
        string Half_Code { get; set; }
        string Name { get; set; }
        decimal Amount_AvalDore { get; set; }
        string Description { get; set; }
        string Pic { get; set; }
        string Phone1 { get; set; }
        string Phone2 { get; set; }
        string Mobile1 { get; set; }
        string Mobile2 { get; set; }
        string Address { get; set; }
        string Fax { get; set; }
        string PostalCode { get; set; }
        string Email { get; set; }
        bool Status { get; set; }
    }
}
