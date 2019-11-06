using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interface;

namespace DataLayer.Models
{
   public class Hazine:IHasGuid
    {
        [Key]
        public Guid Guid { get; set; }
        [MaxLength(15)]
        public string DateSabt { get; set; }
        [MaxLength(10)]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
    }
}
