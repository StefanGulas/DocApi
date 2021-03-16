using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Nachname { get; set; } 
        public string RoleName { get; set; }
    }
}
