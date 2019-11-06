using System;

namespace DataLayer.Interface
{
    public interface IHasGuid
    {
        Guid Guid { get; set; }
        string DateSabt { get; set; }
    }
}