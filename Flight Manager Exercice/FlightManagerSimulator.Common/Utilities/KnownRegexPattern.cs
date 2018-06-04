namespace FlightManagerSimulator.Core.Common
{
    /// <summary>
    /// Provide Common Regular Expressions
    /// </summary>
    public static class KnownRegexPatterns
    {
        /// <summary>
        /// AlphanumericCharsGroup
        /// </summary>
        public const string AlphanumericCharsGroup = @"[a-zA-Z0-9]";

        /// <summary>
        /// AlphanumericCharsGroup
        /// </summary>
        public const string NonAlphanumericCharsGroup = @"[^a-zA-Z0-9]";

        /// <summary>
        /// AlphanumericCharsGroup
        /// </summary>
        public const string NonNumericCharsGroup = @"[^0-9]";

        /// <summary>
        /// AlphanumericText
        /// </summary>
        public const string AlphanumericText = "^" + AlphanumericCharsGroup + "+$";

        /// <summary>
        /// AlphanumericTextOrEmpty
        /// </summary>
        public const string AlphanumericTextOrEmpty = "^" + AlphanumericCharsGroup + "*$";

        /// <summary>
        /// NumericDecimal
        /// </summary>
        public const string NumericDecimal = "^[0-9]+(,[0 - 9]+)?$";
    }
}
