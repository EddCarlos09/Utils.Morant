namespace Utils.Morant.ViewModels
{
    public class UriRequest
    {
        public UriRequest()
        {
            Url = string.Empty;
            Domain = string.Empty;
            Alias = string.Empty;
        }
        public string Url { get; set; }
        public string Domain { get; set; }
        public string Alias { get; set; }
        public DateTime? Expires_at { get; set; }
    }
}
