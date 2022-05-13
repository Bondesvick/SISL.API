namespace SISL.Core.Responses
{
    public abstract class BaseResponse
    {
        public bool success { get; protected set; }

        public BaseResponse(bool value)
        {
            success = value;
        }
    }
}