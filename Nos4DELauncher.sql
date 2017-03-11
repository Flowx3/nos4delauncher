/*
Navicat MySQL Data Transfer

Source Server         : 127.0.0.1
Source Server Version : 50554
Source Host           : 127.0.0.1:3306
Source Database       : Nostale

Target Server Type    : MYSQL
Target Server Version : 50554
File Encoding         : 65001

Date: 2017-03-11 07:58:49
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for blog
-- ----------------------------
DROP TABLE IF EXISTS `blog`;
CREATE TABLE `blog` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` text,
  `Content_launcher` text,
  `date` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of blog
-- ----------------------------
INSERT INTO `blog` VALUES ('1', 'Test', 'This is a Text Message', '2017-03-11');
INSERT INTO `blog` VALUES ('2', 'Test 2', 'This is a Text Message', '2017-03-11');

-- ----------------------------
-- Table structure for launcher
-- ----------------------------
DROP TABLE IF EXISTS `launcher`;
CREATE TABLE `launcher` (
  `IP` text NOT NULL,
  `Port` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of launcher
-- ----------------------------
INSERT INTO `launcher` VALUES ('127.0.0.1', '4001');
SET FOREIGN_KEY_CHECKS=1;
