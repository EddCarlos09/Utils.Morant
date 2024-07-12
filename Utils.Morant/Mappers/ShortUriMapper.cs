using Utils.Morant.Models.Tiny;
using Utils.Morant.Utils;
using Utils.Morant.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Utils.Morant.Mappers
{
    public static class ShortUriMapper
    {
        public static ShortUri Map(UriRequest request)
        {
            var shortUri = new ShortUri()
            {
                Alias = request.Alias,
                Domain = request.Domain,
                Url = request.Url,
                Created_at = DateTime.UtcNow,
                Expires_at = request.Expires_at
            };
            return shortUri;
        }

        public static UriResponse Map(ShortUri shortUri)
        {
            var response = new UriResponse()
            {
                Alias = shortUri.Alias,
                Domain = shortUri.Domain,
                Url = shortUri.Url,
                Created_at = shortUri.Created_at.ToMxDateTime(),
                Expires_at = shortUri.Expires_at.ToMxDateTime(),
                Id = shortUri.Id,
                Short_url = string.Format("{0}/{1}", shortUri.Domain, shortUri.Short_url)
            };
            return response;
        }
    }
}
