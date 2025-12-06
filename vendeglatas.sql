-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Dec 06. 09:52
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `vendeglatas`
--
CREATE DATABASE IF NOT EXISTS `vendeglatas` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `vendeglatas`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `furdok`
--

CREATE TABLE `furdok` (
  `id` int(11) NOT NULL,
  `nev` varchar(30) DEFAULT NULL,
  `cim` varchar(40) DEFAULT NULL,
  `irnyitoszam` varchar(5) DEFAULT NULL,
  `regtime` datetime DEFAULT NULL,
  `varosid` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `varosok`
--

CREATE TABLE `varosok` (
  `id` int(11) NOT NULL,
  `nev` varchar(30) DEFAULT NULL,
  `tipus` varchar(20) DEFAULT NULL,
  `lakosokszama` int(11) DEFAULT NULL,
  `regtime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `furdok`
--
ALTER TABLE `furdok`
  ADD PRIMARY KEY (`id`),
  ADD KEY `varosid` (`varosid`);

--
-- A tábla indexei `varosok`
--
ALTER TABLE `varosok`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `furdok`
--
ALTER TABLE `furdok`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `varosok`
--
ALTER TABLE `varosok`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `furdok`
--
ALTER TABLE `furdok`
  ADD CONSTRAINT `furdok_ibfk_1` FOREIGN KEY (`varosid`) REFERENCES `varosok` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
