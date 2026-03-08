using Microsoft.AspNetCore.Mvc;
using latihan.Data;
using latihan.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace latihan.Controllers
{
    public class DocsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // REVISI: Menambahkan searchString agar bisa mencari di semua halaman
        public IActionResult Index(string searchString, int page = 1)
        {
            int pageSize = 6;

            // 1. Ambil query dasar (AsNoTracking untuk performa)
            var query = _context.Posts
                .AsNoTracking()
                .Where(p => p.IsActive == true);

            // 2. FUNGSI SEARCH: Filter data di database sebelum dipaginasi
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(p => p.Title.Contains(searchString));
            }

            // 3. Urutkan data
            query = query.OrderBy(p => p.DisplayOrder);

            // 4. Hitung total data setelah difilter untuk menentukan jumlah halaman
            int totalItems = query.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            // 5. Ambil data sesuai potongan halaman (Pagination)
            var docs = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // 6. Kirim data ke View melalui ViewBag
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentFilter = searchString; // Penting agar teks pencarian tidak hilang saat pindah page

            return View(docs);
        }

        // Method Details dengan Route eksplisit
        [Route("Docs/Detail/{id}")]
        public IActionResult Details(int id)
        {
            // Ambil data dokumen utama
            var post = _context.Posts
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id && p.IsActive == true);

            if (post == null) return NotFound();

            // Ambil semua dokumen aktif untuk sidebar (tanpa paginasi agar lengkap)
            var listDokumen = _context.Posts
                .AsNoTracking()
                .Where(p => p.IsActive == true)
                .OrderBy(p => p.DisplayOrder)
                .ToList();

            ViewBag.AllDocs = listDokumen;

            return View(post);
        }
    }
}