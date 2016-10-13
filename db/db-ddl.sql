/*
SQLyog Community v10.0 
MySQL - 5.5.5-10.1.16-MariaDB : Database - phototrails
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`phototrails` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `phototrails`;

/*Table structure for table `trackpoint` */

DROP TABLE IF EXISTS `trackpoint`;

CREATE TABLE `trackpoint` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `trail` int(10) unsigned NOT NULL,
  `order` smallint(5) unsigned NOT NULL,
  `latitude` decimal(8,6) NOT NULL,
  `longitude` decimal(9,6) NOT NULL,
  `elevation` smallint(6) DEFAULT NULL,
  `date_time` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `unique_trail_trail_order` (`trail`,`order`),
  CONSTRAINT `fk_trackpoint_trail_trail` FOREIGN KEY (`trail`) REFERENCES `trail` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `trail` */

DROP TABLE IF EXISTS `trail`;

CREATE TABLE `trail` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(200) NOT NULL,
  `description` text,
  `duration` time DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
