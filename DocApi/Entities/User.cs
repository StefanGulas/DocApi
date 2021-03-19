using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocApi.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Anrede { get; set; }
        public string Vorname { get; set; }
        [Required(ErrorMessage = "Der Benutzer benötigt einen Nachnamen")]
        public string Nachname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public ICollection<Document> Documents { get; set; } = new List<Document>();


    }
}
