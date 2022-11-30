-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: bankdiba
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.27-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `address_book`
--

DROP TABLE IF EXISTS `address_book`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `address_book` (
  `tabungan_no_rekening` varchar(10) NOT NULL,
  `pengguna_nik` varchar(16) NOT NULL,
  `keterangan` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`tabungan_no_rekening`,`pengguna_nik`),
  KEY `fk_tabungan_has_pengguna_pengguna1_idx` (`pengguna_nik`),
  KEY `fk_tabungan_has_pengguna_tabungan1_idx` (`tabungan_no_rekening`),
  CONSTRAINT `fk_tabungan_has_pengguna_pengguna1` FOREIGN KEY (`pengguna_nik`) REFERENCES `pengguna` (`nik`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_tabungan_has_pengguna_tabungan1` FOREIGN KEY (`tabungan_no_rekening`) REFERENCES `tabungan` (`no_rekening`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `address_book`
--

LOCK TABLES `address_book` WRITE;
/*!40000 ALTER TABLE `address_book` DISABLE KEYS */;
/*!40000 ALTER TABLE `address_book` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `deposito`
--

DROP TABLE IF EXISTS `deposito`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `deposito` (
  `id_deposito` varchar(20) NOT NULL,
  `jatuh_tempo` enum('Sudah','Belum') NOT NULL,
  `nominal` double NOT NULL,
  `bunga` double NOT NULL,
  `status` enum('Approve','Disapprove') NOT NULL,
  `tgl_buat` datetime NOT NULL,
  `tgl_perubahan` datetime DEFAULT NULL,
  `tabungan_no_rekening` varchar(10) NOT NULL,
  `verifikator_buka` int(11) NOT NULL,
  `verifikator_cair` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_deposito`),
  KEY `fk_deposito_tabungan1_idx` (`tabungan_no_rekening`),
  KEY `fk_deposito_employee1_idx` (`verifikator_buka`),
  KEY `fk_deposito_employee2_idx` (`verifikator_cair`),
  CONSTRAINT `fk_deposito_employee1` FOREIGN KEY (`verifikator_buka`) REFERENCES `employee` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_deposito_employee2` FOREIGN KEY (`verifikator_cair`) REFERENCES `employee` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_deposito_tabungan1` FOREIGN KEY (`tabungan_no_rekening`) REFERENCES `tabungan` (`no_rekening`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `deposito`
--

LOCK TABLES `deposito` WRITE;
/*!40000 ALTER TABLE `deposito` DISABLE KEYS */;
/*!40000 ALTER TABLE `deposito` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `employee` (
  `id` int(11) NOT NULL,
  `nama_depan` varchar(45) NOT NULL,
  `nama_keluarga` varchar(100) DEFAULT NULL,
  `position_id` int(11) NOT NULL AUTO_INCREMENT,
  `nik` varchar(16) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(128) NOT NULL,
  `tgl_buat` datetime NOT NULL,
  `tgl_perubahan` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_employee_position1_idx` (`position_id`),
  CONSTRAINT `fk_employee_position1` FOREIGN KEY (`position_id`) REFERENCES `positions` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `history_password`
--

DROP TABLE IF EXISTS `history_password`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `history_password` (
  `tanggal_diubah` datetime NOT NULL,
  `pengguna_nik` varchar(16) NOT NULL,
  `password` varchar(45) NOT NULL,
  PRIMARY KEY (`tanggal_diubah`,`pengguna_nik`),
  KEY `fk_history_password_pengguna1_idx` (`pengguna_nik`),
  CONSTRAINT `fk_history_password_pengguna1` FOREIGN KEY (`pengguna_nik`) REFERENCES `pengguna` (`nik`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `history_password`
--

LOCK TABLES `history_password` WRITE;
/*!40000 ALTER TABLE `history_password` DISABLE KEYS */;
/*!40000 ALTER TABLE `history_password` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inbox`
--

DROP TABLE IF EXISTS `inbox`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `inbox` (
  `id_pesan` varchar(16) NOT NULL,
  `id_pengguna` varchar(16) NOT NULL,
  `pesan` longtext DEFAULT NULL,
  `tanggal_kirim` datetime NOT NULL,
  `status` enum('Approve','Disapprove') DEFAULT NULL,
  `tanggal_perubahan` datetime DEFAULT NULL,
  PRIMARY KEY (`id_pesan`,`id_pengguna`),
  KEY `fk_inbox_pengguna1_idx` (`id_pengguna`),
  CONSTRAINT `fk_inbox_pengguna1` FOREIGN KEY (`id_pengguna`) REFERENCES `pengguna` (`nik`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inbox`
--

LOCK TABLES `inbox` WRITE;
/*!40000 ALTER TABLE `inbox` DISABLE KEYS */;
/*!40000 ALTER TABLE `inbox` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jenis_transaksi`
--

DROP TABLE IF EXISTS `jenis_transaksi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `jenis_transaksi` (
  `id` int(11) NOT NULL,
  `kode` varchar(45) NOT NULL,
  `nama` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jenis_transaksi`
--

LOCK TABLES `jenis_transaksi` WRITE;
/*!40000 ALTER TABLE `jenis_transaksi` DISABLE KEYS */;
INSERT INTO `jenis_transaksi` VALUES (0,'CRT','Buyback'),(9,'TAX','Pajak');
/*!40000 ALTER TABLE `jenis_transaksi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pengguna`
--

DROP TABLE IF EXISTS `pengguna`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pengguna` (
  `nik` varchar(16) NOT NULL,
  `nama_depan` varchar(100) NOT NULL,
  `nama_keluarga` varchar(100) DEFAULT NULL,
  `alamat` varchar(150) DEFAULT NULL,
  `email` varchar(100) NOT NULL,
  `no_telepon` varchar(15) NOT NULL,
  `password` varchar(128) NOT NULL,
  `pin` varchar(128) NOT NULL,
  `tgl_buat` datetime NOT NULL,
  `tgl_perubahan` datetime DEFAULT NULL,
  `security_question_id` int(11) DEFAULT NULL,
  `security_answer` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`nik`),
  KEY `fk_pengguna_security_question1_idx` (`security_question_id`),
  CONSTRAINT `fk_pengguna_security_question1` FOREIGN KEY (`security_question_id`) REFERENCES `security_question` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pengguna`
--

LOCK TABLES `pengguna` WRITE;
/*!40000 ALTER TABLE `pengguna` DISABLE KEYS */;
INSERT INTO `pengguna` VALUES ('000','Admin','Admin','Ubaya','admin@ubaya.com','081916129xxx','c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec','c6001d5b2ac3df314204a8f9d7a00e1503c9aba0fd4538645de4bf4cc7e2555cfe9ff9d0236bf327ed3e907849a98df4d330c4bea551017d465b4c1d9b80bcb0','2022-11-26 21:51:48','2022-11-26 21:51:48',1,'Obama'),('512872','Steve','Job','House','p@gmail.com','08786318','ec193fe60c27f3bc90bfc324f70a50d1237f9629f87e6937cc67eb9cab7611aee87d2df3df88d85bb1fcd5914cb6b7e2a482678eaa6b259d6d4387882a109d91','8f38ba1b52fdbe35907eeb02f4cdd923dc608cbb560f1415cbac5858345e8aeaa3f43756602e2ec5f5e7637d65a627ccffa8cd636237110a9e8e207ad70d6bb5','2022-11-26 19:11:39','2022-11-26 19:11:39',1,'obama');
/*!40000 ALTER TABLE `pengguna` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `positions`
--

DROP TABLE IF EXISTS `positions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `positions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nama` varchar(100) NOT NULL,
  `keterangan` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `positions`
--

LOCK TABLES `positions` WRITE;
/*!40000 ALTER TABLE `positions` DISABLE KEYS */;
INSERT INTO `positions` VALUES (1,'CEO','Apex'),(2,'Admin','Nice Money'),(3,'Regular Employee','Loyal');
/*!40000 ALTER TABLE `positions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `security_question`
--

DROP TABLE IF EXISTS `security_question`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `security_question` (
  `id` int(11) NOT NULL,
  `question` longtext NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `security_question`
--

LOCK TABLES `security_question` WRITE;
/*!40000 ALTER TABLE `security_question` DISABLE KEYS */;
INSERT INTO `security_question` VALUES (1,'What is obama\'s last name?');
/*!40000 ALTER TABLE `security_question` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tabungan`
--

DROP TABLE IF EXISTS `tabungan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tabungan` (
  `no_rekening` varchar(10) NOT NULL,
  `saldo` double DEFAULT NULL,
  `status` enum('Approve','Disapprove') DEFAULT NULL,
  `keterangan` varchar(255) DEFAULT NULL,
  `tgl_buat` datetime NOT NULL,
  `tgl_perubahan` datetime DEFAULT NULL,
  `pengguna_nik` varchar(16) DEFAULT NULL,
  `verifikator` int(11) NOT NULL,
  PRIMARY KEY (`no_rekening`),
  KEY `fk_tabungan_pengguna1_idx` (`pengguna_nik`),
  KEY `fk_tabungan_employee1_idx` (`verifikator`),
  CONSTRAINT `fk_tabungan_employee1` FOREIGN KEY (`verifikator`) REFERENCES `employee` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_tabungan_pengguna1` FOREIGN KEY (`pengguna_nik`) REFERENCES `pengguna` (`nik`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tabungan`
--

LOCK TABLES `tabungan` WRITE;
/*!40000 ALTER TABLE `tabungan` DISABLE KEYS */;
/*!40000 ALTER TABLE `tabungan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transaksi`
--

DROP TABLE IF EXISTS `transaksi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `transaksi` (
  `id` varchar(45) NOT NULL,
  `tgl_transaksi` datetime NOT NULL,
  `nominal` double NOT NULL,
  `keterangan` varchar(45) DEFAULT NULL,
  `jenis_transaksi_id` int(11) NOT NULL,
  `rekening_sumber` varchar(10) NOT NULL,
  `virtual_gift_card_id` varchar(45) DEFAULT NULL,
  `rekening_tujuan` varchar(10) NOT NULL,
  PRIMARY KEY (`id`,`rekening_sumber`),
  KEY `fk_transaksi_jenis_transaksi_idx` (`jenis_transaksi_id`),
  KEY `fk_transaksi_tabungan1_idx` (`rekening_sumber`),
  KEY `fk_transaksi_virtual_gift_card1_idx` (`virtual_gift_card_id`),
  KEY `fk_transaksi_tabungan2_idx` (`rekening_tujuan`),
  CONSTRAINT `fk_transaksi_jenis_transaksi` FOREIGN KEY (`jenis_transaksi_id`) REFERENCES `jenis_transaksi` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_transaksi_tabungan1` FOREIGN KEY (`rekening_sumber`) REFERENCES `tabungan` (`no_rekening`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_transaksi_tabungan2` FOREIGN KEY (`rekening_tujuan`) REFERENCES `tabungan` (`no_rekening`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_transaksi_virtual_gift_card1` FOREIGN KEY (`virtual_gift_card_id`) REFERENCES `virtual_gift_card` (`code`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transaksi`
--

LOCK TABLES `transaksi` WRITE;
/*!40000 ALTER TABLE `transaksi` DISABLE KEYS */;
/*!40000 ALTER TABLE `transaksi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `virtual_gift_card`
--

DROP TABLE IF EXISTS `virtual_gift_card`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `virtual_gift_card` (
  `code` varchar(45) NOT NULL,
  `kadaluarsa` date NOT NULL,
  `limit` int(11) NOT NULL,
  `asal_gift_card` varchar(10) NOT NULL,
  `tujuan_gift_card` varchar(10) NOT NULL,
  PRIMARY KEY (`code`),
  KEY `fk_virtual_card_tabungan1_idx` (`asal_gift_card`),
  KEY `fk_virtual_gift_card_tabungan1_idx` (`tujuan_gift_card`),
  CONSTRAINT `fk_virtual_card_tabungan1` FOREIGN KEY (`asal_gift_card`) REFERENCES `tabungan` (`no_rekening`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_virtual_gift_card_tabungan1` FOREIGN KEY (`tujuan_gift_card`) REFERENCES `tabungan` (`no_rekening`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `virtual_gift_card`
--

LOCK TABLES `virtual_gift_card` WRITE;
/*!40000 ALTER TABLE `virtual_gift_card` DISABLE KEYS */;
/*!40000 ALTER TABLE `virtual_gift_card` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-26 21:58:25
