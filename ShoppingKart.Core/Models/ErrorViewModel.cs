namespace ShoppingKart.Core.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public string? Message { get; set; } //kim cr
        public string? StackTrace { get; set; } //kim cr
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
