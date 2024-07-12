namespace Utils.Morant.ViewModels
{
    public class QRCodeViewModel
    {
        public QRCodeViewModel()
        {
            Url = string.Empty;
            QrCodeBase64 = string.Empty;
        }
        public string Url { get; set; }
        public string QrCodeBase64 { get; set; }
    }
}
