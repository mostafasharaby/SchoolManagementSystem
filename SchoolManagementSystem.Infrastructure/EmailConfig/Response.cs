namespace AngularApi.Services
{
    public class EmailResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }

        public EmailResponse(string status, string message)
        {
            Status = status;
            Message = message;
        }
    }

}
