using System.ComponentModel.DataAnnotations;

namespace Utils.Morant.Models.Tiny
{
    public class ShortUri
    {
        public int Id { get; set; }
        public string Url { get; set; }
        [MaxLength(120)]
        public string Domain { get; set; }
        [MaxLength(80)]
        public string Alias { get; set; }
        [MaxLength(150)]
        public string Short_url { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Expires_at { get; set; }

    }
}
