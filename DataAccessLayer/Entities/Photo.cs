using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Photo : BaseEntity
    {
        public byte[] Thumb { get; set; }
        public byte[] Img { get; set; }
    }
}

