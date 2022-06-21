using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCodeMenu.Server.Controllers.Base;
using QRCodeMenu.Server.Data;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace QRCodeMenu.Server.Controllers
{
    [Route("/qr")]
    [ApiController]
    public class QRCodeController : BaseApiController
    {
        public QRCodeController(DataDbContext dataContext)
            : base(dataContext)
        {

        }

        public string URL => string.Concat(this.Request.Scheme, "://", this.Request.Host, "/");

        [HttpGet("{restaurantName}")]
        public async Task<IActionResult> Index([FromRoute] string restaurantName)
        {
            var restaurant =
                await _data.Restaurants.FirstOrDefaultAsync(x => x.Name == restaurantName);

            if (restaurant is null)
            {
                return NotFound();
            }

            var paht = Path.Combine(this.URL, $"menus/{restaurantName}");

            MemoryStream memoryStream = new MemoryStream();
            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(paht, QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode = new QRCode(qRCodeData);
            using (Bitmap bitmap = qRCode.GetGraphic(20))
            {
                bitmap.Save(memoryStream, ImageFormat.Png);
                
                
            }
            memoryStream.Position = 0;
            return File(memoryStream, "image/png");
        }
    }
}
