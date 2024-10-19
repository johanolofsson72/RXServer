/*
SQLyog Enterprise - MySQL GUI v8.05 
MySQL - 5.5.9 : Database - RXServer4
*********************************************************************
*/


/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

CREATE DATABASE IF NOT EXISTS`rx4_crm` DEFAULT CHARACTER SET latin1;

use rx4_crm;

/*Table structure for table `adr_authorizeddocumentsroles` */

DROP TABLE IF EXISTS `adr_authorizeddocumentsroles`;

CREATE TABLE `adr_authorizeddocumentsroles` (
  `adr_id` int(11) NOT NULL AUTO_INCREMENT,
  `sta_id` int(11) NOT NULL DEFAULT '0',
  `lng_id` int(11) NOT NULL DEFAULT '0',
  `doc_id` int(11) NOT NULL DEFAULT '0',
  `rol_id` int(11) NOT NULL DEFAULT '0',
  `adr_revision` int(11) NOT NULL DEFAULT '0',
  `adr_createddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `adr_createdby` varchar(255) NOT NULL DEFAULT '',
  `adr_updateddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `adr_updatedby` varchar(255) NOT NULL DEFAULT '',
  `adr_hidden` int(1) NOT NULL DEFAULT '0',
  `adr_deleted` int(1) NOT NULL DEFAULT '0',
  `adr_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`adr_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `adr_authorizeddocumentsroles` */

/*Table structure for table `agg_aggregation` */

DROP TABLE IF EXISTS `agg_aggregation`;

CREATE TABLE `agg_aggregation` (
  `agg_id` int(11) NOT NULL AUTO_INCREMENT,
  `sta_id` int(11) NOT NULL DEFAULT '0',
  `sit_id` int(11) NOT NULL DEFAULT '0',
  `pag_id` int(11) NOT NULL DEFAULT '0',
  `mod_id` int(11) NOT NULL DEFAULT '0',
  `agg_revision` int(11) NOT NULL DEFAULT '0',
  `agg_createddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `agg_createdby` varchar(255) NOT NULL DEFAULT '',
  `agg_updateddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `agg_updatedby` varchar(255) NOT NULL DEFAULT '',
  `agg_hidden` int(1) NOT NULL DEFAULT '0',
  `agg_deleted` int(1) NOT NULL DEFAULT '0',
  `agg_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`agg_id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=latin1;

/*Data for the table `agg_aggregation` */

insert  into `agg_aggregation`(`agg_id`,`sta_id`,`sit_id`,`pag_id`,`mod_id`,`agg_revision`,`agg_createddate`,`agg_createdby`,`agg_updateddate`,`agg_updatedby`,`agg_hidden`,`agg_deleted`,`agg_ts`) values (11,1,1,3,16,0,'2009-02-03 14:28:08','mange','2009-02-03 14:28:08','mange',0,0,'2009-02-03 14:28:08'),(26,1,1,4,33,0,'2009-02-05 13:09:04','mange','2009-02-05 13:09:04','mange',0,0,'2009-02-05 13:09:04'),(27,1,1,2,34,0,'2009-02-05 16:13:44','mange','2009-02-05 16:13:44','mange',0,0,'2009-02-05 16:13:44');

/*Table structure for table `amr_authorizedmodulesroles` */

DROP TABLE IF EXISTS `amr_authorizedmodulesroles`;

CREATE TABLE `amr_authorizedmodulesroles` (
  `amr_id` int(11) NOT NULL AUTO_INCREMENT,
  `sta_id` int(11) NOT NULL DEFAULT '0',
  `lng_id` int(11) NOT NULL DEFAULT '0',
  `mod_id` int(11) NOT NULL DEFAULT '0',
  `rol_id` int(11) NOT NULL DEFAULT '0',
  `amr_revision` int(11) NOT NULL DEFAULT '0',
  `amr_createddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `amr_createdby` varchar(255) NOT NULL DEFAULT '',
  `amr_updateddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `amr_updatedby` varchar(255) NOT NULL DEFAULT '',
  `amr_hidden` int(1) NOT NULL DEFAULT '0',
  `amr_deleted` int(1) NOT NULL DEFAULT '0',
  `amr_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`amr_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `amr_authorizedmodulesroles` */

/*Table structure for table `apr_authorizedpagesroles` */

DROP TABLE IF EXISTS `apr_authorizedpagesroles`;

CREATE TABLE `apr_authorizedpagesroles` (
  `apr_id` int(11) NOT NULL AUTO_INCREMENT,
  `sta_id` int(11) NOT NULL DEFAULT '0',
  `lng_id` int(11) NOT NULL DEFAULT '0',
  `pag_id` int(11) NOT NULL DEFAULT '0',
  `rol_id` int(11) NOT NULL DEFAULT '0',
  `apr_revision` int(11) NOT NULL DEFAULT '0',
  `apr_createddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `apr_createdby` varchar(255) NOT NULL DEFAULT '',
  `apr_updateddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `apr_updatedby` varchar(255) NOT NULL DEFAULT '',
  `apr_hidden` int(1) NOT NULL DEFAULT '0',
  `apr_deleted` int(1) NOT NULL DEFAULT '0',
  `apr_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`apr_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `apr_authorizedpagesroles` */

/*Table structure for table `asr_authorizedsitesroles` */

DROP TABLE IF EXISTS `asr_authorizedsitesroles`;

CREATE TABLE `asr_authorizedsitesroles` (
  `asr_id` int(11) NOT NULL AUTO_INCREMENT,
  `sta_id` int(11) NOT NULL DEFAULT '0',
  `lng_id` int(11) NOT NULL DEFAULT '0',
  `sit_id` int(11) NOT NULL DEFAULT '0',
  `rol_id` int(11) NOT NULL DEFAULT '0',
  `asr_revision` int(11) NOT NULL DEFAULT '0',
  `asr_createddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `asr_createdby` varchar(255) NOT NULL DEFAULT '',
  `asr_updateddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `asr_updatedby` varchar(255) NOT NULL DEFAULT '',
  `asr_hidden` int(1) NOT NULL DEFAULT '0',
  `asr_deleted` int(1) NOT NULL DEFAULT '0',
  `asr_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`asr_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `asr_authorizedsitesroles` */

insert  into `asr_authorizedsitesroles`(`asr_id`,`sta_id`,`lng_id`,`sit_id`,`rol_id`,`asr_revision`,`asr_createddate`,`asr_createdby`,`asr_updateddate`,`asr_updatedby`,`asr_hidden`,`asr_deleted`,`asr_ts`) values (1,1,1,1,1,0,'2009-01-01 01:01:01','System','2009-01-01 01:01:01','System',0,0,'2008-12-22 10:06:20');

/*Table structure for table `atr_authorizedtasksroles` */

DROP TABLE IF EXISTS `atr_authorizedtasksroles`;

CREATE TABLE `atr_authorizedtasksroles` (
  `atr_id` int(11) NOT NULL AUTO_INCREMENT,
  `sta_id` int(11) NOT NULL DEFAULT '0',
  `tas_id` int(11) NOT NULL DEFAULT '0',
  `rol_id` int(11) NOT NULL DEFAULT '0',
  `atr_createddate` datetime NOT NULL DEFAULT '2006-01-01 01:01:01',
  `atr_createdby` varchar(255) NOT NULL DEFAULT '',
  `atr_updateddate` datetime NOT NULL DEFAULT '2006-01-01 01:01:01',
  `atr_updatedby` varchar(255) NOT NULL DEFAULT '',
  `atr_hidden` int(1) NOT NULL DEFAULT '0',
  `atr_deleted` int(1) NOT NULL DEFAULT '0',
  `atr_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`atr_id`),
  KEY `atr_1` (`atr_id`,`sta_id`,`tas_id`,`rol_id`,`atr_hidden`,`atr_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `atr_authorizedtasksroles` */

/*Table structure for table `doc_documents` */

DROP TABLE IF EXISTS `doc_documents`;

CREATE TABLE `doc_documents` (
  `doc_id` int(11) NOT NULL AUTO_INCREMENT,
  `sta_id` int(11) NOT NULL DEFAULT '0',
  `lng_id` int(11) NOT NULL DEFAULT '0',
  `sit_id` int(11) NOT NULL DEFAULT '0',
  `pag_id` int(11) NOT NULL DEFAULT '0',
  `mod_id` int(11) NOT NULL DEFAULT '0',
  `doc_parentid` int(11) NOT NULL DEFAULT '0',
  `doc_order` int(11) NOT NULL DEFAULT '0',
  `doc_type` int(11) NOT NULL DEFAULT '0',
  `doc_revision` int(11) NOT NULL DEFAULT '0',
  `doc_title` varchar(255) NOT NULL DEFAULT '',
  `doc_alias` varchar(255) NOT NULL DEFAULT '',
  `doc_description` longtext NOT NULL,
  `doc_contenttype` varchar(255) NOT NULL DEFAULT '',
  `doc_contentsize` int(11) NOT NULL DEFAULT '0',
  `doc_version` int(11) NOT NULL DEFAULT '0',
  `doc_charset` varchar(255) NOT NULL DEFAULT '',
  `doc_extension` varchar(10) NOT NULL DEFAULT '',
  `doc_path` varchar(255) NOT NULL DEFAULT '',
  `doc_checkoutusrid` int(11) NOT NULL DEFAULT '0',
  `doc_checkoutdate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `doc_checkoutexpiredate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `doc_lastvieweddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `doc_lastviewedby` varchar(255) NOT NULL DEFAULT '',
  `doc_isdirty` int(1) NOT NULL DEFAULT '0',
  `doc_isdelivered` int(1) NOT NULL DEFAULT '0',
  `doc_issigned` int(1) NOT NULL DEFAULT '0',
  `doc_iscertified` int(1) NOT NULL DEFAULT '0',
  `doc_deliverdate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `doc_deliverby` varchar(255) NOT NULL DEFAULT '',
  `doc_deliverto` varchar(255) NOT NULL DEFAULT '',
  `doc_createddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `doc_createdby` varchar(255) NOT NULL DEFAULT '',
  `doc_updateddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `doc_updatedby` varchar(255) NOT NULL DEFAULT '',
  `doc_hidden` int(1) NOT NULL DEFAULT '0',
  `doc_deleted` int(1) NOT NULL DEFAULT '0',
  `doc_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`doc_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `doc_documents` */

/*Table structure for table `lng_language` */

DROP TABLE IF EXISTS `lng_language`;

CREATE TABLE `lng_language` (
  `lng_id` int(11) NOT NULL AUTO_INCREMENT,
  `lng_parentid` int(11) NOT NULL DEFAULT '0',
  `lng_order` int(11) NOT NULL DEFAULT '0',
  `lng_revision` int(11) NOT NULL DEFAULT '0',
  `lng_title` varchar(255) NOT NULL DEFAULT '',
  `lng_alias` varchar(255) NOT NULL DEFAULT '',
  `lng_description` longtext NOT NULL,
  `lng_createddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `lng_createdby` varchar(255) NOT NULL DEFAULT '',
  `lng_updateddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `lng_updatedby` varchar(255) NOT NULL DEFAULT '',
  `lng_hidden` int(1) NOT NULL DEFAULT '0',
  `lng_deleted` int(1) NOT NULL DEFAULT '0',
  `lng_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`lng_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `lng_language` */

insert  into `lng_language`(`lng_id`,`lng_parentid`,`lng_order`,`lng_revision`,`lng_title`,`lng_alias`,`lng_description`,`lng_createddate`,`lng_createdby`,`lng_updateddate`,`lng_updatedby`,`lng_hidden`,`lng_deleted`,`lng_ts`) values (1,0,1,0,'Svenska','sv-SE','','2009-01-01 01:01:01','AutoScript','2009-01-01 01:01:01','AutoScript',0,0,'2008-12-22 10:07:29');

/*Table structure for table `mde_moduledefinitions` */

DROP TABLE IF EXISTS `mde_moduledefinitions`;

CREATE TABLE `mde_moduledefinitions` (
  `mde_id` int(11) NOT NULL AUTO_INCREMENT,
  `sta_id` int(11) NOT NULL DEFAULT '0',
  `sit_id` int(11) NOT NULL DEFAULT '0',
  `lng_id` int(11) NOT NULL DEFAULT '0',
  `mde_parentid` int(11) NOT NULL DEFAULT '0',
  `mde_order` int(11) NOT NULL DEFAULT '0',
  `mde_revision` int(11) NOT NULL DEFAULT '0',
  `mde_title` varchar(255) NOT NULL DEFAULT '',
  `mde_alias` varchar(255) NOT NULL DEFAULT '',
  `mde_description` longtext NOT NULL,
  `mde_src` varchar(255) NOT NULL DEFAULT '',
  `mde_createddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `mde_createdby` varchar(255) NOT NULL DEFAULT '',
  `mde_updateddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `mde_updatedby` varchar(255) NOT NULL DEFAULT '',
  `mde_hidden` int(1) NOT NULL DEFAULT '0',
  `mde_deleted` int(1) NOT NULL DEFAULT '0',
  `mde_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`mde_id`)
) ENGINE=InnoDB AUTO_INCREMENT=103 DEFAULT CHARSET=latin1;

/*Data for the table `mde_moduledefinitions` */

insert  into `mde_moduledefinitions`(`mde_id`,`sta_id`,`sit_id`,`lng_id`,`mde_parentid`,`mde_order`,`mde_revision`,`mde_title`,`mde_alias`,`mde_description`,`mde_src`,`mde_createddate`,`mde_createdby`,`mde_updateddate`,`mde_updatedby`,`mde_hidden`,`mde_deleted`,`mde_ts`) values (19,1,1,1,0,5,0,'Modules/Footer/Footer','Footer','Modules/Footer/Footer','Modules/Footer/Footer/Footer.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:23:25'),(26,1,1,1,0,5,0,'Modules/Menus/SubMenu','SubMenu','Modules/Menus/SubMenu','Modules/Menus/SubMenu/SubMenu.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:23:26'),(31,1,1,1,0,5,0,'Modules/Boxes/Calendar','Calendar','Modules/Boxes/Calendar','Modules/Boxes/Calendar/Calendar.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:23:26'),(32,1,1,1,0,5,0,'Modules/Boxes/News','News','Modules/Boxes/News','Modules/Boxes/News/News.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:23:26'),(33,1,1,1,0,5,0,'Modules/UserView/UVCalendar','UserView Calendar','Modules/UserView/UVCalendar','Modules/UserView/UVCalendar/UVCalendar.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:23:26'),(34,1,1,1,0,5,0,'Modules/Menus/TopMenu','TopMenu','Modules/Menus/TopMenu','Modules/Menus/TopMenu/TopMenu.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:23:27'),(41,1,1,1,0,2,0,'Modules/_System/AdminHeader','AdminHeader','Modules/_System/AdminHeader','Modules/_System/AdminHeader/AdminHeader.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:23:27'),(44,1,1,1,0,1,0,'Modules/_System/PageTemplate','PageTemplate','Modules/_System/PageTemplate','Modules/_System/PageTemplate/PageTemplate.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:23:27'),(49,1,1,1,0,5,0,'Modules/User/RegisterUser','RegisterUser','Modules/User/RegisterUser','Modules/User/RegisterUser/RegisterUser.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:23:55'),(56,1,1,1,0,1,0,'Modules/Modules/EditModules','EditModules 1','Modules/Modules/EditModules','Modules/Modules/EditModules/EditModules_1.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:24:18'),(57,1,1,1,0,1,0,'Modules/Modules/EditModules','EditModules 2','Modules/Modules/EditModules','Modules/Modules/EditModules/EditModules_2.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:24:24'),(58,1,1,1,0,5,0,'Modules/Boxes/LiteBox','LiteBox','Modules/Boxes/LiteBox','Modules/Boxes/LiteBox/LiteBox.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:24:35'),(61,1,1,1,0,5,0,'Modules/User/UserInfo','UserInfo','Modules/User/UserInfo','Modules/User/UserInfo/UserInfo.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:25:58'),(62,1,1,1,0,1,0,'Modules/Modules/EditLargeModules','EditLargeModules','Modules/Modules/EditLargeModules','Modules/Modules/EditLargeModules/EditLargeModules_1.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:26:11'),(63,1,1,1,0,1,0,'Modules/User/LoginUser','LoginUser','Modules/User/LoginUser','Modules/User/LoginUser/LoginUser.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:26:24'),(64,1,1,1,0,1,0,'Modules/User/LostUserInfo','LostUserInfo','Modules/User/LostUserInfo','Modules/User/LostUserInfo/LostUserInfo.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:26:37'),(65,1,1,1,0,5,0,'Modules/Boxes/LiteBox2','LiteBox2','Modules/Boxes/LiteBox2','Modules/Boxes/LiteBox2/LiteBox2.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:26:49'),(66,1,1,1,0,5,0,'Modules/Boxes/RSSBox','RSSBox','Modules/Boxes/RSSBox','Modules/Boxes/RSSBox/RSSBox.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:26:59'),(68,1,1,1,0,5,0,'Modules/Boxes/RSSBox','RSSBox','Modules/Boxes/RSSBox','Modules/Boxes/RSSBox/RSSBox_small.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:27:30'),(71,1,1,1,0,5,0,'Modules/Boxes/TextBox','TextBox','Modules/Boxes/TextBox','Modules/Boxes/TextBox/TextBox.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:28:11'),(73,1,1,1,0,5,0,'Modules/Boxes/Operators','Operators','Modules/Boxes/Operators','Modules/Boxes/Operators/Operators.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:28:39'),(74,1,1,1,0,5,0,'Modules/UserView/UVRSS','UserView RSS','Modules/UserView/UVRSS','Modules/UserView/UVRSS/UVRSS.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:28:50'),(75,1,1,1,0,5,0,'Modules/UserModules/UserRSS','UserRSS','Modules/UserModules/UserRSS','Modules/UserModules/UserRSS/UserRSS.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:29:03'),(76,1,1,1,0,5,0,'Modules/Boxes/WelcomeBox','WelcomeBox','Modules/Boxes/WelcomeBox','Modules/Boxes/WelcomeBox/WelcomeBox.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:29:15'),(77,1,1,1,0,5,0,'Modules/Search/Search','Search','Modules/Search/Search','Modules/Search/Search/Search.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2009-02-05 16:15:39'),(78,1,1,1,0,5,0,'Modules/Boxes/Forum','Forum','Modules/Boxes/Forum','Modules/Boxes/Forum/Forum.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:29:35'),(79,1,1,1,0,5,0,'Modules/Images/TopImage','TopImage','Modules/Images/TopImage','Modules/Images/TopImage/TopImage.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2008-12-22 10:29:52'),(83,1,1,1,0,5,0,'Modules/Menus/ExtraMenu','ExtraMenu','Modules/Menus/ExtraMenu','Modules/Menus/ExtraMenu/ExtraMenu.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2009-01-07 14:29:58'),(87,1,1,1,0,6,0,'Modules/Links/TagCloud','TagCloud','Modules/Links/TagCloud','Modules/Links/TagCloud/TagCloud.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2009-01-19 11:25:45'),(89,1,1,1,0,5,0,'Modules/Boxes/MediaBox','MediaBox','Modules/Boxes/MediaBox','Modules/Boxes/MediaBox/MediaBox.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2009-01-30 11:06:51'),(90,1,1,1,0,5,0,'Modules/Boxes/GalleryBox','GalleryBox','Modules/Boxes/GalleryBox','Modules/Boxes/GalleryBox/GalleryBox.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2009-02-02 10:41:07'),(91,1,1,1,0,5,0,'Modules/Boxes/GalleryBox2','GalleryBox2','Modules/Boxes/GalleryBox2','Modules/Boxes/GalleryBox2/GalleryBox2.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2009-02-02 10:41:02'),(92,1,1,1,0,5,0,'Modules/Exit/Exit','Exit','Modules/Exit/Exit','Modules/Exit/Exit/Exit.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2009-02-03 14:11:05'),(93,1,1,1,0,5,0,'Modules/Menus/SubMenu2','Submenu 2','Modules/Menus/SubMenu2','Modules/Menus/SubMenu2/SubMenu2.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2009-02-03 15:28:30'),(94,1,1,1,0,5,0,'Modules/Boxes/TabTextBox','TabText','Modules/Boxes/TabTextBox','Modules/Boxes/TabTextBox/TabTextBox.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2009-02-04 09:57:45'),(95,1,1,1,0,5,0,'Modules/Boxes/StartBox','StartBox','Modules/Boxes/StartBox','Modules/Boxes/StartBox/StartBox.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2009-02-04 12:42:05'),(96,1,1,1,0,5,0,'Modules/Boxes/TeaserBox','TeaserBox','Modules/Boxes/TeaserBox','Modules/Boxes/TeaserBox/TeaserBox.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2009-02-04 15:54:47'),(97,1,1,1,0,5,0,'Modules/Newsletter/Register/','Newsletter Register','Modules/Newsletter/Register/','Modules/Newsletter/Register/Register.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2009-02-05 10:15:20'),(98,1,1,1,0,5,0,'Modules/Newsletter/Unregister/','Newsletter Unregister','Modules/Newsletter/Unregister/','Modules/Newsletter/Unregister/Unregister.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2009-02-05 13:00:42'),(99,1,1,1,0,5,0,'Modules/Boxes/ContactBox','ContactBox','Modules/Boxes/ContactBox','Modules/Boxes/ContactBox/ContactBox.ascx','2009-01-01 01:01:01','nc_mali','2009-01-01 01:01:01','nc_mali',0,0,'2009-02-09 10:28:57'),(100,1,1,1,0,5,0,'Modules/Boxes/ProductBrowser','ProductBrowser','Modules/Boxes/ProductBrowser','Modules/Boxes/ProductBrowser/ProductBrowser.ascx','2009-01-01 01:01:01','nc_bjan','2009-01-01 01:01:01','nc_bjan',0,0,'2009-05-18 16:21:43'),(101,1,1,1,0,5,0,'Modules/Boxes/HtmlBox','HtmlBox','Modules/Boxes/HtmlBox','Modules/Boxes/HtmlBox/HtmlBox.ascx','2009-01-01 01:01:01','nc_daol','2009-01-01 01:01:01','nc_daol',0,0,'2010-05-26 10:01:05'),(102,1,1,1,0,5,0,'Modules/Boxes/DocumentBox','DocumentBox','Modules/Boxes/DocumentBox','Modules/Boxes/DocumentBox/DocumentBox.ascx','2009-01-01 01:01:01','nc_daol','2009-01-01 01:01:01','nc_daol',0,0,'2010-05-26 13:24:07');

/*Table structure for table `mdi_modelitems` */

DROP TABLE IF EXISTS `mdi_modelitems`;

CREATE TABLE `mdi_modelitems` (
  `mdi_id` int(11) NOT NULL AUTO_INCREMENT,
  `sta_id` int(11) NOT NULL DEFAULT '0',
  `sit_id` int(11) NOT NULL DEFAULT '0',
  `lng_id` int(11) NOT NULL DEFAULT '0',
  `mdl_id` int(11) NOT NULL DEFAULT '0',
  `mde_id` int(11) NOT NULL DEFAULT '0',
  `mdi_parentid` int(11) NOT NULL DEFAULT '0',
  `mdi_order` int(11) NOT NULL DEFAULT '0',
  `mdi_revision` int(11) NOT NULL DEFAULT '0',
  `mdi_contentpane` varchar(50) NOT NULL DEFAULT '',
  `mdi_createddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `mdi_createdby` varchar(255) NOT NULL DEFAULT '',
  `mdi_updateddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `mdi_updatedby` varchar(255) NOT NULL DEFAULT '',
  `mdi_hidden` int(1) NOT NULL DEFAULT '0',
  `mdi_deleted` int(1) NOT NULL DEFAULT '0',
  `mdi_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`mdi_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mdi_modelitems` */

/*Table structure for table `mdl_model` */

DROP TABLE IF EXISTS `mdl_model`;

CREATE TABLE `mdl_model` (
  `mdl_id` int(11) NOT NULL AUTO_INCREMENT,
  `sta_id` int(11) NOT NULL DEFAULT '0',
  `sit_id` int(11) NOT NULL DEFAULT '0',
  `lng_id` int(11) NOT NULL DEFAULT '0',
  `mdl_parentid` int(11) NOT NULL DEFAULT '0',
  `mdl_order` int(11) NOT NULL DEFAULT '0',
  `mdl_revision` int(11) NOT NULL DEFAULT '0',
  `mdl_title` varchar(255) NOT NULL DEFAULT '',
  `mdl_alias` varchar(255) NOT NULL DEFAULT '',
  `mdl_description` longtext NOT NULL,
  `mdl_createddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `mdl_createdby` varchar(255) NOT NULL DEFAULT '',
  `mdl_updateddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `mdl_updatedby` varchar(255) NOT NULL DEFAULT '',
  `mdl_hidden` int(1) NOT NULL DEFAULT '0',
  `mdl_deleted` int(1) NOT NULL DEFAULT '0',
  `mdl_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`mdl_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `mdl_model` */

insert  into `mdl_model`(`mdl_id`,`sta_id`,`sit_id`,`lng_id`,`mdl_parentid`,`mdl_order`,`mdl_revision`,`mdl_title`,`mdl_alias`,`mdl_description`,`mdl_createddate`,`mdl_createdby`,`mdl_updateddate`,`mdl_updatedby`,`mdl_hidden`,`mdl_deleted`,`mdl_ts`) values (1,1,1,1,0,1,0,'Model 1','Empty','','2009-01-01 01:01:01','','2009-01-01 01:01:01','',0,0,'2009-02-03 21:15:44');

/*Table structure for table `mod_modules` */

DROP TABLE IF EXISTS `mod_modules`;

CREATE TABLE `mod_modules` (
  `mod_id` int(11) NOT NULL AUTO_INCREMENT,
  `sta_id` int(11) NOT NULL DEFAULT '0',
  `sit_id` int(11) NOT NULL DEFAULT '0',
  `pag_id` int(11) NOT NULL DEFAULT '0',
  `mde_id` int(11) NOT NULL DEFAULT '0',
  `lng_id` int(11) NOT NULL DEFAULT '0',
  `mod_parentid` int(11) NOT NULL DEFAULT '0',
  `mod_order` int(11) NOT NULL DEFAULT '0',
  `mod_revision` int(11) NOT NULL DEFAULT '0',
  `mod_title` varchar(255) NOT NULL DEFAULT '',
  `mod_alias` varchar(255) NOT NULL DEFAULT '',
  `mod_description` longtext NOT NULL,
  `mod_src` varchar(255) NOT NULL DEFAULT '',
  `mod_allpages` int(1) NOT NULL DEFAULT '0',
  `mod_ssl` int(1) NOT NULL DEFAULT '0',
  `mod_contentpane` varchar(255) NOT NULL DEFAULT '',
  `mod_cachetime` int(11) NOT NULL DEFAULT '0',
  `mod_createddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `mod_createdby` varchar(255) NOT NULL DEFAULT '',
  `mod_updateddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `mod_updatedby` varchar(255) NOT NULL DEFAULT '',
  `mod_hidden` int(1) NOT NULL DEFAULT '0',
  `mod_deleted` int(1) NOT NULL DEFAULT '0',
  `mod_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`mod_id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `mod_modules` */

insert  into `mod_modules`(`mod_id`,`sta_id`,`sit_id`,`pag_id`,`mde_id`,`lng_id`,`mod_parentid`,`mod_order`,`mod_revision`,`mod_title`,`mod_alias`,`mod_description`,`mod_src`,`mod_allpages`,`mod_ssl`,`mod_contentpane`,`mod_cachetime`,`mod_createddate`,`mod_createdby`,`mod_updateddate`,`mod_updatedby`,`mod_hidden`,`mod_deleted`,`mod_ts`) values (1,1,1,1,44,1,0,15,0,'Modules/_System/PageTemplate','','','Modules/_System/PageTemplate/PageTemplate.ascx',1,0,'SystemContentPane0',20,'2009-01-01 01:01:01','','2009-01-01 01:01:01','',0,0,'2010-05-25 11:37:27'),(2,1,1,1,41,1,0,17,0,'Modules/_System/AdminHeader','','','Modules/_System/AdminHeader/AdminHeader.ascx',1,0,'SystemContentPane1',20,'2009-01-01 01:01:01','','2009-01-01 01:01:01','',0,0,'2010-05-25 11:37:27'),(3,1,1,1,26,1,0,13,0,'Modules/Menus/SubMenu','','','Modules/Menus/SubMenu/SubMenu.ascx',1,0,'SiteContentPane4',0,'2009-01-01 01:01:01','','2009-01-01 01:01:01','',0,0,'2010-05-25 11:37:27'),(4,1,1,1,34,1,0,9,0,'Modules/Menus/TopMenu','','','Modules/Menus/TopMenu/TopMenu.ascx',1,0,'SiteContentPane2',0,'2009-01-01 01:01:01','','2009-01-01 01:01:01','',0,0,'2010-05-25 11:37:27'),(5,1,1,1,56,1,0,3,0,'Modules/Modules/EditModules_1','','','Modules/Modules/EditModules/EditModules_1.ascx',1,0,'ContentPane1A',20,'2009-01-01 01:01:01','','2009-01-01 01:01:01','',0,0,'2010-05-25 11:37:26'),(6,1,1,1,57,1,0,5,0,'Modules/Modules/EditModules_2','','','Modules/Modules/EditModules/EditModules_2.ascx',1,0,'ContentPane2A',20,'2009-01-01 01:01:01','','2009-01-01 01:01:01','',0,0,'2010-05-25 11:37:26'),(7,1,1,1,19,1,0,11,0,'Modules/Footer/Footer','','','Modules/Footer/Footer/Footer.ascx',1,0,'SiteContentPane3',20,'2009-01-01 01:01:01','','2009-01-01 01:01:01','',0,0,'2010-05-25 11:37:27'),(16,1,1,3,92,1,0,21,0,'Modules/Exit/Exit_Instance','Exit_Instance','Modules/Exit/Exit_Instance','Modules/Exit/Exit/Exit.ascx',0,0,'ContentPane1',20,'2009-02-03 14:28:08','mange','2009-02-03 14:28:08','mange',0,0,'2010-05-25 11:37:27'),(17,1,1,1,93,1,0,7,0,'Modules/Menus/SubMenu2','','Modules/Menus/SubMenu2','Modules/Menus/SubMenu2/SubMenu2.ascx',1,0,'ContentPane3',0,'2009-01-01 01:01:01','','2009-01-01 01:01:01','',0,0,'2010-05-25 11:37:26'),(33,1,1,4,98,1,0,23,0,'Modules/Newsletter/Unregister/_Instance','Newsletter Unregister_Instance','Modules/Newsletter/Unregister/_Instance','Modules/Newsletter/Unregister/Unregister.ascx',0,0,'ContentPane1',20,'2009-02-05 13:09:04','mange','2009-02-05 13:09:04','mange',0,0,'2010-05-25 11:37:27'),(34,1,1,2,77,1,0,19,0,'Modules/Search/Search_Instance','Search_Instance','Modules/Boxes/Search_Instance','Modules/Search/Search/Search.ascx',0,0,'ContentPane1',0,'2009-02-05 16:13:44','mange','2009-02-05 16:13:44','mange',0,0,'2010-05-25 11:37:27');

/*Table structure for table `obd_objectdata` */

DROP TABLE IF EXISTS `obd_objectdata`;

CREATE TABLE `obd_objectdata` (
  `obd_id` int(11) NOT NULL AUTO_INCREMENT,
  `sta_id` int(11) NOT NULL DEFAULT '0',
  `lng_id` int(11) NOT NULL DEFAULT '0',
  `sit_id` int(11) NOT NULL DEFAULT '0',
  `pag_id` int(11) NOT NULL DEFAULT '0',
  `mod_id` int(11) NOT NULL DEFAULT '0',
  `obd_parentid` int(11) NOT NULL DEFAULT '0',
  `obd_order` int(11) NOT NULL DEFAULT '0',
  `obd_type` int(11) NOT NULL DEFAULT '0',
  `obd_revision` int(11) NOT NULL DEFAULT '0',
  `obd_title` varchar(255) NOT NULL DEFAULT '',
  `obd_alias` varchar(255) NOT NULL DEFAULT '',
  `obd_description` longtext NOT NULL,
  `obd_varchar1` longtext NOT NULL,
  `obd_varchar2` longtext NOT NULL,
  `obd_varchar3` longtext NOT NULL,
  `obd_varchar4` longtext NOT NULL,
  `obd_varchar5` longtext NOT NULL,
  `obd_varchar6` longtext NOT NULL,
  `obd_varchar7` longtext NOT NULL,
  `obd_varchar8` longtext NOT NULL,
  `obd_varchar9` longtext NOT NULL,
  `obd_varchar10` longtext NOT NULL,
  `obd_varchar11` longtext NOT NULL,
  `obd_varchar12` longtext NOT NULL,
  `obd_varchar13` longtext NOT NULL,
  `obd_varchar14` longtext NOT NULL,
  `obd_varchar15` longtext NOT NULL,
  `obd_varchar16` longtext NOT NULL,
  `obd_varchar17` longtext NOT NULL,
  `obd_varchar18` longtext NOT NULL,
  `obd_varchar19` longtext NOT NULL,
  `obd_varchar20` longtext NOT NULL,
  `obd_varchar21` longtext NOT NULL,
  `obd_varchar22` longtext NOT NULL,
  `obd_varchar23` longtext NOT NULL,
  `obd_varchar24` longtext NOT NULL,
  `obd_varchar25` longtext NOT NULL,
  `obd_varchar26` longtext NOT NULL,
  `obd_varchar27` longtext NOT NULL,
  `obd_varchar28` longtext NOT NULL,
  `obd_varchar29` longtext NOT NULL,
  `obd_varchar30` longtext NOT NULL,
  `obd_varchar31` longtext NOT NULL,
  `obd_varchar32` longtext NOT NULL,
  `obd_varchar33` longtext NOT NULL,
  `obd_varchar34` longtext NOT NULL,
  `obd_varchar35` longtext NOT NULL,
  `obd_varchar36` longtext NOT NULL,
  `obd_varchar37` longtext NOT NULL,
  `obd_varchar38` longtext NOT NULL,
  `obd_varchar39` longtext NOT NULL,
  `obd_varchar40` longtext NOT NULL,
  `obd_varchar41` longtext NOT NULL,
  `obd_varchar42` longtext NOT NULL,
  `obd_varchar43` longtext NOT NULL,
  `obd_varchar44` longtext NOT NULL,
  `obd_varchar45` longtext NOT NULL,
  `obd_varchar46` longtext NOT NULL,
  `obd_varchar47` longtext NOT NULL,
  `obd_varchar48` longtext NOT NULL,
  `obd_varchar49` longtext NOT NULL,
  `obd_varchar50` longtext NOT NULL,
  `obd_createddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `obd_createdby` varchar(255) NOT NULL DEFAULT '',
  `obd_updateddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `obd_updatedby` varchar(255) NOT NULL DEFAULT '',
  `obd_hidden` int(1) NOT NULL DEFAULT '0',
  `obd_deleted` int(1) NOT NULL DEFAULT '0',
  `obd_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`obd_id`),
  KEY `obd_1` (`obd_id`,`sta_id`,`lng_id`,`obd_parentid`,`sit_id`,`pag_id`,`obd_type`),
  KEY `obd_2` (`obd_id`,`sta_id`,`lng_id`,`obd_parentid`,`sit_id`,`pag_id`,`obd_type`,`obd_alias`,`obd_hidden`,`obd_deleted`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `obd_objectdata` */

insert  into `obd_objectdata`(`obd_id`,`sta_id`,`lng_id`,`sit_id`,`pag_id`,`mod_id`,`obd_parentid`,`obd_order`,`obd_type`,`obd_revision`,`obd_title`,`obd_alias`,`obd_description`,`obd_varchar1`,`obd_varchar2`,`obd_varchar3`,`obd_varchar4`,`obd_varchar5`,`obd_varchar6`,`obd_varchar7`,`obd_varchar8`,`obd_varchar9`,`obd_varchar10`,`obd_varchar11`,`obd_varchar12`,`obd_varchar13`,`obd_varchar14`,`obd_varchar15`,`obd_varchar16`,`obd_varchar17`,`obd_varchar18`,`obd_varchar19`,`obd_varchar20`,`obd_varchar21`,`obd_varchar22`,`obd_varchar23`,`obd_varchar24`,`obd_varchar25`,`obd_varchar26`,`obd_varchar27`,`obd_varchar28`,`obd_varchar29`,`obd_varchar30`,`obd_varchar31`,`obd_varchar32`,`obd_varchar33`,`obd_varchar34`,`obd_varchar35`,`obd_varchar36`,`obd_varchar37`,`obd_varchar38`,`obd_varchar39`,`obd_varchar40`,`obd_varchar41`,`obd_varchar42`,`obd_varchar43`,`obd_varchar44`,`obd_varchar45`,`obd_varchar46`,`obd_varchar47`,`obd_varchar48`,`obd_varchar49`,`obd_varchar50`,`obd_createddate`,`obd_createdby`,`obd_updateddate`,`obd_updatedby`,`obd_hidden`,`obd_deleted`,`obd_ts`) values (1,1,1,1,1,7,0,3,0,0,'','','','','','','','Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Praesent consequat diam sed lacus. Curabitur adipiscing leo eget neque. <br />\r\n','Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Praesent consequat diam sed lacus. Curabitur adipiscing leo eget neque. <br />\r\n','','','','','','','','','','','','','','','','','','','&#169; N&#228;ttraby Verktygs AB','Angelskogsv&#228;gen 8, SE-372 38 Ronneby, SWE\r\n','Tel: +46 (0)457 192 20&lt;br /&gt;\r\n','Email: &lt;a href=&quot;mailto:info@nva.se&quot;&gt;info@nva.se&lt;/a&gt;\r\n','','','','','','','','','','','','','','','','','','','','','','','2009-01-01 01:01:01','','2010-05-24 14:01:41','admin',0,0,'2010-05-24 14:01:41'),(2,1,1,1,3,16,0,31,0,0,'','','','','','','','','','','','','','','','','','','','','','','','','','','','You are now leaving NFM.no','Links to external websites are intended as a resource for our visitors. NFM Group does not take responsibility for the content of external websites. To proceed, please click &quot;Continue&quot; or &quot;Back&quot;.\r\n','','','','','','','','','','','','','','','','','','','','','','','','','2009-02-03 14:28:09','mange','2009-02-25 13:43:20','mange',0,0,'2010-05-27 14:57:11'),(3,1,1,1,1,0,0,1,0,0,'','MailGroup','','','','','','','','','','','','','','','','','','','','','','','','','','Sales','','','','','','','','','','','','','','','','','','','','','','','','','','2009-01-01 01:01:01','','2009-01-01 01:01:01','',0,0,'2010-05-27 14:57:12'),(4,1,1,1,4,33,0,35,0,0,'','','','Want to remove your email?','','','Just enter your mail in the textbox and press \"remove me\". If your mail exists in more than one mailing list you need to remove the certains groups you wanna leave... bla bla.<br />','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2009-02-05 13:09:05','mange','2009-02-05 13:21:47','mange',0,0,'2010-05-27 14:57:12'),(5,1,1,1,4,0,0,33,0,0,'','MailGroup','','','','','','','','','','','','','','','','','','','','','','','','','','Press','','','','','','','','','','','','','','','','','','','','','','','','','','2009-01-01 01:01:01','','2009-01-01 01:01:01','',0,0,'2010-05-27 14:57:13'),(6,1,1,1,2,34,0,29,0,0,'','','','','','','','','true','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2009-02-05 16:13:45','mange','2010-04-29 15:05:00','mange',0,0,'2010-05-27 14:57:13');

/*Table structure for table `pag_pages` */

DROP TABLE IF EXISTS `pag_pages`;

CREATE TABLE `pag_pages` (
  `pag_id` int(11) NOT NULL AUTO_INCREMENT,
  `sta_id` int(11) NOT NULL DEFAULT '0',
  `sit_id` int(11) NOT NULL DEFAULT '0',
  `lng_id` int(11) NOT NULL DEFAULT '0',
  `mdl_id` int(11) NOT NULL DEFAULT '0',
  `pag_parentid` int(11) NOT NULL DEFAULT '0',
  `pag_order` int(11) NOT NULL DEFAULT '0',
  `pag_revision` int(11) NOT NULL DEFAULT '0',
  `pag_title` varchar(255) NOT NULL DEFAULT '',
  `pag_alias` varchar(255) NOT NULL DEFAULT '',
  `pag_description` longtext NOT NULL,
  `pag_template` varchar(255) NOT NULL DEFAULT '',
  `pag_createddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `pag_createdby` varchar(255) NOT NULL DEFAULT '',
  `pag_updateddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `pag_updatedby` varchar(255) NOT NULL DEFAULT '',
  `pag_hidden` int(1) NOT NULL DEFAULT '0',
  `pag_deleted` int(1) NOT NULL DEFAULT '0',
  `pag_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`pag_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `pag_pages` */

insert  into `pag_pages`(`pag_id`,`sta_id`,`sit_id`,`lng_id`,`mdl_id`,`pag_parentid`,`pag_order`,`pag_revision`,`pag_title`,`pag_alias`,`pag_description`,`pag_template`,`pag_createddate`,`pag_createdby`,`pag_updateddate`,`pag_updatedby`,`pag_hidden`,`pag_deleted`,`pag_ts`) values (1,1,1,1,1,0,1,0,'Start','Start','SystemPage1','Template1.master','2009-01-01 01:01:01','AutoScript','2010-05-25 11:29:23','admin',0,0,'2010-05-25 11:29:23'),(2,2,1,1,1,0,27,0,'Search','search','SystemPage2','Template1.master','2009-01-01 01:01:01','AutoScript','2009-01-01 01:01:01','AutoScript',0,0,'2010-05-25 10:23:04'),(3,2,1,1,1,0,29,0,'Exitpage','exit','SystemPage3','Template1.master','2009-01-01 01:01:01','AutoScript','2009-01-01 01:01:01','AutoScript',0,0,'2010-05-25 10:23:04'),(4,2,1,1,1,0,25,0,'Unregister','unregister','SystemPage5','Template1.master','2009-01-01 01:01:01','AutoScript','2009-01-01 01:01:01','AutoScript',0,0,'2010-05-25 10:23:04');

/*Table structure for table `rol_roles` */

DROP TABLE IF EXISTS `rol_roles`;

CREATE TABLE `rol_roles` (
  `rol_id` int(11) NOT NULL AUTO_INCREMENT,
  `sta_id` int(11) NOT NULL DEFAULT '0',
  `lng_id` int(11) NOT NULL DEFAULT '0',
  `rol_parentid` int(11) NOT NULL DEFAULT '0',
  `rol_order` int(11) NOT NULL DEFAULT '0',
  `rol_revision` int(11) NOT NULL DEFAULT '0',
  `rol_title` varchar(255) NOT NULL DEFAULT '',
  `rol_alias` varchar(255) NOT NULL DEFAULT '',
  `rol_description` longtext NOT NULL,
  `rol_createddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `rol_createdby` varchar(255) NOT NULL DEFAULT '',
  `rol_updateddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `rol_updatedby` varchar(255) NOT NULL DEFAULT '',
  `rol_hidden` int(1) NOT NULL DEFAULT '0',
  `rol_deleted` int(1) NOT NULL DEFAULT '0',
  `rol_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`rol_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `rol_roles` */

insert  into `rol_roles`(`rol_id`,`sta_id`,`lng_id`,`rol_parentid`,`rol_order`,`rol_revision`,`rol_title`,`rol_alias`,`rol_description`,`rol_createddate`,`rol_createdby`,`rol_updateddate`,`rol_updatedby`,`rol_hidden`,`rol_deleted`,`rol_ts`) values (1,1,1,0,1,0,'Admin','Admin','Admins','2009-01-01 01:01:01','System','2009-01-01 01:01:01','System',0,0,'2008-12-22 12:56:22');

/*Table structure for table `set_settings` */

DROP TABLE IF EXISTS `set_settings`;

CREATE TABLE `set_settings` (
  `set_id` int(11) NOT NULL AUTO_INCREMENT,
  `sta_id` int(11) NOT NULL DEFAULT '0',
  `lng_id` int(11) NOT NULL DEFAULT '0',
  `sit_id` int(11) NOT NULL DEFAULT '0',
  `pag_id` int(11) NOT NULL DEFAULT '0',
  `mod_id` int(11) NOT NULL DEFAULT '0',
  `set_pointer` int(11) NOT NULL DEFAULT '0',
  `set_parentid` int(11) NOT NULL DEFAULT '0',
  `set_order` int(11) NOT NULL DEFAULT '0',
  `set_revision` int(11) NOT NULL DEFAULT '0',
  `set_title` varchar(255) NOT NULL DEFAULT '',
  `set_alias` varchar(255) NOT NULL DEFAULT '',
  `set_description` longtext NOT NULL,
  `set_value` longtext NOT NULL,
  `set_createddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `set_createdby` varchar(255) NOT NULL DEFAULT '',
  `set_updateddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `set_updatedby` varchar(255) NOT NULL DEFAULT '',
  `set_hidden` int(1) NOT NULL DEFAULT '0',
  `set_deleted` int(1) NOT NULL DEFAULT '0',
  `set_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`set_id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=latin1;

/*Data for the table `set_settings` */

insert  into `set_settings`(`set_id`,`sta_id`,`lng_id`,`sit_id`,`pag_id`,`mod_id`,`set_pointer`,`set_parentid`,`set_order`,`set_revision`,`set_title`,`set_alias`,`set_description`,`set_value`,`set_createddate`,`set_createdby`,`set_updateddate`,`set_updatedby`,`set_hidden`,`set_deleted`,`set_ts`) values (1,1,1,1,4,0,0,0,1,0,'MetaTitle','User-Setting','MetaTitle','RXServer4','2009-02-02 14:19:23','mange','2009-02-02 14:19:23','mange',0,0,'2011-04-28 18:22:57'),(2,1,1,1,4,0,0,0,3,0,'MetaDescription','User-Setting','MetaDescription','','2009-02-02 14:19:23','mange','2009-02-02 14:19:23','mange',0,0,'2009-02-02 14:19:23'),(3,1,1,1,4,0,0,0,5,0,'MetaKeywords','User-Setting','MetaKeywords','','2009-02-02 14:19:23','mange','2009-02-02 14:19:23','mange',0,0,'2009-02-02 14:19:23'),(4,1,1,1,4,0,0,0,7,0,'MetaAuthor','User-Setting','MetaAuthor','','2009-02-02 14:19:23','mange','2009-02-02 14:19:23','mange',0,0,'2009-02-02 14:19:23'),(5,1,1,1,4,0,0,0,9,0,'MetaCopyright','User-Setting','MetaCopyright','','2009-02-02 14:19:23','mange','2009-02-02 14:19:23','mange',0,0,'2009-02-02 14:19:23'),(6,1,1,1,4,0,0,0,11,0,'MetaRobots','User-Setting','MetaRobots','','2009-02-02 14:19:23','mange','2009-02-02 14:19:23','mange',0,0,'2009-02-02 14:19:23'),(7,1,1,1,4,0,0,0,13,0,'MetaCustom','User-Setting','MetaCustom','','2009-02-02 14:19:23','mange','2009-02-02 14:19:23','mange',0,0,'2009-02-02 14:19:23'),(8,1,1,1,4,0,0,0,15,0,'MetaTitle','User-Setting','MetaTitle','RXServer4','2009-02-02 14:19:23','mange','2009-02-02 14:19:23','mange',0,0,'2011-04-28 18:23:01'),(9,1,1,1,4,0,0,0,17,0,'MetaDescription','User-Setting','MetaDescription','','2009-02-02 14:19:23','mange','2009-02-02 14:19:23','mange',0,0,'2009-02-02 14:19:23'),(10,1,1,1,4,0,0,0,19,0,'MetaKeywords','User-Setting','MetaKeywords','','2009-02-02 14:19:24','mange','2009-02-02 14:19:24','mange',0,0,'2009-02-02 14:19:24'),(11,1,1,1,4,0,0,0,21,0,'MetaAuthor','User-Setting','MetaAuthor','','2009-02-02 14:19:24','mange','2009-02-02 14:19:24','mange',0,0,'2009-02-02 14:19:24'),(12,1,1,1,4,0,0,0,23,0,'MetaCopyright','User-Setting','MetaCopyright','','2009-02-02 14:19:24','mange','2009-02-02 14:19:24','mange',0,0,'2009-02-02 14:19:24'),(13,1,1,1,4,0,0,0,25,0,'MetaRobots','User-Setting','MetaRobots','','2009-02-02 14:19:24','mange','2009-02-02 14:19:24','mange',0,0,'2009-02-02 14:19:24'),(14,1,1,1,4,0,0,0,27,0,'MetaCustom','User-Setting','MetaCustom','','2009-02-02 14:19:24','mange','2009-02-02 14:19:24','mange',0,0,'2009-02-02 14:19:24'),(15,1,1,1,1,0,0,0,29,0,'MetaTitle','User-Setting','MetaTitle','RXServer4','2009-02-24 14:16:56','mange','2010-05-24 11:57:29','admin',0,0,'2011-04-28 18:23:05'),(16,1,1,1,1,0,0,0,31,0,'MetaKeywords','User-Setting','MetaKeywords','','2009-02-24 14:16:56','mange','2009-02-24 14:16:56','mange',0,0,'2010-05-27 14:56:46'),(17,1,1,1,1,0,0,0,33,0,'MetaDescription','User-Setting','MetaDescription','','2009-02-24 14:16:57','mange','2009-02-24 14:16:57','mange',0,0,'2010-05-27 14:56:47'),(18,1,1,1,3,0,0,0,35,0,'MetaTitle','User-Setting','MetaTitle','RXServer4','2009-02-25 12:48:01','mange','2009-02-25 12:48:01','mange',0,0,'2011-04-28 18:23:09'),(19,1,1,1,3,0,0,0,37,0,'MetaKeywords','User-Setting','MetaKeywords','','2009-02-25 12:48:01','mange','2009-02-25 12:48:01','mange',0,0,'2010-05-27 14:56:49'),(20,1,1,1,3,0,0,0,39,0,'MetaDescription','User-Setting','MetaDescription','','2009-02-25 12:48:01','mange','2009-02-25 12:48:01','mange',0,0,'2010-05-27 14:56:50'),(21,1,1,1,3,0,0,0,41,0,'MetaAuthor','User-Setting','MetaAuthor','','2009-02-25 12:48:02','mange','2009-02-25 12:48:02','mange',0,0,'2010-05-27 14:56:53'),(22,1,1,1,3,0,0,0,43,0,'MetaCopyright','User-Setting','MetaCopyright','','2009-02-25 12:48:02','mange','2009-02-25 12:48:02','mange',0,0,'2010-05-27 14:56:56');

/*Table structure for table `sit_sites` */

DROP TABLE IF EXISTS `sit_sites`;

CREATE TABLE `sit_sites` (
  `sit_id` int(11) NOT NULL AUTO_INCREMENT,
  `sta_id` int(11) NOT NULL DEFAULT '0',
  `lng_id` int(11) NOT NULL DEFAULT '0',
  `sit_parentid` int(11) NOT NULL DEFAULT '0',
  `sit_order` int(11) NOT NULL DEFAULT '0',
  `sit_revision` int(11) NOT NULL DEFAULT '0',
  `sit_title` varchar(255) NOT NULL DEFAULT '',
  `sit_alias` varchar(255) NOT NULL DEFAULT '',
  `sit_description` longtext NOT NULL,
  `sit_theme` varchar(255) NOT NULL DEFAULT '',
  `sit_structure` varchar(255) NOT NULL DEFAULT '',
  `sit_createddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `sit_createdby` varchar(255) NOT NULL DEFAULT '',
  `sit_updateddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `sit_updatedby` varchar(255) NOT NULL DEFAULT '',
  `sit_hidden` int(1) NOT NULL DEFAULT '0',
  `sit_deleted` int(1) NOT NULL DEFAULT '0',
  `sit_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`sit_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `sit_sites` */

insert  into `sit_sites`(`sit_id`,`sta_id`,`lng_id`,`sit_parentid`,`sit_order`,`sit_revision`,`sit_title`,`sit_alias`,`sit_description`,`sit_theme`,`sit_structure`,`sit_createddate`,`sit_createdby`,`sit_updateddate`,`sit_updatedby`,`sit_hidden`,`sit_deleted`,`sit_ts`) values (1,1,1,0,1,0,'RXServer4','RXServer4','RXServer4','RXSK','RXSK','2009-01-01 01:01:01','','2009-01-01 01:01:01','',0,0,'2011-04-28 18:23:22');

/*Table structure for table `sta_status` */

DROP TABLE IF EXISTS `sta_status`;

CREATE TABLE `sta_status` (
  `sta_id` int(11) NOT NULL AUTO_INCREMENT,
  `lng_id` int(11) NOT NULL DEFAULT '0',
  `sta_parentid` int(11) NOT NULL DEFAULT '0',
  `sta_order` int(11) NOT NULL DEFAULT '0',
  `sta_revision` int(11) NOT NULL DEFAULT '0',
  `sta_title` varchar(255) NOT NULL DEFAULT '',
  `sta_alias` varchar(255) NOT NULL DEFAULT '',
  `sta_description` longtext NOT NULL,
  `sta_createddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `sta_createdby` varchar(255) NOT NULL DEFAULT '',
  `sta_updateddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `sta_updatedby` varchar(255) NOT NULL DEFAULT '',
  `sta_hidden` int(1) NOT NULL DEFAULT '0',
  `sta_deleted` int(1) NOT NULL DEFAULT '0',
  `sta_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`sta_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `sta_status` */

insert  into `sta_status`(`sta_id`,`lng_id`,`sta_parentid`,`sta_order`,`sta_revision`,`sta_title`,`sta_alias`,`sta_description`,`sta_createddate`,`sta_createdby`,`sta_updateddate`,`sta_updatedby`,`sta_hidden`,`sta_deleted`,`sta_ts`) values (1,1,0,1,0,'Active','Active','Active','2009-01-01 01:01:01','','2009-01-01 01:01:01','',0,0,'2008-12-22 12:59:55'),(2,1,0,1,0,'Unactive','Hidden','Unactive','2009-01-01 01:01:01','','2009-01-01 01:01:01','',0,0,'2008-12-22 12:59:59'),(3,1,0,1,0,'UserPage','UserPage','UserPage','2009-01-01 01:01:01','','2009-01-01 01:01:01','',0,0,'2008-12-22 13:00:07'),(4,1,0,1,0,'Editable','Editable','Editable','2009-01-01 01:01:01','','2009-01-01 01:01:01','',0,0,'2008-12-22 13:00:12'),(5,1,0,1,0,'Deleteable','Deleteable','Deleteable','2009-01-01 01:01:01','','2009-01-01 01:01:01','',0,0,'2008-12-22 13:00:20');

/*Table structure for table `tas_tasks` */

DROP TABLE IF EXISTS `tas_tasks`;

CREATE TABLE `tas_tasks` (
  `tas_id` int(11) NOT NULL AUTO_INCREMENT,
  `sta_id` int(11) NOT NULL DEFAULT '0',
  `lng_id` int(11) NOT NULL DEFAULT '0',
  `tas_parentid` int(11) NOT NULL DEFAULT '0',
  `tas_order` int(11) NOT NULL DEFAULT '0',
  `tas_title` varchar(255) NOT NULL DEFAULT '',
  `tas_alias` varchar(255) NOT NULL DEFAULT '',
  `tas_description` longtext NOT NULL,
  `tas_theme` varchar(255) NOT NULL DEFAULT '',
  `tas_skin` varchar(255) NOT NULL DEFAULT '',
  `tas_createddate` datetime NOT NULL DEFAULT '2006-01-01 01:01:01',
  `tas_createdby` varchar(255) NOT NULL DEFAULT '',
  `tas_updateddate` datetime NOT NULL DEFAULT '2006-01-01 01:01:01',
  `tas_updatedby` varchar(255) NOT NULL DEFAULT '',
  `tas_hidden` int(1) NOT NULL DEFAULT '0',
  `tas_deleted` int(1) NOT NULL DEFAULT '0',
  `tas_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`tas_id`),
  KEY `tas_1` (`tas_id`,`sta_id`,`lng_id`,`tas_parentid`,`tas_alias`,`tas_hidden`,`tas_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tas_tasks` */

/*Table structure for table `uro_usersroles` */

DROP TABLE IF EXISTS `uro_usersroles`;

CREATE TABLE `uro_usersroles` (
  `uro_id` int(11) NOT NULL AUTO_INCREMENT,
  `sta_id` int(11) NOT NULL DEFAULT '0',
  `lng_id` int(11) NOT NULL DEFAULT '0',
  `usr_id` int(11) NOT NULL DEFAULT '0',
  `rol_id` int(11) NOT NULL DEFAULT '0',
  `uro_revision` int(11) NOT NULL DEFAULT '0',
  `uro_createddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `uro_createdby` varchar(255) NOT NULL DEFAULT '',
  `uro_updateddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `uro_updatedby` varchar(255) NOT NULL DEFAULT '',
  `uro_hidden` int(1) NOT NULL DEFAULT '0',
  `uro_deleted` int(1) NOT NULL DEFAULT '0',
  `uro_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`uro_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `uro_usersroles` */

insert  into `uro_usersroles`(`uro_id`,`sta_id`,`lng_id`,`usr_id`,`rol_id`,`uro_revision`,`uro_createddate`,`uro_createdby`,`uro_updateddate`,`uro_updatedby`,`uro_hidden`,`uro_deleted`,`uro_ts`) values (1,1,1,1,1,0,'2010-05-24 11:12:06','mange','2010-05-24 11:12:06','mange',0,0,'2010-05-27 14:58:24');

/*Table structure for table `usr_users` */

DROP TABLE IF EXISTS `usr_users`;

CREATE TABLE `usr_users` (
  `usr_id` int(11) NOT NULL AUTO_INCREMENT,
  `sta_id` int(11) NOT NULL DEFAULT '0',
  `lng_id` int(11) NOT NULL DEFAULT '0',
  `ust_id` int(11) NOT NULL DEFAULT '0',
  `usr_parentid` int(11) NOT NULL DEFAULT '0',
  `usr_order` int(11) NOT NULL DEFAULT '0',
  `usr_revision` int(11) NOT NULL DEFAULT '0',
  `usr_title` varchar(255) NOT NULL DEFAULT '',
  `usr_alias` varchar(255) NOT NULL DEFAULT '',
  `usr_description` longtext NOT NULL,
  `usr_mail` varchar(255) NOT NULL DEFAULT '',
  `usr_loginname` varchar(255) NOT NULL DEFAULT '',
  `usr_password` varchar(255) NOT NULL DEFAULT '',
  `usr_firstname` varchar(255) NOT NULL DEFAULT '',
  `usr_middlename` varchar(255) NOT NULL DEFAULT '',
  `usr_lastname` varchar(255) NOT NULL DEFAULT '',
  `usr_address` varchar(255) NOT NULL DEFAULT '',
  `usr_co` varchar(255) NOT NULL DEFAULT '',
  `usr_postalcode` varchar(255) NOT NULL DEFAULT '',
  `usr_city` varchar(255) NOT NULL DEFAULT '',
  `usr_country` varchar(255) NOT NULL DEFAULT '',
  `usr_phone` varchar(255) NOT NULL DEFAULT '',
  `usr_mobile` varchar(255) NOT NULL DEFAULT '',
  `usr_fax` varchar(255) NOT NULL DEFAULT '',
  `usr_company` varchar(255) NOT NULL DEFAULT '',
  `usr_startpage` int(11) NOT NULL DEFAULT '0',
  `usr_createddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `usr_createdby` varchar(255) NOT NULL DEFAULT '',
  `usr_updateddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `usr_updatedby` varchar(255) NOT NULL DEFAULT '',
  `usr_hidden` int(1) NOT NULL DEFAULT '0',
  `usr_deleted` int(1) NOT NULL DEFAULT '0',
  `usr_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`usr_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `usr_users` */

insert  into `usr_users`(`usr_id`,`sta_id`,`lng_id`,`ust_id`,`usr_parentid`,`usr_order`,`usr_revision`,`usr_title`,`usr_alias`,`usr_description`,`usr_mail`,`usr_loginname`,`usr_password`,`usr_firstname`,`usr_middlename`,`usr_lastname`,`usr_address`,`usr_co`,`usr_postalcode`,`usr_city`,`usr_country`,`usr_phone`,`usr_mobile`,`usr_fax`,`usr_company`,`usr_startpage`,`usr_createddate`,`usr_createdby`,`usr_updateddate`,`usr_updatedby`,`usr_hidden`,`usr_deleted`,`usr_ts`) values (1,1,1,1,0,3,0,'','User','','teknik@noisycricket.se','admin','HIzVlYE+bVQWdmMRyC+OfQ==','','','','','','','','','','','','',0,'2010-05-24 11:12:06','mange','2010-05-24 11:12:06','mange',0,0,'2010-05-27 14:58:17');

/*Table structure for table `ust_usertypes` */

DROP TABLE IF EXISTS `ust_usertypes`;

CREATE TABLE `ust_usertypes` (
  `ust_id` int(11) NOT NULL AUTO_INCREMENT,
  `sta_id` int(11) NOT NULL DEFAULT '0',
  `lng_id` int(11) NOT NULL DEFAULT '0',
  `ust_parentid` int(11) NOT NULL DEFAULT '0',
  `ust_order` int(11) NOT NULL DEFAULT '0',
  `ust_revision` int(11) NOT NULL DEFAULT '0',
  `ust_title` varchar(255) NOT NULL DEFAULT '',
  `ust_alias` varchar(255) NOT NULL DEFAULT '',
  `ust_description` longtext NOT NULL,
  `ust_createddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `ust_createdby` varchar(255) NOT NULL DEFAULT '',
  `ust_updateddate` datetime NOT NULL DEFAULT '2009-01-01 01:01:01',
  `ust_updatedby` varchar(255) NOT NULL DEFAULT '',
  `ust_hidden` int(1) NOT NULL DEFAULT '0',
  `ust_deleted` int(1) NOT NULL DEFAULT '0',
  `ust_ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ust_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `ust_usertypes` */

insert  into `ust_usertypes`(`ust_id`,`sta_id`,`lng_id`,`ust_parentid`,`ust_order`,`ust_revision`,`ust_title`,`ust_alias`,`ust_description`,`ust_createddate`,`ust_createdby`,`ust_updateddate`,`ust_updatedby`,`ust_hidden`,`ust_deleted`,`ust_ts`) values (1,1,1,0,1,0,'','','','2009-01-01 01:01:01','','2009-01-01 01:01:01','',0,0,'2008-12-22 13:03:22');

/* Procedure structure for procedure `delete_agg_aggregation` */

/*!50003 DROP PROCEDURE IF EXISTS  `delete_agg_aggregation` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_agg_aggregation`(aggid INT)
BEGIN
DECLARE EXIT HANDLER FOR NOT FOUND ROLLBACK;
DECLARE EXIT HANDLER FOR SQLEXCEPTION ROLLBACK;
DECLARE EXIT HANDLER FOR SQLWARNING ROLLBACK; 
SET max_sp_recursion_depth=255;
START TRANSACTION;
  UPDATE agg_aggregation SET agg_deleted = 1 WHERE agg_id = aggid;
COMMIT;
END */$$
DELIMITER ;

/* Procedure structure for procedure `delete_doc_documents` */

/*!50003 DROP PROCEDURE IF EXISTS  `delete_doc_documents` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_doc_documents`(docid INT)
BEGIN
DECLARE EXIT HANDLER FOR NOT FOUND ROLLBACK;
DECLARE EXIT HANDLER FOR SQLEXCEPTION ROLLBACK;
DECLARE EXIT HANDLER FOR SQLWARNING ROLLBACK;
SET max_sp_recursion_depth=255;
START TRANSACTION;
  UPDATE doc_documents SET doc_deleted = 1 WHERE doc_id = docid;
COMMIT;
END */$$
DELIMITER ;

/* Procedure structure for procedure `delete_mde_moduledefinitions` */

/*!50003 DROP PROCEDURE IF EXISTS  `delete_mde_moduledefinitions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_mde_moduledefinitions`(mdeid INT)
BEGIN
DECLARE EXIT HANDLER FOR NOT FOUND ROLLBACK;
DECLARE EXIT HANDLER FOR SQLEXCEPTION ROLLBACK;
DECLARE EXIT HANDLER FOR SQLWARNING ROLLBACK;
SET max_sp_recursion_depth=255;
START TRANSACTION;
  UPDATE mde_moduledefinitions SET mde_deleted = 1 WHERE mde_id = mdeid;
  CALL sort_mde_modeldefinitions();
COMMIT;
END */$$
DELIMITER ;

/* Procedure structure for procedure `delete_mdi_modelitems` */

/*!50003 DROP PROCEDURE IF EXISTS  `delete_mdi_modelitems` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_mdi_modelitems`(mdiid INT)
BEGIN
DECLARE EXIT HANDLER FOR NOT FOUND ROLLBACK;
DECLARE EXIT HANDLER FOR SQLEXCEPTION ROLLBACK;
DECLARE EXIT HANDLER FOR SQLWARNING ROLLBACK;
SET max_sp_recursion_depth=255;
START TRANSACTION;
  UPDATE mdi_modelitems SET mdi_deleted = 1 WHERE mdi_id = mdiid;
COMMIT;
END */$$
DELIMITER ;

/* Procedure structure for procedure `delete_mdl_model` */

/*!50003 DROP PROCEDURE IF EXISTS  `delete_mdl_model` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_mdl_model`(mdlid INT)
BEGIN
   DECLARE done INT DEFAULT 0;
   DECLARE i INT;
   DECLARE cur CURSOR FOR SELECT mdi_id FROM mdi_modelitems WHERE mdl_id = mdlid;
   DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1; 
   DECLARE EXIT HANDLER FOR SQLEXCEPTION ROLLBACK;
   DECLARE EXIT HANDLER FOR SQLWARNING ROLLBACK;
   SET max_sp_recursion_depth=255;
   OPEN cur;
   read_loop: LOOP
    FETCH cur INTO i;
    IF done THEN
      LEAVE read_loop;
    END IF;
    START TRANSACTION;
      UPDATE mdi_modelitems SET mdi_deleted = 1 WHERE mdi_id = i;
    COMMIT;
   END LOOP;
  CLOSE cur;
  START TRANSACTION;
    UPDATE mdl_model SET mdl_deleted = 1 WHERE mdl_id = mdlid;
    CALL sort_mdl_model();
    CALL sort_mdi_modelitems();
  COMMIT;
END */$$
DELIMITER ;

/* Procedure structure for procedure `delete_mod_modules` */

/*!50003 DROP PROCEDURE IF EXISTS  `delete_mod_modules` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_mod_modules`(modid INT)
BEGIN
DECLARE EXIT HANDLER FOR NOT FOUND ROLLBACK;
DECLARE EXIT HANDLER FOR SQLEXCEPTION ROLLBACK;
DECLARE EXIT HANDLER FOR SQLWARNING ROLLBACK;
SET max_sp_recursion_depth=255;
START TRANSACTION;
  UPDATE amr_authorizedmodulesroles SET amr_deleted = 1 WHERE mod_id = modid;
  UPDATE agg_aggregation SET agg_deleted = 1 WHERE mod_id = modid;
  UPDATE set_settings SET set_deleted = 1 WHERE mod_id = modid;
  UPDATE mod_modules SET mod_deleted = 1 WHERE mod_id = modid;
  CALL sort_set_settings();
  CALL sort_mod_modules();
COMMIT;
END */$$
DELIMITER ;

/* Procedure structure for procedure `delete_mod_modules_by_pagid_recursive` */

/*!50003 DROP PROCEDURE IF EXISTS  `delete_mod_modules_by_pagid_recursive` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_mod_modules_by_pagid_recursive`(pagid INT)
BEGIN
   DECLARE done INT DEFAULT 0;
   DECLARE i INT;
   DECLARE cur CURSOR FOR SELECT mod_id FROM mod_modules WHERE pag_id = pagid;
   DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1; 
   DECLARE EXIT HANDLER FOR SQLEXCEPTION ROLLBACK;
   DECLARE EXIT HANDLER FOR SQLWARNING ROLLBACK;
   SET max_sp_recursion_depth=255;
   OPEN cur;
   read_loop: LOOP
    FETCH cur INTO i;
    IF done THEN
      LEAVE read_loop;
    END IF;
    CALL delete_obd_objectdata_by_modid_recursive(i);
    CALL delete_mod_modules(i);
   END LOOP;
  CLOSE cur;
END */$$
DELIMITER ;

/* Procedure structure for procedure `delete_mod_modules_recursive` */

/*!50003 DROP PROCEDURE IF EXISTS  `delete_mod_modules_recursive` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_mod_modules_recursive`(modid INT)
BEGIN
DECLARE EXIT HANDLER FOR NOT FOUND ROLLBACK;
DECLARE EXIT HANDLER FOR SQLEXCEPTION ROLLBACK;
DECLARE EXIT HANDLER FOR SQLWARNING ROLLBACK;
SET max_sp_recursion_depth=255;
START TRANSACTION;
  CALL delete_obd_objectdata_by_modid_recursive(modid);
  UPDATE amr_authorizedmodulesroles SET amr_deleted = 1 WHERE mod_id = modid;
  UPDATE agg_aggregation SET agg_deleted = 1 WHERE mod_id = modid;
  UPDATE set_settings SET set_deleted = 1 WHERE mod_id = modid;
  UPDATE mod_modules SET mod_deleted = 1 WHERE mod_id = modid;
  CALL sort_set_settings();
  CALL sort_mod_modules();
COMMIT;
END */$$
DELIMITER ;

/* Procedure structure for procedure `delete_obd_objectdata` */

/*!50003 DROP PROCEDURE IF EXISTS  `delete_obd_objectdata` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_obd_objectdata`(obdid INT)
BEGIN
   DECLARE done INT DEFAULT 0;
   DECLARE i INT;
   DECLARE cur CURSOR FOR SELECT obd_id FROM obd_objectdata WHERE obd_parentid = obdid;
   DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1; 
   DECLARE EXIT HANDLER FOR SQLEXCEPTION ROLLBACK;
   DECLARE EXIT HANDLER FOR SQLWARNING ROLLBACK;
   SET max_sp_recursion_depth=255;
   OPEN cur;
   read_loop: LOOP
    FETCH cur INTO i;
    IF done THEN
      LEAVE read_loop;
    END IF;
    CALL delete_obd_objectdata(i);
    START TRANSACTION;
      UPDATE set_settings SET set_deleted = 1 WHERE set_pointer = i;
      UPDATE obd_objectdata SET obd_deleted = 1 WHERE obd_id = i;
    COMMIT;
   END LOOP;
  CLOSE cur;
  START TRANSACTION;
    UPDATE set_settings SET set_deleted = 1 WHERE set_pointer = obdid;
    UPDATE obd_objectdata SET obd_deleted = 1 WHERE obd_id = obdid;
    CALL sort_obd_objectdata();
  COMMIT;
END */$$
DELIMITER ;

/* Procedure structure for procedure `delete_obd_objectdata_by_modid_recursive` */

/*!50003 DROP PROCEDURE IF EXISTS  `delete_obd_objectdata_by_modid_recursive` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_obd_objectdata_by_modid_recursive`(modid INT)
BEGIN
   DECLARE done INT DEFAULT 0;
   DECLARE i INT;
   DECLARE cur CURSOR FOR SELECT obd_id FROM obd_objectdata WHERE mod_id = modid;
   DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1; 
   DECLARE EXIT HANDLER FOR SQLEXCEPTION ROLLBACK;
   DECLARE EXIT HANDLER FOR SQLWARNING ROLLBACK;
   SET max_sp_recursion_depth=255;
   OPEN cur;
   read_loop: LOOP
    FETCH cur INTO i;
    IF done THEN
      LEAVE read_loop;
    END IF;
    CALL delete_obd_objectdata(i);
   END LOOP;
  CLOSE cur;
END */$$
DELIMITER ;

/* Procedure structure for procedure `delete_pag_pages` */

/*!50003 DROP PROCEDURE IF EXISTS  `delete_pag_pages` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_pag_pages`(pagid INT)
BEGIN
   DECLARE done INT DEFAULT 0;
   DECLARE i INT;
   DECLARE cur CURSOR FOR SELECT pag_id FROM pag_pages WHERE pag_parentid = pagid;
   DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1; 
   DECLARE EXIT HANDLER FOR SQLEXCEPTION ROLLBACK;
   DECLARE EXIT HANDLER FOR SQLWARNING ROLLBACK;
   SET max_sp_recursion_depth=255;
   OPEN cur;
   read_loop: LOOP
    FETCH cur INTO i;
    IF done THEN
      LEAVE read_loop;
    END IF;
    CALL delete_pag_pages(i);
    START TRANSACTION;
      UPDATE apr_authorizedpagesroles SET apr_deleted = 1 WHERE pag_id = i;
      UPDATE set_settings SET set_deleted = 1 WHERE pag_id = i;
      UPDATE pag_pages SET pag_deleted = 1 WHERE pag_id = i;
    COMMIT;
   END LOOP;
  CLOSE cur;
  START TRANSACTION;
    UPDATE apr_authorizedpagesroles SET apr_deleted = 1 WHERE pag_id = pagid;
    UPDATE set_settings SET set_deleted = 1 WHERE pag_id = pagid;
    UPDATE pag_pages SET pag_deleted = 1 WHERE pag_id = pagid;
    CALL sort_pag_pages();
  COMMIT;
END */$$
DELIMITER ;

/* Procedure structure for procedure `delete_pag_pages_recursive` */

/*!50003 DROP PROCEDURE IF EXISTS  `delete_pag_pages_recursive` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_pag_pages_recursive`(pagid INT)
BEGIN
   DECLARE done INT DEFAULT 0;
   DECLARE i INT;
   DECLARE cur CURSOR FOR SELECT pag_id FROM pag_pages WHERE pag_parentid = pagid;
   DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1; 
   DECLARE EXIT HANDLER FOR SQLEXCEPTION ROLLBACK;
   DECLARE EXIT HANDLER FOR SQLWARNING ROLLBACK;
   SET max_sp_recursion_depth=255;
   OPEN cur;
   read_loop: LOOP
    FETCH cur INTO i;
    IF done THEN
      LEAVE read_loop;
    END IF;
    CALL delete_mod_modules_by_pagid_recursive(i);
    CALL delete_pag_pages(i);
    START TRANSACTION;
      UPDATE apr_authorizedpagesroles SET apr_deleted = 1 WHERE pag_id = i;
      UPDATE set_settings SET set_deleted = 1 WHERE pag_id = i;
      UPDATE pag_pages SET pag_deleted = 1 WHERE pag_id = i;
    COMMIT;
   END LOOP;
  CLOSE cur;
  CALL delete_mod_modules_by_pagid_recursive(pagid);
  START TRANSACTION;
    UPDATE apr_authorizedpagesroles SET apr_deleted = 1 WHERE pag_id = pagid;
    UPDATE set_settings SET set_deleted = 1 WHERE pag_id = pagid;
    UPDATE pag_pages SET pag_deleted = 1 WHERE pag_id = pagid;
    CALL sort_pag_pages();
  COMMIT;
END */$$
DELIMITER ;

/* Procedure structure for procedure `delete_rol_roles` */

/*!50003 DROP PROCEDURE IF EXISTS  `delete_rol_roles` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_rol_roles`(rolid INT)
BEGIN
DECLARE EXIT HANDLER FOR NOT FOUND ROLLBACK;
DECLARE EXIT HANDLER FOR SQLEXCEPTION ROLLBACK;
DECLARE EXIT HANDLER FOR SQLWARNING ROLLBACK;
SET max_sp_recursion_depth=255;
START TRANSACTION;
  UPDATE asr_authorizedsitesroles SET asr_deleted = 1 WHERE rol_id = rolid;
  UPDATE adr_authorizeddocumentsroles SET adr_deleted = 1 WHERE rol_id = rolid;
  UPDATE amr_authorizedmodulesroles SET amr_deleted = 1 WHERE rol_id = rolid;
  UPDATE apr_authorizedpagesroles SET apr_deleted = 1 WHERE rol_id = rolid;
  UPDATE atr_authorizedtasksroles SET atr_deleted = 1 WHERE rol_id = rolid;
  UPDATE uro_usersroles SET uro_deleted = 1 WHERE rol_id = rolid;
  UPDATE rol_roles SET rol_deleted = 1 WHERE rol_id = rolid;
  CALL sort_rol_roles();
COMMIT;
END */$$
DELIMITER ;

/* Procedure structure for procedure `delete_set_settings` */

/*!50003 DROP PROCEDURE IF EXISTS  `delete_set_settings` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_set_settings`(setid INT)
BEGIN
DECLARE EXIT HANDLER FOR NOT FOUND ROLLBACK;
DECLARE EXIT HANDLER FOR SQLEXCEPTION ROLLBACK;
DECLARE EXIT HANDLER FOR SQLWARNING ROLLBACK;
SET max_sp_recursion_depth=255;
START TRANSACTION;
  UPDATE set_settings SET set_deleted = 1 WHERE set_id = setid;
  CALL sort_set_settings();
COMMIT;
END */$$
DELIMITER ;

/* Procedure structure for procedure `delete_sit_sites` */

/*!50003 DROP PROCEDURE IF EXISTS  `delete_sit_sites` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_sit_sites`(sitid INT)
BEGIN
DECLARE EXIT HANDLER FOR NOT FOUND ROLLBACK;
DECLARE EXIT HANDLER FOR SQLEXCEPTION ROLLBACK;
DECLARE EXIT HANDLER FOR SQLWARNING ROLLBACK;
SET max_sp_recursion_depth=255;
START TRANSACTION;
  UPDATE asr_authorizedsitesroles SET asr_deleted = 1 WHERE sit_id = sitid;
  UPDATE set_settings SET set_deleted = 1 WHERE sit_id = sitid;
  UPDATE sit_sites SET sit_deleted = 1 WHERE sit_id = sitid;
  CALL sort_sit_sites();
COMMIT;
END */$$
DELIMITER ;

/* Procedure structure for procedure `delete_sta_status` */

/*!50003 DROP PROCEDURE IF EXISTS  `delete_sta_status` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_sta_status`(staid INT)
BEGIN
DECLARE EXIT HANDLER FOR NOT FOUND ROLLBACK;
DECLARE EXIT HANDLER FOR SQLEXCEPTION ROLLBACK;
DECLARE EXIT HANDLER FOR SQLWARNING ROLLBACK;
SET max_sp_recursion_depth=255;
START TRANSACTION;
  UPDATE sta_status SET sta_deleted = 1 WHERE sta_id = staid;
  CALL sort_sta_status();
COMMIT;
END */$$
DELIMITER ;

/* Procedure structure for procedure `delete_tas_tasks` */

/*!50003 DROP PROCEDURE IF EXISTS  `delete_tas_tasks` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_tas_tasks`(tasid INT)
BEGIN
DECLARE EXIT HANDLER FOR NOT FOUND ROLLBACK;
DECLARE EXIT HANDLER FOR SQLEXCEPTION ROLLBACK;
DECLARE EXIT HANDLER FOR SQLWARNING ROLLBACK;
SET max_sp_recursion_depth=255;
START TRANSACTION;
  UPDATE tas_tasks SET tas_deleted = 1 WHERE tas_id = tasid;
COMMIT;
END */$$
DELIMITER ;

/* Procedure structure for procedure `delete_usr_users` */

/*!50003 DROP PROCEDURE IF EXISTS  `delete_usr_users` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_usr_users`(usrid INT)
BEGIN
DECLARE EXIT HANDLER FOR NOT FOUND ROLLBACK;
DECLARE EXIT HANDLER FOR SQLEXCEPTION ROLLBACK;
DECLARE EXIT HANDLER FOR SQLWARNING ROLLBACK;
SET max_sp_recursion_depth=255;
START TRANSACTION;
  UPDATE uro_usersroles SET uro_deleted = 1 WHERE usr_id = usrid;
  UPDATE usr_users SET usr_deleted = 1 WHERE usr_id = usrid;
  CALL sort_usr_users();
COMMIT;
END */$$
DELIMITER ;

/* Procedure structure for procedure `delete_ust_usertypes` */

/*!50003 DROP PROCEDURE IF EXISTS  `delete_ust_usertypes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_ust_usertypes`(ustid INT)
BEGIN
DECLARE EXIT HANDLER FOR NOT FOUND ROLLBACK;
DECLARE EXIT HANDLER FOR SQLEXCEPTION ROLLBACK;
DECLARE EXIT HANDLER FOR SQLWARNING ROLLBACK;
SET max_sp_recursion_depth=255;
START TRANSACTION;
  UPDATE ust_usertypes SET ust_deleted = 1 WHERE ust_id = ustid;
  CALL sort_ust_usertypes();
COMMIT;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sort_mde_modeldefinitions` */

/*!50003 DROP PROCEDURE IF EXISTS  `sort_mde_modeldefinitions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sort_mde_modeldefinitions`()
BEGIN
   DECLARE done INT DEFAULT 0;
   DECLARE i,o INT;
   DECLARE cur CURSOR FOR SELECT mde_id FROM mde_moduledefinitions WHERE mde_deleted = 0 ORDER BY sit_id, sta_id, lng_id, mde_parentid, mde_order;
   DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1; 
   SET max_sp_recursion_depth=255;
   SET o = 1;
   OPEN cur;
   read_loop: LOOP
    FETCH cur INTO i;
    IF done THEN
      LEAVE read_loop;
    END IF;
    UPDATE mde_moduledefinitions SET mde_order = o WHERE mde_id = i;
    SET o = o + 2;
   END LOOP;
  CLOSE cur;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sort_mdi_modelitems` */

/*!50003 DROP PROCEDURE IF EXISTS  `sort_mdi_modelitems` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sort_mdi_modelitems`()
BEGIN
   DECLARE done INT DEFAULT 0;
   DECLARE i,o INT;
   DECLARE cur CURSOR FOR SELECT mdi_id FROM mdi_modelitems WHERE mdi_deleted = 0 ORDER BY sit_id, mdl_id, sta_id, lng_id, mdi_parentid, mdi_order;
   DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1; 
   SET max_sp_recursion_depth=255;
   SET o = 1;
   OPEN cur;
   read_loop: LOOP
    FETCH cur INTO i;
    IF done THEN
      LEAVE read_loop;
    END IF;
    UPDATE mdi_modelitems SET mdi_order = o WHERE mdi_id = i;
    SET o = o + 2;
   END LOOP;
  CLOSE cur;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sort_mod_modules` */

/*!50003 DROP PROCEDURE IF EXISTS  `sort_mod_modules` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sort_mod_modules`()
BEGIN
   DECLARE done INT DEFAULT 0;
   DECLARE i,o INT;
   DECLARE cur CURSOR FOR SELECT mod_id FROM mod_modules WHERE mod_deleted = 0 ORDER BY sit_id, pag_id, sta_id, lng_id, mod_parentid, mod_revision, mod_contentpane, mod_order;
   DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1; 
   SET max_sp_recursion_depth=255;
   SET o = 1;
   OPEN cur;
   read_loop: LOOP
    FETCH cur INTO i;
    IF done THEN
      LEAVE read_loop;
    END IF;
    UPDATE mod_modules SET mod_order = o WHERE mod_id = i;
    SET o = o + 2;
   END LOOP;
  CLOSE cur;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sort_obd_objectdata` */

/*!50003 DROP PROCEDURE IF EXISTS  `sort_obd_objectdata` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sort_obd_objectdata`()
BEGIN
   DECLARE done INT DEFAULT 0;
   DECLARE i,o INT;
   DECLARE cur CURSOR FOR SELECT obd_id FROM obd_objectdata WHERE obd_deleted = 0 ORDER BY sit_id, pag_id, mod_id, sta_id, lng_id, obd_parentid, obd_order;
   DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1; 
   SET max_sp_recursion_depth=255;
   SET o = 1;
   OPEN cur;
   read_loop: LOOP
    FETCH cur INTO i;
    IF done THEN
      LEAVE read_loop;
    END IF;
    UPDATE obd_objectdata SET obd_order = o WHERE obd_id = i;
    SET o = o + 2;
   END LOOP;
  CLOSE cur;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sort_pag_pages` */

/*!50003 DROP PROCEDURE IF EXISTS  `sort_pag_pages` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sort_pag_pages`()
BEGIN
   DECLARE done INT DEFAULT 0;
   DECLARE i,o INT;
   DECLARE cur CURSOR FOR SELECT pag_id FROM pag_pages WHERE pag_deleted = 0 ORDER BY sit_id, sta_id, lng_id, pag_parentid, pag_order;
   DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1; 
   SET max_sp_recursion_depth=255;
   SET o = 1;
   OPEN cur;
   read_loop: LOOP
    FETCH cur INTO i;
    IF done THEN
      LEAVE read_loop;
    END IF;
    UPDATE pag_pages SET pag_order = o WHERE pag_id = i;
    SET o = o + 2;
   END LOOP;
  CLOSE cur;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sort_rol_roles` */

/*!50003 DROP PROCEDURE IF EXISTS  `sort_rol_roles` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sort_rol_roles`()
BEGIN
   DECLARE done INT DEFAULT 0;
   DECLARE i,o INT;
   DECLARE cur CURSOR FOR SELECT rol_id FROM rol_roles WHERE rol_deleted = 0 ORDER BY sta_id, lng_id, rol_parentid, rol_order;
   DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1; 
   SET max_sp_recursion_depth=255;
   SET o = 1;
   OPEN cur;
   read_loop: LOOP
    FETCH cur INTO i;
    IF done THEN
      LEAVE read_loop;
    END IF;
    UPDATE rol_roles SET rol_order = o WHERE rol_id = i;
    SET o = o + 2;
   END LOOP;
  CLOSE cur;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sort_set_settings` */

/*!50003 DROP PROCEDURE IF EXISTS  `sort_set_settings` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sort_set_settings`()
BEGIN
   DECLARE done INT DEFAULT 0;
   DECLARE i,o INT;
   DECLARE cur CURSOR FOR SELECT set_id FROM set_settings WHERE set_deleted = 0 ORDER BY sta_id, lng_id, set_parentid, set_order;
   DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1; 
   SET max_sp_recursion_depth=255;
   SET o = 1;
   OPEN cur;
   read_loop: LOOP
    FETCH cur INTO i;
    IF done THEN
      LEAVE read_loop;
    END IF;
    UPDATE set_settings SET set_order = o WHERE set_id = i;
    SET o = o + 2;
   END LOOP;
  CLOSE cur;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sort_sit_sites` */

/*!50003 DROP PROCEDURE IF EXISTS  `sort_sit_sites` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sort_sit_sites`()
BEGIN
   DECLARE done INT DEFAULT 0;
   DECLARE i,o INT;
   DECLARE cur CURSOR FOR SELECT sit_id FROM sit_sites WHERE sit_deleted = 0 ORDER BY sta_id, lng_id, sit_parentid, sit_order;
   DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1; 
   SET max_sp_recursion_depth=255;
   SET o = 1;
   OPEN cur;
   read_loop: LOOP
    FETCH cur INTO i;
    IF done THEN
      LEAVE read_loop;
    END IF;
    UPDATE sit_sites SET sit_order = o WHERE sit_id = i;
    SET o = o + 2;
   END LOOP;
  CLOSE cur;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sort_sta_status` */

/*!50003 DROP PROCEDURE IF EXISTS  `sort_sta_status` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sort_sta_status`()
BEGIN
   DECLARE done INT DEFAULT 0;
   DECLARE i,o INT;
   DECLARE cur CURSOR FOR SELECT sta_id FROM sta_status WHERE sta_deleted = 0 ORDER BY lng_id, sta_parentid, sta_order;
   DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1; 
   SET max_sp_recursion_depth=255;
   SET o = 1;
   OPEN cur;
   read_loop: LOOP
    FETCH cur INTO i;
    IF done THEN
      LEAVE read_loop;
    END IF;
    UPDATE sta_status SET sta_order = o WHERE sta_id = i;
    SET o = o + 2;
   END LOOP;
  CLOSE cur;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sort_usr_users` */

/*!50003 DROP PROCEDURE IF EXISTS  `sort_usr_users` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sort_usr_users`()
BEGIN
   DECLARE done INT DEFAULT 0;
   DECLARE i,o INT;
   DECLARE cur CURSOR FOR SELECT usr_id FROM usr_users WHERE usr_deleted = 0 ORDER BY sta_id, lng_id, usr_parentid, usr_order;
   DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1; 
   SET max_sp_recursion_depth=255;
   SET o = 1;
   OPEN cur;
   read_loop: LOOP
    FETCH cur INTO i;
    IF done THEN
      LEAVE read_loop;
    END IF;
    UPDATE usr_users SET usr_order = o WHERE usr_id = i;
    SET o = o + 2;
   END LOOP;
  CLOSE cur;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sort_ust_usertypes` */

/*!50003 DROP PROCEDURE IF EXISTS  `sort_ust_usertypes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sort_ust_usertypes`()
BEGIN
   DECLARE done INT DEFAULT 0;
   DECLARE i,o INT;
   DECLARE cur CURSOR FOR SELECT ust_id FROM ust_usertypes WHERE ust_deleted = 0 ORDER BY sta_id, lng_id, ust_parentid, ust_order;
   DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1; 
   SET max_sp_recursion_depth=255;
   SET o = 1;
   OPEN cur;
   read_loop: LOOP
    FETCH cur INTO i;
    IF done THEN
      LEAVE read_loop;
    END IF;
    UPDATE ust_usertypes SET ust_order = o WHERE ust_id = i;
    SET o = o + 2;
   END LOOP;
  CLOSE cur;
END */$$
DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
