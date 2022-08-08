using System.Net;

namespace DataBase.Entities
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }
    
        public HttpStatusCode StatusCode { get; set; }
    
        public T Data { get; set; }
    }
    
    public interface IBaseResponse<T>
    {
        HttpStatusCode StatusCode { get; }
        T Data { get; }
    }
}
