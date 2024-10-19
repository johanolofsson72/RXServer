
--MSSQL
DROP TABLE [adg_authorizeddocumentsgroups]
CREATE TABLE [adg_authorizeddocumentsgroups] (
	[adg_id] [int] IDENTITY (1, 1) NOT NULL ,
	[sta_id] [int] NOT NULL ,
	[pag_id] [int] NOT NULL ,
	[grp_id] [int] NOT NULL ,
	[adg_createddate] [datetime] NOT NULL ,
	[adg_createdby] [varchar] (255) COLLATE Finnish_Swedish_CI_AS NOT NULL ,
	[adg_updateddate] [datetime] NOT NULL ,
	[adg_updatedby] [varchar] (255) COLLATE Finnish_Swedish_CI_AS NOT NULL ,
	[adg_hidden] [int] NOT NULL ,
	[adg_deleted] [int] NOT NULL ,
	[adg_ts] [datetime] NULL ,
	CONSTRAINT [adg_authorizeddocumentsgroups_PK] PRIMARY KEY  NONCLUSTERED 
	(
		[adg_id]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO

DROP TABLE [adr_authorizeddocumentsroles]
CREATE TABLE [adr_authorizeddocumentsroles] (
	[adr_id] [int] IDENTITY (1, 1) NOT NULL ,
	[sta_id] [int] NOT NULL ,
	[pag_id] [int] NOT NULL ,
	[rol_id] [int] NOT NULL ,
	[adr_createddate] [datetime] NOT NULL ,
	[adr_createdby] [varchar] (255) COLLATE Finnish_Swedish_CI_AS NOT NULL ,
	[adr_updateddate] [datetime] NOT NULL ,
	[adr_updatedby] [varchar] (255) COLLATE Finnish_Swedish_CI_AS NOT NULL ,
	[adr_hidden] [int] NOT NULL ,
	[adr_deleted] [int] NOT NULL ,
	[adr_ts] [datetime] NULL ,
	CONSTRAINT [adr_authorizeddocumentsroles_PK] PRIMARY KEY  NONCLUSTERED 
	(
		[adr_id]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO



/* MySQL */
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
