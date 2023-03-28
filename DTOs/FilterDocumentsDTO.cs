using System.ComponentModel.DataAnnotations;

namespace apiDocuments.DTOs
{
    public class FilterDocumentsDTO
    {
        public string CustomName { get; set; }
        public string OriginalName { get; set; }
        public string Extension { get; set; }
        public string MimeType { get; set; }
    }
}
