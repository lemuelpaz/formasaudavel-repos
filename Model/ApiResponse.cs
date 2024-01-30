using API.Source.Base.Utils;

namespace API.Model
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public EnResultCode Code { get; set; }
        public string Message { get; set; }
        public int ResultCount { get; set; }
    }
    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }
    }
}
