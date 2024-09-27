using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace sharurl_api.Model
{
    public class UrlInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id {  get; set; }

        [BsonElement("url")]
        public String Url { get; set; }

        [BsonElement("shortcode")]
        public String ShortCode { get; set; }

        [BsonElement("createdat")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedat")]
        public DateTime UpdatedAt { get; set; }

        [BsonElement("accesscount")]
        public int AccessCount { get; set; }

        public UrlInfo(String baseUrl, String shortCode)
        {
            this.AccessCount = 0;
            this.Url = baseUrl;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.ShortCode = shortCode;
        }

        public void updateCode(string code)
        {
            this.ShortCode = code;
            this.AccessCount = 0;
            this.UpdatedAt = DateTime.Now;
        }

        public void addAccess()
        {
            this.AccessCount++;
        }
    }
}
