using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace latihan.Controllers
{
    public class FilesController : Controller
    {
        private readonly string _uploadPath;

        public FilesController()
        {
            // Path folder tempat menyimpan dokumen (wwwroot/uploads)
            _uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            // Membuat folder otomatis jika belum ada
            if (!Directory.Exists(_uploadPath))
            {
                Directory.CreateDirectory(_uploadPath);
            }
        }

        // Menampilkan daftar file dokumen yang bisa diunduh oleh user
        public IActionResult Index()
        {
            // Mengambil daftar file selain file gambar (opsional, tergantung kebutuhan)
            var files = Directory.GetFiles(_uploadPath)
                                 .Select(Path.GetFileName)
                                 .ToList();

            return View(files);
        }

        // Fungsi untuk mendownload file
        [HttpGet]
        public IActionResult Download(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return RedirectToAction("Index");

            var filePath = Path.Combine(_uploadPath, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                TempData["Error"] = "File tidak ditemukan di server.";
                return RedirectToAction("Index");
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;

            // Mengembalikan file dengan tipe MIME yang sesuai
            return File(memory, GetContentType(filePath), fileName);
        }

        // Helper untuk mendeteksi tipe file berdasarkan ekstensi
        private string GetContentType(string path)
        {
            var types = new Dictionary<string, string>
            {
                {".pdf", "application/pdf"},
                {".doc", "application/msword"},
                {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".txt", "text/plain"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"}
            };

            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types.ContainsKey(ext) ? types[ext] : "application/octet-stream";
        }
    }
}