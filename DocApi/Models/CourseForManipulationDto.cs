using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocApi.Models
{
    //[CourseTitleMustBeDifferentFromDescription(
    //      ErrorMessage = "Title must be different from description.")]
    public abstract class CourseForManipulationDto
    {
        [Required(ErrorMessage = "Sie müssen den Nachnamen angeben.")]
        [MaxLength(30, ErrorMessage = "Der Nachname sollte nicht länger als 30 Zeichen sein.")]
        public string Nachname { get; set; }

    }
}
