namespace PowerBuddy.Data.Models.Auth
{
    public struct RefreshTokenNotFound
    {
        public string Message { get; }

        public RefreshTokenNotFound(string message)
        {
            Message = message;
        }
    }
}
