using System;
using System.ComponentModel.DataAnnotations;

namespace DocApi.Entities
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Das Dokument benötigt einen Namen")]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Größe { get; set; }
        public string Typ { get; set; }
        public DateTime ZeitpunktDesHochladens { get; set; }
        public int UserId { get; set; }
    }
}
