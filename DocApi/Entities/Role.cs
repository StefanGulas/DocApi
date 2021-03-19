using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocApi.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Beschreibung { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
