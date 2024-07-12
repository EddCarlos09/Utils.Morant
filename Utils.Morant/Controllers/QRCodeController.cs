using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using System.Drawing;
using Utils.Morant.Mappers;
using Utils.Morant.ViewModels;

namespace Utils.Morant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRCodeController : ControllerBase
    {
        [HttpPost]
        public ActionResult<QRCodeViewModel> PostQRCode(QRCodeViewModel data)
        {
            //var qrCodeGenerator = new QRCodeGenerator();
            //var qrCodeData = qrCodeGenerator.CreateQrCode(data.Url, QRCodeGenerator.ECCLevel.Q);
            //BitmapByteQRCode bitmapByteQrCode = new BitmapByteQRCode(qrCodeData);
            //var bitMap = bitmapByteQrCode.GetGraphic(20);

            //using var ms = new MemoryStream();
            //ms.Write(bitMap);
            //byte[] byteImage = ms.ToArray();
            ////data.QrCodeBase64 = Convert.ToBase64String(byteImage);
            //data.QrCodeArray = byteImage;
            //return data;
            var imgType = Base64QRCode.ImageType.Png;
            var qrCodeGenerator = new QRCodeGenerator();
            var qrCodeData = qrCodeGenerator.CreateQrCode(data.Url, QRCodeGenerator.ECCLevel.Q);
            Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            string qrCodeImageAsBase64 = qrCode.GetGraphic(20, Color.Black, Color.White, true, imgType);
            //var htmlPictureTag = $"<img alt=\"Embedded QR Code\" src=\"data:image/{imgType.ToString().ToLower()};base64,{qrCodeImageAsBase64}\" />";
            data.QrCodeBase64 = qrCodeImageAsBase64;
            return Ok(data);
        }
    }
}
