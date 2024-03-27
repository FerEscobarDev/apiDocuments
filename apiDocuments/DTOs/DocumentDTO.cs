using System.ComponentModel.DataAnnotations;

namespace apiDocuments.DTOs
{
    public class DocumentDTO: DocumentCreateDTO
    {
        public int Id { get; set; }
        [Required]
        public string OriginalName { get; set; }
        [Required]
        public string Extension { get; set; }
        [Required]
        public string MimeType { get; set; }
        [Required]
        public string DocumentFile { get; set; }
    }
}
