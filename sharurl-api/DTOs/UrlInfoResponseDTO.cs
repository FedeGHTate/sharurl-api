using MongoDB.Bson;
using sharurl_api.Model;

namespace sharurl_api.DTOs
{
    public class UrlInfoResponseDTO
    {

        public String Id { get; set; }
        public String Url { get; set; }
        public String ShortCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public UrlInfoResponseDTO(UrlInfo urlInfo) 
        {
            this.Url = urlInfo.Url;
            this.Id = urlInfo.Id.ToString();
            this.ShortCode = urlInfo.ShortCode;
            this.CreatedAt = urlInfo.CreatedAt;
            this.UpdatedAt = urlInfo.UpdatedAt;
        }

    }
}
