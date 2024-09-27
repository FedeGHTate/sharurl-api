namespace sharurl_api.DTOs
{
    public class UrlRequest
    {
        public string Url { get; set; }

        public UrlRequest(string url)
        {
            this.Url = url;
        }
    }
}
