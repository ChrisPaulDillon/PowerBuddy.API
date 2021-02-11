namespace PowerBuddy.Util
{
    public static class ValidationConstants
    {
        public const string GREATER_THAN = "{PropertyName} must be greater than {ComparisonValue}.";
        public const string NOT_NULL = "{PropertyName} cannot be null";
        public const string NOT_EMPTY = "{PropertyName} cannot be empty";
        public const string MAX_LENGTH = "{PropertyName} should be no longer than {MaxLength} characters";
    }
}
