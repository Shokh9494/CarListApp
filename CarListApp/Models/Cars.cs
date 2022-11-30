using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarListApp.Models
{
    [Table("cars")]
    public class Cars :BaseEntity
    {
        public string Make { get; set; }
        public string Model { get; set; }
        [MaxLength(50),Unique]
        public string Vin { get; set; }
    }
}
