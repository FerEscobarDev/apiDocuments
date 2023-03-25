using System.ComponentModel.DataAnnotations;

namespace apiDocuments.Models
{
    public class Document
    {
        public int Id { get; set; }
        [Required]
        public string CustomName { get; set; }
        [Required]
        public string OriginalName { get; set; }
        [Required]
        public string Extension { get; set; }
        [Required]
        public string MimeType { get; set; }
        [Required]
        public string DocumentUrl { get; set; }
    }
}
