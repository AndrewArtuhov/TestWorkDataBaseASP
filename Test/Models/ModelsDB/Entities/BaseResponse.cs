using Test.Models.ModelsDB.Enum;

namespace Test.Models.ModelsDB.Entities
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }
    
        public StatusCode StatusCode { get; set; }
    
        public T Data { get; set; }
    }
    
    public interface IBaseResponse<T>
    {
        StatusCode StatusCode { get; }
        T Data { get; }
    }
}
