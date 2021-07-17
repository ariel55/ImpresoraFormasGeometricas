
namespace CodingChallenge.Data.Utilities
{
    public class BooleanResponse<T>
    {
        public bool hasError { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public BooleanResponse(){ }

        public BooleanResponse(T data)
        {
            hasError = false;
            Data = data;
        }


    }
}
