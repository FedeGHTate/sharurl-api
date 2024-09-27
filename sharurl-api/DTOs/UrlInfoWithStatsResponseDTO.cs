using sharurl_api.Model;

namespace sharurl_api.DTOs
{
    public class UrlInfoWithStatsResponseDTO : UrlInfoResponseDTO
    {
        public int AccessCount { get; set; }
        public UrlInfoWithStatsResponseDTO(UrlInfo urlInfo) : base(urlInfo)
        {
            this.AccessCount = urlInfo.AccessCount;
        }
    }
}
