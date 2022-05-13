namespace SISL.Core.Constants
{
    public sealed class RESPONSE_CODE
    {
        private RESPONSE_CODE()
        { }

        public const string SUCCESS = "00";
        public const string FAILURE = "999";
        public const string SUCCESS_WITH_TRIPLE_ZERO = "000";
        public const string SUCCESS_WITH_202 = "202";
        public const string BAD_REQUEST = "400";
        public const string INTERNAL_EXCEPTION = "XX";
    }
}