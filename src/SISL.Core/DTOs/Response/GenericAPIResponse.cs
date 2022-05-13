namespace SISL.Core.DTOs.Response
{
    public class GenericApiResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }

        public GenericApiResponse()
        { }

        public GenericApiResponse(string responseCode, string responseDescription)
        {
            ResponseCode = responseCode;
            ResponseDescription = responseDescription;
        }
    }

    public class GenericApiResponse<T> : GenericApiResponse
    {
        public T Data { get; set; }

        public GenericApiResponse(string responseCode, string responseDescription, T data)
            : base(responseCode, responseDescription)
        {
            Data = data;
        }

        public GenericApiResponse()
        { }
    }
}