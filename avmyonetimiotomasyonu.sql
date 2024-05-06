CREATE DATABASE  IF NOT EXISTS `avmyonetimiotomasyonu` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `avmyonetimiotomasyonu`;
-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: avmyonetimiotomasyonu
-- ------------------------------------------------------
-- Server version	8.0.32

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `guvenlikkameralari`
--

DROP TABLE IF EXISTS `guvenlikkameralari`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `guvenlikkameralari` (
  `kameraID` int NOT NULL AUTO_INCREMENT,
  `kameraTipi` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `konum` int NOT NULL,
  PRIMARY KEY (`kameraID`),
  KEY `FK_KAMERA_KONUM_idx` (`konum`),
  CONSTRAINT `FK_KAMERA_KONUM` FOREIGN KEY (`konum`) REFERENCES `konumlar` (`konumID`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=94 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `guvenlikkameralari`
--

LOCK TABLES `guvenlikkameralari` WRITE;
/*!40000 ALTER TABLE `guvenlikkameralari` DISABLE KEYS */;
INSERT INTO `guvenlikkameralari` VALUES (1,'Dome Güvenlik Kamerası',5),(2,'Bullet Güvenlik Kamerası',5),(3,'AHD Güvenlik Kamerası',5),(4,'Dome Güvenlik Kamerası',6),(5,'Bullet Güvenlik Kamerası',6),(6,'Wi-Fi Güvenlik Kamerası',6),(7,'Analog Güvenlik Kamerası',7),(8,'AHD Güvenlik Kamerası',7),(9,'Wi-Fi Güvenlik Kamerası',7),(10,'Dome Güvenlik Kamerası',8),(11,'Bullet Güvenlik Kamerası',8),(12,'Analog Güvenlik Kamerası',8),(13,'AHD Güvenlik Kamerası',9),(14,'Çok Mercekli Multi Sensör',9),(15,'Wi-Fi Güvenlik Kamerası',9),(16,'Dome Güvenlik Kamerası',10),(17,'Bullet Güvenlik Kamerası',10),(18,'Analog Güvenlik Kamerası',10),(19,'AHD Güvenlik Kamerası',11),(20,'Wi-Fi Güvenlik Kamerası',11),(21,'Dome Güvenlik Kamerası',11),(22,'Bullet Güvenlik Kamerası',12),(23,'Analog Güvenlik Kamerası',12),(24,'AHD Güvenlik Kamerası',12),(25,'Wi-Fi Güvenlik Kamerası',13),(26,'Dome Güvenlik Kamerası',13),(27,'Bullet Güvenlik Kamerası',13),(28,'Çok Mercekli Multi Sensör Güvenlik Kamerası',14),(29,'Analog Güvenlik Kamerası',14),(30,'AHD Güvenlik Kamerası',14),(31,'Wi-Fi Güvenlik Kamerası',15),(32,'Dome Güvenlik Kamerası',15),(33,'Bullet Güvenlik Kamerası',15),(34,'Analog Güvenlik Kamerası',16),(35,'AHD Güvenlik Kamerası',16),(36,'Wi-Fi Güvenlik Kamerası',16),(37,'Dome Güvenlik Kamerası',17),(38,'Bullet Güvenlik Kamerası',17),(39,'Analog Güvenlik Kamerası',17),(40,'AHD Güvenlik Kamerası',18),(41,'Wi-Fi Güvenlik Kamerası',18),(42,'Dome Güvenlik Kamerası',18),(43,'Çok Mercekli Multi Sensör Güvenlik Kamerası',19),(44,'Bullet Güvenlik Kamerası',19),(45,'Analog Güvenlik Kamerası',19),(46,'AHD Güvenlik Kamerası',20),(47,'Wi-Fi Güvenlik Kamerası',20),(48,'Dome Güvenlik Kamerası',20),(49,'Bullet Güvenlik Kamerası',21),(50,'Analog Güvenlik Kamerası',21),(51,'AHD Güvenlik Kamerası',21),(52,'Wi-Fi Güvenlik Kamerası',22),(53,'Dome Güvenlik Kamerası',22),(54,'Bullet Güvenlik Kamerası',22),(55,'Analog Güvenlik Kamerası',23),(56,'AHD Güvenlik Kamerası',23),(57,'Wi-Fi Güvenlik Kamerası',23),(58,'Çok Mercekli Multi Sensör Güvenlik Kamerası',24),(59,'Dome Güvenlik Kamerası',24),(60,'Bullet Güvenlik Kamerası',24),(61,'Kızılötesi Güvenlik Kamerası',25),(62,'Termal Güvenlik Kamerası',25),(63,'Dış Ortam Box Güvenlik Kamerası',25),(64,'Fish Eye Güvenlik Kamerası',26),(65,'Çok Mercekli Multi Sensör Güvenlik Kamerası',26),(66,'Dome Güvenlik Kamerası',26),(67,'Termal Güvenlik Kamerası',27),(68,'Bullet Güvenlik Kamerası',27),(69,'Analog Güvenlik Kamerası',27),(70,'Fish Eye Güvenlik Kamerası',28),(71,'AHD Güvenlik Kamerası',28),(72,'Dome Güvenlik Kamerası',28),(73,'Bullet Güvenlik Kamerası',29),(74,'Analog Güvenlik Kamerası',29),(75,'Dome Güvenlik Kamerası',29),(76,'Çok Mercekli Multi Sensör Güvenlik Kamerası',30),(77,'Termal Güvenlik Kamerası',30),(78,'Ex-Proof Güvenlik Kamerası',30),(79,'Bullet Güvenlik Kamerası',31),(80,'AHD Güvenlik Kamerası',31),(81,'Analog Güvenlik Kamerası',31),(82,'Termal Güvenlik Kamerası',1),(83,'Kızılötesi Güvenlik Kamerası',1),(84,'Dome Güvenlik Kamerası',1),(85,'Kızılötesi Güvenlik Kamerası',2),(86,'Termal Güvenlik Kamerası',2),(87,'Bullet Güvenlik Kamerası',2),(88,'Termal Güvenlik Kamerası',3),(89,'AHD Güvenlik Kamerası',3),(90,'Kızılötesi Güvenlik Kamerası',3),(91,'Dome Güvenlik Kamerası',4),(92,'Analog Güvenlik Kamerası',4),(93,'Kızılötesi Güvenlik Kamerası',4);
/*!40000 ALTER TABLE `guvenlikkameralari` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `guvenlikyonetimi_verileri`
--

DROP TABLE IF EXISTS `guvenlikyonetimi_verileri`;
/*!50001 DROP VIEW IF EXISTS `guvenlikyonetimi_verileri`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `guvenlikyonetimi_verileri` AS SELECT 
 1 AS `kameraID`,
 1 AS `kameraTipi`,
 1 AS `konumAdi`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `isletmeler`
--

DROP TABLE IF EXISTS `isletmeler`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `isletmeler` (
  `isletmeID` int NOT NULL AUTO_INCREMENT,
  `isletmeAdi` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `mekan` int NOT NULL,
  `isletmeTelefon` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `calisanSayisi` int NOT NULL,
  `konum` int NOT NULL,
  PRIMARY KEY (`isletmeID`),
  KEY `FK_ISLETME_MEKAN_idx` (`mekan`),
  KEY `FK_ISLETME_KONUM_idx` (`konum`),
  CONSTRAINT `FK_ISLETME_KONUM` FOREIGN KEY (`konum`) REFERENCES `konumlar` (`konumID`) ON UPDATE CASCADE,
  CONSTRAINT `FK_ISLETME_MEKAN` FOREIGN KEY (`mekan`) REFERENCES `mekanlar` (`mekanID`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `isletmeler`
--

LOCK TABLES `isletmeler` WRITE;
/*!40000 ALTER TABLE `isletmeler` DISABLE KEYS */;
INSERT INTO `isletmeler` VALUES (1,'LTB Jeans',1,'05628948918',15,7),(2,'Migros',4,'05658189518',20,5),(3,'Dürümle',3,'07989919448',10,20),(4,'H&M',1,'05541269987',7,6),(5,'Pull&Bear',1,'05413594465',11,9),(6,'Çöps',3,'05324865799',5,22),(7,'Adidas',1,'05365486522',9,8),(8,'Arby\'s',3,'05413258794',12,3),(9,'Starbucks',2,'05341268874',16,20),(10,'Cinemaximum',6,'05562154889',22,23),(11,'DinoLino',5,'05341256544',15,21),(12,'DapYapı',7,'05461534855',3,19),(13,'Kahve Dünyası',2,'05461875352',4,17),(14,'Ekleristan',2,'02624584452',1,16),(15,'Kipa',4,'05365545544',27,2),(16,'Zara',1,'02625444814',19,10),(17,'Calvin Klein',1,'05468546541',12,12),(18,'Beymen Club',1,'05464652212',6,11),(19,'KFC',3,'05423651212',9,24),(20,'Macro Center',4,'05462154896',14,1),(23,'Pennaut Waffle',2,'05996534135',10,4);
/*!40000 ALTER TABLE `isletmeler` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `isletmeyonetimi_verileri`
--

DROP TABLE IF EXISTS `isletmeyonetimi_verileri`;
/*!50001 DROP VIEW IF EXISTS `isletmeyonetimi_verileri`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `isletmeyonetimi_verileri` AS SELECT 
 1 AS `isletmeID`,
 1 AS `isletmeAdi`,
 1 AS `mekanTipi`,
 1 AS `isletmeTelefon`,
 1 AS `calisanSayisi`,
 1 AS `konumAdi`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `kiracilar`
--

DROP TABLE IF EXISTS `kiracilar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kiracilar` (
  `kiraciID` int NOT NULL AUTO_INCREMENT,
  `kiraciAdi` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `kiraciTelefon` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `kiraciEposta` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  PRIMARY KEY (`kiraciID`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kiracilar`
--

LOCK TABLES `kiracilar` WRITE;
/*!40000 ALTER TABLE `kiracilar` DISABLE KEYS */;
INSERT INTO `kiracilar` VALUES (1,'Onur SULKALAR','07491918489','ornek@example.com'),(2,'Çak Şirketler Grubu','05949195629','ornek@example.com'),(3,'Anadolu Grubu','05865991951','ornek@example.com'),(4,'Yener ÇEVİK','05423158843','ornek@example.com'),(5,'Akif TURGUT','05462154421','ornek@example.com'),(6,'Yaman CEYLAN','05364851225','ornek@example.com'),(7,'Halit ALKAN','05245651858','ornek@example.com'),(8,'Gülsüm AYDIN','0546+821548','ornek@example.com'),(9,'Eyüp ALABORA','05468512456','ornek@example.com'),(10,'Müjgan MORKOÇ','05368451565','ornek@example.com'),(11,'Ahmet SAĞIN','05462148522','ornek@example.com'),(12,'Mehmet BİNBOĞA','02620548532','ornek@example.com'),(13,'Necati ÖKSÜZ','02625416542','ornek@example.com'),(14,'Ahu DEMİR','05412354656','ornek@example.com'),(15,'Hilal ERSOY','05468241548','ornek@example.com ');
/*!40000 ALTER TABLE `kiracilar` ENABLE KEYS */;
UNLOCK TABLES;
ALTER DATABASE `avmyonetimiotomasyonu` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `Kiracilar_AFTER_INSERT` AFTER INSERT ON `kiracilar` FOR EACH ROW BEGIN
	INSERT INTO MailKuyruklari (e_posta, baslik, mesaj) 
	VALUES (NEW.kiraciEposta, 'Hoş Geldiniz', CONCAT('Merhaba ', NEW.kiraciAdi, ', \nAramıza hoş geldiniz!'));
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `avmyonetimiotomasyonu` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci ;

--
-- Temporary view structure for view `kiragelirleri`
--

DROP TABLE IF EXISTS `kiragelirleri`;
/*!50001 DROP VIEW IF EXISTS `kiragelirleri`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `kiragelirleri` AS SELECT 
 1 AS `isletmeID`,
 1 AS `isletmeAdi`,
 1 AS `kiraBedeli`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `kiralananisletmeler`
--

DROP TABLE IF EXISTS `kiralananisletmeler`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kiralananisletmeler` (
  `kiraID` int NOT NULL AUTO_INCREMENT,
  `isletme` int NOT NULL,
  `kiraci` int NOT NULL,
  `mekan` int NOT NULL,
  `konum` int NOT NULL,
  `kiralikAlan` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `kiraBedeli` double NOT NULL,
  `kiraSozlesmesiBaslangicTarihi` datetime NOT NULL,
  `kiraSozlesmesiBitisTarihi` datetime NOT NULL,
  PRIMARY KEY (`kiraID`),
  KEY `FK_KIRALANANISLETME_ISLETME_idx` (`isletme`),
  KEY `FK_KIRALANANISLETME_KIRACI_idx` (`kiraci`),
  KEY `FK_KIRALANANISLETME_MEKAN_idx` (`mekan`),
  KEY `FK_KIRALANANISLETME_KONUM_idx` (`konum`),
  CONSTRAINT `FK_KIRALANANISLETME_ISLETME` FOREIGN KEY (`isletme`) REFERENCES `isletmeler` (`isletmeID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_KIRALANANISLETME_KIRACI` FOREIGN KEY (`kiraci`) REFERENCES `kiracilar` (`kiraciID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_KIRALANANISLETME_KONUM` FOREIGN KEY (`konum`) REFERENCES `konumlar` (`konumID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_KIRALANANISLETME_MEKAN` FOREIGN KEY (`mekan`) REFERENCES `mekanlar` (`mekanID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kiralananisletmeler`
--

LOCK TABLES `kiralananisletmeler` WRITE;
/*!40000 ALTER TABLE `kiralananisletmeler` DISABLE KEYS */;
INSERT INTO `kiralananisletmeler` VALUES (1,1,1,1,7,'120 Metrekare',50000,'2024-04-30 00:00:00','2025-05-01 00:00:00'),(2,2,2,4,5,'200 Metrekare',90000,'2024-02-15 00:00:00','2027-02-15 00:00:00'),(3,3,3,3,20,'50 Metrekare',30000,'2024-01-21 00:00:00','2025-07-21 00:00:00'),(4,4,4,1,6,'75 Metrekare',35000,'2024-07-30 00:00:00','2025-07-30 00:00:00'),(5,5,5,1,9,'80 Metrekare',40000,'2024-04-12 00:00:00','2026-04-12 00:00:00'),(6,6,6,3,22,'55 Metrekare',34000,'2024-08-10 00:00:00','2025-08-10 00:00:00'),(7,7,7,1,8,'120 Metrekare',50000,'2024-05-20 00:00:00','2025-05-20 00:00:00'),(8,8,8,3,3,'55 Metrekare',32000,'2024-04-13 00:00:00','2025-04-13 00:00:00'),(9,9,9,2,20,'200 Metrekare',100000,'2024-09-19 00:00:00','2025-09-19 00:00:00'),(10,10,10,6,23,'300 Metrekare',165000,'2024-01-15 00:00:00','2029-01-15 00:00:00'),(11,11,11,5,21,'250 Metrekare',125000,'2024-02-11 00:00:00','2028-02-11 00:00:00'),(12,12,12,7,19,'50 Metrekare',30000,'2024-09-17 00:00:00','2025-09-17 00:00:00'),(13,13,13,2,17,'70 Metrekare',65200,'2024-03-09 00:00:00','2025-03-09 00:00:00'),(14,14,14,2,16,'45 Metrekare',29500,'2024-06-16 00:00:00','2026-06-16 00:00:00'),(15,15,15,4,2,'300 Metrekare',175000,'2024-06-13 00:00:00','2030-06-13 00:00:00'),(16,15,15,4,5,'200 Metrekare',125000,'2024-10-15 00:00:00','2028-10-15 00:00:00'),(18,16,14,4,7,'100 Metrekare',100000,'2024-05-06 00:00:00','2026-05-06 00:00:00');
/*!40000 ALTER TABLE `kiralananisletmeler` ENABLE KEYS */;
UNLOCK TABLES;
ALTER DATABASE `avmyonetimiotomasyonu` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `KiralananIsletmeler_AFTER_DELETE` AFTER DELETE ON `kiralananisletmeler` FOR EACH ROW BEGIN
	DECLARE isletme_sayisi INT;
    
    SELECT COUNT(*) INTO isletme_sayisi
    FROM KiralanIsletmeler
    WHERE isletme = OLD.isletme;

    IF isletme_sayisi = 0 THEN
        DELETE FROM Isletmeler 
        WHERE isletmeID=OLD.isletme;
    END IF;   
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `avmyonetimiotomasyonu` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci ;
ALTER DATABASE `avmyonetimiotomasyonu` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `KiralananIsletmeler_AFTER_DELETE_1` AFTER DELETE ON `kiralananisletmeler` FOR EACH ROW BEGIN
	DECLARE kiraci_sayisi INT;
    
    SELECT COUNT(*) INTO kiraci_sayisi
    FROM KiralanIsletmeler
    WHERE kiraci = OLD.kiraci;

    IF isletme_sayisi = 0 THEN
        DELETE FROM Kiracilar 
        WHERE kiraciID=OLD.kiraci;
    END IF;   
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `avmyonetimiotomasyonu` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci ;

--
-- Temporary view structure for view `kirasozlesmeleri`
--

DROP TABLE IF EXISTS `kirasozlesmeleri`;
/*!50001 DROP VIEW IF EXISTS `kirasozlesmeleri`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `kirasozlesmeleri` AS SELECT 
 1 AS `kiraID`,
 1 AS `isletme`,
 1 AS `kiraci`,
 1 AS `mekanTipi`,
 1 AS `konum`,
 1 AS `kiralikAlan`,
 1 AS `kiraBedeli`,
 1 AS `kiraSozlesmesiBaslangicTarihi`,
 1 AS `kiraSozlesmesiBitisTarihi`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `konumlar`
--

DROP TABLE IF EXISTS `konumlar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `konumlar` (
  `konumID` int NOT NULL AUTO_INCREMENT,
  `konumAdi` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`konumID`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `konumlar`
--

LOCK TABLES `konumlar` WRITE;
/*!40000 ALTER TABLE `konumlar` DISABLE KEYS */;
INSERT INTO `konumlar` VALUES (1,'Kuzey Giriş'),(2,'Güney Giriş'),(3,'Doğu Giriş'),(4,'Batı Giriş'),(5,'Zemin Kat Kuzey'),(6,'Zemin Kat Güney'),(7,'Zemin Kat Doğu'),(8,'Zemin Kat Batı'),(9,'Zemin Kat Merkez'),(10,'1. Kat Kuzey'),(11,'1. Kat Güney'),(12,'1. Kat Doğu'),(13,'1. Kat Batı'),(14,'1. Kat Merkez'),(15,'2. Kat Kuzey'),(16,'2. Kat Güney'),(17,'2. Kat Doğu'),(18,'2. Kat Batı'),(19,'2. Kat Merkez'),(20,'3. Kat Kuzey'),(21,'3. Kat Güney'),(22,'3. Kat Doğu'),(23,'3. Kat Batı'),(24,'3. Kat Merkez'),(25,'Otopark Giriş'),(26,'Otopark Kuzey'),(27,'Otopark Güney'),(28,'Otopark Doğu'),(29,'Otopark Batı'),(30,'Otopark Merkez'),(31,'Teras');
/*!40000 ALTER TABLE `konumlar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kullanicilar`
--

DROP TABLE IF EXISTS `kullanicilar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kullanicilar` (
  `kullaniciID` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `adi` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `soyadi` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `e_posta` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  `sifre` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  `rol` int NOT NULL,
  PRIMARY KEY (`kullaniciID`),
  UNIQUE KEY `kullaniciID_UNIQUE` (`kullaniciID`),
  UNIQUE KEY `e_posta_UNIQUE` (`e_posta`),
  UNIQUE KEY `sifre_UNIQUE` (`sifre`),
  KEY `FK_KULANICI_ROLID_idx` (`rol`),
  CONSTRAINT `FK_KULANICI_ROL` FOREIGN KEY (`rol`) REFERENCES `roller` (`rolID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kullanicilar`
--

LOCK TABLES `kullanicilar` WRITE;
/*!40000 ALTER TABLE `kullanicilar` DISABLE KEYS */;
INSERT INTO `kullanicilar` VALUES ('gugugogo','GOGO','GUGU','GGUHGI@gwbwrb','1234567',2),('yamancylnn','Yaman','Ceylan','yamancylnn@gmail.com','514514',1);
/*!40000 ALTER TABLE `kullanicilar` ENABLE KEYS */;
UNLOCK TABLES;
ALTER DATABASE `avmyonetimiotomasyonu` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `Kullanicilar_BEFORE_INSERT` BEFORE INSERT ON `kullanicilar` FOR EACH ROW BEGIN
	DECLARE eposta_sayisi INT;
    
    SELECT COUNT(*) INTO eposta_sayisi
    FROM Kullanicilar
    WHERE e_posta = NEW.e_posta;

    IF eposta_sayisi > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Aynı E-Posta adresine sahip bir kayıt zaten var.';
    END IF;   
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `avmyonetimiotomasyonu` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci ;
ALTER DATABASE `avmyonetimiotomasyonu` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `Kullanicilar_BEFORE_INSERT_1` BEFORE INSERT ON `kullanicilar` FOR EACH ROW BEGIN
	DECLARE sifre_sayisi INT;
    
    SELECT COUNT(*) INTO sifre_sayisi
    FROM Kullanicilar
    WHERE sifre = NEW.sifre;

    IF sifre_sayisi > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Bu Şifre zaten kullanılıyor.';
    END IF;   
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `avmyonetimiotomasyonu` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci ;
ALTER DATABASE `avmyonetimiotomasyonu` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `Kullanicilar_AFTER_INSERT` AFTER INSERT ON `kullanicilar` FOR EACH ROW BEGIN
	INSERT INTO MailKuyruklari (e_posta, baslik, mesaj) 
	VALUES (NEW.e_posta, 'Yeni Kayıt', CONCAT('Merhaba ', NEW.adi, ', \nAVM Yönetimi Otomasyon sistemine kaydınız başrıyla yapılmıştır. \nİyi Çalışmalar'));
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `avmyonetimiotomasyonu` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `kullanicilar_BEFORE_UPDATE_1` BEFORE UPDATE ON `kullanicilar` FOR EACH ROW BEGIN
	DECLARE sifre_sayisi INT;
    
    IF OLD.sifre != NEW.sifre THEN
		SELECT COUNT(*) INTO sifre_sayisi
		FROM Kullanicilar
		WHERE sifre = NEW.sifre;
	END IF;
    IF sifre_sayisi > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Bu Şifre Başka Bir Kullanıcı Tarafından Kullanılıyor.';
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `kullanicilar_BEFORE_UPDATE` BEFORE UPDATE ON `kullanicilar` FOR EACH ROW BEGIN
	DECLARE eposta_sayisi INT;
    
    IF OLD.e_posta != NEW.e_posta THEN
		SELECT COUNT(*) INTO eposta_sayisi
		FROM Kullanicilar
		WHERE e_posta = NEW.e_posta;
	END IF;
    IF eposta_sayisi > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Aynı E-Posta adresine sahip bir kayıt zaten var.';
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `kullanicilar_BEFORE_UPDATE_2` BEFORE UPDATE ON `kullanicilar` FOR EACH ROW BEGIN
	DECLARE kullanici_sayisi INT;
    
    IF OLD.kullaniciID != NEW.kullaniciID THEN
		SELECT COUNT(*) INTO kullanici_sayisi
		FROM Kullanicilar
		WHERE kullaniciID = NEW.kullaniciID;
	END IF;
    IF kullanici_sayisi > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Bu Kullanıcı ID Başka Bir Kullanıcı Tarafından Kullanılıyor.';
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Temporary view structure for view `kullaniciyonetimi_verileri`
--

DROP TABLE IF EXISTS `kullaniciyonetimi_verileri`;
/*!50001 DROP VIEW IF EXISTS `kullaniciyonetimi_verileri`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `kullaniciyonetimi_verileri` AS SELECT 
 1 AS `kullaniciID`,
 1 AS `adi`,
 1 AS `soyadi`,
 1 AS `e_posta`,
 1 AS `sifre`,
 1 AS `rolAdi`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `mailkuyruklari`
--

DROP TABLE IF EXISTS `mailkuyruklari`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mailkuyruklari` (
  `mailID` int NOT NULL AUTO_INCREMENT,
  `e_posta` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  `baslik` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT 'Hoş Geldiniz',
  `mesaj` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`mailID`)
) ENGINE=InnoDB AUTO_INCREMENT=112 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mailkuyruklari`
--

LOCK TABLES `mailkuyruklari` WRITE;
/*!40000 ALTER TABLE `mailkuyruklari` DISABLE KEYS */;
INSERT INTO `mailkuyruklari` VALUES (1,'ornek@example.com','Hoş Geldiniz','Merhaba Çak Şirketler Grubu, \nAramıza hoş geldiniz!'),(2,'ornek@example.com','Hoş Geldiniz','Merhaba Anadolu Grubu, \nAramıza hoş geldiniz!'),(3,'ornek@example.com','Hoş Geldiniz','Merhaba Ali Bey, \nAramıza hoş geldiniz! \nİyi Çalışmalar.'),(4,'ornek@example.com','Hoş Geldiniz','Merhaba Ayşe Hanım, \nAramıza hoş geldiniz! \nİyi Çalışmalar.'),(5,'ornek@example.com','Hoş Geldiniz','Merhaba Onur Sulkalar, \nAramıza hoş geldiniz!'),(19,'ornek@example.com','Hoş Geldiniz','Merhaba Yener ÇEVİK, \nAramıza hoş geldiniz!'),(20,'ornek@example.com','Hoş Geldiniz','Merhaba Akif TURGUT, \nAramıza hoş geldiniz!'),(21,'ornek@example.com','Hoş Geldiniz','Merhaba Yaman CEYLAN, \nAramıza hoş geldiniz!'),(22,'ornek@example.com','Hoş Geldiniz','Merhaba Halit ALKAN, \nAramıza hoş geldiniz!'),(23,'ornek@example.com','Hoş Geldiniz','Merhaba Gülsüm AYDIN, \nAramıza hoş geldiniz!'),(24,'ornek@example.com','Hoş Geldiniz','Merhaba Eyüp ALABORA, \nAramıza hoş geldiniz!'),(25,'ornek@example.com','Hoş Geldiniz','Merhaba Müjgan MORKOÇ, \nAramıza hoş geldiniz!'),(26,'ornek@example.com','Hoş Geldiniz','Merhaba Ahmet SAĞIN, \nAramıza hoş geldiniz!'),(27,'ornek@example.com','Hoş Geldiniz','Merhaba Mehmet BİNBOĞA, \nAramıza hoş geldiniz!'),(28,'ornek@example.com','Hoş Geldiniz','Merhaba Necati ÖKSÜZ, \nAramıza hoş geldiniz!'),(29,'ornek@example.com','Hoş Geldiniz','Merhaba Ahu DEMİR, \nAramıza hoş geldiniz!'),(30,'ornek@example.com ','Hoş Geldiniz','Merhaba Hilal ERSOY, \nAramıza hoş geldiniz!'),(91,'ornek@example.com','Hoş Geldiniz','Merhaba Gözde Hanım, \nAramıza hoş geldiniz! \nİyi Çalışmalar.'),(92,'ornek@example.com','Hoş Geldiniz','Merhaba İsmail Bey, \nAramıza hoş geldiniz! \nİyi Çalışmalar.'),(93,'ornek@example.com','Hoş Geldiniz','Merhaba Gülçin Hanım, \nAramıza hoş geldiniz! \nİyi Çalışmalar.'),(94,'ornek@example.com','Hoş Geldiniz','Merhaba Ahmet Bey, \nAramıza hoş geldiniz! \nİyi Çalışmalar.'),(95,'ornek@example.com','Hoş Geldiniz','Merhaba Mustafa Bey, \nAramıza hoş geldiniz! \nİyi Çalışmalar.'),(96,'ornek@example.com','Hoş Geldiniz','Merhaba Hakan Bey, \nAramıza hoş geldiniz! \nİyi Çalışmalar.'),(97,'ornek@example.com','Hoş Geldiniz','Merhaba Hakan Bey, \nAramıza hoş geldiniz! \nİyi Çalışmalar.'),(98,'ornek@example.com','Hoş Geldiniz','Merhaba Selim Bey, \nAramıza hoş geldiniz! \nİyi Çalışmalar.'),(99,'ornek@example.com','Hoş Geldiniz','Merhaba Müjgan Hanım, \nAramıza hoş geldiniz! \nİyi Çalışmalar.'),(100,'ornek@example.com','Hoş Geldiniz','Merhaba Hanife Hanım, \nAramıza hoş geldiniz! \nİyi Çalışmalar.'),(101,'ornek@example.com','Hoş Geldiniz','Merhaba Şeyma Hanım, \nAramıza hoş geldiniz! \nİyi Çalışmalar.'),(102,'ornek@example.com','Hoş Geldiniz','Merhaba Ahmet Bey, \nAramıza hoş geldiniz! \nİyi Çalışmalar.'),(103,'ornek@example.com','Hoş Geldiniz','Merhaba Özcan Bey, \nAramıza hoş geldiniz! \nİyi Çalışmalar.'),(104,'ornek@example.com','Hoş Geldiniz','Merhaba Sedat Bey, \nAramıza hoş geldiniz! \nİyi Çalışmalar.'),(105,'ornek@example.com','Hoş Geldiniz','Merhaba Sülayman Bey, \nAramıza hoş geldiniz! \nİyi Çalışmalar.'),(106,'yamancylnn@gmail.com','Yeni Kayıt','Merhaba Yaman, \nAVM Yönetimi Otomasyon sistemine kaydınız başrıyla yapılmıştır. \nİyi Çalışmalar'),(109,'aliveli@gmail.com','Yeni Kayıt','Merhaba ali, \nAVM Yönetimi Otomasyon sistemine kaydınız başrıyla yapılmıştır. \nİyi Çalışmalar'),(111,'GGUHGI','Yeni Kayıt','Merhaba GOGO, \nAVM Yönetimi Otomasyon sistemine kaydınız başrıyla yapılmıştır. \nİyi Çalışmalar');
/*!40000 ALTER TABLE `mailkuyruklari` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mekanlar`
--

DROP TABLE IF EXISTS `mekanlar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mekanlar` (
  `mekanID` int NOT NULL AUTO_INCREMENT,
  `mekanTipi` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`mekanID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mekanlar`
--

LOCK TABLES `mekanlar` WRITE;
/*!40000 ALTER TABLE `mekanlar` DISABLE KEYS */;
INSERT INTO `mekanlar` VALUES (1,'Mağaza'),(2,'Kafe'),(3,'Restoran'),(4,'Market'),(5,'Eğlence'),(6,'Sinema'),(7,'Ofis'),(8,'Otopark'),(9,'Tuvalet'),(10,'Mescit');
/*!40000 ALTER TABLE `mekanlar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `personelgiderleri`
--

DROP TABLE IF EXISTS `personelgiderleri`;
/*!50001 DROP VIEW IF EXISTS `personelgiderleri`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `personelgiderleri` AS SELECT 
 1 AS `personel_TCNo`,
 1 AS `Personel`,
 1 AS `pozisyon`,
 1 AS `maas`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `personeller`
--

DROP TABLE IF EXISTS `personeller`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `personeller` (
  `personel_TCNo` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `personelAdi` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `personelSoyadi` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `cinsiyet` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `telefon` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `e_posta` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  `adres` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `pozisyon` int NOT NULL,
  `maas` double NOT NULL,
  PRIMARY KEY (`personel_TCNo`),
  UNIQUE KEY `personel_TCNo_UNIQUE` (`personel_TCNo`),
  KEY `FK_PERSONEL_POZISYON_idx` (`pozisyon`),
  CONSTRAINT `FK_PERSONEL_POZISYON` FOREIGN KEY (`pozisyon`) REFERENCES `pozisyonlar` (`pozisyonID`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personeller`
--

LOCK TABLES `personeller` WRITE;
/*!40000 ALTER TABLE `personeller` DISABLE KEYS */;
INSERT INTO `personeller` VALUES ('11654984898','Selim','GÜNAY','Erkek','05144896633','ornek@example.com','Kabaoğlu, Baki Komsuoğlu bulvarı No:515, Umuttepe, 41001 İzmit/Kocaeli',6,20000),('12355645649','Özcan','ERDAĞ','Erkek','05465312851','ornek@example.com','Tatlıkuyu, 41400 Gebze/Kocaeli',5,25000),('13216549647','Mustafa','YILDIRIM','Erkek','05134688913','ornek@example.com','Karabaş, Ncity AVM İç Yolu, 41040 İzmit/Kocaeli',2,40000),('16321546454','Hakan','ÖKSÜZ','Erkek','05334658484','ornek@example.com',' Kaynarca, Neomarin AVM No:6, 34890 Pendik/İstanbul',6,20000),('16351564749','Hanife','ŞAHİN','Kadın','05369974315','ornek@example.com','Tatlıkuyu, 41400 Gebze/Kocaeli',7,17002),('16516541648','Gülçin','ATMACA','Kadın','05465161848','ornek@example.com','Kabaoğlu, Baki Komsuoğlu bulvarı No:515, Umuttepe, 41001 İzmit/Kocaeli',4,25000),('18486248957','Ali','ATILGAN','Erkek','05765812146','ornek@example.com','Kabaoğlu, Baki Komsuoğlu bulvarı No:515, Umuttepe, 41001 İzmit/Kocaeli',5,25000),('23123154164','Sülayman','ÇAKIR','Erkek','05548616368','ornek@example.com','Karabaş, Ncity AVM İç Yolu, 41040 İzmit/Kocaeli',7,17002),('23135416546','Hakan','TOPAL','Erkek','05314865264','ornek@example.com','Tatlıkuyu, 41400 Gebze/Kocaeli',1,60000),('23156496841','Gözde','ÜNAL','Kadın','05465128488','ornek@example.com','Tatlıkuyu, 41400 Gebze/Kocaeli',7,17002),('28421226949','Ayşe','KABATAŞ','Kadın','04826297497','ornek@example.com','Kabaoğlu, Baki Komsuoğlu bulvarı No:515, Umuttepe, 41001 İzmit/Kocaeli',7,17002),('32132165464','Ahmet','SUBAŞI','Erkek','05432199148','ornek@example.com','Kabaoğlu, Baki Komsuoğlu bulvarı No:515, Umuttepe, 41001 İzmit/Kocaeli',2,40000),('51654196488','Şeyma','TAŞCI','Kadın','05314899662','ornek@example.com','Karabaş, Ncity AVM İç Yolu, 41040 İzmit/Kocaeli',3,22000),('54165484546','Müjgan','YILDIZ','Kadın','05498732214','ornek@example.com',' Kaynarca, Neomarin AVM No:6, 34890 Pendik/İstanbul',7,17002),('54165489489','Sedat','PEKER','Erkek','05416542165','ornek@example.com','Tatlıkuyu, 41400 Gebze/Kocaeli',5,25000),('61564894898','Ahmet','AYDOĞAN','Erkek','05314643899','ornek@example.com','Karabaş, Ncity AVM İç Yolu, 41040 İzmit/Kocaeli',3,22000),('85498465849','İsmail','GEDİK','Erkek','05468123659','ornek@example.com','Karabaş, Ncity AVM İç Yolu, 41040 İzmit/Kocaeli',2,40000);
/*!40000 ALTER TABLE `personeller` ENABLE KEYS */;
UNLOCK TABLES;
ALTER DATABASE `avmyonetimiotomasyonu` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `Personeller_BEFORE_INSERT` BEFORE INSERT ON `personeller` FOR EACH ROW BEGIN
	DECLARE personel_sayisi INT;
    
    SELECT COUNT(*) INTO personel_sayisi
    FROM Personeller
    WHERE personel_TCNo = NEW.personel_TCNo;

    IF personel_sayisi > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Aynı personel kimlik numarasına sahip bir kayıt zaten var.';
    END IF;    
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `avmyonetimiotomasyonu` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci ;
ALTER DATABASE `avmyonetimiotomasyonu` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `Personeller_AFTER_INSERT` AFTER INSERT ON `personeller` FOR EACH ROW BEGIN
	IF NEW.cinsiyet = 'Erkek' THEN
		INSERT INTO MailKuyruklari (e_posta, baslik, mesaj) 
    	VALUES (NEW.e_posta, 'Hoş Geldiniz', CONCAT('Merhaba ', NEW.personelAdi, ' Bey, \nAramıza hoş geldiniz! \nİyi Çalışmalar.'));
    ELSEIF NEW.cinsiyet = 'Kadın' THEN
		INSERT INTO MailKuyruklari (e_posta, baslik, mesaj) 
    	VALUES (NEW.e_posta, 'Hoş Geldiniz', CONCAT('Merhaba ', NEW.personelAdi, ' Hanım, \nAramıza hoş geldiniz! \nİyi Çalışmalar.'));
	END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `avmyonetimiotomasyonu` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `Personeller_BEFORE_UPDATE` BEFORE UPDATE ON `personeller` FOR EACH ROW BEGIN
	DECLARE personel_sayisi INT;
    
    IF OLD.personel_TCNo != NEW.personel_TCNo THEN
		SELECT COUNT(*) INTO personel_sayisi
		FROM Personeller
		WHERE personel_TCNo = NEW.personel_TCNo;
	END IF;
    IF personel_sayisi > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Aynı personel kimlik numarasına sahip bir kayıt zaten var.';
    END IF;   
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Temporary view structure for view `personelyonetimi_verileri`
--

DROP TABLE IF EXISTS `personelyonetimi_verileri`;
/*!50001 DROP VIEW IF EXISTS `personelyonetimi_verileri`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `personelyonetimi_verileri` AS SELECT 
 1 AS `personel_TCNo`,
 1 AS `personelAdi`,
 1 AS `personelSoyadi`,
 1 AS `cinsiyet`,
 1 AS `telefon`,
 1 AS `e_posta`,
 1 AS `adres`,
 1 AS `pozisyon`,
 1 AS `maas`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `pozisyonlar`
--

DROP TABLE IF EXISTS `pozisyonlar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pozisyonlar` (
  `pozisyonID` int NOT NULL AUTO_INCREMENT,
  `pozisyonAdi` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`pozisyonID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pozisyonlar`
--

LOCK TABLES `pozisyonlar` WRITE;
/*!40000 ALTER TABLE `pozisyonlar` DISABLE KEYS */;
INSERT INTO `pozisyonlar` VALUES (1,'Yönetim Kurulu'),(2,'Müdür'),(3,'İnsan Kaynakları'),(4,'Muhasebe'),(5,'Teknisyen'),(6,'Güvenlik'),(7,'Temizlik');
/*!40000 ALTER TABLE `pozisyonlar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roller`
--

DROP TABLE IF EXISTS `roller`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roller` (
  `rolID` int NOT NULL AUTO_INCREMENT,
  `rolAdi` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`rolID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roller`
--

LOCK TABLES `roller` WRITE;
/*!40000 ALTER TABLE `roller` DISABLE KEYS */;
INSERT INTO `roller` VALUES (1,'Yönetici'),(2,'Standart');
/*!40000 ALTER TABLE `roller` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'avmyonetimiotomasyonu'
--

--
-- Dumping routines for database 'avmyonetimiotomasyonu'
--

--
-- Final view structure for view `guvenlikyonetimi_verileri`
--

/*!50001 DROP VIEW IF EXISTS `guvenlikyonetimi_verileri`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `guvenlikyonetimi_verileri` AS select `gk`.`kameraID` AS `kameraID`,`gk`.`kameraTipi` AS `kameraTipi`,`k`.`konumAdi` AS `konumAdi` from (`guvenlikkameralari` `gk` join `konumlar` `k` on((`gk`.`konum` = `k`.`konumID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `isletmeyonetimi_verileri`
--

/*!50001 DROP VIEW IF EXISTS `isletmeyonetimi_verileri`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `isletmeyonetimi_verileri` AS select `i`.`isletmeID` AS `isletmeID`,`i`.`isletmeAdi` AS `isletmeAdi`,`m`.`mekanTipi` AS `mekanTipi`,`i`.`isletmeTelefon` AS `isletmeTelefon`,`i`.`calisanSayisi` AS `calisanSayisi`,`k`.`konumAdi` AS `konumAdi` from ((`isletmeler` `i` join `mekanlar` `m` on((`i`.`mekan` = `m`.`mekanID`))) join `konumlar` `k` on((`i`.`konum` = `k`.`konumID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `kiragelirleri`
--

/*!50001 DROP VIEW IF EXISTS `kiragelirleri`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `kiragelirleri` AS select `i`.`isletmeID` AS `isletmeID`,`i`.`isletmeAdi` AS `isletmeAdi`,sum(`ki`.`kiraBedeli`) AS `kiraBedeli` from (`kiralananisletmeler` `ki` join `isletmeler` `i` on((`i`.`isletmeID` = `ki`.`isletme`))) group by `i`.`isletmeID` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `kirasozlesmeleri`
--

/*!50001 DROP VIEW IF EXISTS `kirasozlesmeleri`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `kirasozlesmeleri` AS select `ki`.`kiraID` AS `kiraID`,`i`.`isletmeAdi` AS `isletme`,`k`.`kiraciAdi` AS `kiraci`,`m`.`mekanTipi` AS `mekanTipi`,`ko`.`konumAdi` AS `konum`,`ki`.`kiralikAlan` AS `kiralikAlan`,`ki`.`kiraBedeli` AS `kiraBedeli`,date_format(`ki`.`kiraSozlesmesiBaslangicTarihi`,'%d-%m-%Y') AS `kiraSozlesmesiBaslangicTarihi`,date_format(`ki`.`kiraSozlesmesiBitisTarihi`,'%d-%m-%Y') AS `kiraSozlesmesiBitisTarihi` from ((((`kiralananisletmeler` `ki` join `isletmeler` `i` on((`i`.`isletmeID` = `ki`.`isletme`))) join `kiracilar` `k` on((`k`.`kiraciID` = `ki`.`kiraci`))) join `mekanlar` `m` on((`m`.`mekanID` = `ki`.`mekan`))) join `konumlar` `ko` on((`ko`.`konumID` = `ki`.`konum`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `kullaniciyonetimi_verileri`
--

/*!50001 DROP VIEW IF EXISTS `kullaniciyonetimi_verileri`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `kullaniciyonetimi_verileri` AS select `k`.`kullaniciID` AS `kullaniciID`,`k`.`adi` AS `adi`,`k`.`soyadi` AS `soyadi`,`k`.`e_posta` AS `e_posta`,`k`.`sifre` AS `sifre`,`r`.`rolAdi` AS `rolAdi` from (`kullanicilar` `k` join `roller` `r` on((`k`.`rol` = `r`.`rolID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `personelgiderleri`
--

/*!50001 DROP VIEW IF EXISTS `personelgiderleri`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `personelgiderleri` AS select `per`.`personel_TCNo` AS `personel_TCNo`,concat(`per`.`personelAdi`,' ',`per`.`personelSoyadi`) AS `Personel`,`po`.`pozisyonAdi` AS `pozisyon`,`per`.`maas` AS `maas` from (`personeller` `per` join `pozisyonlar` `po` on((`po`.`pozisyonID` = `per`.`pozisyon`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `personelyonetimi_verileri`
--

/*!50001 DROP VIEW IF EXISTS `personelyonetimi_verileri`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `personelyonetimi_verileri` AS select `p`.`personel_TCNo` AS `personel_TCNo`,`p`.`personelAdi` AS `personelAdi`,`p`.`personelSoyadi` AS `personelSoyadi`,`p`.`cinsiyet` AS `cinsiyet`,`p`.`telefon` AS `telefon`,`p`.`e_posta` AS `e_posta`,`p`.`adres` AS `adres`,`poz`.`pozisyonAdi` AS `pozisyon`,`p`.`maas` AS `maas` from (`personeller` `p` join `pozisyonlar` `poz` on((`p`.`pozisyon` = `poz`.`pozisyonID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-06 13:04:19
