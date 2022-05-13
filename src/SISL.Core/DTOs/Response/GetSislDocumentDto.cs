using SISL.Core.Entities;

namespace SISL.Core.DTOs.Response
{
    public class GetSislDocumentDto
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public string ContentOrPath { get; set; }
        public string ContentType { get; set; }
    }
}