using apiDocuments.Validations;
using System.ComponentModel.DataAnnotations;

namespace apiDocuments.DTOs
{
    public class DocumentPutDTO
    {
        [Required]
        public string CustomName { get; set; }

        [MaxSizeFile(MaxSizeMb: 4)]
        public IFormFile DocumentFile { get; set; }    
    }
}
