# 📚 Digital Library - PT Sepatu Mas Idaman (SMI)

Sistem Manajemen Dokumentasi dan Instruksi Kerja (IK) Digital yang dirancang untuk efisiensi operasional di lingkungan pabrik. Aplikasi ini dibangun menggunakan **ASP.NET Core 8.0 MVC** dengan fokus pada kecepatan akses, antarmuka modern, dan kemudahan navigasi bagi operator maupun staff.

---

## ✨ Fitur Unggulan

* **🔍 Live Search AJAX**: Pencarian dokumen secara real-time menggunakan Fetch API (Instan tanpa reload halaman).
* **🌓 Hybrid Dark Mode**: Antarmuka adaptif yang mendukung tema gelap dan terang secara otomatis mengikuti sistem.
* **📱 Optimized View**: Layout kartu (Card UI) yang responsif, sangat cocok untuk penggunaan di tablet atau perangkat mobile di area produksi.
* **📑 Smart Pagination (Limit 3)**: Navigasi halaman yang ringkas, hanya menampilkan maksimal 3 nomor halaman aktif untuk menjaga kebersihan antarmuka.
* **🔗 Sidebar Terkait (Limit 3)**: Halaman detail dilengkapi sidebar yang dibatasi maksimal 3 dokumen terkait agar pengguna tetap fokus pada materi yang sedang dibaca.
* **🎨 Premium Typography**: Menggunakan font *Plus Jakarta Sans* untuk tampilan instruksi yang profesional dan nyaman di mata.

---

## 🚀 Spesifikasi Teknologi

| Komponen | Teknologi |
| :--- | :--- |
| **Framework** | ASP.NET Core 8.0 MVC |
| **ORM** | Entity Framework Core |
| **Database** | SQL Server / LocalDB |
| **Frontend** | Razor Pages, Bootstrap 5, Custom CSS Variables |
| **Icons** | Bootstrap Icons v1.11.1 |
| **Scripting** | Vanilla JavaScript (Async/Await Fetch) |

---

## 🛠️ Panduan Instalasi & Menjalankan Proyek

Ikuti langkah-langkah di bawah ini untuk mengonfigurasi dan menjalankan proyek secara langsung dalam satu alur kerja:

1. **Persiapan Project & Database**
   ```bash
   # Clone dan masuk ke folder
   git clone [https://github.com/username-anda/latihan-smi.git](https://github.com/username-anda/latihan-smi.git)
   cd latihan-smi

   # Sesuaikan Connection String di appsettings.json
   "ConnectionStrings": {
     "DefaultConnection": "Server=NAMA_SERVER_ANDA;Database=SmiDigitalLibrary;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
   }

   # Jalankan Migrasi Database dan Eksekusi Program
   Update-Database
   dotnet run

   # Username dan Password
   Admin
   Password123
