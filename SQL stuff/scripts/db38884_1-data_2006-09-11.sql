# ==========================================================
#
# Database dump of tables in `db38884_1`
# September 11, 2006, 12:28:30 
#
# ==========================================================


#
# Dumping data in `smf_scato_attachments`
#

INSERT INTO `smf_scato_attachments`
	(`ID_ATTACH`, `ID_THUMB`, `ID_MSG`, `ID_MEMBER`, `attachmentType`, `filename`, `size`, `downloads`, `width`, `height`)
VALUES (1, 0, 0, 2, 0, 'avatar_2.png', 4865, 7, 48, 65),
	(2, 0, 0, 3, 0, 'avatar_3.png', 7608, 40, 49, 65),
	(3, 0, 0, 1, 0, 'avatar_1.png', 8413, 64, 65, 58);
# --------------------------------------------------------

#
# Dumping data in `smf_scato_board_permissions`
#

INSERT INTO `smf_scato_board_permissions`
	(`ID_GROUP`, `ID_BOARD`, `permission`, `addDeny`)
VALUES (-1, 0, 'poll_view', 1),
	(0, 0, 'remove_own', 1),
	(0, 0, 'lock_own', 1),
	(0, 0, 'mark_any_notify', 1),
	(0, 0, 'mark_notify', 1),
	(0, 0, 'modify_own', 1),
	(0, 0, 'poll_add_own', 1),
	(0, 0, 'poll_edit_own', 1),
	(0, 0, 'poll_lock_own', 1),
	(0, 0, 'poll_post', 1),
	(0, 0, 'poll_view', 1),
	(0, 0, 'poll_vote', 1),
	(0, 0, 'post_attachment', 1),
	(0, 0, 'post_new', 1),
	(0, 0, 'post_reply_any', 1),
	(0, 0, 'post_reply_own', 1),
	(0, 0, 'delete_own', 1),
	(0, 0, 'report_any', 1),
	(0, 0, 'send_topic', 1),
	(0, 0, 'view_attachments', 1),
	(2, 0, 'moderate_board', 1),
	(2, 0, 'post_new', 1),
	(2, 0, 'post_reply_own', 1),
	(2, 0, 'post_reply_any', 1),
	(2, 0, 'poll_post', 1),
	(2, 0, 'poll_add_any', 1),
	(2, 0, 'poll_remove_any', 1),
	(2, 0, 'poll_view', 1),
	(2, 0, 'poll_vote', 1),
	(2, 0, 'poll_edit_any', 1),
	(2, 0, 'report_any', 1),
	(2, 0, 'lock_own', 1),
	(2, 0, 'send_topic', 1),
	(2, 0, 'mark_any_notify', 1),
	(2, 0, 'mark_notify', 1),
	(2, 0, 'delete_own', 1),
	(2, 0, 'modify_own', 1),
	(2, 0, 'make_sticky', 1),
	(2, 0, 'lock_any', 1),
	(2, 0, 'remove_any', 1),
	(2, 0, 'move_any', 1),
	(2, 0, 'merge_any', 1),
	(2, 0, 'split_any', 1),
	(2, 0, 'delete_any', 1),
	(2, 0, 'modify_any', 1),
	(3, 0, 'moderate_board', 1),
	(3, 0, 'post_new', 1),
	(3, 0, 'post_reply_own', 1),
	(3, 0, 'post_reply_any', 1),
	(3, 0, 'poll_post', 1),
	(3, 0, 'poll_add_own', 1),
	(3, 0, 'poll_remove_any', 1),
	(3, 0, 'poll_view', 1),
	(3, 0, 'poll_vote', 1),
	(3, 0, 'report_any', 1),
	(3, 0, 'lock_own', 1),
	(3, 0, 'send_topic', 1),
	(3, 0, 'mark_any_notify', 1),
	(3, 0, 'mark_notify', 1),
	(3, 0, 'delete_own', 1),
	(3, 0, 'modify_own', 1),
	(3, 0, 'make_sticky', 1),
	(3, 0, 'lock_any', 1),
	(3, 0, 'remove_any', 1),
	(3, 0, 'move_any', 1),
	(3, 0, 'merge_any', 1),
	(3, 0, 'split_any', 1),
	(3, 0, 'delete_any', 1),
	(3, 0, 'modify_any', 1),
	(9, 0, 'poll_view', 1),
	(9, 0, 'post_new', 1),
	(9, 0, 'post_reply_own', 1),
	(9, 0, 'post_reply_any', 1),
	(9, 0, 'delete_own', 1),
	(9, 0, 'modify_own', 1),
	(9, 0, 'mark_any_notify', 1),
	(9, 0, 'mark_notify', 1),
	(9, 0, 'report_any', 1),
	(9, 0, 'send_topic', 1),
	(9, 0, 'poll_vote', 1),
	(9, 0, 'poll_edit_own', 1),
	(9, 0, 'poll_post', 1),
	(9, 0, 'poll_add_own', 1),
	(9, 0, 'post_attachment', 1),
	(9, 0, 'lock_own', 1),
	(9, 0, 'remove_own', 1),
	(9, 0, 'view_attachments', 1),
	(10, 0, 'delete_own', 1),
	(10, 0, 'lock_own', 1),
	(10, 0, 'mark_any_notify', 1),
	(10, 0, 'mark_notify', 1),
	(10, 0, 'modify_own', 1),
	(10, 0, 'poll_add_own', 1),
	(10, 0, 'poll_edit_own', 1),
	(10, 0, 'poll_lock_own', 1),
	(10, 0, 'poll_post', 1),
	(10, 0, 'poll_view', 1),
	(10, 0, 'poll_vote', 1),
	(10, 0, 'post_attachment', 1),
	(10, 0, 'post_new', 1),
	(10, 0, 'post_reply_any', 1),
	(10, 0, 'post_reply_own', 1),
	(10, 0, 'remove_own', 1),
	(10, 0, 'report_any', 1),
	(10, 0, 'send_topic', 1),
	(10, 0, 'view_attachments', 1),
	(11, 0, 'delete_own', 1),
	(11, 0, 'lock_own', 1),
	(11, 0, 'mark_any_notify', 1),
	(11, 0, 'mark_notify', 1),
	(11, 0, 'modify_own', 1),
	(11, 0, 'poll_add_own', 1),
	(11, 0, 'poll_edit_own', 1),
	(11, 0, 'poll_lock_own', 1),
	(11, 0, 'poll_post', 1),
	(11, 0, 'poll_view', 1),
	(11, 0, 'poll_vote', 1),
	(11, 0, 'post_attachment', 1),
	(11, 0, 'post_new', 1),
	(11, 0, 'post_reply_any', 1),
	(11, 0, 'post_reply_own', 1),
	(11, 0, 'remove_own', 1),
	(11, 0, 'report_any', 1),
	(11, 0, 'send_topic', 1),
	(11, 0, 'view_attachments', 1);
# --------------------------------------------------------

#
# Dumping data in `smf_scato_boards`
#

INSERT INTO `smf_scato_boards`
	(`ID_BOARD`, `ID_CAT`, `childLevel`, `ID_PARENT`, `boardOrder`, `ID_LAST_MSG`, `ID_MSG_UPDATED`, `memberGroups`, `name`, `description`, `numTopics`, `numPosts`, `countPosts`, `ID_THEME`, `permission_mode`, `override_theme`)
VALUES (4, 4, 0, 0, 1, 0, 0, '-1,0,2,10,9,11', 'Ankündigungen und Informationen', '', 0, 0, 0, 0, 0, 0),
	(5, 4, 0, 0, 2, 0, 0, '-1,0,2,10,9,11', 'LARP', 'Larp im Allgemeinen und Cons anderer Veranstalter', 0, 0, 0, 0, 0, 0),
	(3, 4, 0, 0, 3, 0, 0, '-1,0,2,10,9,11', 'Hintergrund', 'Der Landeshintergrund', 0, 0, 0, 0, 0, 0),
	(2, 4, 0, 0, 4, 0, 0, '-1,0,2,10,9,11', 'Off-Topic', 'Alles was sonst nirgend rein darf.', 0, 0, 0, 0, 0, 0),
	(10, 7, 0, 0, 5, 0, 0, '-1,0,2,10,9,11', 'Fragen und Antworten', '', 0, 0, 0, 0, 0, 0),
	(9, 7, 0, 0, 6, 0, 0, '-1,0,2,10,9,11', 'Diskussion', 'Anregungen, Kritik, Bücherverbrennung rund ums Regelwerk', 0, 0, 0, 0, 0, 0),
	(6, 5, 0, 0, 7, 0, 0, '2,10,9,11', 'Allgemeines', '', 0, 0, 0, 0, 0, 0),
	(7, 3, 0, 0, 8, 17, 17, '2,9', 'Allgemeines', '', 4, 7, 0, 0, 0, 0),
	(8, 3, 0, 0, 9, 15, 15, 9, 'Regelwerk-Errata', 'Änderungen und Diskussionen ums Regelwerk', 1, 1, 0, 0, 0, 0),
	(11, 3, 0, 0, 10, 9, 9, '2,9', 'NonSenSe', 'Hier darf nix rein, was wir nicht auch durchfunken würden ;-)', 1, 8, 0, 0, 0, 0);
# --------------------------------------------------------

#
# Dumping data in `smf_scato_calendar_holidays`
#

INSERT INTO `smf_scato_calendar_holidays`
	(`ID_HOLIDAY`, `eventDate`, `title`)
VALUES (1, '0004-01-01', 'New Year\'s'),
	(2, '0004-12-25', 'Christmas'),
	(3, '0004-02-14', 'Valentine\'s Day'),
	(4, '0004-03-17', 'St. Patrick\'s Day'),
	(5, '0004-04-01', 'April Fools'),
	(6, '0004-04-22', 'Earth Day'),
	(7, '0004-10-24', 'United Nations Day'),
	(8, '0004-10-31', 'Halloween'),
	(9, '2004-05-09', 'Mother\'s Day'),
	(10, '2005-05-08', 'Mother\'s Day'),
	(11, '2006-05-14', 'Mother\'s Day'),
	(12, '2007-05-13', 'Mother\'s Day'),
	(13, '2008-05-11', 'Mother\'s Day'),
	(14, '2009-05-10', 'Mother\'s Day'),
	(15, '2010-05-09', 'Mother\'s Day'),
	(16, '2011-05-08', 'Mother\'s Day'),
	(17, '2012-05-13', 'Mother\'s Day'),
	(18, '2013-05-12', 'Mother\'s Day'),
	(19, '2014-05-11', 'Mother\'s Day'),
	(20, '2015-05-10', 'Mother\'s Day'),
	(21, '2016-05-08', 'Mother\'s Day'),
	(22, '2017-05-14', 'Mother\'s Day'),
	(23, '2018-05-13', 'Mother\'s Day'),
	(24, '2019-05-12', 'Mother\'s Day'),
	(25, '2020-05-10', 'Mother\'s Day'),
	(26, '2004-06-20', 'Father\'s Day'),
	(27, '2005-06-19', 'Father\'s Day'),
	(28, '2006-06-18', 'Father\'s Day'),
	(29, '2007-06-17', 'Father\'s Day'),
	(30, '2008-06-15', 'Father\'s Day'),
	(31, '2009-06-21', 'Father\'s Day'),
	(32, '2010-06-20', 'Father\'s Day'),
	(33, '2011-06-19', 'Father\'s Day'),
	(34, '2012-06-17', 'Father\'s Day'),
	(35, '2013-06-16', 'Father\'s Day'),
	(36, '2014-06-15', 'Father\'s Day'),
	(37, '2015-06-21', 'Father\'s Day'),
	(38, '2016-06-19', 'Father\'s Day'),
	(39, '2017-06-18', 'Father\'s Day'),
	(40, '2018-06-17', 'Father\'s Day'),
	(41, '2019-06-16', 'Father\'s Day'),
	(42, '2020-06-21', 'Father\'s Day'),
	(43, '2004-06-20', 'Summer Solstice'),
	(44, '2005-06-20', 'Summer Solstice'),
	(45, '2006-06-21', 'Summer Solstice'),
	(46, '2007-06-21', 'Summer Solstice'),
	(47, '2008-06-20', 'Summer Solstice'),
	(48, '2009-06-20', 'Summer Solstice'),
	(49, '2010-06-21', 'Summer Solstice'),
	(50, '2011-06-21', 'Summer Solstice'),
	(51, '2012-06-20', 'Summer Solstice'),
	(52, '2013-06-21', 'Summer Solstice'),
	(53, '2014-06-21', 'Summer Solstice'),
	(54, '2015-06-21', 'Summer Solstice'),
	(55, '2016-06-20', 'Summer Solstice'),
	(56, '2017-06-20', 'Summer Solstice'),
	(57, '2018-06-21', 'Summer Solstice'),
	(58, '2019-06-21', 'Summer Solstice'),
	(59, '2020-06-20', 'Summer Solstice'),
	(60, '2004-03-19', 'Vernal Equinox'),
	(61, '2005-03-20', 'Vernal Equinox'),
	(62, '2006-03-20', 'Vernal Equinox'),
	(63, '2007-03-20', 'Vernal Equinox'),
	(64, '2008-03-19', 'Vernal Equinox'),
	(65, '2009-03-20', 'Vernal Equinox'),
	(66, '2010-03-20', 'Vernal Equinox'),
	(67, '2011-03-20', 'Vernal Equinox'),
	(68, '2012-03-20', 'Vernal Equinox'),
	(69, '2013-03-20', 'Vernal Equinox'),
	(70, '2014-03-20', 'Vernal Equinox'),
	(71, '2015-03-20', 'Vernal Equinox'),
	(72, '2016-03-19', 'Vernal Equinox'),
	(73, '2017-03-20', 'Vernal Equinox'),
	(74, '2018-03-20', 'Vernal Equinox'),
	(75, '2019-03-20', 'Vernal Equinox'),
	(76, '2020-03-19', 'Vernal Equinox'),
	(77, '2004-12-21', 'Winter Solstice'),
	(78, '2005-12-21', 'Winter Solstice'),
	(79, '2006-12-22', 'Winter Solstice'),
	(80, '2007-12-22', 'Winter Solstice'),
	(81, '2008-12-21', 'Winter Solstice'),
	(82, '2009-12-21', 'Winter Solstice'),
	(83, '2010-12-21', 'Winter Solstice'),
	(84, '2011-12-22', 'Winter Solstice'),
	(85, '2012-12-21', 'Winter Solstice'),
	(86, '2013-12-21', 'Winter Solstice'),
	(87, '2014-12-21', 'Winter Solstice'),
	(88, '2015-12-21', 'Winter Solstice'),
	(89, '2016-12-21', 'Winter Solstice'),
	(90, '2017-12-21', 'Winter Solstice'),
	(91, '2018-12-21', 'Winter Solstice'),
	(92, '2019-12-21', 'Winter Solstice'),
	(93, '2020-12-21', 'Winter Solstice'),
	(94, '2004-09-22', 'Autumnal Equinox'),
	(95, '2005-09-22', 'Autumnal Equinox'),
	(96, '2006-09-22', 'Autumnal Equinox'),
	(97, '2007-09-23', 'Autumnal Equinox'),
	(98, '2008-09-22', 'Autumnal Equinox'),
	(99, '2009-09-22', 'Autumnal Equinox'),
	(100, '2010-09-22', 'Autumnal Equinox'),
	(101, '2011-09-23', 'Autumnal Equinox'),
	(102, '2012-09-22', 'Autumnal Equinox'),
	(103, '2013-09-22', 'Autumnal Equinox'),
	(104, '2014-09-22', 'Autumnal Equinox'),
	(105, '2015-09-23', 'Autumnal Equinox'),
	(106, '2016-09-22', 'Autumnal Equinox'),
	(107, '2017-09-22', 'Autumnal Equinox'),
	(108, '2018-09-22', 'Autumnal Equinox'),
	(109, '2019-09-23', 'Autumnal Equinox'),
	(110, '2020-09-22', 'Autumnal Equinox'),
	(111, '0000-07-04', 'Independence Day'),
	(112, '0000-05-05', 'Cinco de Mayo'),
	(113, '0000-06-14', 'Flag Day'),
	(114, '0004-11-11', 'Veterans Day'),
	(115, '0004-02-02', 'Groundhog Day'),
	(116, '2004-11-25', 'Thanksgiving'),
	(117, '2005-11-24', 'Thanksgiving'),
	(118, '2006-11-23', 'Thanksgiving'),
	(119, '2007-11-22', 'Thanksgiving'),
	(120, '2008-11-27', 'Thanksgiving'),
	(121, '2009-11-26', 'Thanksgiving'),
	(122, '2010-11-25', 'Thanksgiving'),
	(123, '2011-11-24', 'Thanksgiving'),
	(124, '2012-11-22', 'Thanksgiving'),
	(125, '2013-11-21', 'Thanksgiving'),
	(126, '2014-11-20', 'Thanksgiving'),
	(127, '2015-11-26', 'Thanksgiving'),
	(128, '2016-11-24', 'Thanksgiving'),
	(129, '2017-11-23', 'Thanksgiving'),
	(130, '2018-11-22', 'Thanksgiving'),
	(131, '2019-11-21', 'Thanksgiving'),
	(132, '2020-11-26', 'Thanksgiving'),
	(133, '2004-05-31', 'Memorial Day'),
	(134, '2005-05-30', 'Memorial Day'),
	(135, '2006-05-29', 'Memorial Day'),
	(136, '2007-05-28', 'Memorial Day'),
	(137, '2008-05-26', 'Memorial Day'),
	(138, '2009-05-25', 'Memorial Day'),
	(139, '2010-05-31', 'Memorial Day'),
	(140, '2011-05-30', 'Memorial Day'),
	(141, '2012-05-28', 'Memorial Day'),
	(142, '2013-05-27', 'Memorial Day'),
	(143, '2014-05-26', 'Memorial Day'),
	(144, '2015-05-25', 'Memorial Day'),
	(145, '2016-05-30', 'Memorial Day'),
	(146, '2017-05-29', 'Memorial Day'),
	(147, '2018-05-28', 'Memorial Day'),
	(148, '2019-05-27', 'Memorial Day'),
	(149, '2020-05-25', 'Memorial Day'),
	(150, '2004-09-06', 'Labor Day'),
	(151, '2005-09-05', 'Labor Day'),
	(152, '2006-09-04', 'Labor Day'),
	(153, '2007-09-03', 'Labor Day'),
	(154, '2008-09-01', 'Labor Day'),
	(155, '2009-09-07', 'Labor Day'),
	(156, '2010-09-06', 'Labor Day'),
	(157, '2011-09-05', 'Labor Day'),
	(158, '2012-09-03', 'Labor Day'),
	(159, '2013-09-09', 'Labor Day'),
	(160, '2014-09-08', 'Labor Day'),
	(161, '2015-09-07', 'Labor Day'),
	(162, '2016-09-05', 'Labor Day'),
	(163, '2017-09-04', 'Labor Day'),
	(164, '2018-09-03', 'Labor Day'),
	(165, '2019-09-09', 'Labor Day'),
	(166, '2020-09-07', 'Labor Day'),
	(167, '0004-06-06', 'D-Day');
# --------------------------------------------------------

#
# Dumping data in `smf_scato_categories`
#

INSERT INTO `smf_scato_categories`
	(`ID_CAT`, `catOrder`, `name`, `canCollapse`)
VALUES (3, 3, 'SL-Bereich', 1),
	(4, 0, 'Allgemeines', 1),
	(7, 1, 'Regelwerk', 1),
	(5, 2, 'NSC-Bereich', 1);
# --------------------------------------------------------

#
# Dumping data in `smf_scato_log_actions`
#

INSERT INTO `smf_scato_log_actions`
	(`ID_ACTION`, `logTime`, `ID_MEMBER`, `ip`, `action`, `extra`)
VALUES (1, 1157918540, 1, '84.63.50.57', 'news', 'a:0:{}'),
	(2, 1157967679, 1, '84.63.44.159', 'sticky', 'a:1:{s:5:\"topic\";i:6;}');
# --------------------------------------------------------

#
# Dumping data in `smf_scato_log_activity`
#

INSERT INTO `smf_scato_log_activity`
	(`date`, `hits`, `topics`, `posts`, `registers`, `mostOn`)
VALUES ('2006-09-10', 0, 1, 2, 1, 3),
	('2006-09-11', 0, 5, 14, 3, 5);
# --------------------------------------------------------

#
# Dumping data in `smf_scato_log_boards`
#

INSERT INTO `smf_scato_log_boards`
	(`ID_MEMBER`, `ID_BOARD`, `ID_MSG`)
VALUES (1, 11, 17),
	(2, 11, 9),
	(3, 11, 9),
	(4, 11, 5),
	(2, 7, 17),
	(1, 7, 17),
	(3, 7, 13),
	(1, 8, 17),
	(2, 8, 15),
	(2, 4, 15);
# --------------------------------------------------------

#
# Dumping data in `smf_scato_log_floodcontrol`
#

INSERT INTO `smf_scato_log_floodcontrol`
	(`ip`, `logTime`)
VALUES ('64.107.155.201', 1157969930);
# --------------------------------------------------------

#
# Dumping data in `smf_scato_log_karma`
#

INSERT INTO `smf_scato_log_karma`
	(`ID_TARGET`, `ID_EXECUTOR`, `logTime`, `action`)
VALUES (2, 1, 1157962494, 1);
# --------------------------------------------------------

#
# Dumping data in `smf_scato_log_notify`
#

INSERT INTO `smf_scato_log_notify`
	(`ID_MEMBER`, `ID_TOPIC`, `ID_BOARD`, `sent`)
VALUES (1, 2, 0, 0),
	(3, 2, 0, 0),
	(1, 3, 0, 0),
	(1, 5, 0, 0),
	(1, 6, 0, 0),
	(1, 7, 0, 0);
# --------------------------------------------------------

#
# Dumping data in `smf_scato_log_online`
#

INSERT INTO `smf_scato_log_online`
	(`session`, `logTime`, `ID_MEMBER`, `ip`, `url`)
VALUES ('ip65.54.188.29', 20060911121902, 0, 1094106141, 'a:4:{s:5:\"board\";s:0:\"\";s:5:\"topic\";s:0:\"\";s:6:\"action\";s:0:\"\";s:10:\"USER_AGENT\";s:46:\"msnbot/1.0 (+http://search.msn.com/msnbot.htm)\";}'),
	('3f37e869412e9c9fff19bfa6e842bb34', 20060911122830, 1, 1413426335, 'a:4:{s:4:\"data\";s:2:\"on\";s:8:\"compress\";s:4:\"gzip\";s:6:\"action\";s:6:\"dumpdb\";s:10:\"USER_AGENT\";s:87:\"Mozilla/5.0 (Windows; U; Windows NT 5.1; de; rv:1.8.0.6) Gecko/20060728 Firefox/1.5.0.6\";}'),
	('ip64.107.155.201', 20060911121851, 0, 1080794057, 'a:5:{s:5:\"board\";s:0:\"\";s:6:\"action\";s:0:\"\";s:5:\"title\";s:19:\"Neues Thema starten\";s:5:\"topic\";s:0:\"\";s:10:\"USER_AGENT\";s:50:\"Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0)\";}');
# --------------------------------------------------------

#
# Dumping data in `smf_scato_log_polls`
#

INSERT INTO `smf_scato_log_polls`
	(`ID_POLL`, `ID_MEMBER`, `ID_CHOICE`)
VALUES (1, 1, 1),
	(1, 2, 2),
	(1, 4, 2);
# --------------------------------------------------------

#
# Dumping data in `smf_scato_log_search_subjects`
#

INSERT INTO `smf_scato_log_search_subjects`
	(`word`, `ID_TOPIC`)
VALUES ('2007-2008', 4),
	('die', 5),
	('erk', 3),
	('ideen-sammlung', 6),
	('locations', 7),
	('lustige', 6),
	('neue', 5),
	('scato-homepage', 5),
	('schulferien', 4),
	('semesterzeiten', 4),
	('und', 4),
	('willkommen', 2);
# --------------------------------------------------------

#
# Dumping data in `smf_scato_log_topics`
#

INSERT INTO `smf_scato_log_topics`
	(`ID_MEMBER`, `ID_TOPIC`, `ID_MSG`)
VALUES (1, 2, 17),
	(2, 2, 8),
	(3, 2, 10),
	(4, 2, 6),
	(2, 3, 17),
	(1, 3, 13),
	(3, 3, 11),
	(2, 4, 13),
	(3, 4, 13),
	(1, 4, 13),
	(1, 5, 15),
	(1, 6, 15),
	(2, 5, 15),
	(2, 6, 15),
	(1, 7, 17),
	(2, 7, 18);
# --------------------------------------------------------

#
# Dumping data in `smf_scato_membergroups`
#

INSERT INTO `smf_scato_membergroups`
	(`ID_GROUP`, `groupName`, `onlineColor`, `minPosts`, `maxMessages`, `stars`)
VALUES (1, 'Administrator', '#FF0000', -1, 0, '5#staradmin.gif'),
	(2, 'Global Moderator', '#0000FF', -1, 0, '5#starmod.gif'),
	(3, 'Moderator', '', -1, 0, '4#starmod.gif'),
	(4, 'Fremder', '', 0, 0, '1#star.gif'),
	(5, 'Schon mal gesehen', '', 50, 0, '2#star.gif'),
	(6, 'Freund', '', 100, 0, '3#star.gif'),
	(7, 'Einheimischer', '', 250, 0, '4#star.gif'),
	(8, 'Hat zuviel Zeit!', '', 500, 0, '5#star.gif'),
	(9, 'Spielleitung/Orga', '', -1, 0, '3#stargmod.gif'),
	(10, 'NSC', '', -1, 0, '1#stargmod.gif'),
	(11, 'Veteran', '', -1, 0, '1#stargmod.gif');
# --------------------------------------------------------

#
# Dumping data in `smf_scato_members`
#

INSERT INTO `smf_scato_members`
	(`ID_MEMBER`, `memberName`, `dateRegistered`, `posts`, `ID_GROUP`, `lngfile`, `lastLogin`, `realName`, `instantMessages`, `unreadMessages`, `buddy_list`, `pm_ignore_list`, `messageLabels`, `passwd`, `emailAddress`, `personalText`, `gender`, `birthdate`, `websiteTitle`, `websiteUrl`, `location`, `ICQ`, `AIM`, `YIM`, `MSN`, `hideEmail`, `showOnline`, `timeFormat`, `signature`, `timeOffset`, `avatar`, `pm_email_notify`, `karmaBad`, `karmaGood`, `usertitle`, `notifyAnnouncements`, `notifyOnce`, `notifySendBody`, `notifyTypes`, `memberIP`, `memberIP2`, `secretQuestion`, `secretAnswer`, `ID_THEME`, `is_activated`, `validation_code`, `ID_MSG_LAST_VISIT`, `additionalGroups`, `smileySet`, `ID_POST_GROUP`, `totalTimeLoggedIn`, `passwordSalt`)
VALUES (1, 'bdornauf', 1157889397, 5, 1, 'german', 1157970475, 'Bastian', 1, 0, '', '', '', 'ddd59e48bf0cf6a80c4256e1c4494452ef48bd4f', 'koch@bastian-dornauf.de', '', 1, '1977-01-22', '', '', 'Bonn', '', '', '', '', 1, 1, '', '-- <br />Nimm an, was nützlich ist. Lass weg, was unnütz ist. Und füge das hinzu, was dein Eigenes ist.<br /><br />(Bruce Lee)', 0, '', 0, 0, 0, 'Spielleitung/Orga', 1, 1, 0, 2, '84.63.44.159', '84.63.44.159', '', '', 0, 1, '', 5, 9, '', 4, 12493, 2974),
	(2, 'Narrman', 1157918630, 6, 9, 'german', 1157969504, 'Narrman', 0, 0, '', '', '', '48367309efc8e97e89bdabb0e57cfdaf4a7aa517', 'norman@scato.de', '', 1, '1978-01-29', '', '', 'Aachen', 238757229, 'Silberfischesser', '', 'namnamreramnon@hotmail.com', 1, 1, '', '&quot;Man könnte viele Beispiele für unsinnige Ausgaben nennen, aber keines ist treffender als die Errichtung einer Friedhofsmauer. Die, die drinnen sind, können sowieso nicht hinaus, und die, die draußen sind, wollen nicht hinein.&quot;<br />Mark Twain', 0, '', 1, 0, 1, 'Plot und Magie', 1, 1, 0, 2, '134.130.144.41', '134.130.144.41', '', '', 0, 1, '', 7, 2, '', 4, 4707, 'dc12'),
	(3, 'Kerowyn', 1157956212, 4, 9, 'german', 1157966308, 'Kerowyn', 0, 0, '', '', '', '53c10d850fdd1f6104ebc44faa978e2a84a7cf20', 'Ute@geekgirls.de', '', 2, '1977-11-22', 'Ha Psi gleich E Psi', 'http://blog.geekgirls.de/Lessa/', 'Aachen', '', '', '', '', 1, 1, '%d-%m-%Y, %H:%M:%S', '', 0, '', 1, 0, 1, '', 1, 0, 1, 1, '134.94.82.89', '134.94.82.89', 'Mädchenname der Mutter', '49af63bda9a5dc50cf5d8dcbfab3f363', 0, 1, '', 5, '', '', 4, 3941, '70d5'),
	(4, 'Alex', 1157957654, 1, 9, 'german', 1157958052, 'Alex', 0, 0, '', '', '', 'b0dc025c8f9a391057c39ee8201c4cf315ce8eea', 'a_briemle@web.de', '', 2, '1980-09-25', '', '', '', '', '', '', '', 1, 1, '', '', 0, '', 1, 0, 0, '', 1, 1, 0, 2, '134.130.97.9', '134.130.97.9', '', '', 0, 1, '', 4, '', '', 4, 76, '8cd6'),
	(5, 'Doc', 1157960602, 0, 9, 'german', 0, 'Doc', 0, 0, '', '', '', '3567b9b7f9d0ee08ee60558337152896c7636cf1', 'doc@scato.de', '', 0, '0001-01-01', '', '', '', '', '', '', '', 0, 1, '', '', 0, '', 1, 0, 0, '', 1, 1, 0, 2, '84.63.9.0', '84.63.9.0', '', '', 0, 1, '', 0, '', '', 4, 0, 'd3af');
# --------------------------------------------------------

#
# Dumping data in `smf_scato_message_icons`
#

INSERT INTO `smf_scato_message_icons`
	(`ID_ICON`, `title`, `filename`, `ID_BOARD`, `iconOrder`)
VALUES (1, 'Standard', 'xx', 0, 0),
	(2, 'Thumb Up', 'thumbup', 0, 1),
	(3, 'Thumb Down', 'thumbdown', 0, 2),
	(4, 'Exclamation point', 'exclamation', 0, 3),
	(5, 'Question mark', 'question', 0, 4),
	(6, 'Lamp', 'lamp', 0, 5),
	(7, 'Smiley', 'smiley', 0, 6),
	(8, 'Angry', 'angry', 0, 7),
	(9, 'Cheesy', 'cheesy', 0, 8),
	(10, 'Grin', 'grin', 0, 9),
	(11, 'Sad', 'sad', 0, 10),
	(12, 'Wink', 'wink', 0, 11);
# --------------------------------------------------------

#
# Dumping data in `smf_scato_messages`
#

INSERT INTO `smf_scato_messages`
	(`ID_MSG`, `ID_TOPIC`, `ID_BOARD`, `posterTime`, `ID_MEMBER`, `ID_MSG_MODIFIED`, `subject`, `posterName`, `posterEmail`, `posterIP`, `smileysEnabled`, `modifiedTime`, `modifiedName`, `body`, `icon`)
VALUES (2, 2, 11, 1157919018, 1, 2, 'Willkommen!', 'bdornauf', 'koch@bastian-dornauf.de', '84.63.50.57', 1, 0, '', 'Ich bin erster! Muuaahaahaa!&nbsp; :D', 'xx'),
	(3, 2, 11, 1157919303, 2, 3, 'Re: Willkommen!', 'Narrman', 'norman@scato.de', '89.52.157.225', 1, 0, '', 'Zwoiter!', 'xx'),
	(4, 2, 11, 1157956278, 3, 4, 'Re: Willkommen!', 'Kerowyn', 'Ute@geekgirls.de', '134.94.82.89', 1, 0, '', 'Ich bin jetzt auch drin. Bekomme ich jetzt Mod-Rechte?', 'xx'),
	(5, 2, 11, 1157957961, 4, 5, 'Re: Willkommen!', 'Alex', 'a_briemle@web.de', '134.130.97.9', 1, 0, '', 'Bin auch da!!!', 'xx'),
	(6, 2, 11, 1157958591, 3, 6, 'Re: Willkommen!', 'Kerowyn', 'Ute@geekgirls.de', '134.94.82.89', 1, 0, '', 'Schon besser, jetzt fühle ich mich auch gleich richtig wichtig! *bg*', 'xx'),
	(7, 2, 11, 1157958880, 3, 7, 'Re: Willkommen!', 'Kerowyn', 'Ute@geekgirls.de', '134.94.82.89', 1, 0, '', 'Und bevor ich es vergesse: Basti du bist der Beste, sogar die Seite schon relauncht. Sieht super aus.<br /><br />Und toi toi toi für dein Vorstellungsgespräch heute.', 'xx'),
	(8, 2, 11, 1157960002, 2, 8, 'Re: Willkommen!', 'Narrman', 'norman@scato.de', '134.130.144.41', 1, 0, '', 'Sieht echt aus, als könne man damit arbeiten!&nbsp; ;D<br /><br />Jetzt muss das ganze nur noch gefüllt werden mit Inhalt...', 'xx'),
	(9, 2, 11, 1157960167, 3, 9, 'Re: Willkommen!', 'Kerowyn', 'Ute@geekgirls.de', '134.94.82.89', 1, 0, '', 'Ich habe auch schon beschlossen, dass ich heute eher weniger Arbeiten und dafür mehr tippen werde. Mich juckt es sowas von in den Fingern... ;D<br /><br />Und wenn ich gleich meinen Plichtteil (Vortrag vorbereiten) für heute erledigt habe, werde ich mal schauen was man der Webseite so an sinnvollem Inhalt hinzufügen könnte.', 'xx'),
	(10, 3, 7, 1157960423, 2, 10, 'Erk', 'Narrman', 'norman@scato.de', '134.130.144.41', 1, 0, '', 'Erk habe ich gestern telefonisch erreicht. Ich werd ihm mal den Link zu dem Forum hier durchgeben, damit er mitreden kann. Mit email ist im Moment etwas schlecht, er meinte aber, solange keiner Spam oder &quot;Pornos&quot; über den Verteiler schickt, könne man auch seine Arbeitsadresse nutzen.<br />Auf jeden Fall wäre er wieder dabei, gerne auch als SL, ungerne allerdings in irgendeeiner Weise an Auf- oder Abbau beteiligt. Nachdem er mir auf dem Scato 9 merhmals Europalletten auf den Fuß geworfen hat, kann ich nur raten, diese Konditzionen anzunehmen. ;)<br />Nein, im Ernst halte ich das für eine praktikable Lösung, und es wird sich schon etwas finden, was man ihm als Ausgleich aufs Auge drücken kann, damit niemand jammern kann, die Aufgaben wären ungerecht verteilt.', 'xx'),
	(11, 3, 7, 1157960821, 1, 11, 'Re: Erk', 'bdornauf', 'koch@bastian-dornauf.de', '84.63.50.57', 1, 0, '', 'Agree. Ich freu mich<br /><br />Keinen Spam kann ich nicht versprechen... es gibt aber ne neuer Adresse für den Verteiler, die relativ sicher sein sollte, solange die keiner von uns irgendwohin schreibt.', 'xx'),
	(12, 3, 7, 1157963049, 2, 12, 'Re: Erk', 'Narrman', 'norman@scato.de', '134.130.144.41', 1, 0, '', 'Na ich hoffe, wie man mit Emails umgeht wissen mitlerweile alle...&nbsp; ::)', 'xx'),
	(13, 4, 7, 1157964734, 2, 13, 'Semesterzeiten und Schulferien 2007-2008', 'Narrman', 'norman@scato.de', '134.130.144.41', 1, 0, '', '[b]Semester[/b]<br />Wintersemester 2007/08: 15.10.2007 - 8.2.2008<br />Sommersemester 2008: 7.4.2008 - 18.7.2008<br /><br />[b]Schulferien[/b]<br /><br />Sommer<br />Donnerstag, 21. Juni 2007 - Freitag, 3. August 2007<br /><br />Herbst<br />Montag, 24. September 2007 - Samstag, 6. Oktober 2007<br /><br />Weihnachten	<br />Donnerstag, 20. Dezember 2007 - Freitag, 4. Januar 2008<br /><br />Ostern<br />Montag, 17. März 2008 - Samstag, 29. März 2008<br /><br />Pfingsten<br />Dienstag, 13. Mai 2008<br /><br />[b]Sonstige (bewegliche)Ferientage:[/b]<br /><br />Montag, 4. Februar 2008 (Rosenmontag)<br />Dienstag, 5. Februar 2008 (Fastnachtsdienstag)<br />Montag, 31. März 2008 (Verlängerung der Osterferien)<br />Mittwoch, 14. Mai 2008 (Verlängerung der Pfingstferien)<br /><br />[b]Feiertage[/b]<br />Mi.	03.10.2007	Tag der Deutschen Einheit<br />Do.	01.11.2007	Allerheiligen<br /><br />Di.	01.01.2008	Neujahr<br />Fr.	21.03.2008	Karfreitag<br />Mo.	24.03.2008	Ostermontag<br />Do.	01.05.2008	Maifeiertag<br />Do.	01.05.2008	Christi Himmelfahrt<br />Mo.	12.05.2008	Pfingstmontag<br />Do.	22.05.2008	Fronleichnam<br />Fr.	03.10.2008	Tag der Deutschen Einheit<br />Sa.	01.11.2008	Allerheiligen<br />Do.	25.12.2008	1. Weihnachtstag<br />Fr.	26.12.2008	2. Weihnachtstag', 'xx'),
	(14, 5, 7, 1157966530, 1, 14, 'die neue Scato-Homepage', 'bdornauf', 'koch@bastian-dornauf.de', '84.63.44.159', 1, 0, '', 'Wie schon angedeutet ist sie eingerichtet - aber weit weg von fertig. Wer möchte darf auch hier gerne mitarbeiten, da es sich um ein [url=http://de.wikipedia.org/wiki/Content-Management-System]CMS[/url] handelt, kann jeder übers Netz ohne allzu große Fähigkeiten erwerben zu müssen Artikel schreiben und ggfs. veröffentlichen.<br /><br />Also, anmelden, und mich anmailen, ob ich da Autoren-Rechte vergeben soll. <br /><br />Hilfestellung wird Ute oder ich geben können, aber für mich zumindest ist die ganze Maschine auch noch recht neu. Ansonsten im Internet finden sich auch Anleitungen, zumbeispiel unter [url=http://joomlaos.de]http://joomlaos.de[/url]<br /><br />So, falls das noch unklar ist, ihr findet Sie natürlich unter<br />[url=http://www.scato.de]http://www.scato.de[/url]<br />oder direkt<br />[url=http://cms.scato.de]http://cms.scato.de[/url]', 'xx'),
	(15, 6, 8, 1157966774, 1, 15, 'Lustige Ideen-Sammlung', 'bdornauf', 'koch@bastian-dornauf.de', '84.63.44.159', 1, 0, '', 'Wie solls gehen:<br />[list]<br />[li]hier kommen Ideen rein[/li]<br />[li]die werden [b]hier[/b] nicht kommentiert[/li]<br />[li]dafür darfst du aber natürlich einen eigenen Thread eröffnen[/li]<br />[li]ansonsten ist jede Anregung, Kritik, Lücke, Unzulänglichkeit hier richtig, sofern sie was mit dem Regelwerk zu tun hat.[/li]<br />[/list]', 'xx'),
	(16, 7, 7, 1157969162, 1, 16, 'Locations', 'bdornauf', 'koch@bastian-dornauf.de', '84.63.44.159', 1, 0, '', 'Hier Vorschläge für Locations reinposten. Auch hier gilt: nicht diskutieren! Die Location sollte kurz beschrieben werden...<br /><br />Sie muss nicht unbedingt für den nächsten 10.000-Mann-Con geeignet sein, wir machen ja vielleicht auch mal andere Sachen (Hoffnung nicht aufgeb ;) )', 'xx'),
	(17, 7, 7, 1157969504, 2, 17, 'Re: Locations', 'Narrman', 'norman@scato.de', '134.130.144.41', 1, 0, '', 'http://www.haus-hoher-hagen.de/<br /><br />Sehr süßes lauschiges Häusle bei Göttinge. Für kleine Cons geeignet. ca. 40 Hausplätze und bedingte Zeltmöglichkeiten. Sieht meiner Meinung nach sehr geil aus.', 'xx');
# --------------------------------------------------------

#
# Dumping data in `smf_scato_moderators`
#

INSERT INTO `smf_scato_moderators`
	(`ID_BOARD`, `ID_MEMBER`)
VALUES (4, 3),
	(5, 3),
	(6, 5),
	(7, 3),
	(8, 1),
	(8, 2),
	(9, 1),
	(9, 2),
	(10, 1),
	(10, 2);
# --------------------------------------------------------

#
# Dumping data in `smf_scato_package_servers`
#

INSERT INTO `smf_scato_package_servers`
	(`ID_SERVER`, `name`, `url`)
VALUES (1, 'Simple Machines Third-party Mod Site', 'http://mods.simplemachines.org');
# --------------------------------------------------------

#
# Dumping data in `smf_scato_permissions`
#

INSERT INTO `smf_scato_permissions`
	(`ID_GROUP`, `permission`, `addDeny`)
VALUES (-1, 'search_posts', 1),
	(-1, 'calendar_view', 1),
	(-1, 'view_stats', 1),
	(-1, 'profile_view_any', 1),
	(0, 'view_mlist', 1),
	(0, 'search_posts', 1),
	(0, 'profile_view_own', 1),
	(0, 'profile_view_any', 1),
	(0, 'pm_read', 1),
	(0, 'pm_send', 1),
	(0, 'calendar_view', 1),
	(0, 'view_stats', 1),
	(0, 'who_view', 1),
	(0, 'profile_identity_own', 1),
	(0, 'profile_extra_own', 1),
	(0, 'profile_remove_own', 1),
	(0, 'profile_server_avatar', 1),
	(0, 'profile_upload_avatar', 1),
	(0, 'profile_remote_avatar', 1),
	(0, 'karma_edit', 1),
	(2, 'view_mlist', 1),
	(2, 'search_posts', 1),
	(2, 'profile_view_own', 1),
	(2, 'profile_view_any', 1),
	(2, 'pm_read', 1),
	(2, 'pm_send', 1),
	(2, 'calendar_view', 1),
	(2, 'view_stats', 1),
	(2, 'who_view', 1),
	(2, 'profile_identity_own', 1),
	(2, 'profile_extra_own', 1),
	(2, 'profile_remove_own', 1),
	(2, 'profile_server_avatar', 1),
	(2, 'profile_upload_avatar', 1),
	(2, 'profile_remote_avatar', 1),
	(2, 'profile_title_own', 1),
	(2, 'calendar_post', 1),
	(2, 'calendar_edit_any', 1),
	(2, 'karma_edit', 1),
	(9, 'search_posts', 1),
	(9, 'calendar_view', 1),
	(9, 'view_stats', 1),
	(9, 'who_view', 1),
	(9, 'profile_view_own', 1),
	(9, 'profile_identity_own', 1),
	(9, 'view_mlist', 1),
	(9, 'karma_edit', 1),
	(9, 'pm_read', 1),
	(9, 'pm_send', 1),
	(9, 'profile_view_any', 1),
	(9, 'profile_extra_own', 1),
	(9, 'profile_server_avatar', 1),
	(9, 'profile_upload_avatar', 1),
	(9, 'profile_remote_avatar', 1),
	(9, 'profile_remove_own', 1),
	(10, 'calendar_view', 1),
	(10, 'karma_edit', 1),
	(10, 'pm_read', 1),
	(10, 'pm_send', 1),
	(10, 'profile_extra_own', 1),
	(10, 'profile_identity_own', 1),
	(10, 'profile_remote_avatar', 1),
	(10, 'profile_remove_own', 1),
	(10, 'profile_server_avatar', 1),
	(10, 'profile_upload_avatar', 1),
	(10, 'profile_view_any', 1),
	(10, 'profile_view_own', 1),
	(10, 'search_posts', 1),
	(10, 'view_mlist', 1),
	(10, 'view_stats', 1),
	(10, 'who_view', 1),
	(11, 'calendar_view', 1),
	(11, 'karma_edit', 1),
	(11, 'pm_read', 1),
	(11, 'pm_send', 1),
	(11, 'profile_extra_own', 1),
	(11, 'profile_identity_own', 1),
	(11, 'profile_remote_avatar', 1),
	(11, 'profile_remove_own', 1),
	(11, 'profile_server_avatar', 1),
	(11, 'profile_upload_avatar', 1),
	(11, 'profile_view_any', 1),
	(11, 'profile_view_own', 1),
	(11, 'search_posts', 1),
	(11, 'view_mlist', 1),
	(11, 'view_stats', 1),
	(11, 'who_view', 1),
	(2, 'manage_boards', 1),
	(9, 'edit_news', 1),
	(2, 'send_mail', 1);
# --------------------------------------------------------

#
# Dumping data in `smf_scato_personal_messages`
#

INSERT INTO `smf_scato_personal_messages`
	(`ID_PM`, `ID_MEMBER_FROM`, `deletedBySender`, `fromName`, `msgtime`, `subject`, `body`)
VALUES (2, 3, 1, 'Kerowyn', 1157959685, 'Re: (Kein Betreff)', '[quote author=Bastian link=action=profile;u=1 date=1157959056]<br />Du bist jetz mal Mod in<br /> Allgemeines - Ankündigungen<br />&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; - LARP<br /> SL - Allgemein<br /><br />Im NSC-Bereich hätte ich gern den Doc als Mod, im Hintergrund den Jens etc.[/quote]<br /><br />Ist sinnvoll.<br /><br />[quote author=Bastian link=action=profile;u=1 date=1157959056]GlobalMod ist der Norman, da hätte ich gerne nur einen, wenn alles klappt.<br />Schauen wir mal.[/quote]<br /><br />Auch sinnvoll. Notfalls kann man da ja nach und nach mehr Leute einsetzen.<br /><br />[quote author=Bastian link=action=profile;u=1 date=1157959056]ah ... www.scato.de ist updatet, da kannstu dich auch anmelden. Das CMS heißt JOOMLA - docu ist eher mau, aber ich hab schon was deutsches für den start gefunden, was geht, ne englische gibts auch ... sonst foren[/quote]<br /><br />Habe ich schon gesehen. Sieht gut aus, evtl. kann man da noch etwas am Design feilen. Und der Rest wird sich von selbst fügen. WIe ich im Forum schon schrieb: Du bist der Beste!');
# --------------------------------------------------------

#
# Dumping data in `smf_scato_pm_recipients`
#

INSERT INTO `smf_scato_pm_recipients`
	(`ID_PM`, `ID_MEMBER`, `labels`, `bcc`, `is_read`, `deleted`)
VALUES (2, 1, -1, 0, 1, 0);
# --------------------------------------------------------

#
# Dumping data in `smf_scato_poll_choices`
#

INSERT INTO `smf_scato_poll_choices`
	(`ID_POLL`, `ID_CHOICE`, `label`, `votes`)
VALUES (1, 0, 'Hund', 0),
	(1, 1, 'Auch', 1),
	(1, 2, 'Zwei davon', 2),
	(1, 3, 'Mama', 0),
	(1, 4, 'Wer?', 0);
# --------------------------------------------------------

#
# Dumping data in `smf_scato_polls`
#

INSERT INTO `smf_scato_polls`
	(`ID_POLL`, `question`, `votingLocked`, `maxVotes`, `expireTime`, `hideResults`, `changeVote`, `ID_MEMBER`, `posterName`)
VALUES (1, 'Was ist größer?', 0, 1, 1158524216, 0, 0, 2, 'Narrman');
# --------------------------------------------------------

#
# Dumping data in `smf_scato_sessions`
#

INSERT INTO `smf_scato_sessions`
	(`session_id`, `last_update`, `data`)
VALUES ('68462070871b00c797d5a0ff5fea44cb', 1157969510, 'rand_code|s:32:\"6b7c7da900db7ef05428e37d08b5ec7e\";ID_MSG_LAST_VISIT|s:1:\"5\";log_time|i:1157969508;timeOnlineUpdated|i:1157969508;unread_messages|i:0;old_url|s:44:\"http://forumneu.scato.de/index.php?topic=7.0\";USER_AGENT|s:87:\"Mozilla/5.0 (Windows; U; Windows NT 5.1; de; rv:1.8.0.6) Gecko/20060728 Firefox/1.5.0.6\";temp_attachments|a:0:{}forms|a:1:{i:0;i:13293867;}last_read_topic|i:7;'),
	('18d6e704555cb8326b66ecf2bbeeee6f', 1157969521, 'rand_code|s:32:\"555c2e0e2b64060099e2f0777485cf4a\";ID_MSG_LAST_VISIT|s:1:\"7\";ban|a:5:{s:12:\"last_checked\";i:1157969521;s:9:\"ID_MEMBER\";s:1:\"2\";s:2:\"ip\";s:14:\"134.130.144.41\";s:3:\"ip2\";s:14:\"134.130.144.41\";s:5:\"email\";s:15:\"norman@scato.de\";}log_time|i:1157969514;timeOnlineUpdated|i:1157969504;unread_messages|i:0;old_url|s:34:\"http://forumneu.scato.de/index.php\";USER_AGENT|s:87:\"Mozilla/5.0 (Windows; U; Windows NT 5.0; de; rv:1.8.0.6) Gecko/20060728 Firefox/1.5.0.6\";last_read_topic|i:3;temp_attachments|a:0:{}forms|a:5:{i:0;i:12176376;i:1;i:12802578;i:2;i:701567;i:3;i:7040411;i:4;i:14170620;}'),
	('24f194192c7a8b06719c49f19f3b2cff', 1157966993, 'rand_code|s:32:\"4f5fd2e166514f7da7449975a527ca5e\";ban|a:5:{s:12:\"last_checked\";i:1157966993;s:9:\"ID_MEMBER\";i:0;s:2:\"ip\";s:12:\"134.94.82.89\";s:3:\"ip2\";s:12:\"134.94.82.89\";s:5:\"email\";s:0:\"\";}log_time|i:1157966993;timeOnlineUpdated|i:1157966993;old_url|s:25:\"http://forumneu.scato.de/\";USER_AGENT|s:87:\"Mozilla/5.0 (Windows; U; Windows NT 5.0; de; rv:1.8.0.6) Gecko/20060728 Firefox/1.5.0.6\";'),
	('e1a7c1e312c0a974ccefbb3a7c2d8030', 1157969931, 'rand_code|s:32:\"6a3b2bd1b5d964496c4a48dd5a7b797e\";log_time|i:1157969931;timeOnlineUpdated|i:1157969918;old_url|s:84:\"http://forumneu.scato.de/index.php?board=7;action=post;title=Neues%2BThema%2Bstarten\";USER_AGENT|s:50:\"Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0)\";ban|a:5:{s:12:\"last_checked\";i:1157969930;s:9:\"ID_MEMBER\";i:0;s:2:\"ip\";s:14:\"64.107.155.201\";s:3:\"ip2\";s:14:\"64.107.155.201\";s:5:\"email\";s:0:\"\";}visual_verification_code|s:5:\"FVNWG\";login_url|s:84:\"http://forumneu.scato.de/index.php?board=7;action=post;title=Neues%2BThema%2Bstarten\";'),
	('e7daafe99d1de373a741041650f84698', 1157969942, 'rand_code|s:32:\"46a41c6dda488640d520a09a4d41bbd8\";log_time|i:1157969942;timeOnlineUpdated|i:1157969942;login_url|s:43:\"http://forumneu.scato.de/index.php?board=16\";old_url|s:43:\"http://forumneu.scato.de/index.php?board=16\";USER_AGENT|s:46:\"msnbot/1.0 (+http://search.msn.com/msnbot.htm)\";'),
	('3f37e869412e9c9fff19bfa6e842bb34', 1157970505, 'rand_code|s:32:\"53f464a5d027a6c2198416600acd3d71\";ID_MSG_LAST_VISIT|s:1:\"5\";log_time|i:1157970500;timeOnlineUpdated|i:1157970475;unread_messages|i:0;old_url|s:50:\"http://forumneu.scato.de/index.php?action=maintain\";USER_AGENT|s:87:\"Mozilla/5.0 (Windows; U; Windows NT 5.1; de; rv:1.8.0.6) Gecko/20060728 Firefox/1.5.0.6\";admin_time|i:1157970243;last_read_topic|i:2;pm_selected|a:0:{}'),
	('81f750fab67031361e153f1b96e337c9', 1157969629, 'rand_code|s:32:\"cf6fcbc1df0b90475213641495d312b4\";ID_MSG_LAST_VISIT|s:1:\"3\";ban|a:5:{s:12:\"last_checked\";i:1157966308;s:9:\"ID_MEMBER\";s:1:\"3\";s:2:\"ip\";s:12:\"134.94.82.89\";s:3:\"ip2\";s:12:\"134.94.82.89\";s:5:\"email\";s:16:\"Ute@geekgirls.de\";}log_time|i:1157966308;timeOnlineUpdated|i:1157966308;unread_messages|i:0;old_url|s:70:\"http://forumneu.scato.de/index.php?action=post;topic=4.0;num_replies=0\";USER_AGENT|s:34:\"Opera/9.01 (Windows NT 5.0; U; de)\";last_read_topic|i:4;language|s:6:\"german\";temp_attachments|a:0:{}forms|a:4:{i:0;i:2042351;i:1;i:7454909;i:2;i:9643891;i:3;i:11407346;}pm_selected|a:0:{}'),
	('c45d9dc5288b2405ff823709c912ca05', 1157968508, 'rand_code|s:32:\"1b66be6756a3ddae82df861a350da1b9\";ID_MSG_LAST_VISIT|s:1:\"3\";log_time|i:1157968507;timeOnlineUpdated|i:1157968507;last_read_topic|i:6;unread_messages|i:0;old_url|s:34:\"http://forumneu.scato.de/index.php\";USER_AGENT|s:87:\"Mozilla/5.0 (Windows; U; Windows NT 5.1; de; rv:1.8.0.6) Gecko/20060728 Firefox/1.5.0.6\";admin_time|i:1157967102;forms|a:4:{i:0;i:9826887;i:1;i:4913438;i:2;i:9220545;i:3;i:2209018;}pm_selected|a:0:{}temp_attachments|a:0:{}');
# --------------------------------------------------------

#
# Dumping data in `smf_scato_settings`
#

INSERT INTO `smf_scato_settings`
	(`variable`, `value`)
VALUES ('smfVersion', '1.1 RC3'),
	('news', 'Wir sind wieder hier!'),
	('compactTopicPagesContiguous', 3),
	('compactTopicPagesEnable', 1),
	('enableStickyTopics', 1),
	('todayMod', 1),
	('karmaMode', 1),
	('karmaTimeRestrictAdmins', 1),
	('enablePreviousNext', 1),
	('pollMode', 1),
	('enableVBStyleLogin', 1),
	('enableCompressedOutput', 1),
	('karmaWaitTime', 1),
	('karmaMinPosts', 0),
	('karmaLabel', 'Karma:'),
	('karmaSmiteLabel', '[smite]'),
	('karmaApplaudLabel', '[applaud]'),
	('attachmentSizeLimit', 128),
	('attachmentPostLimit', 192),
	('attachmentNumPerPostLimit', 1),
	('attachmentDirSizeLimit', 10240),
	('attachmentUploadDir', '/kunden/bastian-dornauf.de/webseiten/www.scato.de/forum_neu.scato.de/attachments'),
	('attachmentExtensions', 'doc,gif,jpg,mpg,pdf,png,txt,zip'),
	('attachmentCheckExtensions', 1),
	('attachmentShowImages', 1),
	('attachmentEnable', 1),
	('attachmentEncryptFilenames', 1),
	('attachmentThumbnails', 1),
	('attachmentThumbWidth', 150),
	('attachmentThumbHeight', 150),
	('censorIgnoreCase', 1),
	('mostOnline', 5),
	('mostOnlineToday', 5),
	('mostDate', 1157963540),
	('allow_disableAnnounce', 1),
	('trackStats', 1),
	('userLanguage', 1),
	('titlesEnable', 1),
	('topicSummaryPosts', 15),
	('enableErrorLogging', 1),
	('max_image_width', 80),
	('max_image_height', 80),
	('onlineEnable', 0),
	('cal_holidaycolor', 000080),
	('cal_bdaycolor', '920AC4'),
	('cal_eventcolor', 078907),
	('cal_enabled', 0),
	('cal_maxyear', 2010),
	('cal_minyear', 2004),
	('cal_daysaslink', 0),
	('cal_defaultboard', ''),
	('cal_showeventsonindex', 0),
	('cal_showbdaysonindex', 0),
	('cal_showholidaysonindex', 0),
	('cal_showeventsoncalendar', 1),
	('cal_showbdaysoncalendar', 1),
	('cal_showholidaysoncalendar', 1),
	('cal_showweeknum', 0),
	('cal_maxspan', 7),
	('smtp_host', ''),
	('smtp_port', 25),
	('smtp_username', ''),
	('smtp_password', ''),
	('mail_type', 0),
	('timeLoadPageEnable', 0),
	('totalTopics', 6),
	('totalMessages', 16),
	('simpleSearch', 0),
	('censor_vulgar', ''),
	('censor_proper', ''),
	('enablePostHTML', 0),
	('theme_allow', 1),
	('theme_default', 1),
	('theme_guests', 1),
	('enableEmbeddedFlash', 0),
	('xmlnews_enable', 1),
	('xmlnews_maxlen', 255),
	('hotTopicPosts', 15),
	('hotTopicVeryPosts', 25),
	('registration_method', 1),
	('send_validation_onChange', 1),
	('send_welcomeEmail', 1),
	('allow_editDisplayName', 1),
	('allow_hideOnline', 1),
	('allow_hideEmail', 1),
	('guest_hideContacts', 1),
	('spamWaitTime', 5),
	('max_pm_recipients', 3),
	('reserveWord', 0),
	('reserveCase', 1),
	('reserveUser', 1),
	('reserveName', 1),
	('reserveNames', 'Admin\nWebmaster\nGuest\nroot\nScato\nIsharian\nJensKlenke\nSL\n\n'),
	('autoLinkUrls', 1),
	('banLastUpdated', 0),
	('smileys_dir', '/kunden/bastian-dornauf.de/webseiten/www.scato.de/forum_neu.scato.de/Smileys'),
	('smileys_url', 'http://forumneu.scato.de/Smileys'),
	('avatar_directory', '/kunden/bastian-dornauf.de/webseiten/www.scato.de/forum_neu.scato.de/avatars'),
	('avatar_url', 'http://forumneu.scato.de/avatars'),
	('avatar_max_height_external', 65),
	('avatar_max_width_external', 65),
	('avatar_action_too_large', 'option_html_resize'),
	('avatar_max_height_upload', 65),
	('avatar_max_width_upload', 65),
	('avatar_resize_upload', 1),
	('avatar_download_png', 1),
	('failed_login_threshold', 3),
	('oldTopicDays', 120),
	('edit_wait_time', 90),
	('edit_disable_time', 0),
	('autoFixDatabase', 1),
	('allow_guestAccess', 1),
	('time_format', '%B %d, %Y, %I:%M:%S %p'),
	('number_format', '1.234,00'),
	('enableBBC', 1),
	('max_messageLength', 20000),
	('max_signatureLength', 300),
	('autoOptDatabase', 7),
	('autoOptMaxOnline', 0),
	('autoOptLastOpt', 1157970502),
	('defaultMaxMessages', 15),
	('defaultMaxTopics', 20),
	('defaultMaxMembers', 30),
	('enableParticipation', 1),
	('recycle_enable', 0),
	('recycle_board', 0),
	('maxMsgID', 17),
	('enableAllMessages', 0),
	('fixLongWords', 0),
	('knownThemes', '1,2,3,4,5,6'),
	('who_enabled', 1),
	('time_offset', 0),
	('cookieTime', 60),
	('lastActive', 15),
	('smiley_sets_known', 'default,classic'),
	('smiley_sets_names', 'Default\nClassic'),
	('smiley_sets_default', 'default'),
	('cal_days_for_index', 7),
	('requireAgreement', 1),
	('unapprovedMembers', 0),
	('default_personalText', ''),
	('package_make_backups', 1),
	('databaseSession_enable', 1),
	('databaseSession_loose', 1),
	('databaseSession_lifetime', 2880),
	('search_cache_size', 50),
	('search_results_per_page', 30),
	('search_weight_frequency', 30),
	('search_weight_age', 25),
	('search_weight_length', 20),
	('search_weight_subject', 15),
	('search_weight_first_message', 10),
	('search_max_results', 1200),
	('permission_enable_deny', 0),
	('permission_enable_postgroups', 0),
	('permission_enable_by_board', 0),
	('memberlist_updated', 1157970372),
	('latestMember', 5),
	('totalMembers', 5),
	('latestRealName', 'Doc'),
	('mostOnlineUpdated', '2006-09-11'),
	('modlog_enabled', 1),
	('notify_new_registration', 1),
	('password_strength', 1),
	('cal_today_updated', 20060911),
	('cal_today_holiday', 'a:0:{}'),
	('cal_today_birthday', 'a:0:{}'),
	('cal_today_event', 'a:0:{}');
# --------------------------------------------------------

#
# Dumping data in `smf_scato_smileys`
#

INSERT INTO `smf_scato_smileys`
	(`ID_SMILEY`, `code`, `filename`, `description`, `smileyRow`, `smileyOrder`, `hidden`)
VALUES (1, ':)', 'smiley.gif', 'Smiley', 0, 0, 0),
	(2, ';)', 'wink.gif', 'Wink', 0, 1, 0),
	(3, ':D', 'cheesy.gif', 'Cheesy', 0, 2, 0),
	(4, ';D', 'grin.gif', 'Grin', 0, 3, 0),
	(5, '>:(', 'angry.gif', 'Angry', 0, 4, 0),
	(6, ':(', 'sad.gif', 'Sad', 0, 5, 0),
	(7, ':o', 'shocked.gif', 'Shocked', 0, 6, 0),
	(8, '8)', 'cool.gif', 'Cool', 0, 7, 0),
	(9, '???', 'huh.gif', 'Huh?', 0, 8, 0),
	(10, '::)', 'rolleyes.gif', 'Roll Eyes', 0, 9, 0),
	(11, ':P', 'tongue.gif', 'Tongue', 0, 10, 0),
	(12, ':-[', 'embarrassed.gif', 'Embarrassed', 0, 11, 0),
	(13, ':-X', 'lipsrsealed.gif', 'Lips Sealed', 0, 12, 0),
	(14, ':-\\', 'undecided.gif', 'Undecided', 0, 13, 0),
	(15, ':-*', 'kiss.gif', 'Kiss', 0, 14, 0),
	(16, ':\'(', 'cry.gif', 'Cry', 0, 15, 0),
	(17, '>:D', 'evil.gif', 'Evil', 0, 16, 1),
	(18, '^-^', 'azn.gif', 'Azn', 0, 17, 1),
	(19, 'O0', 'afro.gif', 'Afro', 0, 18, 1);
# --------------------------------------------------------

#
# Dumping data in `smf_scato_themes`
#

INSERT INTO `smf_scato_themes`
	(`ID_MEMBER`, `ID_THEME`, `variable`, `value`)
VALUES (0, 1, 'name', 'SMF Default Theme - Core'),
	(0, 1, 'theme_url', 'http://forumneu.scato.de/Themes/default'),
	(0, 1, 'images_url', 'http://forumneu.scato.de/Themes/default/images'),
	(0, 1, 'theme_dir', '/kunden/bastian-dornauf.de/webseiten/www.scato.de/forum_neu.scato.de/Themes/default'),
	(0, 1, 'show_bbc', 1),
	(0, 1, 'show_latest_member', 1),
	(0, 1, 'show_modify', 1),
	(0, 1, 'show_user_images', 1),
	(0, 1, 'show_blurb', 1),
	(0, 1, 'show_gender', 0),
	(0, 1, 'show_newsfader', 0),
	(0, 1, 'number_recent_posts', 0),
	(0, 1, 'show_member_bar', 1),
	(0, 1, 'linktree_link', 1),
	(0, 1, 'show_profile_buttons', 1),
	(0, 1, 'show_mark_read', 1),
	(0, 1, 'show_sp1_info', 1),
	(0, 1, 'linktree_inline', 0),
	(0, 1, 'show_board_desc', 1),
	(0, 1, 'newsfader_time', 5000),
	(0, 1, 'allow_no_censored', 0),
	(0, 1, 'additional_options_collapsable', 1),
	(0, 1, 'use_image_buttons', 1),
	(0, 1, 'enable_news', 1),
	(0, 2, 'name', 'Classic YaBB SE Theme'),
	(0, 2, 'theme_url', 'http://forumneu.scato.de/Themes/classic'),
	(0, 2, 'images_url', 'http://forumneu.scato.de/Themes/classic/images'),
	(0, 2, 'theme_dir', '/kunden/bastian-dornauf.de/webseiten/www.scato.de/forum_neu.scato.de/Themes/classic'),
	(0, 3, 'name', 'Babylon Theme'),
	(0, 3, 'theme_url', 'http://forumneu.scato.de/Themes/babylon'),
	(0, 3, 'images_url', 'http://forumneu.scato.de/Themes/babylon/images'),
	(0, 3, 'theme_dir', '/kunden/bastian-dornauf.de/webseiten/www.scato.de/forum_neu.scato.de/Themes/babylon'),
	(0, 4, 'theme_url', 'http://forumneu.scato.de/Themes/manuscript_11rc2'),
	(0, 4, 'images_url', 'http://forumneu.scato.de/Themes/manuscript_11rc2/images'),
	(0, 4, 'theme_dir', '/kunden/bastian-dornauf.de/webseiten/www.scato.de/forum_neu.scato.de/Themes/manuscript_11rc2'),
	(0, 4, 'name', 'Manuscript'),
	(0, 4, 'theme_layers', 'main'),
	(0, 4, 'theme_templates', 'index'),
	(0, 5, 'theme_url', 'http://forumneu.scato.de/Themes/arcane_magic'),
	(0, 5, 'images_url', 'http://forumneu.scato.de/Themes/arcane_magic/images'),
	(0, 5, 'theme_dir', '/kunden/bastian-dornauf.de/webseiten/www.scato.de/forum_neu.scato.de/Themes/arcane_magic'),
	(0, 5, 'name', 'Arcane Magic'),
	(0, 5, 'theme_layers', 'main'),
	(0, 5, 'theme_templates', 'index'),
	(0, 6, 'theme_url', 'http://forumneu.scato.de/Themes/smf_arobase_up'),
	(0, 6, 'images_url', 'http://forumneu.scato.de/Themes/smf_arobase_up/german'),
	(0, 6, 'theme_dir', '/kunden/bastian-dornauf.de/webseiten/www.scato.de/forum_neu.scato.de/Themes/smf_arobase_up'),
	(0, 6, 'name', 'Arobase Skin'),
	(0, 6, 'theme_layers', 'main'),
	(0, 6, 'theme_templates', 'index'),
	(0, 6, 'header_logo_url', ''),
	(0, 6, 'number_recent_posts', 0),
	(0, 6, 'display_who_viewing', 0),
	(0, 6, 'smiley_sets_default', ''),
	(0, 6, 'show_modify', 1),
	(0, 6, 'show_member_bar', 1),
	(0, 6, 'linktree_link', 1),
	(0, 6, 'show_profile_buttons', 1),
	(0, 6, 'show_mark_read', 1),
	(0, 6, 'linktree_inline', 0),
	(0, 6, 'show_sp1_info', 1),
	(0, 6, 'allow_no_censored', 0),
	(0, 6, 'show_bbc', 1),
	(0, 6, 'additional_options_collapsable', 1),
	(0, 6, 'enable_news', 1),
	(0, 6, 'show_newsfader', 0),
	(0, 6, 'newsfader_time', 5000),
	(0, 6, 'show_user_images', 1),
	(0, 6, 'show_blurb', 1),
	(0, 6, 'show_latest_member', 1),
	(0, 6, 'use_image_buttons', 1),
	(0, 6, 'show_gender', 0),
	(0, 6, 'hide_post_group', 0),
	(1, 1, 'show_board_desc', 0),
	(1, 1, 'show_children', 0),
	(1, 1, 'show_no_avatars', 0),
	(1, 1, 'show_no_signatures', 0),
	(1, 1, 'return_to_post', 0),
	(1, 1, 'no_new_reply_warning', 0),
	(1, 1, 'view_newest_first', 0),
	(1, 1, 'view_newest_pm_first', 0),
	(1, 1, 'calendar_start_day', 0),
	(1, 1, 'display_quick_reply', 0),
	(1, 1, 'display_quick_mod', 0),
	(1, 1, 'auto_notify', 1),
	(1, 1, 'collapse_header', 1),
	(3, 1, 'auto_notify', 1),
	(4, 1, 'show_board_desc', 0),
	(4, 1, 'show_children', 0),
	(4, 1, 'show_no_avatars', 0),
	(4, 1, 'show_no_signatures', 0),
	(4, 1, 'return_to_post', 1),
	(4, 1, 'no_new_reply_warning', 0),
	(4, 1, 'view_newest_first', 1),
	(4, 1, 'view_newest_pm_first', 1),
	(4, 1, 'calendar_start_day', 1),
	(4, 1, 'display_quick_reply', 0),
	(4, 1, 'display_quick_mod', 0),
	(3, 1, 'show_board_desc', 0),
	(3, 1, 'show_children', 0),
	(3, 1, 'show_no_avatars', 0),
	(3, 1, 'show_no_signatures', 0),
	(3, 1, 'return_to_post', 0),
	(3, 1, 'no_new_reply_warning', 0),
	(3, 1, 'view_newest_first', 0),
	(3, 1, 'view_newest_pm_first', 0),
	(3, 1, 'calendar_start_day', 1),
	(3, 1, 'display_quick_reply', 0),
	(3, 1, 'display_quick_mod', 2),
	(3, 1, 'collapse_header', 1);
# --------------------------------------------------------

#
# Dumping data in `smf_scato_topics`
#

INSERT INTO `smf_scato_topics`
	(`ID_TOPIC`, `isSticky`, `ID_BOARD`, `ID_FIRST_MSG`, `ID_LAST_MSG`, `ID_MEMBER_STARTED`, `ID_MEMBER_UPDATED`, `ID_POLL`, `numReplies`, `numViews`, `locked`)
VALUES (2, 0, 11, 2, 9, 1, 3, 1, 7, 14, 0),
	(3, 0, 7, 10, 12, 2, 2, 0, 2, 6, 0),
	(4, 0, 7, 13, 13, 2, 2, 0, 0, 4, 0),
	(5, 0, 7, 14, 14, 1, 1, 0, 0, 2, 0),
	(6, 1, 8, 15, 15, 1, 1, 0, 0, 2, 0),
	(7, 0, 7, 16, 17, 1, 2, 0, 1, 2, 0);
# --------------------------------------------------------

# Done
