using System.ComponentModel.DataAnnotations;
using apiDocuments.Validations;

namespace apiDocuments.DTOs
{
    public class DocumentCreateDTO
    {
        [Required]
        public string CustomName { get; set; }
        [Required]
        [MaxSizeFile(MaxSizeMb:4)]
        public IFormFile DocumentFile { get; set; }
    }
}
