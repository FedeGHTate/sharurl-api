namespace sharurl_api.DTOs
{
    public class ExceptionDTO
    {
        public string Message { get; set; }

        public ExceptionDTO(string message)
        {
            this.Message = message;
        }
    }
}
