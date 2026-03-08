namespace latihan.Models
{
    public class ErrorViewModel
    {
        // Menyimpan ID unik dari request yang menyebabkan error
        public string? RequestId { get; set; }

        // Properti untuk mengecek apakah RequestId ada isinya atau tidak
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}