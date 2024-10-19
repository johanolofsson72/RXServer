/*
SQLyog Enterprise - MySQL GUI v5.17
Host - 5.0.24-community-nt : Database - bayerwebsite
*********************************************************************
Server version : 5.0.24-community-nt
*/


SET NAMES utf8;

SET SQL_MODE='';

create database if not exists `bayerwebsite`;

USE `bayerwebsite`;

SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO';

/*Table structure for table `adg_authorizeddocumentsgroups` */

DROP TABLE IF EXISTS `adg_authorizeddocumentsgroups`;

CREATE TABLE `adg_authorizeddocumentsgroups` (
  `adg_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `doc_id` int(11) NOT NULL default '0',
  `grp_id` int(11) NOT NULL default '0',
  `adg_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `adg_createdby` varchar(255) NOT NULL default '',
  `adg_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `adg_updatedby` varchar(255) NOT NULL default '',
  `adg_hidden` int(1) NOT NULL default '0',
  `adg_deleted` int(1) NOT NULL default '0',
  `adg_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`adg_id`),
  KEY `adg_1` (`adg_id`,`sta_id`,`doc_id`,`grp_id`,`adg_hidden`,`adg_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `adg_authorizeddocumentsgroups` */

LOCK TABLES `adg_authorizeddocumentsgroups` WRITE;

UNLOCK TABLES;

/*Table structure for table `adr_authorizeddocumentsroles` */

DROP TABLE IF EXISTS `adr_authorizeddocumentsroles`;

CREATE TABLE `adr_authorizeddocumentsroles` (
  `adr_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `doc_id` int(11) NOT NULL default '0',
  `rol_id` int(11) NOT NULL default '0',
  `adr_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `adr_createdby` varchar(255) NOT NULL default '',
  `adr_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `adr_updatedby` varchar(255) NOT NULL default '',
  `adr_hidden` int(1) NOT NULL default '0',
  `adr_deleted` int(1) NOT NULL default '0',
  `adr_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`adr_id`),
  KEY `adr_1` (`adr_id`,`sta_id`,`doc_id`,`rol_id`,`adr_hidden`,`adr_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `adr_authorizeddocumentsroles` */

LOCK TABLES `adr_authorizeddocumentsroles` WRITE;

UNLOCK TABLES;

/*Table structure for table `amg_authorizedmodulesgroups` */

DROP TABLE IF EXISTS `amg_authorizedmodulesgroups`;

CREATE TABLE `amg_authorizedmodulesgroups` (
  `amg_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `mod_id` int(11) NOT NULL default '0',
  `grp_id` int(11) NOT NULL default '0',
  `amg_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `amg_createdby` varchar(255) NOT NULL default '',
  `amg_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `amg_updatedby` varchar(255) NOT NULL default '',
  `amg_hidden` int(1) NOT NULL default '0',
  `amg_deleted` int(1) NOT NULL default '0',
  `amg_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`amg_id`),
  KEY `amg_1` (`amg_id`,`sta_id`,`mod_id`,`grp_id`,`amg_hidden`,`amg_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `amg_authorizedmodulesgroups` */

LOCK TABLES `amg_authorizedmodulesgroups` WRITE;

UNLOCK TABLES;

/*Table structure for table `amr_authorizedmodulesroles` */

DROP TABLE IF EXISTS `amr_authorizedmodulesroles`;

CREATE TABLE `amr_authorizedmodulesroles` (
  `amr_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `mod_id` int(11) NOT NULL default '0',
  `rol_id` int(11) NOT NULL default '0',
  `amr_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `amr_createdby` varchar(255) NOT NULL default '',
  `amr_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `amr_updatedby` varchar(255) NOT NULL default '',
  `amr_hidden` int(1) NOT NULL default '0',
  `amr_deleted` int(1) NOT NULL default '0',
  `amr_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`amr_id`),
  KEY `amr_1` (`amr_id`,`sta_id`,`mod_id`,`rol_id`,`amr_hidden`,`amr_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `amr_authorizedmodulesroles` */

LOCK TABLES `amr_authorizedmodulesroles` WRITE;

UNLOCK TABLES;

/*Table structure for table `apg_authorizedpagesgroups` */

DROP TABLE IF EXISTS `apg_authorizedpagesgroups`;

CREATE TABLE `apg_authorizedpagesgroups` (
  `apg_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `pag_id` int(11) NOT NULL default '0',
  `grp_id` int(11) NOT NULL default '0',
  `apg_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `apg_createdby` varchar(255) NOT NULL default '',
  `apg_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `apg_updatedby` varchar(255) NOT NULL default '',
  `apg_hidden` int(1) NOT NULL default '0',
  `apg_deleted` int(1) NOT NULL default '0',
  `apg_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`apg_id`),
  KEY `apg_1` (`apg_id`,`sta_id`,`pag_id`,`grp_id`,`apg_hidden`,`apg_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `apg_authorizedpagesgroups` */

LOCK TABLES `apg_authorizedpagesgroups` WRITE;

UNLOCK TABLES;

/*Table structure for table `apr_authorizedpagesroles` */

DROP TABLE IF EXISTS `apr_authorizedpagesroles`;

CREATE TABLE `apr_authorizedpagesroles` (
  `apr_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `pag_id` int(11) NOT NULL default '0',
  `rol_id` int(11) NOT NULL default '0',
  `apr_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `apr_createdby` varchar(255) NOT NULL default '',
  `apr_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `apr_updatedby` varchar(255) NOT NULL default '',
  `apr_hidden` int(1) NOT NULL default '0',
  `apr_deleted` int(1) NOT NULL default '0',
  `apr_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`apr_id`),
  KEY `apr_1` (`apr_id`,`sta_id`,`pag_id`,`rol_id`,`apr_hidden`,`apr_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `apr_authorizedpagesroles` */

LOCK TABLES `apr_authorizedpagesroles` WRITE;

insert into `apr_authorizedpagesroles` (`apr_id`,`sta_id`,`pag_id`,`rol_id`,`apr_createddate`,`apr_createdby`,`apr_updateddate`,`apr_updatedby`,`apr_hidden`,`apr_deleted`,`apr_ts`) 
values (1,1,1,1,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:01:44'),
(2,1,2,1,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:02:48'),
(3,1,3,1,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:02:52'),
(4,1,4,1,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:02:54'),
(5,1,5,1,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:02:57'),
(6,1,6,1,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:03:00'),
(7,1,7,1,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:03:04'),
(8,1,8,9,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:04:39'),
(9,1,9,2,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:04:48'),
(10,1,10,2,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:04:52'),
(11,1,11,2,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:04:55'),
(12,1,12,2,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:08:25'),
(13,1,13,2,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:08:25'),
(14,1,14,2,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:08:25'),
(15,1,15,2,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:08:26'),
(16,1,16,10,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:08:53'),
(17,1,17,3,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:09:10'),
(18,1,18,3,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:09:10'),
(19,1,19,3,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:09:12'),
(20,1,20,3,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:09:12'),
(21,1,21,3,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:09:12'),
(22,1,22,3,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:09:13'),
(23,1,23,3,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:09:14'),
(24,1,24,11,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:09:22'),
(25,1,25,4,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:09:23'),
(26,1,26,4,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:09:23'),
(27,1,27,4,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:09:24'),
(28,1,28,4,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:09:24'),
(29,1,29,4,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:09:24'),
(30,1,30,4,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:09:25'),
(31,1,31,4,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:09:38'),
(32,1,32,12,'2006-01-01 01:01:01','','2006-01-01 01:01:01','',0,0,'2006-12-12 15:09:41');

UNLOCK TABLES;

/*Table structure for table `asg_authorizedsitesgroups` */

DROP TABLE IF EXISTS `asg_authorizedsitesgroups`;

CREATE TABLE `asg_authorizedsitesgroups` (
  `asg_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `sit_id` int(11) NOT NULL default '0',
  `grp_id` int(11) NOT NULL default '0',
  `asg_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `asg_createdby` varchar(255) NOT NULL default '',
  `asg_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `asg_updatedby` varchar(255) NOT NULL default '',
  `asg_hidden` int(1) NOT NULL default '0',
  `asg_deleted` int(1) NOT NULL default '0',
  `asg_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`asg_id`),
  KEY `asg_1` (`asg_id`,`sta_id`,`sit_id`,`grp_id`,`asg_hidden`,`asg_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `asg_authorizedsitesgroups` */

LOCK TABLES `asg_authorizedsitesgroups` WRITE;

UNLOCK TABLES;

/*Table structure for table `asr_authorizedsitesroles` */

DROP TABLE IF EXISTS `asr_authorizedsitesroles`;

CREATE TABLE `asr_authorizedsitesroles` (
  `asr_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `sit_id` int(11) NOT NULL default '0',
  `rol_id` int(11) NOT NULL default '0',
  `asr_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `asr_createdby` varchar(255) NOT NULL default '',
  `asr_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `asr_updatedby` varchar(255) NOT NULL default '',
  `asr_hidden` int(1) NOT NULL default '0',
  `asr_deleted` int(1) NOT NULL default '0',
  `asr_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`asr_id`),
  KEY `asr_1` (`asr_id`,`sta_id`,`sit_id`,`rol_id`,`asr_hidden`,`asr_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `asr_authorizedsitesroles` */

LOCK TABLES `asr_authorizedsitesroles` WRITE;

UNLOCK TABLES;

/*Table structure for table `atg_authorizedtasksgroups` */

DROP TABLE IF EXISTS `atg_authorizedtasksgroups`;

CREATE TABLE `atg_authorizedtasksgroups` (
  `atg_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `tas_id` int(11) NOT NULL default '0',
  `grp_id` int(11) NOT NULL default '0',
  `atg_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `atg_createdby` varchar(255) NOT NULL default '',
  `atg_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `atg_updatedby` varchar(255) NOT NULL default '',
  `atg_hidden` int(1) NOT NULL default '0',
  `atg_deleted` int(1) NOT NULL default '0',
  `atg_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`atg_id`),
  KEY `atg_1` (`atg_id`,`sta_id`,`tas_id`,`grp_id`,`atg_hidden`,`atg_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `atg_authorizedtasksgroups` */

LOCK TABLES `atg_authorizedtasksgroups` WRITE;

UNLOCK TABLES;

/*Table structure for table `atr_authorizedtasksroles` */

DROP TABLE IF EXISTS `atr_authorizedtasksroles`;

CREATE TABLE `atr_authorizedtasksroles` (
  `atr_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `tas_id` int(11) NOT NULL default '0',
  `rol_id` int(11) NOT NULL default '0',
  `atr_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `atr_createdby` varchar(255) NOT NULL default '',
  `atr_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `atr_updatedby` varchar(255) NOT NULL default '',
  `atr_hidden` int(1) NOT NULL default '0',
  `atr_deleted` int(1) NOT NULL default '0',
  `atr_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`atr_id`),
  KEY `atr_1` (`atr_id`,`sta_id`,`tas_id`,`rol_id`,`atr_hidden`,`atr_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `atr_authorizedtasksroles` */

LOCK TABLES `atr_authorizedtasksroles` WRITE;

UNLOCK TABLES;

/*Table structure for table `doc_documents` */

DROP TABLE IF EXISTS `doc_documents`;

CREATE TABLE `doc_documents` (
  `doc_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `lng_id` int(11) NOT NULL default '0',
  `sit_id` int(11) NOT NULL default '0',
  `pag_id` int(11) NOT NULL default '0',
  `doc_parentid` int(11) NOT NULL default '0',
  `doc_order` int(11) NOT NULL default '0',
  `doc_type` int(11) NOT NULL default '0',
  `doc_title` varchar(255) NOT NULL default '',
  `doc_alias` varchar(255) NOT NULL default '',
  `doc_description` longtext NOT NULL,
  `doc_contenttype` varchar(255) NOT NULL default '',
  `doc_contentsize` int(11) NOT NULL default '0',
  `doc_version` int(11) NOT NULL default '0',
  `doc_charset` varchar(255) NOT NULL default '',
  `doc_extension` varchar(10) NOT NULL default '',
  `doc_path` varchar(255) NOT NULL default '',
  `doc_checkoutusrid` int(11) NOT NULL default '0',
  `doc_checkoutdate` datetime NOT NULL default '2006-01-01 01:01:01',
  `doc_checkoutexpiredate` datetime NOT NULL default '2006-01-01 01:01:01',
  `doc_lastvieweddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `doc_lastviewedby` varchar(255) NOT NULL default '',
  `doc_isdirty` int(1) NOT NULL default '0',
  `doc_isdelivered` int(1) NOT NULL default '0',
  `doc_issigned` int(1) NOT NULL default '0',
  `doc_iscertified` int(1) NOT NULL default '0',
  `doc_deliverdate` datetime NOT NULL default '2006-01-01 01:01:01',
  `doc_deliverby` varchar(255) NOT NULL default '',
  `doc_deliverto` varchar(255) NOT NULL default '',
  `doc_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `doc_createdby` varchar(255) NOT NULL default '',
  `doc_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `doc_updatedby` varchar(255) NOT NULL default '',
  `doc_hidden` int(1) NOT NULL default '0',
  `doc_deleted` int(1) NOT NULL default '0',
  `doc_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`doc_id`),
  KEY `doc_1` (`doc_id`,`sta_id`,`lng_id`,`doc_parentid`),
  KEY `doc_2` (`doc_id`,`sta_id`,`lng_id`,`doc_parentid`,`doc_alias`,`doc_hidden`,`doc_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `doc_documents` */

LOCK TABLES `doc_documents` WRITE;

UNLOCK TABLES;

/*Table structure for table `grp_groups` */

DROP TABLE IF EXISTS `grp_groups`;

CREATE TABLE `grp_groups` (
  `grp_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `lng_id` int(11) NOT NULL default '0',
  `grp_parentid` int(11) NOT NULL default '0',
  `grp_order` int(11) NOT NULL default '0',
  `grp_title` varchar(255) NOT NULL default '',
  `grp_alias` varchar(255) NOT NULL default '',
  `grp_description` longtext NOT NULL,
  `grp_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `grp_createdby` varchar(255) NOT NULL default '',
  `grp_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `grp_updatedby` varchar(255) NOT NULL default '',
  `grp_hidden` int(1) NOT NULL default '0',
  `grp_deleted` int(1) NOT NULL default '0',
  `grp_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`grp_id`),
  KEY `grp_1` (`grp_id`,`sta_id`,`lng_id`,`grp_parentid`,`grp_alias`,`grp_hidden`,`grp_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `grp_groups` */

LOCK TABLES `grp_groups` WRITE;

insert into `grp_groups` (`grp_id`,`sta_id`,`lng_id`,`grp_parentid`,`grp_order`,`grp_title`,`grp_alias`,`grp_description`,`grp_createddate`,`grp_createdby`,`grp_updateddate`,`grp_updatedby`,`grp_hidden`,`grp_deleted`,`grp_ts`) 
values 
(1,1,1,0,1,'Swe','Swe','Swe','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:29'),
(2,1,2,0,3,'Nor','Nor','Nor','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:29'),
(3,1,3,0,5,'Fin','Fin','Fin','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:29'),
(4,1,4,0,7,'Den','Den','Den','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:29');

UNLOCK TABLES;

/*Table structure for table `lng_language` */

DROP TABLE IF EXISTS `lng_language`;

CREATE TABLE `lng_language` (
  `lng_id` int(11) NOT NULL auto_increment,
  `lng_parentid` int(11) NOT NULL default '0',
  `lng_order` int(11) NOT NULL default '0',
  `lng_title` varchar(255) NOT NULL default '',
  `lng_alias` varchar(255) NOT NULL default '',
  `lng_description` longtext NOT NULL,
  `lng_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `lng_createdby` varchar(255) NOT NULL default '',
  `lng_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `lng_updatedby` varchar(255) NOT NULL default '',
  `lng_hidden` int(1) NOT NULL default '0',
  `lng_deleted` int(1) NOT NULL default '0',
  `lng_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`lng_id`),
  KEY `lng_1` (`lng_id`,`lng_parentid`),
  KEY `lng_2` (`lng_id`,`lng_parentid`,`lng_alias`,`lng_hidden`,`lng_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `lng_language` */

LOCK TABLES `lng_language` WRITE;

insert into `lng_language` (`lng_id`,`lng_parentid`,`lng_order`,`lng_title`,`lng_alias`,`lng_description`,`lng_createddate`,`lng_createdby`,`lng_updateddate`,`lng_updatedby`,`lng_hidden`,`lng_deleted`,`lng_ts`) 
values 
(1,0,1,'Svenska','swe','Swedish','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:29'),
(2,0,2,'Norsk','nor','Norway','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:29'),
(3,0,3,'Suomi','fin','Finnish','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:29'),
(4,0,4,'Danish','dan','Danish','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:29');

UNLOCK TABLES;

/*Table structure for table `mde_moduledefinitions` */

DROP TABLE IF EXISTS `mde_moduledefinitions`;

CREATE TABLE `mde_moduledefinitions` (
  `mde_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `sit_id` int(11) NOT NULL default '0',
  `lng_id` int(11) NOT NULL default '0',
  `mde_parentid` int(11) NOT NULL default '0',
  `mde_order` int(11) NOT NULL default '0',
  `mde_title` varchar(255) NOT NULL default '',
  `mde_alias` varchar(255) NOT NULL default '',
  `mde_description` longtext NOT NULL,
  `mde_src` varchar(255) NOT NULL default '',
  `mde_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `mde_createdby` varchar(255) NOT NULL default '',
  `mde_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `mde_updatedby` varchar(255) NOT NULL default '',
  `mde_hidden` int(1) NOT NULL default '0',
  `mde_deleted` int(1) NOT NULL default '0',
  `mde_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`mde_id`),
  KEY `mde_1` (`mde_id`,`sit_id`,`sta_id`,`lng_id`,`mde_parentid`,`mde_alias`,`mde_hidden`,`mde_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mde_moduledefinitions` */

LOCK TABLES `mde_moduledefinitions` WRITE;

insert into `mde_moduledefinitions` (`mde_id`,`sta_id`,`sit_id`,`lng_id`,`mde_parentid`,`mde_order`,`mde_title`,`mde_alias`,`mde_description`,`mde_src`,`mde_createddate`,`mde_createdby`,`mde_updateddate`,`mde_updatedby`,`mde_hidden`,`mde_deleted`,`mde_ts`) 
values 
(13,0,0,0,0,13,'Menu03','Menu03','Menu03','~/UserControlsBayer/Menu03.ascx','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:29'),
(17,0,0,0,0,17,'Kontakta oss','Kontakta oss','Kontakta oss','~/UserControlsBayer/Contact.ascx','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:29'),
(18,0,0,0,0,18,'S%c3%b6k','S%c3%b6k','S%c3%b6k','~/UserControlsBayer/Search.ascx','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:29'),
(19,0,0,0,0,19,'Press','Press','Press','~/UserControlsBayer/Press.ascx','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:29'),
(20,0,0,0,0,20,'MainArea','MainArea','MainArea','~/UserControlsBayer/MainArea.ascx','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:29'),
(21,0,0,0,0,21,'Article1','Article1','Article1','~/UserControlsBayer/Article1.ascx','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:29'),
(22,0,0,0,0,22,'Article2','Article2','Article2','~/UserControlsBayer/Article2.ascx','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:29'),
(23,0,0,0,0,23,'Article3','Article3','Article3','~/UserControlsBayer/Article3.ascx','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:29'),
(24,0,0,0,0,24,'Article1ReadMore','Article1ReadMore','Article1ReadMore','~/UserControlsBayer/Article1ReadMore.ascx','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(25,0,0,0,0,25,'Article2ReadMore','Article2ReadMore','Article2ReadMore','~/UserControlsBayer/Article2ReadMore.ascx','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(26,0,0,0,0,26,'Article3ReadMore','Article3ReadMore','Article3ReadMore','~/UserControlsBayer/Article3ReadMore.ascx','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(27,0,0,0,0,27,'mainArea','mainArea','mainArea','~/UserControlsBayer/mainArea.ascx','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(28,0,0,0,0,28,'teaserArea','teaserArea','teaserArea','~/UserControlsBayer/teaserArea.ascx','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(29,0,0,0,0,29,'TeaserLayout','TeaserLayout','TeaserLayout','~/UserControlsBayer/TeaserLayout.ascx','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(30,0,0,0,0,30,'Calender','Calender','Calender','~/UserControlsBayer/Calender.ascx','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(31,0,0,0,0,31,'Article3StartPage','Article3StartPage','Article3StartPage','~/UserControlsBayer/Article3StartPage.ascx','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:29');


UNLOCK TABLES;

/*Table structure for table `mod_modules` */

DROP TABLE IF EXISTS `mod_modules`;

CREATE TABLE `mod_modules` (
  `mod_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `sit_id` int(11) NOT NULL default '0',
  `pag_id` int(11) NOT NULL default '0',
  `mde_id` int(11) NOT NULL default '0',
  `lng_id` int(11) NOT NULL default '0',
  `mod_parentid` int(11) NOT NULL default '0',
  `mod_order` int(11) NOT NULL default '0',
  `mod_title` varchar(255) NOT NULL default '',
  `mod_alias` varchar(255) NOT NULL default '',
  `mod_description` longtext NOT NULL,
  `mod_pane` varchar(255) NOT NULL default '',
  `mod_cachetime` int(11) NOT NULL default '0',
  `mod_theme` varchar(255) NOT NULL default '',
  `mod_skin` varchar(255) NOT NULL default '',
  `mod_editsrc` varchar(255) NOT NULL default '',
  `mod_secure` int(1) NOT NULL default '0',
  `mod_allpages` int(1) NOT NULL default '0',
  `mod_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `mod_createdby` varchar(255) NOT NULL default '',
  `mod_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `mod_updatedby` varchar(255) NOT NULL default '',
  `mod_hidden` int(1) NOT NULL default '0',
  `mod_deleted` int(1) NOT NULL default '0',
  `mod_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`mod_id`),
  KEY `mod_1` (`mod_id`,`sit_id`,`pag_id`,`sta_id`,`lng_id`,`mod_parentid`,`mod_alias`,`mod_hidden`,`mod_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mod_modules` */

LOCK TABLES `mod_modules` WRITE;

insert into `mod_modules` (`mod_id`,`sta_id`,`sit_id`,`pag_id`,`mde_id`,`lng_id`,`mod_parentid`,`mod_order`,`mod_title`,`mod_alias`,`mod_description`,`mod_pane`,`mod_cachetime`,`mod_theme`,`mod_skin`,`mod_editsrc`,`mod_secure`,`mod_allpages`,`mod_createddate`,`mod_createdby`,`mod_updateddate`,`mod_updatedby`,`mod_hidden`,`mod_deleted`,`mod_ts`) 
values 
(22,1,1,2,17,1,0,22,'Kontakta oss','Kontakta oss','Kontakta oss','ContentPane422',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(23,1,1,3,18,1,0,23,'S%c3%b6k','S%c3%b6k','S%c3%b6k','ContentPane422',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),

(25,1,1,1,27,1,0,25,'MainArea','MainArea','MainArea','ContentPane1',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(26,1,1,5,27,1,0,26,'MainArea','MainArea','MainArea','ContentPane1',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(27,1,1,6,27,1,0,27,'MainArea','MainArea','MainArea','ContentPane1',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(28,1,1,7,27,1,0,28,'MainArea','MainArea','MainArea','ContentPane1',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(29,1,1,8,27,1,0,29,'MainArea','MainArea','MainArea','ContentPane1',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),

(30,1,2,9,27,2,0,30,'MainArea','MainArea','MainArea','ContentPane1',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(31,1,2,13,27,2,0,31,'MainArea','MainArea','MainArea','ContentPane1',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(32,1,2,14,27,2,0,32,'MainArea','MainArea','MainArea','ContentPane1',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(33,1,2,15,27,2,0,33,'MainArea','MainArea','MainArea','ContentPane1',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(34,1,2,16,27,2,0,34,'MainArea','MainArea','MainArea','ContentPane1',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),

(35,1,3,17,27,3,0,35,'MainArea','MainArea','MainArea','ContentPane1',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(36,1,3,21,27,3,0,36,'MainArea','MainArea','MainArea','ContentPane1',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(37,1,3,22,27,3,0,37,'MainArea','MainArea','MainArea','ContentPane1',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(38,1,3,23,27,3,0,38,'MainArea','MainArea','MainArea','ContentPane1',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(39,1,3,24,27,3,0,39,'MainArea','MainArea','MainArea','ContentPane1',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),

(40,1,4,25,27,4,0,40,'MainArea','MainArea','MainArea','ContentPane1',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(41,1,4,29,27,4,0,41,'MainArea','MainArea','MainArea','ContentPane1',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(42,1,4,30,27,4,0,42,'MainArea','MainArea','MainArea','ContentPane1',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(43,1,4,31,27,4,0,43,'MainArea','MainArea','MainArea','ContentPane1',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(44,1,4,32,27,4,0,44,'MainArea','MainArea','MainArea','ContentPane1',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),

(45,1,1,4,13,1,0,45,'Menu03','Menu03','Menu03','ContentPane1',0,'bayer_swe','ContentPanes2','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(46,1,2,12,13,2,0,46,'Menu03','Menu03','Menu03','ContentPane1',0,'bayer_dan','ContentPanes2','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(47,1,3,20,13,3,0,47,'Menu03','Menu03','Menu03','ContentPane1',0,'bayer_fin','ContentPanes2','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(48,1,4,28,13,4,0,48,'Menu03','Menu03','Menu03','ContentPane1',0,'bayer_dan','ContentPanes2','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),

(49,1,2,10,17,2,0,49,'Kontakta oss','Kontakta oss','Kontakta oss','ContentPane422',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(50,1,2,11,18,2,0,50,'S%c3%b6k','S%c3%b6k','S%c3%b6k','ContentPane422',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),

(51,1,3,18,17,3,0,51,'Kontakta oss','Kontakta oss','Kontakta oss','ContentPane422',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(52,1,3,19,18,3,0,52,'S%c3%b6k','S%c3%b6k','S%c3%b6k','ContentPane422',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),

(53,1,4,26,17,4,0,53,'Kontakta oss','Kontakta oss','Kontakta oss','ContentPane422',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(54,1,4,27,18,4,0,54,'S%c3%b6k','S%c3%b6k','S%c3%b6k','ContentPane422',0,'','','',0,0,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30');


UNLOCK TABLES;

/*Table structure for table `obd_objectdata` */

DROP TABLE IF EXISTS `obd_objectdata`;

CREATE TABLE `obd_objectdata` (
  `obd_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `lng_id` int(11) NOT NULL default '0',
  `sit_id` int(11) NOT NULL default '0',
  `pag_id` int(11) NOT NULL default '0',
  `mod_id` int(11) NOT NULL default '0',
  `obd_parentid` int(11) NOT NULL default '0',
  `obd_order` int(11) NOT NULL default '0',
  `obd_type` int(11) NOT NULL default '0',
  `obd_title` varchar(255) NOT NULL default '',
  `obd_alias` varchar(255) NOT NULL default '',
  `obd_description` longtext NOT NULL,
  `obd_varchar1` longtext NOT NULL default '',
  `obd_varchar2` longtext NOT NULL default '',
  `obd_varchar3` longtext NOT NULL default '',
  `obd_varchar4` longtext NOT NULL default '',
  `obd_varchar5` longtext NOT NULL default '',
  `obd_varchar6` longtext NOT NULL default '',
  `obd_varchar7` longtext NOT NULL default '',
  `obd_varchar8` longtext NOT NULL default '',
  `obd_varchar9` longtext NOT NULL default '',
  `obd_varchar10` longtext NOT NULL default '',
  `obd_varchar11` longtext NOT NULL default '',
  `obd_varchar12` longtext NOT NULL default '',
  `obd_varchar13` longtext NOT NULL default '',
  `obd_varchar14` longtext NOT NULL default '',
  `obd_varchar15` longtext NOT NULL default '',
  `obd_varchar16` longtext NOT NULL default '',
  `obd_varchar17` longtext NOT NULL default '',
  `obd_varchar18` longtext NOT NULL default '',
  `obd_varchar19` longtext NOT NULL default '',
  `obd_varchar20` longtext NOT NULL default '',
  `obd_varchar21` longtext NOT NULL default '',
  `obd_varchar22` longtext NOT NULL default '',
  `obd_varchar23` longtext NOT NULL default '',
  `obd_varchar24` longtext NOT NULL default '',
  `obd_varchar25` longtext NOT NULL default '',
  `obd_varchar26` longtext NOT NULL default '',
  `obd_varchar27` longtext NOT NULL default '',
  `obd_varchar28` longtext NOT NULL default '',
  `obd_varchar29` longtext NOT NULL default '',
  `obd_varchar30` longtext NOT NULL default '',
  `obd_varchar31` longtext NOT NULL default '',
  `obd_varchar32` longtext NOT NULL default '',
  `obd_varchar33` longtext NOT NULL default '',
  `obd_varchar34` longtext NOT NULL default '',
  `obd_varchar35` longtext NOT NULL default '',
  `obd_varchar36` longtext NOT NULL default '',
  `obd_varchar37` longtext NOT NULL default '',
  `obd_varchar38` longtext NOT NULL default '',
  `obd_varchar39` longtext NOT NULL default '',
  `obd_varchar40` longtext NOT NULL default '',
  `obd_varchar41` longtext NOT NULL default '',
  `obd_varchar42` longtext NOT NULL default '',
  `obd_varchar43` longtext NOT NULL default '',
  `obd_varchar44` longtext NOT NULL default '',
  `obd_varchar45` longtext NOT NULL default '',
  `obd_varchar46` longtext NOT NULL default '',
  `obd_varchar47` longtext NOT NULL default '',
  `obd_varchar48` longtext NOT NULL default '',
  `obd_varchar49` longtext NOT NULL default '',
  `obd_varchar50` longtext NOT NULL default '',
  `obd_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `obd_createdby` varchar(255) NOT NULL default '',
  `obd_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `obd_updatedby` varchar(255) NOT NULL default '',
  `obd_hidden` int(1) NOT NULL default '0',
  `obd_deleted` int(1) NOT NULL default '0',
  `obd_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`obd_id`),
  KEY `obd_1` (`obd_id`,`sta_id`,`lng_id`,`obd_parentid`,`sit_id`,`pag_id`,`obd_type`),
  KEY `obd_2` (`obd_id`,`sta_id`,`lng_id`,`obd_parentid`,`sit_id`,`pag_id`,`obd_type`,`obd_alias`,`obd_hidden`,`obd_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `obd_objectdata` */

LOCK TABLES `obd_objectdata` WRITE;

insert into `obd_objectdata` (`obd_id`,`sta_id`,`lng_id`,`sit_id`,`pag_id`,`mod_id`,`obd_parentid`,`obd_order`,`obd_type`,`obd_title`,`obd_alias`,`obd_description`,`obd_varchar1`,`obd_varchar2`,`obd_varchar3`,`obd_varchar4`,`obd_varchar5`,`obd_varchar6`,`obd_varchar7`,`obd_varchar8`,`obd_varchar9`,`obd_varchar10`,`obd_varchar11`,`obd_varchar12`,`obd_varchar13`,`obd_varchar14`,`obd_varchar15`,`obd_varchar16`,`obd_varchar17`,`obd_varchar18`,`obd_varchar19`,`obd_varchar20`,`obd_varchar21`,`obd_varchar22`,`obd_varchar23`,`obd_varchar24`,`obd_varchar25`,`obd_varchar26`,`obd_varchar27`,`obd_varchar28`,`obd_varchar29`,`obd_varchar30`,`obd_varchar31`,`obd_varchar32`,`obd_varchar33`,`obd_varchar34`,`obd_varchar35`,`obd_varchar36`,`obd_varchar37`,`obd_varchar38`,`obd_varchar39`,`obd_varchar40`,`obd_varchar41`,`obd_varchar42`,`obd_varchar43`,`obd_varchar44`,`obd_varchar45`,`obd_varchar46`,`obd_varchar47`,`obd_varchar48`,`obd_varchar49`,`obd_varchar50`,`obd_createddate`,`obd_createdby`,`obd_updateddate`,`obd_updatedby`,`obd_hidden`,`obd_deleted`,`obd_ts`) 
values 
(1,1,1,1,1,0,0,1,0,'MenuColor','MenuColor','MenuColor','134,143,114','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(2,1,1,1,5,0,0,2,0,'MenuColor','MenuColor','MenuColor','182,169,122','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(3,1,1,1,6,0,0,3,0,'MenuColor','MenuColor','MenuColor','135,144,116','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(4,1,1,1,7,0,0,4,0,'MenuColor','MenuColor','MenuColor','75,82,87','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(5,1,1,1,8,0,0,5,0,'MenuColor','MenuColor','MenuColor','121,162,176','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),

(6,1,2,2,9,0,0,6,0,'MenuColor','MenuColor','MenuColor','134,143,114','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(7,1,2,2,13,0,0,2,0,'MenuColor','MenuColor','MenuColor','182,169,122','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(8,1,2,2,14,0,0,3,0,'MenuColor','MenuColor','MenuColor','135,144,116','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(9,1,2,2,15,0,0,4,0,'MenuColor','MenuColor','MenuColor','75,82,87','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(10,1,2,2,16,0,0,5,0,'MenuColor','MenuColor','MenuColor','121,162,176','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),

(11,1,3,3,17,0,0,7,0,'MenuColor','MenuColor','MenuColor','134,143,114','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(12,1,3,3,21,0,0,2,0,'MenuColor','MenuColor','MenuColor','182,169,122','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(13,1,3,3,22,0,0,3,0,'MenuColor','MenuColor','MenuColor','135,144,116','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(14,1,3,3,23,0,0,4,0,'MenuColor','MenuColor','MenuColor','75,82,87','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(15,1,3,3,24,0,0,5,0,'MenuColor','MenuColor','MenuColor','121,162,176','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),

(16,1,4,4,25,0,0,8,0,'MenuColor','MenuColor','MenuColor','134,143,114','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(17,1,4,4,29,0,0,2,0,'MenuColor','MenuColor','MenuColor','182,169,122','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(18,1,4,4,30,0,0,3,0,'MenuColor','MenuColor','MenuColor','135,144,116','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(19,1,4,4,31,0,0,4,0,'MenuColor','MenuColor','MenuColor','75,82,87','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(20,1,4,4,32,0,0,5,0,'MenuColor','MenuColor','MenuColor','121,162,176','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30');

UNLOCK TABLES;

/*Table structure for table `pag_pages` */

DROP TABLE IF EXISTS `pag_pages`;

CREATE TABLE `pag_pages` (
  `pag_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `sit_id` int(11) NOT NULL default '0',
  `lng_id` int(11) NOT NULL default '0',
  `pag_parentid` int(11) NOT NULL default '0',
  `pag_order` int(11) NOT NULL default '0',
  `pag_title` varchar(255) NOT NULL default '',
  `pag_alias` varchar(255) NOT NULL default '',
  `pag_description` longtext NOT NULL,
  `pag_theme` varchar(255) NOT NULL default '',
  `pag_skin` varchar(255) NOT NULL default '',
  `pag_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `pag_createdby` varchar(255) NOT NULL default '',
  `pag_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `pag_updatedby` varchar(255) NOT NULL default '',
  `pag_hidden` int(1) NOT NULL default '0',
  `pag_deleted` int(1) NOT NULL default '0',
  `pag_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`pag_id`),
  KEY `pag_1` (`pag_id`,`sit_id`,`sta_id`,`lng_id`,`pag_parentid`,`pag_alias`,`pag_hidden`,`pag_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `pag_pages` */

LOCK TABLES `pag_pages` WRITE;

insert into `pag_pages` (`pag_id`,`sta_id`,`sit_id`,`lng_id`,`pag_parentid`,`pag_order`,`pag_title`,`pag_alias`,`pag_description`,`pag_theme`,`pag_skin`,`pag_createddate`,`pag_createdby`,`pag_updateddate`,`pag_updatedby`,`pag_hidden`,`pag_deleted`,`pag_ts`) 
values 
(1,1,1,1,0,1,'Hem','Default','menu_se_01','bayer_swe','ContentPanes1','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(2,1,1,1,0,3,'Kontakta','Contact','Contact','bayer_swe','ContentPanes4','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',1,0,'2006-12-12 14:06:30'),
(3,1,1,1,0,5,'S%c3%b6k','S%c3%b6k','S%c3%b6k','bayer_swe','ContentPanes4','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',1,0,'2006-12-12 14:06:31'),
(4,1,1,1,0,7,'Press','Press','Press','bayer_swe','ContentPanes2','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',1,0,'2006-12-12 14:06:31'),
(5,1,1,1,0,9,'Ungdomar','Ungdomar','menu_se_02','bayer_swe','ContentPanes1','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(6,1,1,1,0,11,'Vuxna','Vuxna','menu_se_03','bayer_swe','ContentPanes1','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(7,1,1,1,0,13,'Anh%c3%b6riga','Anh%c3%b6riga','menu_se_04','bayer_swe','ContentPanes1','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(8,1,1,1,0,15,'L%c3%a4kare','L%c3%a4kare','menu_se_05','bayer_swe','ContentPanes1','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),

(9,1,2,2,0,17,'Hjem','Default','menu_no_01','bayer_nor','ContentPanes1','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(10,1,2,2,0,19,'Kontakta','Contact','Contact','bayer_nor','ContentPanes4','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',1,0,'2006-12-12 14:06:30'),
(11,1,2,2,0,21,'S%c3%b6k','S%c3%b6k','S%c3%b6k','bayer_nor','ContentPanes4','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',1,0,'2006-12-12 14:06:31'),
(12,1,2,2,0,23,'Press','Press','Press','bayer_nor','ContentPanes2','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',1,0,'2006-12-12 14:06:31'),
(13,1,2,2,0,25,'Ungdommer','Ungdommer','menu_no_02','bayer_nor','ContentPanes1','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(14,1,2,2,0,27,'Voksne','Voksne','menu_no_03','bayer_nor','ContentPanes1','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(15,1,2,2,0,29,'P%c3%a5r%c3%b8rende','P%c3%a5r%c3%b8rende','menu_no_04','bayer_nor','ContentPanes1','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(16,1,2,2,0,31,'Lege','Lege','menu_no_05','bayer_nor','ContentPanes1','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),

(17,1,3,3,0,33,'Koti','Default','menu_fi_01','bayer_fin','ContentPanes1','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(18,1,3,3,0,35,'Kontakta','Contact','Contact','bayer_fin','ContentPanes4','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',1,0,'2006-12-12 14:06:30'),
(19,1,3,3,0,37,'S%c3%b6k','S%c3%b6k','S%c3%b6k','bayer_fin','ContentPanes4','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',1,0,'2006-12-12 14:06:31'),
(20,1,3,3,0,39,'Press','Press','Press','bayer_fin','ContentPanes2','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',1,0,'2006-12-12 14:06:31'),
(21,1,3,3,0,41,'Nuoret','Nuoret','menu_fi_02','bayer_fin','ContentPanes1','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(22,1,3,3,0,43,'Aikuiset','Aikuiset','menu_fi_03','bayer_fin','ContentPanes1','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(23,1,3,3,0,45,'Omaiset','Omaiset','menu_fi_04','bayer_fin','ContentPanes1','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(24,1,3,3,0,47,'L%c3%a4%c3%a4k%c3%a4rit','L%c3%a4%c3%a4k%c3%a4rit','menu_fi_05','bayer_fin','ContentPanes1','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),

(25,1,4,4,0,49,'H%c3%a6m','Default','menu_da_01','bayer_den','ContentPanes1','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(26,1,4,4,0,51,'Kontakta','Contact','Contact','bayer_den','ContentPanes4','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',1,0,'2006-12-12 14:06:30'),
(27,1,4,4,0,53,'S%c3%b6k','S%c3%b6k','S%c3%b6k','bayer_den','ContentPanes4','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',1,0,'2006-12-12 14:06:31'),
(28,1,4,4,0,55,'Press','Press','Press','bayer_den','ContentPanes2','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',1,0,'2006-12-12 14:06:31'),
(29,1,4,4,0,57,'Ungdom','Ungdom','menu_da_02','bayer_den','ContentPanes1','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(30,1,4,4,0,59,'Voksne','Voksne','menu_da_03','bayer_den','ContentPanes1','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(31,1,4,4,0,61,'P%c3%a5r%c3%b8rende','P%c3%a5r%c3%b8rende','menu_da_04','bayer_den','ContentPanes1','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(32,1,4,4,0,63,'L%c3%a6ger','L%c3%a6ger','menu_da_05','bayer_den','ContentPanes1','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31');

UNLOCK TABLES;

/*Table structure for table `rol_roles` */

DROP TABLE IF EXISTS `rol_roles`;

CREATE TABLE `rol_roles` (
  `rol_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `lng_id` int(11) NOT NULL default '0',
  `rol_parentid` int(11) NOT NULL default '0',
  `rol_order` int(11) NOT NULL default '0',
  `rol_title` varchar(255) NOT NULL default '',
  `rol_alias` varchar(255) NOT NULL default '',
  `rol_description` longtext NOT NULL,
  `rol_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `rol_createdby` varchar(255) NOT NULL default '',
  `rol_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `rol_updatedby` varchar(255) NOT NULL default '',
  `rol_hidden` int(1) NOT NULL default '0',
  `rol_deleted` int(1) NOT NULL default '0',
  `rol_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`rol_id`),
  KEY `rol_1` (`rol_id`,`sta_id`,`lng_id`,`rol_parentid`,`rol_alias`,`rol_hidden`,`rol_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `rol_roles` */

LOCK TABLES `rol_roles` WRITE;

insert into `rol_roles` (`rol_id`,`sta_id`,`lng_id`,`rol_parentid`,`rol_order`,`rol_title`,`rol_alias`,`rol_description`,`rol_createddate`,`rol_createdby`,`rol_updateddate`,`rol_updatedby`,`rol_hidden`,`rol_deleted`,`rol_ts`) 
values 
(1,1,1,0,1,'All Users','All Users','All Users','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(2,1,2,0,3,'All Users','All Users','All Users','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(3,1,3,0,5,'All Users','All Users','All Users','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(4,1,4,0,7,'All Users','All Users','All Users','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(5,1,1,0,9,'Admin','Admin','Admin','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(6,1,2,0,11,'Admin','Admin','Admin','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(7,1,3,0,13,'Admin','Admin','Admin','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(8,1,4,0,15,'Admin','Admin','Admin','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(9,1,1,0,17,'Doctor','Doctor','Doctor','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(10,1,2,0,19,'Doctor','Doctor','Doctor','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(11,1,3,0,21,'Doctor','Doctor','Doctor','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(12,1,4,0,23,'Doctor','Doctor','Doctor','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31');

UNLOCK TABLES;

/*Table structure for table `sit_sites` */

DROP TABLE IF EXISTS `sit_sites`;

CREATE TABLE `sit_sites` (
  `sit_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `lng_id` int(11) NOT NULL default '0',
  `sit_parentid` int(11) NOT NULL default '0',
  `sit_order` int(11) NOT NULL default '0',
  `sit_title` varchar(255) NOT NULL default '',
  `sit_alias` varchar(255) NOT NULL default '',
  `sit_description` longtext NOT NULL,
  `sit_theme` varchar(255) NOT NULL default '',
  `sit_skin` varchar(255) NOT NULL default '',
  `sit_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `sit_createdby` varchar(255) NOT NULL default '',
  `sit_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `sit_updatedby` varchar(255) NOT NULL default '',
  `sit_hidden` int(1) NOT NULL default '0',
  `sit_deleted` int(1) NOT NULL default '0',
  `sit_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`sit_id`),
  KEY `sit_1` (`sit_id`,`sta_id`,`lng_id`,`sit_parentid`,`sit_alias`,`sit_hidden`,`sit_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `sit_sites` */

LOCK TABLES `sit_sites` WRITE;

insert into `sit_sites` (`sit_id`,`sta_id`,`lng_id`,`sit_parentid`,`sit_order`,`sit_title`,`sit_alias`,`sit_description`,`sit_theme`,`sit_skin`,`sit_createddate`,`sit_createdby`,`sit_updateddate`,`sit_updatedby`,`sit_hidden`,`sit_deleted`,`sit_ts`) 
values 
(1,1,1,0,1,'Hem','Home','Home','bayer_swe','Default','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(2,1,2,0,2,'Home','Home','Home','bayer_nor','Default','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(3,1,3,0,3,'Home','Home','Home','bayer_fin','Default','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31'),
(4,1,4,0,4,'Home','Home','Home','bayer_den','Default','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:31');

UNLOCK TABLES;

/*Table structure for table `sta_status` */

DROP TABLE IF EXISTS `sta_status`;

CREATE TABLE `sta_status` (
  `sta_id` int(11) NOT NULL auto_increment,
  `lng_id` int(11) NOT NULL default '0',
  `sta_parentid` int(11) NOT NULL default '0',
  `sta_order` int(11) NOT NULL default '0',
  `sta_title` varchar(255) NOT NULL default '',
  `sta_alias` varchar(255) NOT NULL default '',
  `sta_description` longtext NOT NULL,
  `sta_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `sta_createdby` varchar(255) NOT NULL default '',
  `sta_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `sta_updatedby` varchar(255) NOT NULL default '',
  `sta_hidden` int(1) NOT NULL default '0',
  `sta_deleted` int(1) NOT NULL default '0',
  `sta_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`sta_id`),
  KEY `sta_1` (`sta_id`,`lng_id`,`sta_parentid`,`sta_alias`,`sta_hidden`,`sta_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `sta_status` */

LOCK TABLES `sta_status` WRITE;

insert into `sta_status` (`sta_id`,`lng_id`,`sta_parentid`,`sta_order`,`sta_title`,`sta_alias`,`sta_description`,`sta_createddate`,`sta_createdby`,`sta_updateddate`,`sta_updatedby`,`sta_hidden`,`sta_deleted`,`sta_ts`) 
values 
(1,0,0,1,'Ok','Ok','System default status','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(2,0,0,2,'Hidden','Hidden','System default status','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(3,0,0,3,'Deleted','Deleted','System default status','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32');

UNLOCK TABLES;

/*Table structure for table `tas_tasks` */

DROP TABLE IF EXISTS `tas_tasks`;

CREATE TABLE `tas_tasks` (
  `tas_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `lng_id` int(11) NOT NULL default '0',
  `tas_parentid` int(11) NOT NULL default '0',
  `tas_order` int(11) NOT NULL default '0',
  `tas_title` varchar(255) NOT NULL default '',
  `tas_alias` varchar(255) NOT NULL default '',
  `tas_description` longtext NOT NULL,
  `tas_theme` varchar(255) NOT NULL default '',
  `tas_skin` varchar(255) NOT NULL default '',
  `tas_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `tas_createdby` varchar(255) NOT NULL default '',
  `tas_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `tas_updatedby` varchar(255) NOT NULL default '',
  `tas_hidden` int(1) NOT NULL default '0',
  `tas_deleted` int(1) NOT NULL default '0',
  `tas_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`tas_id`),
  KEY `tas_1` (`tas_id`,`sta_id`,`lng_id`,`tas_parentid`,`tas_alias`,`tas_hidden`,`tas_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tas_tasks` */

LOCK TABLES `tas_tasks` WRITE;

UNLOCK TABLES;

/*Table structure for table `ugr_usersgroups` */

DROP TABLE IF EXISTS `ugr_usersgroups`;

CREATE TABLE `ugr_usersgroups` (
  `ugr_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `usr_id` int(11) NOT NULL default '0',
  `grp_id` int(11) NOT NULL default '0',
  `ugr_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `ugr_createdby` varchar(255) NOT NULL default '',
  `ugr_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `ugr_updatedby` varchar(255) NOT NULL default '',
  `ugr_hidden` int(1) NOT NULL default '0',
  `ugr_deleted` int(1) NOT NULL default '0',
  `ugr_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`ugr_id`),
  KEY `ugr_1` (`ugr_id`,`sta_id`,`usr_id`,`grp_id`,`ugr_hidden`,`ugr_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `ugr_usersgroups` */

LOCK TABLES `ugr_usersgroups` WRITE;

insert into `ugr_usersgroups` (`ugr_id`,`sta_id`,`usr_id`,`grp_id`,`ugr_createddate`,`ugr_createdby`,`ugr_updateddate`,`ugr_updatedby`,`ugr_hidden`,`ugr_deleted`,`ugr_ts`) 
values 
(1,1,1,1,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(2,1,2,2,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(3,1,3,3,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(4,1,4,4,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(5,1,5,1,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(6,1,6,2,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(7,1,7,3,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(8,1,8,4,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32');

UNLOCK TABLES;

/*Table structure for table `uro_usersroles` */

DROP TABLE IF EXISTS `uro_usersroles`;

CREATE TABLE `uro_usersroles` (
  `uro_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `usr_id` int(11) NOT NULL default '0',
  `rol_id` int(11) NOT NULL default '0',
  `uro_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `uro_createdby` varchar(255) NOT NULL default '',
  `uro_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `uro_updatedby` varchar(255) NOT NULL default '',
  `uro_hidden` int(1) NOT NULL default '0',
  `uro_deleted` int(1) NOT NULL default '0',
  `uro_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`uro_id`),
  KEY `uro_1` (`uro_id`,`sta_id`,`usr_id`,`rol_id`,`uro_hidden`,`uro_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `uro_usersroles` */

LOCK TABLES `uro_usersroles` WRITE;

insert into `uro_usersroles` (`uro_id`,`sta_id`,`usr_id`,`rol_id`,`uro_createddate`,`uro_createdby`,`uro_updateddate`,`uro_updatedby`,`uro_hidden`,`uro_deleted`,`uro_ts`) 
values 
(1,1,1,1,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(2,1,2,2,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(3,1,3,3,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(4,1,4,4,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(5,1,5,1,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(6,1,6,2,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(7,1,7,3,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(8,1,8,4,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(9,1,1,5,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(10,1,2,6,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(11,1,3,7,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(12,1,4,8,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:32'),
(13,1,5,9,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:33'),
(14,1,6,10,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:33'),
(15,1,7,11,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:33'),
(16,1,8,12,'2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:33');

UNLOCK TABLES;

/*Table structure for table `usr_users` */

DROP TABLE IF EXISTS `usr_users`;

CREATE TABLE `usr_users` (
  `usr_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `lng_id` int(11) NOT NULL default '0',
  `ust_id` int(11) NOT NULL default '0',
  `usr_parentid` int(11) NOT NULL default '0',
  `usr_order` int(11) NOT NULL default '0',
  `usr_title` varchar(255) NOT NULL default '',
  `usr_alias` varchar(255) NOT NULL default '',
  `usr_description` longtext NOT NULL,
  `usr_loginname` varchar(255) NOT NULL default '',
  `usr_password` varchar(255) NOT NULL default '',
  `usr_signature` varchar(255) NOT NULL default '',
  `usr_firstname` varchar(255) NOT NULL default '',
  `usr_lastname` varchar(255) NOT NULL default '',
  `usr_tag` varchar(255) NOT NULL default '',
  `usr_co` varchar(255) NOT NULL default '',
  `usr_address` varchar(255) NOT NULL default '',
  `usr_postalcode` varchar(255) NOT NULL default '',
  `usr_city` varchar(255) NOT NULL default '',
  `usr_country` varchar(255) NOT NULL default '',
  `usr_phone1` varchar(255) NOT NULL default '',
  `usr_phone2` varchar(255) NOT NULL default '',
  `usr_phone3` varchar(255) NOT NULL default '',
  `usr_fax` varchar(255) NOT NULL default '',
  `usr_mobile` varchar(255) NOT NULL default '',
  `usr_url1` varchar(255) NOT NULL default '',
  `usr_url2` varchar(255) NOT NULL default '',
  `usr_mail1` varchar(255) NOT NULL default '',
  `usr_mail2` varchar(255) NOT NULL default '',
  `usr_picturepath` varchar(255) NOT NULL default '',
  `usr_signaturepath` varchar(255) NOT NULL default '',
  `usr_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `usr_createdby` varchar(255) NOT NULL default '',
  `usr_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `usr_updatedby` varchar(255) NOT NULL default '',
  `usr_hidden` int(1) NOT NULL default '0',
  `usr_deleted` int(1) NOT NULL default '0',
  `usr_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`usr_id`),
  KEY `usr_1` (`usr_id`,`sta_id`,`lng_id`,`usr_parentid`,`usr_loginname`,`usr_password`),
  KEY `usr_2` (`usr_id`,`sta_id`,`lng_id`,`usr_parentid`,`usr_loginname`,`usr_password`,`usr_hidden`,`usr_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `usr_users` */

LOCK TABLES `usr_users` WRITE;

insert into `usr_users` (`usr_id`,`sta_id`,`lng_id`,`ust_id`,`usr_parentid`,`usr_order`,`usr_title`,`usr_alias`,`usr_description`,`usr_loginname`,`usr_password`,`usr_signature`,`usr_firstname`,`usr_lastname`,`usr_tag`,`usr_co`,`usr_address`,`usr_postalcode`,`usr_city`,`usr_country`,`usr_phone1`,`usr_phone2`,`usr_phone3`,`usr_fax`,`usr_mobile`,`usr_url1`,`usr_url2`,`usr_mail1`,`usr_mail2`,`usr_picturepath`,`usr_signaturepath`,`usr_createddate`,`usr_createdby`,`usr_updateddate`,`usr_updatedby`,`usr_hidden`,`usr_deleted`,`usr_ts`) 
values 
(1,1,1,1,0,1,'User','User','User','admin','QcL7R0g3FiJq4qTfRZtETA==','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:33'),
(2,1,2,2,0,3,'User','User','User','admin','rSQxv2heHqq6Ul02cwh1zw==','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:33'),
(3,1,3,3,0,5,'User','User','User','admin','23fgh43VpWghc0BJ0XzvZw==','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:33'),
(4,1,4,4,0,7,'User','User','User','admin','JtPcz3jQdpLe/IXsDmGr1w==','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:33'),
(5,1,1,5,0,9,'User','User','User','doctor','QcL7R0g3FiJq4qTfRZtETA==','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:33'),
(6,1,2,6,0,11,'User','User','User','doctor','rSQxv2heHqq6Ul02cwh1zw==','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:33'),
(7,1,3,7,0,13,'User','User','User','doctor','23fgh43VpWghc0BJ0XzvZw==','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:33'),
(8,1,4,8,0,15,'User','User','User','doctor','JtPcz3jQdpLe/IXsDmGr1w==','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:33');

UNLOCK TABLES;

/*Table structure for table `ust_usertypes` */

DROP TABLE IF EXISTS `ust_usertypes`;

CREATE TABLE `ust_usertypes` (
  `ust_id` int(11) NOT NULL auto_increment,
  `sta_id` int(11) NOT NULL default '0',
  `lng_id` int(11) NOT NULL default '0',
  `ust_parentid` int(11) NOT NULL default '0',
  `ust_order` int(11) NOT NULL default '0',
  `ust_title` varchar(255) NOT NULL default '',
  `ust_alias` varchar(255) NOT NULL default '',
  `ust_description` longtext NOT NULL,
  `ust_createddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `ust_createdby` varchar(255) NOT NULL default '',
  `ust_updateddate` datetime NOT NULL default '2006-01-01 01:01:01',
  `ust_updatedby` varchar(255) NOT NULL default '',
  `ust_hidden` int(1) NOT NULL default '0',
  `ust_deleted` int(1) NOT NULL default '0',
  `ust_ts` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`ust_id`),
  KEY `ust_1` (`ust_id`,`sta_id`,`lng_id`,`ust_parentid`,`ust_alias`,`ust_hidden`,`ust_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `ust_usertypes` */

LOCK TABLES `ust_usertypes` WRITE;

insert into `ust_usertypes` (`ust_id`,`sta_id`,`lng_id`,`ust_parentid`,`ust_order`,`ust_title`,`ust_alias`,`ust_description`,`ust_createddate`,`ust_createdby`,`ust_updateddate`,`ust_updatedby`,`ust_hidden`,`ust_deleted`,`ust_ts`) 
values 
(1,1,1,0,1,'Admin','Admin','Admin','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:33'),
(2,1,2,0,3,'Admin','Admin','Admin','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:33'),
(3,1,3,0,5,'Admin','Admin','Admin','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:33'),
(4,1,4,0,7,'Admin','Admin','Admin','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:33'),
(5,1,1,0,9,'Doctor','Doctor','Doctor','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:33'),
(6,1,2,0,11,'Doctor','Doctor','Doctor','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:33'),
(7,1,3,0,13,'Doctor','Doctor','Doctor','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:33'),
(8,1,4,0,15,'Doctor','Doctor','Doctor','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:33');

UNLOCK TABLES;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;

