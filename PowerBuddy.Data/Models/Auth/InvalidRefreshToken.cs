namespace PowerBuddy.Data.Models.Auth
{
    public readonly struct InvalidRefreshToken
    {
        public string Message { get; }

        public InvalidRefreshToken(string message)
        {
            Message = message;
        }
    }
}
