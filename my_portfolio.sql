-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Mar 11, 2026 at 02:55 AM
-- Server version: 8.0.30
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `my_portfolio`
--

-- --------------------------------------------------------

--
-- Table structure for table `posts`
--

CREATE TABLE `posts` (
  `Id` int NOT NULL,
  `Title` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Content` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DisplayOrder` int NOT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `ThumbnailUrl` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `posts`
--

INSERT INTO `posts` (`Id`, `Title`, `Content`, `DisplayOrder`, `IsActive`, `CreatedAt`, `ThumbnailUrl`) VALUES
(9, '1. Pendahuluan & Tujuan', '\r\n                        <p>Dokumen ini disusun sebagai panduan resmi bagi operator mesin cutting di PT Sepatu Mas Idaman. Tujuan utama dari prosedur ini adalah: Meminimalisir sisa bahan (waste material) hingga di bawah 3%. Menjaga konsistensi bentuk potongan sesuai dengan pattern (pola) yang telah disetujui. Menjamin keselamatan kerja operator saat berinteraksi dengan mesin bertekanan tinggi.</p>\r\n                    ', 7, 1, '2026-03-04 14:51:03.000000', ''),
(10, '2. Persiapan Sebelum Bekerja (Pre-Operating)', '\r\n                            \r\n                        <p>Sebelum memulai proses pemotongan, operator wajib melakukan pengecekan berikut: Pengecekan Bahan: Pastikan batch kulit atau bahan sintetis memiliki warna yang seragam (matching color). Kondisi Pisau (Dies): Periksa ketajaman pisau pola. Pisau yang tumpul akan merusak serat bahan dan menyebabkan pinggiran kasar. Kebersihan Meja: Area meja potong harus bebas dari debu atau sisa potongan sebelumnya yang dapat mengganjal tekanan mesin.</p>\r\n                    \r\n                        ', 8, 1, '2026-03-04 14:51:22.000000', ''),
(11, '3. Prosedur Inti Pemotongan (Core Process)', '<p>A. Teknik Penempatan Pola (Nesting) Nesting adalah kunci efisiensi. Operator harus: Meletakkan pola sedekat mungkin satu sama lain. Memperhatikan arah serat bahan. Untuk bagian upper (atas) sepatu, serat harus mengikuti arah tarikan agar tidak mudah melar saat proses lasting. Menghindari area bahan yang memiliki cacat alami (seperti bekas luka pada kulit asli). B. Proses Penekanan (Pressing) Letakkan bahan di atas talenan potong (cutting board). Posisikan pisau pola di atas bahan sesuai teknik nesting. Pastikan kedua tangan operator berada pada tombol aktivasi mesin (Sistem Double Button Safety). Tekan tombol secara bersamaan hingga lengan mesin menekan pisau dengan sempurna.</p>', 9, 1, '2026-03-04 14:51:39.707330', ''),
(12, '4. Kendali Mutu (Quality Control)', '<p>Hasil potongan harus diperiksa segera setelah keluar dari mesin: Akurasi: Ukuran harus presisi sesuai dengan nomor seri pola. Kebersihan: Tidak boleh ada noda oli mesin pada permukaan bahan. Kerapian: Pinggiran bahan harus halus, tidak berserabut (fuzzy).</p>', 10, 1, '2026-03-04 14:51:55.889519', ''),
(13, '5. Kesehatan dan Keselamatan Kerja (K3)', '\r\n                            Dilarang keras mengoperasikan mesin jika:\r\n\r\nSalah satu tombol aktivasi tidak berfungsi (tombol dimodifikasi/diganjal).\r\n\r\nOperator tidak menggunakan sarung tangan pelindung baja (jika diinstruksikan).\r\n\r\nLampu area kerja redup atau berkedip.\r\n                        ', 11, 1, '2026-03-04 14:53:21.000000', ''),
(14, '6. Penanganan Sisa Bahan (Scrap Management)', 'Sisa bahan yang sudah tidak bisa dipotong kembali harus:\r\n\r\nDikumpulkan berdasarkan jenis bahan (Kulit, Sintetis, Mesh).\r\n\r\nDimasukkan ke dalam wadah tertutup untuk dikirim ke bagian limbah.\r\n\r\nDicatat beratnya dalam lembar laporan harian untuk audit efisiensi bahan.', 12, 1, '2026-03-04 14:53:37.158224', '');

-- --------------------------------------------------------

--
-- Table structure for table `profiles`
--

CREATE TABLE `profiles` (
  `Id` int NOT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Title` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `AboutMe` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Skills` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `profiles`
--

INSERT INTO `profiles` (`Id`, `Name`, `Title`, `AboutMe`, `Skills`) VALUES
(1, 'Sistem Manajemen Dokumentasi Internal', 'PT Sepatu Mas Idaman - Operational Excellence Portal testing testing lagi', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minimf veniam,s quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.c\r\n\r\nExcepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Curabitur pretium tincidunt lacus. Nulla gravida orci a odio. Nullam varius, turpis et commodo pharetra, est eros bibendum elit, nec luctus magna felis sollicitudin mauris.\r\n\r\nInteger in mauris eu nibh euismod gravida. Duis ac tellus et risus vulputate vehicula. Donec lobortis risus a elit. Etiam tempor. Ut ullamcorper, ligula eu tempor congue, eros est euismod turpis, id tincidunt sapien risus a quam.\r\n\r\nMaecenas fermentum consequat mi. Donec fermentum. Pellentesque malesuada nulla a mi. Duis sapien sem, aliquet nec, commodo eget, consequat quis, neque. Aliquam faucibus, elit ut dictum aliquet, felis nisl adipiscing sapien, sed malesuada diam lacus eget erat.\r\n\r\nCras mollis scelerisque nunc. Nullam arcu. Aliquam consequat. Curabitur augue lorem, dapibus quis, laoreet et, pretium ac, nisi. Aenean magna nisl, mollis quis, molestie eu, feugiat in, orci.\r\n\r\nIn hac habitasse platea dictumst. Fusce convallis, mauris imperdiet gravida bibendum, nisl turpis suscipit mauris, sed placerat ipsum urna sed risus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.wsd', 'Production SOP Cutting, Stitching, Assembly, Quality Control Standar Inspeksi, Grade Bahan, Engineering, Maintenance Mesin, Kelistrikan, HSE / K3 Protokol Keselamatan, Penanganan Limbah');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `Id` int NOT NULL,
  `Username` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Password` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`Id`, `Username`, `Password`) VALUES
(1, 'Admin', 'Password123');

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20260301083124_InitialCreate', '9.0.0'),
('20260301092813_Newfield', '9.0.0');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `posts`
--
ALTER TABLE `posts`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `profiles`
--
ALTER TABLE `profiles`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `posts`
--
ALTER TABLE `posts`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=50;

--
-- AUTO_INCREMENT for table `profiles`
--
ALTER TABLE `profiles`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
