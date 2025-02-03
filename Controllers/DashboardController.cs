using GraduationProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.EntityFrameworkCore;
using GraduationProject.Data;

namespace GraduationProject.Controllers
{
    public static class BitmapExtension
    {
        public static byte[] ConvertBitmapToByteArray(this Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }

    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext db;

        public DashboardController(ApplicationDbContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult CreateqRCode()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateqRCode(QRCodeModel model)
        {
            // البحث عن QR Code مسجل مسبقًا بنفس النص
            var existingChild = await db.Childs.FirstOrDefaultAsync(c => c.ChildQR == model.QRCodeText);

            if (existingChild != null)
            {
                // حذف السجل القديم إذا كان موجودًا
                db.Childs.Remove(existingChild);
                await db.SaveChangesAsync();
            }

            using (QRCodeGenerator qRCodeGenerator = new QRCodeGenerator())
            using (QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(
                model.QRCodeText, QRCodeGenerator.ECCLevel.Q))
            using (QRCode qRCode = new QRCode(qRCodeData))
            {
                Bitmap qrCodeImage = qRCode.GetGraphic(20);
                byte[] BitmapArray = qrCodeImage.ConvertBitmapToByteArray();
                string url = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
                ViewBag.QRCode = url;
            }

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChildName,BirthDate,Weight,ParentRelation,WaterBreak,WaterDuration,BirthType,Diagnosis,QRCodeText")] ChildData childData)
        {
            if (ModelState.IsValid)
            {
                // البحث عن QR Code مكرر
                var existingChild = await db.Childs.FirstOrDefaultAsync(c => c.ChildQR == childData.ChildQR);

                if (existingChild != null)
                {
                    // حذف السجل القديم إذا كان موجودًا
                    db.Childs.Remove(existingChild);
                    await db.SaveChangesAsync();
                }

                db.Add(childData);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(CreateqRCode));
            }
            return View(childData);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}