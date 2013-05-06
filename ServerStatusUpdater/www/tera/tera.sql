-- phpMyAdmin SQL Dump
-- version 3.5.2.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: May 01, 2013 at 02:59 AM
-- Server version: 5.5.27
-- PHP Version: 5.4.7

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `tera`
--

-- --------------------------------------------------------

--
-- Table structure for table `servers`
--

CREATE TABLE IF NOT EXISTS `servers` (
  `id` int(11) NOT NULL,
  `title` varchar(50) NOT NULL,
  `small_text` text NOT NULL,
  `img` longtext NOT NULL,
  `ip` varchar(22) NOT NULL,
  `port` int(5) NOT NULL,
  `category` varchar(3) NOT NULL,
  `name` varchar(25) NOT NULL,
  `crowdness` text NOT NULL,
  `open` int(11) NOT NULL,
  `permission_mask` varchar(15) NOT NULL DEFAULT '0x00000000',
  `server_stat` varchar(15) NOT NULL DEFAULT '0x00000001',
  `language` varchar(2) NOT NULL DEFAULT 'en',
  `l_visible` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `role` varchar(10) NOT NULL DEFAULT 'user',
  `login` varchar(20) NOT NULL,
  `password` varchar(35) NOT NULL,
  `email` varchar(50) NOT NULL,
  `reg_date` varchar(32) NOT NULL,
  `name_user` varchar(32) NOT NULL,
  `lastname` varchar(32) NOT NULL,
  `birth` varchar(16) NOT NULL,
  `country` varchar(32) DEFAULT NULL,
  `city` varchar(32) DEFAULT NULL,
  `sex` varchar(255) DEFAULT NULL,
  `avatar` varchar(255) DEFAULT NULL,
  `icq` varchar(100) NOT NULL,
  `skype` varchar(100) NOT NULL,
  `vk_login` varchar(100) NOT NULL,
  `vk_url` varchar(100) NOT NULL,
  `money` float(64,0) DEFAULT '0',
  `visible` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=0 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
