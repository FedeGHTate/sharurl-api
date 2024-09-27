namespace sharurl_api.Exceptions
{
    [Serializable]
    internal class DeleteFailedException : Exception
    {
        public DeleteFailedException()
        {
        }

        public DeleteFailedException(string? message) : base(message)
        {
        }

        public DeleteFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}