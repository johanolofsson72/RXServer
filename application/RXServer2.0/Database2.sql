
ALTER TABLE `mod_modules` ADD COLUMN `mod_width` varchar(20) NOT NULL default '' AFTER `mod_editsrc`;                              
ALTER TABLE `mod_modules` ADD COLUMN `mod_height` varchar(20) NOT NULL default '' AFTER `mod_width`;                               
ALTER TABLE `mod_modules` ADD COLUMN `mod_editwidth` varchar(20) NOT NULL default '' AFTER `mod_height`;                               
ALTER TABLE `mod_modules` ADD COLUMN `mod_editheight` varchar(20) NOT NULL default '' AFTER `mod_editwidth`;


insert into `obd_objectdata` (`sta_id`,`lng_id`,`sit_id`,`pag_id`,`mod_id`,`obd_parentid`,`obd_order`,`obd_type`,`obd_title`,`obd_alias`,`obd_description`,`obd_varchar1`,`obd_varchar2`,`obd_varchar3`,`obd_varchar4`,`obd_varchar5`,`obd_varchar6`,`obd_varchar7`,`obd_varchar8`,`obd_varchar9`,`obd_varchar10`,`obd_varchar11`,`obd_varchar12`,`obd_varchar13`,`obd_varchar14`,`obd_varchar15`,`obd_varchar16`,`obd_varchar17`,`obd_varchar18`,`obd_varchar19`,`obd_varchar20`,`obd_varchar21`,`obd_varchar22`,`obd_varchar23`,`obd_varchar24`,`obd_varchar25`,`obd_varchar26`,`obd_varchar27`,`obd_varchar28`,`obd_varchar29`,`obd_varchar30`,`obd_varchar31`,`obd_varchar32`,`obd_varchar33`,`obd_varchar34`,`obd_varchar35`,`obd_varchar36`,`obd_varchar37`,`obd_varchar38`,`obd_varchar39`,`obd_varchar40`,`obd_varchar41`,`obd_varchar42`,`obd_varchar43`,`obd_varchar44`,`obd_varchar45`,`obd_varchar46`,`obd_varchar47`,`obd_varchar48`,`obd_varchar49`,`obd_varchar50`,`obd_createddate`,`obd_createdby`,`obd_updateddate`,`obd_updatedby`,`obd_hidden`,`obd_deleted`,`obd_ts`) 
values 
(0,0,0,0,0,0,0,96,'UserSettings','UserSettings_1','UserSettings','1','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(0,0,0,0,0,0,0,96,'UserSettings','UserSettings_2','UserSettings','2','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(0,0,0,0,0,0,0,96,'UserSettings','UserSettings_3','UserSettings','3','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(0,0,0,0,0,0,0,96,'UserSettings','UserSettings_4','UserSettings','4','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(0,0,0,0,0,0,0,96,'UserSettings','UserSettings_5','UserSettings','5','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(0,0,0,0,0,0,0,96,'UserSettings','UserSettings_6','UserSettings','6','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(0,0,0,0,0,0,0,96,'UserSettings','UserSettings_7','UserSettings','7','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30'),
(0,0,0,0,0,0,0,96,'UserSettings','UserSettings_8','UserSettings','8','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','2007-01-01 00:00:00','autoscript','2007-01-01 00:00:00','autoscript',0,0,'2006-12-12 14:06:30')
;