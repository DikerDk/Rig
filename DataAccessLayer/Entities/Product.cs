using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Image { get; set; }
        public ushort Price{ get; set; }
        public bool IsFavourite{ get; set; }
        public int Available { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }


    }
}
