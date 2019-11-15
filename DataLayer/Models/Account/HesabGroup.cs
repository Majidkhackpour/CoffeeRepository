using System;
using System.ComponentModel.DataAnnotations;
using DataLayer.Interface;

namespace DataLayer.Models.Account
{
    public class HesabGroup : IHasGuid
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }
    }
}
