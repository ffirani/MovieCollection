namespace MovieCollection.API.Error
{
    public class AppException:Exception
    {
        public string ErrorCode {  get; set; } 
        public string ReadableMessage { get; set; }
       
    }
}
