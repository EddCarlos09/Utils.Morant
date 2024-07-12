namespace Utils.Morant.ViewModels
{
    public class UriResponse
    {
        public UriResponse()
        {
            Url = string.Empty;
            Domain = string.Empty;
            Alias = string.Empty;
            Short_url = string.Empty;
        }
        public int Id { get; set; }
        public string Url { get; set; }
        public string Domain { get; set; }
        public string Alias { get; set; }
        public string Short_url { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Expires_at { get; set; }
    }
}
