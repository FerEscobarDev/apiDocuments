using apiDocuments.DTOs;
using apiDocuments.Models;
using AutoMapper;

namespace apiDocuments.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Document, DocumentDTO>().ReverseMap();
            CreateMap<DocumentCreateDTO, Document>().ForMember(x => x.DocumentFile, options => options.Ignore());
        }
    }
}
