using Microsoft.AspNetCore.Mvc;
using latihan.Data;
using latihan.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace latihan.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("AdminUsername") != null) return RedirectToAction("Dashboard");
            return View();
        }

        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetString("AdminUsername", user.Username!);
                TempData["Success"] = "Login Berhasil! Selamat Datang.";
                return RedirectToAction("Dashboard");
            }
            TempData["Error"] = "Username atau Password salah!";
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("AdminUsername") == null) return RedirectToAction("Login");
            var posts = _context.Posts.OrderBy(p => p.DisplayOrder).ToList();
            return View(posts);
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            if (HttpContext.Session.GetString("AdminUsername") == null) return RedirectToAction("Login");
            var profile = _context.Profiles.FirstOrDefault() ?? new ProfileModel();
            return View(profile);
        }

        [HttpPost]
        public IActionResult EditProfile(ProfileModel profile)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(profile.Skills)) profile.Skills = "";
                if (profile.Id == 0) _context.Profiles.Add(profile);
                else _context.Update(profile);

                _context.SaveChanges();
                TempData["Success"] = "Konfigurasi Berhasil Diperbarui!";
                return RedirectToAction("Dashboard");
            }
            return View(profile);
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            if (HttpContext.Session.GetString("AdminUsername") == null) return RedirectToAction("Login");
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(Post post)
        {
            if (string.IsNullOrEmpty(post.ThumbnailUrl)) post.ThumbnailUrl = "";
            if (ModelState.IsValid)
            {
                post.CreatedAt = DateTime.Now;
                _context.Posts.Add(post);
                _context.SaveChanges();
                TempData["Success"] = "Dokumen Baru Berhasil Dibuat!";
                return RedirectToAction("Dashboard");
            }
            return View(post);
        }

        [HttpGet]
        public IActionResult EditPost(int id)
        {
            if (HttpContext.Session.GetString("AdminUsername") == null) return RedirectToAction("Login");
            var post = _context.Posts.Find(id);
            if (post == null) return NotFound();
            return View(post);
        }
        [HttpPost]
        public IActionResult EditPost(Post post)
        {
            // Pastikan ThumbnailUrl tidak null agar validasi lolos
            if (string.IsNullOrEmpty(post.ThumbnailUrl)) post.ThumbnailUrl = "";

            // Hapus error validasi untuk ThumbnailUrl secara paksa
            ModelState.Remove("ThumbnailUrl");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    _context.SaveChanges();

                    TempData["Success"] = $"Dokumen '{post.Title}' berhasil diperbarui!";
                    return RedirectToAction("Dashboard");
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Database Error: " + ex.Message;
                }
            }
            else
            {
                // Tangkap alasan kenapa gagal simpan
                var errors = string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                TempData["Error"] = "Validasi Gagal: " + errors;
            }

            return View(post);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            if (HttpContext.Session.GetString("AdminUsername") == null) return RedirectToAction("Login");
            var post = _context.Posts.Find(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
                TempData["Success"] = "Dokumen Telah Dihapus!";
            }
            return RedirectToAction("Dashboard");
        }
    }
}