using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interface;

namespace DataLayer.Models.Account
{
   public class KolHesab:IHasGuid
    {
        [Key]
        public Guid Guid { get; set; }
        [MaxLength(15)]
        public string DateSabt { get; set; }
        public string Name { get; set; }
        [MaxLength(10)]
        public string Code { get; set; }
        [MaxLength(10)]
        public string Half_Code { get; set; }
        public Guid GroupGuid { get; set; }
        public bool Status { get; set; }
        public bool System { get; set; }
        public string Description { get; set; }
        public HesabGroup HesabGroup { get; set; }
    }
}
