using DataAccessLayer.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class User: IdentityUser
    {
        public string Name { get; set;}
        public int ui { get; set; }

        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
        public Guid? PhotoId { get; set; }
        public virtual Photo Photo { get; set; }

    }
}
