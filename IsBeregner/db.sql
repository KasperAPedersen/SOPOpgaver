-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Vært: 127.0.0.1
-- Genereringstid: 28. 02 2025 kl. 12:36:20
-- Serverversion: 10.4.32-MariaDB
-- PHP-version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `isberegner`
--

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `ingredients`
--

CREATE TABLE `ingredients` (
  `ingredientID` int(11) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `sugar` decimal(5,2) DEFAULT NULL,
  `fat` decimal(5,2) DEFAULT NULL,
  `femt` decimal(5,2) DEFAULT NULL,
  `drymatter` decimal(5,2) DEFAULT NULL,
  `total_drymatter` decimal(5,2) DEFAULT NULL,
  `water` decimal(5,2) DEFAULT NULL,
  `price_per_kilo` decimal(10,5) DEFAULT NULL,
  `price` decimal(10,5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Data dump for tabellen `ingredients`
--

INSERT INTO `ingredients` (`ingredientID`, `name`, `sugar`, `fat`, `femt`, `drymatter`, `total_drymatter`, `water`, `price_per_kilo`, `price`) VALUES
(1, 'Hvid Base', 18.15, 6.35, 9.79, 0.65, 34.94, 65.05, 12.87000, 0.01287),
(2, 'Fløde (38% fedt)', 0.00, 38.00, 5.60, 0.00, 43.60, 56.40, 28.90000, 0.02890),
(3, 'Mælk sød (3,5%)', 0.00, 3.50, 9.00, 0.00, 12.50, 87.50, 11.42000, 0.01142),
(4, 'Dextrose', 92.00, 0.00, 0.00, 0.00, 92.00, 8.00, 7.32000, 0.00732),
(5, 'Sukker', 100.00, 0.00, 0.00, 0.00, 100.00, 0.00, 4.16000, 0.00416),
(6, 'Tørret glucose', 96.00, 0.00, 0.00, 0.00, 96.00, 4.00, 10.93000, 0.01093),
(7, 'Skummetmælkspulver', 0.00, 1.00, 95.00, 0.00, 96.00, 4.00, 19.64000, 0.01964),
(8, 'Coldline stabilisator', 0.00, 0.00, 0.00, 100.00, 100.00, 0.00, 111.15000, 0.11115),
(9, 'Sukkerlage 70% - hj.lavet', 70.00, 0.00, 0.00, 0.00, 70.00, 30.00, 4.19000, 0.00419),
(10, 'Abrikospure Boiron', 15.50, 0.00, 0.00, 9.00, 18.00, 82.00, 60.13000, 0.06013),
(11, 'Amarena kirsebær i lage', 58.50, 0.00, 0.00, 10.50, 69.00, 31.00, 85.18000, 0.08518),
(12, 'Ananas', 12.00, 0.00, 0.00, 9.00, 21.00, 79.00, 24.50000, 0.02450),
(13, 'Ananas puré Boiron 100%', 12.00, 0.00, 0.00, 9.00, 21.00, 79.00, 83.42000, 0.08342),
(14, 'Appelsinjuice - færdigkøbt', 9.30, 0.10, 0.00, 0.20, 10.20, 89.80, 11.16000, 0.01116),
(15, 'Appelsinsaft friskpresset alm.', 8.00, 0.00, 0.00, 8.00, 16.00, 84.00, 33.66000, 0.03366),
(16, 'Appelsinsaft friskpresset øko', 8.00, 0.00, 0.00, 8.00, 16.00, 84.00, 84.58000, 0.08458),
(17, 'Appelsinskal øko hj.revet', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 885.00000, 0.88500),
(18, 'Baileys', 24.00, 14.00, 0.00, 0.00, 3.00, 59.00, 184.29000, 0.18429),
(19, 'Banan Frisk/frosne', 18.00, 0.00, 0.00, 5.00, 23.00, 77.00, 19.18000, 0.01918),
(20, 'Bananpuré Boiron', 18.00, 0.00, 0.00, 5.00, 23.00, 77.00, 64.35000, 0.06435),
(21, 'Basilikum - friske blade', 1.00, 1.00, 0.00, 7.00, 9.00, 91.00, 625.00000, 0.62500),
(22, 'Blodappelsin koncentrat - Boiron', 40.00, 0.30, 0.00, 1.00, 44.70, 55.30, 85.60000, 0.08560),
(23, 'Blodappelsinpuré - Boiron', 16.30, 0.00, 0.00, 3.00, 19.80, 80.20, 68.18000, 0.06818),
(24, 'Blåbær frosne', 10.00, 0.00, 0.00, 2.00, 12.00, 88.00, 26.95000, 0.02695),
(25, 'Blåbær puré Boiron', 10.00, 0.00, 0.00, 2.00, 12.00, 88.00, 105.49000, 0.10549),
(26, 'Brombær frosne', 6.00, 0.00, 0.00, 9.00, 15.00, 85.00, 14.17000, 0.01417),
(27, 'Brombær puré Boiron', 6.00, 0.00, 0.00, 9.00, 15.00, 85.00, 103.42000, 0.10342),
(28, 'Cacao 22-24%', 0.00, 23.00, 0.00, 72.00, 95.00, 5.00, 62.72000, 0.06272),
(29, 'Cacao Barry Ocoa 70%', 28.60, 38.00, 0.00, 32.60, 99.20, 0.80, 180.00000, 0.18000),
(30, 'Chili flager tørret', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 607.14000, 0.60714),
(31, 'Chili frisk', 0.00, 0.20, 0.00, 11.50, 11.70, 88.30, 169.34000, 0.16934),
(32, 'Citron puré Boiron', 16.50, 0.00, 0.00, 8.00, 24.50, 75.50, 69.78000, 0.06978),
(33, 'Citron Verbena blade', 2.44, 1.68, 0.00, 5.56, 9.68, 90.32, 2800.00000, 2.80000),
(34, 'Citronsaft friskpresset alm.', 5.00, 0.00, 0.00, 8.00, 13.00, 87.00, 86.10000, 0.08610),
(35, 'Citronsaft friskpresset øko', 5.00, 0.00, 0.00, 8.00, 13.00, 87.00, 189.16000, 0.18916),
(36, 'Citronsaft-Øko færdigkøbt-Lemon Plus', 1.70, 0.00, 0.00, 0.40, 6.90, 93.10, 56.56000, 0.05656),
(37, 'Citronskal øko hj.revet', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1525.00000, 1.52500),
(38, 'Double cream', 2.80, 48.00, 0.00, 1.70, 0.00, 47.50, 38.79000, 0.03879),
(39, 'Fersken', 9.00, 0.00, 0.00, 9.00, 18.00, 82.00, 24.00000, 0.02400),
(40, 'Fersken puré Boiron', 16.20, 0.00, 0.00, 9.00, 25.20, 74.80, 72.97000, 0.07297),
(41, 'Figner', 12.00, 0.00, 0.00, 8.00, 20.00, 80.00, 100.00000, 0.10000),
(42, 'Fløde (35% fedt)', 0.00, 35.00, 5.80, 0.00, 40.80, 59.20, 39.69000, 0.03969),
(43, 'Frugtpasta', 70.00, 0.00, 0.00, 8.00, 78.00, 12.00, 0.00000, 0.00000),
(44, 'Gelatine blade Tørsleffs 2g/blad', 0.00, 0.60, 0.00, 87.10, 87.70, 12.30, 324.16000, 0.32416),
(45, 'Glucose sirup 84%', 84.00, 0.00, 0.00, 0.00, 84.00, 16.00, 10.47000, 0.01047),
(46, 'Gold chokolade Callebaut', 50.50, 37.10, 12.00, 0.50, 99.60, 0.40, 109.59000, 0.10959),
(47, 'Grapefrugt frisk øko', 8.00, 0.00, 0.00, 6.00, 14.00, 86.00, 88.86000, 0.08886),
(48, 'Gulerodssaft Bio - Voelkel', 8.80, 0.10, 0.00, 0.60, 10.50, 89.50, 31.77000, 0.03177),
(49, 'Hasselnød pasta 100% PNP', 0.00, 65.00, 0.00, 35.00, 100.00, 0.00, 154.94000, 0.15494),
(50, 'Hasselnødder', 4.10, 64.00, 0.00, 15.10, 83.20, 16.80, 83.70000, 0.08370),
(51, 'Hindbær frosne', 7.00, 0.00, 0.00, 7.00, 14.00, 86.00, 17.33000, 0.01733),
(52, 'Hindbær puré 100% Boiron', 7.00, 0.00, 0.00, 7.00, 14.00, 86.00, 90.35000, 0.09035),
(53, 'Hindbær puré hj. Lavet af frost hindb.', 7.00, 0.00, 0.00, 7.00, 14.00, 86.00, 23.11000, 0.02311),
(54, 'Hindbær puré m. 15% inv.sukker Boiron', 19.40, 0.00, 0.00, 7.00, 26.40, 73.60, 85.90000, 0.08590),
(55, 'Honning', 80.00, 0.00, 0.00, 0.00, 80.00, 20.00, 105.34000, 0.10534),
(56, 'Hvid chokolade 28% W2 Callebaut', 46.50, 35.50, 17.50, 0.00, 99.50, 0.50, 90.50000, 0.09050),
(57, 'Hyldeblomst saft (DGF/Den gamle Fabrik)', 8.60, 0.00, 0.00, 0.00, 0.00, 0.00, 39.70000, 0.03970),
(58, 'Inulin', 7.00, 0.00, 0.00, 90.00, 97.00, 3.00, 147.50000, 0.14750),
(59, 'Invertsukker/trimoline', 82.00, 0.00, 0.00, 0.00, 82.00, 18.00, 26.68000, 0.02668),
(60, 'Jordbær frosne', 8.00, 0.00, 0.00, 7.00, 15.00, 85.00, 19.17000, 0.01917),
(61, 'Jordbær puré m. 15% inv.sukker Boiron', 18.10, 0.00, 0.00, 7.00, 25.10, 74.90, 85.00000, 0.08500),
(62, 'Jordnødder', 3.00, 53.00, 0.00, 42.00, 98.00, 2.00, 54.90000, 0.05490),
(63, 'Jordskokker', 4.13, 0.60, 0.00, 16.87, 21.60, 78.40, 18.40000, 0.01840),
(64, 'Kaffebønner – hele', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 62.68000, 0.06268),
(65, 'Kakaosmør', 0.00, 100.00, 0.00, 0.00, 100.00, 0.00, 151.26000, 0.15126),
(66, 'Kanel - stødt', 2.20, 1.20, 0.00, 53.00, 90.00, 10.00, 193.63000, 0.19363),
(67, 'Kardemomme kerner', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 850.20000, 0.85020),
(68, 'Kirsebær frosne', 10.00, 0.00, 0.00, 6.00, 16.00, 84.00, 19.56000, 0.01956),
(69, 'Kirsebær puré Boiron', 15.20, 0.00, 0.00, 4.50, 20.60, 79.40, 84.78000, 0.08478),
(70, 'Kiwi frisk', 7.00, 0.00, 0.00, 3.00, 10.00, 90.00, 33.34000, 0.03334),
(71, 'Kiwi puré Boiron', 11.50, 0.00, 0.00, 3.00, 14.50, 85.50, 55.35000, 0.05535),
(72, 'Kokosfedt', 0.00, 100.00, 0.00, 0.00, 100.00, 0.00, 40.29000, 0.04029),
(73, 'Kokosmel', 11.30, 65.70, 0.00, 12.60, 97.70, 2.30, 48.09000, 0.04809),
(74, 'Kokosmælk', 2.50, 18.20, 0.00, 2.20, 21.60, 88.40, 24.35000, 0.02435),
(75, 'KokospuréBoiron-kokos88%+invrt12%', 10.10, 22.00, 0.00, 2.70, 37.80, 62.20, 98.32000, 0.09832),
(76, 'Kondenseret mælk, sødet', 56.40, 8.00, 6.90, 0.00, 71.30, 28.70, 36.47000, 0.03647),
(77, 'Koriander - friske blade', 0.90, 0.50, 0.00, 2.80, 7.80, 92.20, 450.00000, 0.45000),
(78, 'Kærnemælk', 3.70, 0.50, 8.90, 0.00, 8.90, 90.60, 8.35000, 0.00835),
(79, 'Lakrids granulat', 14.00, 0.00, 0.00, 65.60, 79.60, 20.40, 319.63000, 0.31963),
(80, 'Lakridspulver', 27.30, 0.00, 0.00, 57.90, 85.20, 14.80, 164.07000, 0.16407),
(81, 'Langpeber', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 418.50000, 0.41850),
(82, 'Lavendel tørret', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 340.00000, 0.34000),
(83, 'Limesaft - friskpresset alm.', 4.00, 0.20, 0.00, 0.50, 11.70, 88.30, 69.64000, 0.06964),
(84, 'Limesaft - friskpresset øko', 4.00, 0.20, 0.00, 0.50, 11.70, 88.30, 133.93000, 0.13393),
(85, 'Maldon salt', 0.00, 0.00, 0.00, 100.00, 100.00, 0.00, 172.00000, 0.17200),
(86, 'Malibu', 29.00, 0.00, 0.00, 0.00, 29.00, 71.00, 205.00000, 0.20500),
(87, 'Maltodextrin', 7.00, 0.00, 0.00, 91.00, 98.00, 2.00, 53.87000, 0.05387),
(88, 'Mandarin puré Boiron', 10.00, 0.00, 0.00, 2.00, 12.00, 88.00, 65.76000, 0.06576),
(89, 'Mango puré Boiron', 13.90, 0.00, 0.00, 8.00, 21.90, 78.10, 82.56000, 0.08256),
(90, 'Marcipan Lemke', 37.00, 29.00, 0.00, 9.80, 75.80, 24.20, 69.01000, 0.06901),
(91, 'Mascarpone', 0.30, 42.00, 9.30, 0.00, 51.60, 48.40, 66.42000, 0.06642),
(92, 'Melon puré Boiron', 8.00, 0.00, 0.00, 5.00, 13.00, 87.00, 84.20000, 0.08420),
(93, 'Miroir gelé Puratos', 50.50, 0.00, 0.00, 7.50, 58.00, 42.00, 40.14000, 0.04014),
(94, 'Multebær', 7.00, 0.00, 0.00, 0.00, 14.00, 86.00, 350.00000, 0.35000),
(95, 'Mynte - friske blade', 8.40, 0.70, 0.00, 5.30, 14.40, 85.60, 660.00000, 0.66000),
(96, 'Mynte sirup', 78.00, 0.00, 0.00, 2.00, 80.00, 20.00, 83.88000, 0.08388),
(97, 'Mælk let (1,5% fedt)', 0.00, 1.50, 9.00, 0.00, 10.50, 89.50, 9.35000, 0.00935),
(98, 'Mælk skummet (0,1% fedt)', 0.00, 0.10, 9.00, 0.00, 9.10, 90.80, 8.66000, 0.00866),
(99, 'Mælkechokolade 823', 42.00, 36.25, 15.70, 0.00, 99.20, 0.80, 80.00000, 0.08000),
(100, 'Mørk Chokolade 57.7%', 43.00, 38.00, 0.00, 5.50, 86.50, 13.50, 86.85000, 0.08685),
(101, 'Mørk Chokolade 70 %', 26.50, 38.70, 0.00, 34.00, 99.20, 0.80, 90.30000, 0.09030),
(102, 'Mørk chokolade Alto el sol 65%', 32.00, 38.50, 0.00, 0.00, 100.00, 0.00, 134.29000, 0.13429),
(103, 'Nelliker stødt', 2.40, 20.10, 0.00, 64.80, 87.30, 12.70, 193.01000, 0.19301),
(104, 'Nescafe Gold', 0.00, 1.70, 0.00, 91.50, 93.20, 6.80, 595.00000, 0.59500),
(105, 'Nougat - blød - Callebaut', 47.00, 38.00, 12.00, 3.00, 99.60, 0.40, 126.33000, 0.12633),
(106, 'Olivenolie', 0.00, 100.00, 0.00, 100.00, 100.00, 0.00, 38.65000, 0.03865),
(107, 'Paranødder', 4.20, 67.10, 0.00, 14.30, 85.60, 14.40, 105.30000, 0.10530),
(108, 'Passions puré Boiron', 7.40, 0.00, 0.00, 6.40, 13.80, 86.20, 86.63000, 0.08663),
(109, 'Pekan nødder', 4.00, 72.00, 0.00, 10.00, 86.00, 14.00, 135.68000, 0.13568),
(110, 'Pekan puré 100%', 4.00, 72.00, 0.00, 10.00, 86.00, 14.00, 135.68000, 0.13568),
(111, 'Pektin', 40.00, 0.30, 0.00, 42.00, 82.20, 17.70, 290.50000, 0.29050),
(112, 'Pistacie nødder', 5.70, 48.30, 0.00, 29.00, 96.00, 4.00, 280.00000, 0.28000),
(113, 'Pistacie pasta 100%', 4.20, 60.90, 0.00, 26.30, 91.40, 8.60, 549.00000, 0.54900),
(114, 'Praliné Pra Class 50%', 49.00, 31.50, 0.00, 19.50, 100.00, 0.00, 108.10000, 0.10810),
(115, 'Pære puré Boiron', 17.60, 0.00, 0.00, 4.40, 22.00, 88.00, 53.76000, 0.05376),
(116, 'Rabarber frost', 3.00, 0.00, 0.00, 3.80, 9.50, 90.50, 12.26000, 0.01226),
(117, 'Rabarber puré Boiron', 3.00, 0.00, 0.00, 4.00, 7.00, 93.00, 78.59000, 0.07859),
(118, 'Rosenpeber/røde peberkorn', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 574.44000, 0.57444),
(119, 'Salmiak pulver', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 71.64000, 0.07164),
(120, 'Salt', 0.00, 0.00, 0.00, 99.40, 99.40, 0.60, 6.21000, 0.00621),
(121, 'Smør', 0.00, 84.00, 0.00, 0.00, 84.00, 16.00, 71.20000, 0.07120),
(122, 'Solbærpuré Boiron 12% invertsuk.', 16.00, 0.00, 0.00, 3.30, 19.80, 80.20, 68.87000, 0.06887),
(123, 'Solbærpuré hj.lavet u.skal 100%', 16.00, 0.00, 0.00, 0.00, 16.00, 79.00, 44.72000, 0.04472),
(124, 'Solsikkeolie', 0.00, 100.00, 0.00, 0.00, 0.00, 0.00, 19.20000, 0.01920),
(125, 'Sort peber', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 86.00000, 0.08600),
(126, 'Sort sesam', 0.30, 49.70, 0.00, 23.20, 90.90, 9.10, 53.80000, 0.05380),
(127, 'Stikkelsbær frost', 4.10, 0.00, 0.00, 8.20, 12.30, 87.70, 31.91000, 0.03191),
(128, 'Sødmælkspulver', 0.00, 26.00, 70.00, 0.00, 96.00, 4.00, 30.72000, 0.03072),
(129, 'Timian frisk', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 217.00000, 0.21700),
(130, 'Tomat', 4.00, 0.00, 0.00, 4.00, 8.00, 92.00, 23.50000, 0.02350),
(131, 'Tonkabønne', 29.00, 36.00, 0.00, 25.84, 90.84, 9.16, 932.70000, 0.93270),
(132, 'Tranebærsaft 100% biogan', 4.10, 0.00, 0.00, 2.60, 6.70, 93.30, 73.60000, 0.07360),
(133, 'Trehalose', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 55.00000, 0.05500),
(134, 'Trimoline', 82.00, 0.00, 0.00, 0.00, 82.00, 18.00, 28.08000, 0.02808),
(135, 'Valnød', 11.00, 64.00, 0.00, 0.00, 95.00, 5.00, 150.00000, 0.15000),
(136, 'Vand', 0.00, 0.00, 0.00, 0.00, 0.00, 100.00, 0.06000, 0.00006),
(137, 'Vandmelon', 6.00, 0.00, 0.00, 5.00, 11.00, 89.00, 84.20000, 0.08420),
(138, 'Vaniljestang', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 6000.00000, 6.00000),
(139, 'Vanillesukker Tørsleffs', 85.10, 0.00, 0.00, 8.10, 94.20, 0.00, 154.87000, 0.15487),
(140, 'Xantana', 0.00, 0.00, 0.00, 86.30, 86.30, 13.70, 377.87000, 0.37787),
(141, 'Yoghurt 3,5%', 0.00, 3.50, 9.50, 0.00, 13.00, 87.00, 16.05000, 0.01605),
(142, 'Yoghurt 10%, græsk insp.', 0.00, 10.00, 7.80, 0.00, 17.80, 82.20, 36.50000, 0.03650),
(143, 'Yuzu', 9.10, 0.00, 0.00, 0.00, 9.10, 90.90, 400.81000, 0.40081),
(144, 'Æble puré grøn Boiron', 17.40, 0.00, 0.00, 4.10, 21.50, 78.50, 54.08000, 0.05408),
(145, 'Æblejuice - færdigkøbt', 10.00, 0.10, 0.00, 0.00, 10.20, 89.80, 10.72000, 0.01072),
(146, 'Æblemost filteret', 10.00, 0.00, 0.00, 0.00, 10.00, 90.00, 13.19000, 0.01319),
(147, 'Æbler - Granny Smith', 10.60, 0.20, 0.00, 2.30, 13.10, 86.90, 15.38000, 0.01538),
(148, 'Æg, frisk', 0.00, 14.00, 0.00, 11.00, 25.00, 75.00, 36.00000, 0.03600),
(149, 'Æggeblomme', 0.00, 30.00, 0.00, 18.00, 48.00, 52.00, 27.00000, 0.02700),
(150, 'Æggehvider pasteuriserede', 0.90, 0.20, 0.00, 11.70, 12.80, 87.20, 27.64000, 0.02764),
(151, 'Kefir Arla Unika', 4.70, 4.00, 3.40, 0.00, 12.10, 87.90, 26.50000, 0.02650),
(152, 'Skyr, 0,2% - Thise', 3.50, 0.20, 11.00, 0.00, 14.70, 85.30, 32.29000, 0.03229),
(153, 'Creme fraiche 38%', 2.20, 38.00, 2.10, 0.00, 42.30, 57.70, 36.92000, 0.03692),
(154, 'Skovmærke', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 746.67000, 0.74667),
(155, 'Hvedegræs', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 583.25000, 0.58325),
(156, 'Hvedemel', 0.00, 1.50, 0.00, 0.00, 87.40, 12.60, 6.48000, 0.00648),
(157, 'Lys sirup', 78.00, 0.00, 0.00, 0.00, 78.00, 22.00, 26.60000, 0.02660),
(158, 'Natron', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 27.74000, 0.02774),
(159, 'Tørret kamille', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 172.59000, 0.17259),
(160, 'Rosmarin', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 248.50000, 0.24850),
(161, 'Fersken puré 10% sukker (Dira)', 16.00, 0.00, 0.00, 2.00, 18.00, 82.00, 102.00000, 0.10200),
(162, 'Fersken likør 16% (Peche)', 10.00, 0.00, 0.00, 0.00, 0.00, 90.00, 157.14000, 0.15714),
(163, 'Kantareller', 0.00, 1.30, 0.00, 9.60, 10.90, 89.10, 280.00000, 0.28000),
(164, 'Mandler', 3.80, 45.00, 0.00, 46.20, 95.00, 5.00, 87.00000, 0.08700),
(165, 'Limeskal øko, hjemmerevet', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 2433.00000, 2.43300),
(166, 'Nougat - sprøjteklar OM', 58.00, 29.00, 0.00, 13.00, 100.00, 0.00, 143.78000, 0.14378);

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `recipes`
--

CREATE TABLE `recipes` (
  `RecipeID` int(11) NOT NULL,
  `UserID` int(11) DEFAULT NULL,
  `Title` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Data dump for tabellen `recipes`
--

INSERT INTO `recipes` (`RecipeID`, `UserID`, `Title`) VALUES
(1, 4, 'Test oposkrift'),
(5, NULL, 'testy'),
(6, NULL, 'testy'),
(7, 4, 'test');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `recipe_ingredients`
--

CREATE TABLE `recipe_ingredients` (
  `recipeID` int(11) NOT NULL,
  `ingredientID` int(11) NOT NULL,
  `amount` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Data dump for tabellen `recipe_ingredients`
--

INSERT INTO `recipe_ingredients` (`recipeID`, `ingredientID`, `amount`) VALUES
(1, 5, 2.00),
(1, 10, 1.00),
(1, 11, 5.00),
(1, 12, 4.00),
(1, 47, 3.00),
(7, 11, 14.00);

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Data dump for tabellen `users`
--

INSERT INTO `users` (`id`, `username`, `password`) VALUES
(1, 'test', '$2y$10$lSZK1G0ILJn9Eg9jJc0tmetO4AYRh9UrCOCyWgL4ZrQCCE.pvq9YK'),
(2, 'test1', '$2y$10$U8q2CFhF8KxkAZJARrHUde5h0ZG22zeWddfCHd0R1mcIlbPgiusza'),
(3, 'test2', '$2y$10$eOlwZ0ASUcE1PfnNjD2JSevt6agUkVVEtZyNTVv/bo6dH/9hf4T.K'),
(4, 'test3', '$2y$10$.5ElmXrKU.VczGkLn5o0bupSVFNGnsTeFbGjqagykLhSGDHZZ3mVy');

--
-- Begrænsninger for dumpede tabeller
--

--
-- Indeks for tabel `ingredients`
--
ALTER TABLE `ingredients`
  ADD PRIMARY KEY (`ingredientID`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Indeks for tabel `recipes`
--
ALTER TABLE `recipes`
  ADD PRIMARY KEY (`RecipeID`),
  ADD KEY `UserID` (`UserID`);

--
-- Indeks for tabel `recipe_ingredients`
--
ALTER TABLE `recipe_ingredients`
  ADD PRIMARY KEY (`recipeID`,`ingredientID`),
  ADD KEY `ingredientID` (`ingredientID`);

--
-- Indeks for tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- Brug ikke AUTO_INCREMENT for slettede tabeller
--

--
-- Tilføj AUTO_INCREMENT i tabel `ingredients`
--
ALTER TABLE `ingredients`
  MODIFY `ingredientID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=167;

--
-- Tilføj AUTO_INCREMENT i tabel `recipes`
--
ALTER TABLE `recipes`
  MODIFY `RecipeID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Tilføj AUTO_INCREMENT i tabel `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Begrænsninger for dumpede tabeller
--

--
-- Begrænsninger for tabel `recipes`
--
ALTER TABLE `recipes`
  ADD CONSTRAINT `recipes_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `users` (`id`);

--
-- Begrænsninger for tabel `recipe_ingredients`
--
ALTER TABLE `recipe_ingredients`
  ADD CONSTRAINT `recipe_ingredients_ibfk_1` FOREIGN KEY (`recipeID`) REFERENCES `recipes` (`RecipeID`),
  ADD CONSTRAINT `recipe_ingredients_ibfk_2` FOREIGN KEY (`ingredientID`) REFERENCES `ingredients` (`ingredientID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
