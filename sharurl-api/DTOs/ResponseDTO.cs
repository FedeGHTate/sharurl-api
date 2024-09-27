namespace sharurl_api.DTOs
{
    public class ResponseDTO
    {
        public string Message { get; set; }

        public Object data { get; set; }

        public ResponseDTO(string message, Object data)
        {
            this.Message = message;
            this.data = data;
        }
    }
}
