/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 100131
Source Host           : localhost:3306
Source Database       : morlok

Target Server Type    : MYSQL
Target Server Version : 100131
File Encoding         : 65001

Date: 2019-08-10 23:38:37
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for chronic
-- ----------------------------
DROP TABLE IF EXISTS `chronic`;
CREATE TABLE `chronic` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `orderby` varchar(255) DEFAULT NULL,
  `date` varchar(20) DEFAULT NULL,
  `input` text,
  `userid` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of chronic
-- ----------------------------
INSERT INTO `chronic` VALUES ('39', '1', '2018-11-13', 'Hello\nToday I met Kelvin who was from China\nHis main symptom is as follows.\nSnoring - ok\n\nEverything is going well\n', '48');
INSERT INTO `chronic` VALUES ('40', '1', '2018-12-30', 'sdffffffffffffffffffffffdfsdfsdfsdffffffffffffffffffffffffffffffffffffffffffffffsdffffffffff', '47');
INSERT INTO `chronic` VALUES ('41', '2', '2018-12-30', 'asd\nasd\nasd\n', '47');
INSERT INTO `chronic` VALUES ('42', '3', '2019-05-03', 'fh', '47');

-- ----------------------------
-- Table structure for diagnostic
-- ----------------------------
DROP TABLE IF EXISTS `diagnostic`;
CREATE TABLE `diagnostic` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tmj` varchar(1) DEFAULT NULL,
  `snoring` varchar(1) DEFAULT NULL,
  `apnealink` varchar(1) DEFAULT NULL,
  `quisi` varchar(1) DEFAULT NULL,
  `biofeedback` varchar(1) DEFAULT NULL,
  `emg` varchar(1) DEFAULT NULL,
  `kinematographics` varchar(1) DEFAULT NULL,
  `t_scan` varchar(1) DEFAULT NULL,
  `panorama` varchar(1) DEFAULT NULL,
  `panorama_analysis` varchar(1) DEFAULT NULL,
  `lateral_x` varchar(1) DEFAULT NULL,
  `lateral_x_ray` varchar(1) DEFAULT NULL,
  `mri_tmj` varchar(1) DEFAULT NULL,
  `dental_finding` varchar(1) DEFAULT NULL,
  `functional_finding` varchar(1) DEFAULT NULL,
  `orthodontic_model` varchar(1) DEFAULT NULL,
  `model_analysis` varchar(1) DEFAULT NULL,
  `photos` varchar(1) DEFAULT NULL,
  `manual_functional_analysis` varchar(1) DEFAULT NULL,
  `instrumental_functional` varchar(1) DEFAULT NULL,
  `hormones` varchar(1) DEFAULT NULL,
  `eav` varchar(1) DEFAULT NULL,
  `stresstest` varchar(1) DEFAULT NULL,
  `subsitiution` varchar(1) DEFAULT NULL,
  `userid` int(11) DEFAULT NULL,
  `intraoral` varchar(1) DEFAULT NULL,
  `extraoral` varchar(1) DEFAULT NULL,
  `posture` varchar(1) DEFAULT NULL,
  `hormone` varchar(1) DEFAULT NULL,
  `fbs_txt` varchar(255) DEFAULT NULL,
  `mrt_txt` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=129 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of diagnostic
-- ----------------------------
INSERT INTO `diagnostic` VALUES ('29', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '47', '0', '0', '0', null, '', '');
INSERT INTO `diagnostic` VALUES ('119', '1', '2', '2', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '48', '0', '0', '0', null, '1', '');
INSERT INTO `diagnostic` VALUES ('125', '2', '2', '2', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '57', '1', '1', '1', null, '1', '2');
INSERT INTO `diagnostic` VALUES ('127', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '63', '0', '0', '0', null, '', '');
INSERT INTO `diagnostic` VALUES ('128', '0', '0', '1', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '58', '0', '0', '0', null, '', '');

-- ----------------------------
-- Table structure for scanned_form
-- ----------------------------
DROP TABLE IF EXISTS `scanned_form`;
CREATE TABLE `scanned_form` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) DEFAULT NULL,
  `filename` varchar(255) DEFAULT NULL,
  `filetype` varchar(10) DEFAULT NULL,
  `kind` varchar(255) DEFAULT NULL,
  `fdate` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of scanned_form
-- ----------------------------
INSERT INTO `scanned_form` VALUES ('1', '48', 'SAMPLE-HOME-DESIGN.jpg', '.jpg', 'Anamnesis', null);
INSERT INTO `scanned_form` VALUES ('2', '48', 'travel_pdf_2019_04_02_00_00_00_2019_04_03_00_00_00 (1).pdf', '.pdf', 'Anamnesis', null);
INSERT INTO `scanned_form` VALUES ('3', '48', 'ez doc pro (3).pdf', '.pdf', 'Anamnesis', null);
INSERT INTO `scanned_form` VALUES ('4', '48', 'i-589.pdf', '.pdf', 'Anamnesis', '2019-04-03');
INSERT INTO `scanned_form` VALUES ('6', '47', 'The_Thinker,_Rodin.jpg', '.jpg', 'Anamnesis', '2019-04-25');
INSERT INTO `scanned_form` VALUES ('7', '47', 'The_Thinker,_Rodin.jpg', '.jpg', 'Anamnesis', '2019-04-25');
INSERT INTO `scanned_form` VALUES ('8', '47', 'about_blank.pdf', '.pdf', 'Anamnesis', '2019-06-12');

-- ----------------------------
-- Table structure for symptoms
-- ----------------------------
DROP TABLE IF EXISTS `symptoms`;
CREATE TABLE `symptoms` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) DEFAULT NULL,
  `symptoms` varchar(255) DEFAULT NULL,
  `f0` varchar(1) DEFAULT NULL,
  `f1` varchar(1) DEFAULT NULL,
  `f2` varchar(1) DEFAULT NULL,
  `f3` varchar(1) DEFAULT NULL,
  `f4` varchar(1) DEFAULT NULL,
  `f5` varchar(1) DEFAULT NULL,
  `f6` varchar(1) DEFAULT NULL,
  `f7` varchar(1) DEFAULT NULL,
  `f8` varchar(1) DEFAULT NULL,
  `f9` varchar(1) DEFAULT NULL,
  `f10` varchar(1) DEFAULT NULL,
  `forder` varchar(2) DEFAULT NULL,
  `fdate` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10760 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of symptoms
-- ----------------------------
INSERT INTO `symptoms` VALUES ('4665', '47', 'Sensitive teeth', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4666', '47', 'Clicking, grinding and other sounds in the jaw joint? Where?', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '1', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4667', '47', 'Burning of mouth, tongue and palate', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '2', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4668', '47', 'Dry mouth', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '3', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4669', '47', 'Problems of the salivary gland', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '4', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4670', '47', 'Grinding and pressing of the teeth', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '5', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4671', '47', 'Tongue- and lippressing', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '6', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4672', '47', 'Pain in the jaw joint', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '7', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4673', '47', 'Mouth doesn´t open right', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '8', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4674', '47', 'Chewing only at one side – which side?', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '9', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4675', '47', 'Tension when waking up in the morning. Where?', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '10', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4676', '47', 'Tension in general.Where?', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '0', '11', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4677', '47', 'Stiffness? Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '12', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4678', '47', 'Feeling of not feeling straight. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '13', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4679', '47', 'Itchy sculp', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '14', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4680', '47', 'Headache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '15', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4681', '47', 'Faceache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '16', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4682', '47', 'Neckache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '17', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4683', '47', 'Backache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '18', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4684', '47', 'Shoulderache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '19', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4685', '47', 'Hearing disorders', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '20', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4686', '47', 'Earnoise. Which kind? Please describe it.', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '21', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4687', '47', 'Closed feeling of the ears. Both ears?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '22', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4688', '47', 'Earpain', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '23', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4689', '47', 'Earpressure', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '24', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4690', '47', 'Itchy ears', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '25', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4691', '47', 'Dizziness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '26', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4692', '47', 'Pain behind the eyes', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '27', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4693', '47', 'Sensitivity against light', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '28', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4694', '47', 'Visual disturbance', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '29', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4695', '47', 'Double images', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '30', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4696', '47', 'Difficulty swallowing', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '31', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4697', '47', 'Sore throat', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '32', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4698', '47', 'Speaking difficulties', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '33', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4699', '47', 'Hawking', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '34', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4700', '47', 'Numbness. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '35', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4701', '47', 'Daytime sleepiness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '36', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4702', '47', 'Tendency dozing off in daytime', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '37', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4703', '47', 'Morning tiredness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '38', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4704', '47', 'Fit only in the late afternoon or in the evening', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '39', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4705', '47', 'Stress at work', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '40', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4706', '47', 'Stress in familiy', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '41', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4707', '47', 'Stress in school', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '42', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4708', '47', 'Stress somewhere else. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '43', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4709', '47', 'Breathing interruption during sleeping', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '44', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4710', '47', 'Snoring', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '45', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4711', '47', 'Short sleep', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '46', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4712', '47', 'Wake up during sleep? When?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '47', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4713', '47', 'Not able to fall asleep', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '48', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4714', '47', 'Depression', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '49', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4715', '47', 'Excessive Demands? Why?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '50', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4716', '47', 'Fear. Of what?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '51', '2018-11-16');
INSERT INTO `symptoms` VALUES ('4717', '47', 'Restlessness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '52', '2018-11-16');
INSERT INTO `symptoms` VALUES ('6255', '47', 'Sensitive teeth', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6256', '47', 'Clicking, grinding and other sounds in the jaw joint? Where?', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '0', '1', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6257', '47', 'Burning of mouth, tongue and palate', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6258', '47', 'Dry mouth', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '3', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6259', '47', 'Problems of the salivary gland', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '4', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6260', '47', 'Grinding and pressing of the teeth', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '5', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6261', '47', 'Tongue- and lippressing', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '6', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6262', '47', 'Pain in the jaw joint', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '7', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6263', '47', 'Mouth doesn´t open right', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '8', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6264', '47', 'Chewing only at one side – which side?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '9', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6265', '47', 'Tension when waking up in the morning. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '10', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6266', '47', 'Tension in general.Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '11', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6267', '47', 'Stiffness? Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '12', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6268', '47', 'Feeling of not feeling straight. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '13', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6269', '47', 'Itchy sculp', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '14', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6270', '47', 'Headache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '15', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6271', '47', 'Faceache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '16', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6272', '47', 'Neckache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '17', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6273', '47', 'Backache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '18', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6274', '47', 'Shoulderache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '19', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6275', '47', 'Hearing disorders', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '20', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6276', '47', 'Earnoise. Which kind? Please describe it.', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '21', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6277', '47', 'Closed feeling of the ears. Both ears?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '22', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6278', '47', 'Earpain', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '23', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6279', '47', 'Earpressure', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '24', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6280', '47', 'Itchy ears', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '25', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6281', '47', 'Dizziness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '26', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6282', '47', 'Pain behind the eyes', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '27', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6283', '47', 'Sensitivity against light', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '28', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6284', '47', 'Visual disturbance', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '29', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6285', '47', 'Double images', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '30', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6286', '47', 'Difficulty swallowing', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '31', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6287', '47', 'Sore throat', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '32', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6288', '47', 'Speaking difficulties', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '33', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6289', '47', 'Hawking', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '34', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6290', '47', 'Numbness. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '35', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6291', '47', 'Daytime sleepiness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '36', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6292', '47', 'Tendency dozing off in daytime', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '37', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6293', '47', 'Morning tiredness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '38', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6294', '47', 'Fit only in the late afternoon or in the evening', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '39', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6295', '47', 'Stress at work', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '40', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6296', '47', 'Stress in familiy', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '41', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6297', '47', 'Stress in school', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '42', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6298', '47', 'Stress somewhere else. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '43', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6299', '47', 'Breathing interruption during sleeping', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '44', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6300', '47', 'Snoring', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '45', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6301', '47', 'Short sleep', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '46', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6302', '47', 'Wake up during sleep? When?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '47', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6303', '47', 'Not able to fall asleep', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '48', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6304', '47', 'Depression', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '49', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6305', '47', 'Excessive Demands? Why?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '50', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6306', '47', 'Fear. Of what?', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '51', '2018-11-15');
INSERT INTO `symptoms` VALUES ('6307', '47', 'Restlessness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '52', '2018-11-15');
INSERT INTO `symptoms` VALUES ('8852', '48', 'Sensitive teeth', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8853', '48', 'Clicking, grinding and other sounds in the jaw joint? Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8854', '48', 'Burning of mouth, tongue and palate', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8855', '48', 'Dry mouth', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '3', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8856', '48', 'Problems of the salivary gland', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '4', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8857', '48', 'Grinding and pressing of the teeth', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '5', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8858', '48', 'Tongue- and lippressing', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '6', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8859', '48', 'Pain in the jaw joint', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '7', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8860', '48', 'Mouth doesn´t open right', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '8', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8861', '48', 'Chewing only at one side – which side?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '9', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8862', '48', 'Tension when waking up in the morning. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '10', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8863', '48', 'Tension in general.Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '11', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8864', '48', 'Stiffness? Where?', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '12', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8865', '48', 'Feeling of not feeling straight. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '13', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8866', '48', 'Itchy sculp', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '14', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8867', '48', 'Headache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '15', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8868', '48', 'Faceache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '16', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8869', '48', 'Neckache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '17', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8870', '48', 'Backache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '18', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8871', '48', 'Shoulderache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '19', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8872', '48', 'Hearing disorders', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '20', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8873', '48', 'Earnoise. Which kind? Please describe it.', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '21', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8874', '48', 'Closed feeling of the ears. Both ears?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '22', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8875', '48', 'Earpain', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '23', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8876', '48', 'Earpressure', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '24', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8877', '48', 'Itchy ears', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '25', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8878', '48', 'Dizziness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '26', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8879', '48', 'Pain behind the eyes', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '27', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8880', '48', 'Sensitivity against light', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '28', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8881', '48', 'Visual disturbance', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '29', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8882', '48', 'Double images', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '30', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8883', '48', 'Difficulty swallowing', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '31', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8884', '48', 'Sore throat', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '32', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8885', '48', 'Speaking difficulties', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '33', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8886', '48', 'Hawking', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '34', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8887', '48', 'Numbness. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '35', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8888', '48', 'Daytime sleepiness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '36', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8889', '48', 'Tendency dozing off in daytime', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '37', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8890', '48', 'Morning tiredness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '38', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8891', '48', 'Fit only in the late afternoon or in the evening', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '39', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8892', '48', 'Stress at work', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '40', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8893', '48', 'Stress in familiy', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '41', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8894', '48', 'Stress in school', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '42', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8895', '48', 'Stress somewhere else. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '43', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8896', '48', 'Breathing interruption during sleeping', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '44', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8897', '48', 'Snoring', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '45', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8898', '48', 'Short sleep', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '46', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8899', '48', 'Wake up during sleep? When?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '47', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8900', '48', 'Not able to fall asleep', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '48', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8901', '48', 'Depression', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '49', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8902', '48', 'Excessive Demands? Why?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '50', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8903', '48', 'Fear. Of what?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '51', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8904', '48', 'Restlessness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '52', '2018-11-16');
INSERT INTO `symptoms` VALUES ('8905', '48', 'Sensitive teeth', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8906', '48', 'Clicking, grinding and other sounds in the jaw joint? Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8907', '48', 'Burning of mouth, tongue and palate', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8908', '48', 'Dry mouth', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '3', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8909', '48', 'Problems of the salivary gland', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '4', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8910', '48', 'Grinding and pressing of the teeth', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '5', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8911', '48', 'Tongue- and lippressing', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '6', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8912', '48', 'Pain in the jaw joint', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '7', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8913', '48', 'Mouth doesn´t open right', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '8', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8914', '48', 'Chewing only at one side – which side?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '9', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8915', '48', 'Tension when waking up in the morning. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '10', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8916', '48', 'Tension in general.Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '11', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8917', '48', 'Stiffness? Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '12', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8918', '48', 'Feeling of not feeling straight. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '13', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8919', '48', 'Itchy sculp', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '14', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8920', '48', 'Headache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '15', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8921', '48', 'Faceache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '16', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8922', '48', 'Neckache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '17', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8923', '48', 'Backache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '18', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8924', '48', 'Shoulderache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '19', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8925', '48', 'Hearing disorders', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '20', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8926', '48', 'Earnoise. Which kind? Please describe it.', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '21', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8927', '48', 'Closed feeling of the ears. Both ears?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '22', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8928', '48', 'Earpain', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '23', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8929', '48', 'Earpressure', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '24', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8930', '48', 'Itchy ears', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '25', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8931', '48', 'Dizziness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '26', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8932', '48', 'Pain behind the eyes', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '27', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8933', '48', 'Sensitivity against light', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '28', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8934', '48', 'Visual disturbance', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '29', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8935', '48', 'Double images', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '30', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8936', '48', 'Difficulty swallowing', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '31', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8937', '48', 'Sore throat', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '32', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8938', '48', 'Speaking difficulties', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '33', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8939', '48', 'Hawking', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '34', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8940', '48', 'Numbness. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '35', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8941', '48', 'Daytime sleepiness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '36', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8942', '48', 'Tendency dozing off in daytime', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '37', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8943', '48', 'Morning tiredness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '38', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8944', '48', 'Fit only in the late afternoon or in the evening', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '39', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8945', '48', 'Stress at work', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '40', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8946', '48', 'Stress in familiy', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '41', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8947', '48', 'Stress in school', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '42', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8948', '48', 'Stress somewhere else. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '43', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8949', '48', 'Breathing interruption during sleeping', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '44', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8950', '48', 'Snoring', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '45', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8951', '48', 'Short sleep', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '46', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8952', '48', 'Wake up during sleep? When?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '47', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8953', '48', 'Not able to fall asleep', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '48', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8954', '48', 'Depression', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '49', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8955', '48', 'Excessive Demands? Why?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '50', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8956', '48', 'Fear. Of what?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '51', '2018-11-17');
INSERT INTO `symptoms` VALUES ('8957', '48', 'Restlessness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '52', '2018-11-17');
INSERT INTO `symptoms` VALUES ('9276', '48', 'Sensitive teeth', '1', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9277', '48', 'Clicking, grinding and other sounds in the jaw joint? Where?', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9278', '48', 'Burning of mouth, tongue and palate', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9279', '48', 'Dry mouth', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '3', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9280', '48', 'Problems of the salivary gland', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '4', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9281', '48', 'Grinding and pressing of the teeth', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '5', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9282', '48', 'Tongue- and lippressing', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '6', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9283', '48', 'Pain in the jaw joint', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '7', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9284', '48', 'Mouth doesn´t open right', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '8', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9285', '48', 'Chewing only at one side – which side?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '9', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9286', '48', 'Tension when waking up in the morning. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '10', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9287', '48', 'Tension in general.Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '11', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9288', '48', 'Stiffness? Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '12', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9289', '48', 'Feeling of not feeling straight. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '13', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9290', '48', 'Itchy sculp', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '14', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9291', '48', 'Headache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '15', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9292', '48', 'Faceache', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '16', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9293', '48', 'Neckache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '17', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9294', '48', 'Backache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '18', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9295', '48', 'Shoulderache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '19', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9296', '48', 'Hearing disorders', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '20', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9297', '48', 'Earnoise. Which kind? Please describe it.', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '21', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9298', '48', 'Closed feeling of the ears. Both ears?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '22', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9299', '48', 'Earpain', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '23', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9300', '48', 'Earpressure', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '24', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9301', '48', 'Itchy ears', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '25', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9302', '48', 'Dizziness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '26', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9303', '48', 'Pain behind the eyes', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '27', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9304', '48', 'Sensitivity against light', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '28', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9305', '48', 'Visual disturbance', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '29', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9306', '48', 'Double images', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '30', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9307', '48', 'Difficulty swallowing', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '31', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9308', '48', 'Sore throat', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '32', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9309', '48', 'Speaking difficulties', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '33', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9310', '48', 'Hawking', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '34', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9311', '48', 'Numbness. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '35', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9312', '48', 'Daytime sleepiness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '36', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9313', '48', 'Tendency dozing off in daytime', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '37', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9314', '48', 'Morning tiredness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '38', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9315', '48', 'Fit only in the late afternoon or in the evening', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '39', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9316', '48', 'Stress at work', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '40', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9317', '48', 'Stress in familiy', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '41', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9318', '48', 'Stress in school', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '42', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9319', '48', 'Stress somewhere else. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '43', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9320', '48', 'Breathing interruption during sleeping', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '44', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9321', '48', 'Snoring', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '45', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9322', '48', 'Short sleep', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '46', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9323', '48', 'Wake up during sleep? When?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '47', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9324', '48', 'Not able to fall asleep', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '48', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9325', '48', 'Depression', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '49', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9326', '48', 'Excessive Demands? Why?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '50', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9327', '48', 'Fear. Of what?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '51', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9328', '48', 'Restlessness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '52', '2018-11-15');
INSERT INTO `symptoms` VALUES ('9700', '48', 'Sensitive teeth', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9701', '48', 'Clicking, grinding and other sounds in the jaw joint? Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9702', '48', 'Burning of mouth, tongue and palate', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9703', '48', 'Dry mouth', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '3', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9704', '48', 'Problems of the salivary gland', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '4', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9705', '48', 'Grinding and pressing of the teeth', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '5', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9706', '48', 'Tongue- and lippressing', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '6', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9707', '48', 'Pain in the jaw joint', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '7', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9708', '48', 'Mouth doesn´t open right', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '8', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9709', '48', 'Chewing only at one side – which side?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '9', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9710', '48', 'Tension when waking up in the morning. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '10', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9711', '48', 'Tension in general.Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '11', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9712', '48', 'Stiffness? Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '12', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9713', '48', 'Feeling of not feeling straight. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '13', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9714', '48', 'Itchy sculp', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '14', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9715', '48', 'Headache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '15', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9716', '48', 'Faceache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '16', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9717', '48', 'Neckache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '17', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9718', '48', 'Backache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '18', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9719', '48', 'Shoulderache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '19', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9720', '48', 'Hearing disorders', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '20', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9721', '48', 'Earnoise. Which kind? Please describe it.', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '21', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9722', '48', 'Closed feeling of the ears. Both ears?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '22', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9723', '48', 'Earpain', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '23', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9724', '48', 'Earpressure', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '24', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9725', '48', 'Itchy ears', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '25', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9726', '48', 'Dizziness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '26', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9727', '48', 'Pain behind the eyes', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '27', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9728', '48', 'Sensitivity against light', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '28', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9729', '48', 'Visual disturbance', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '29', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9730', '48', 'Double images', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '30', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9731', '48', 'Difficulty swallowing', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '31', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9732', '48', 'Sore throat', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '32', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9733', '48', 'Speaking difficulties', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '33', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9734', '48', 'Hawking', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '34', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9735', '48', 'Numbness. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '35', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9736', '48', 'Daytime sleepiness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '36', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9737', '48', 'Tendency dozing off in daytime', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '37', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9738', '48', 'Morning tiredness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '38', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9739', '48', 'Fit only in the late afternoon or in the evening', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '39', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9740', '48', 'Stress at work', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '40', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9741', '48', 'Stress in familiy', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '41', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9742', '48', 'Stress in school', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '42', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9743', '48', 'Stress somewhere else. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '43', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9744', '48', 'Breathing interruption during sleeping', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '44', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9745', '48', 'Snoring', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '45', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9746', '48', 'Short sleep', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '46', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9747', '48', 'Wake up during sleep? When?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '47', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9748', '48', 'Not able to fall asleep', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '48', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9749', '48', 'Depression', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '49', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9750', '48', 'Excessive Demands? Why?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '50', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9751', '48', 'Fear. Of what?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '51', '2018-11-18');
INSERT INTO `symptoms` VALUES ('9752', '48', 'Restlessness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '52', '2018-11-18');
INSERT INTO `symptoms` VALUES ('10707', '57', 'Sensitive teeth', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10708', '57', 'Clicking, grinding and other sounds in the jaw joint? Where?', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '1', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10709', '57', 'Burning of mouth, tongue and palate', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '2', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10710', '57', 'Dry mouth', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '3', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10711', '57', 'Problems of the salivary gland', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '4', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10712', '57', 'Grinding and pressing of the teeth', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '5', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10713', '57', 'Tongue- and lippressing', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '6', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10714', '57', 'Pain in the jaw joint', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '7', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10715', '57', 'Mouth doesn´t open right', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '8', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10716', '57', 'Chewing only at one side – which side?', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '9', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10717', '57', 'Tension when waking up in the morning. Where?', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '10', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10718', '57', 'Tension in general.Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '11', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10719', '57', 'Stiffness? Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '12', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10720', '57', 'Feeling of not feeling straight. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '13', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10721', '57', 'Itchy sculp', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '14', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10722', '57', 'Headache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '15', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10723', '57', 'Faceache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '16', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10724', '57', 'Neckache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '17', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10725', '57', 'Backache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '18', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10726', '57', 'Shoulderache', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '19', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10727', '57', 'Hearing disorders', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '20', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10728', '57', 'Earnoise. Which kind? Please describe it.', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '21', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10729', '57', 'Closed feeling of the ears. Both ears?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '22', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10730', '57', 'Earpain', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '23', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10731', '57', 'Earpressure', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '24', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10732', '57', 'Itchy ears', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '25', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10733', '57', 'Dizziness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '26', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10734', '57', 'Pain behind the eyes', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '27', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10735', '57', 'Sensitivity against light', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '28', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10736', '57', 'Visual disturbance', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '29', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10737', '57', 'Double images', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '30', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10738', '57', 'Difficulty swallowing', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '31', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10739', '57', 'Sore throat', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '32', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10740', '57', 'Speaking difficulties', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '33', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10741', '57', 'Hawking', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '34', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10742', '57', 'Numbness. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '35', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10743', '57', 'Daytime sleepiness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '36', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10744', '57', 'Tendency dozing off in daytime', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '37', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10745', '57', 'Morning tiredness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '38', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10746', '57', 'Fit only in the late afternoon or in the evening', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '39', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10747', '57', 'Stress at work', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '40', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10748', '57', 'Stress in familiy', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '41', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10749', '57', 'Stress in school', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '42', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10750', '57', 'Stress somewhere else. Where?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '43', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10751', '57', 'Breathing interruption during sleeping', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '44', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10752', '57', 'Snoring', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '45', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10753', '57', 'Short sleep', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '46', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10754', '57', 'Wake up during sleep? When?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '47', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10755', '57', 'Not able to fall asleep', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '48', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10756', '57', 'Depression', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '49', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10757', '57', 'Excessive Demands? Why?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '50', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10758', '57', 'Fear. Of what?', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '51', '2018-11-15');
INSERT INTO `symptoms` VALUES ('10759', '57', 'Restlessness', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '52', '2018-11-15');

-- ----------------------------
-- Table structure for symptoms1
-- ----------------------------
DROP TABLE IF EXISTS `symptoms1`;
CREATE TABLE `symptoms1` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) DEFAULT NULL,
  `symptoms` varchar(255) DEFAULT NULL,
  `f0` varchar(1) DEFAULT NULL,
  `f1` varchar(1) DEFAULT NULL,
  `f2` varchar(1) DEFAULT NULL,
  `f3` varchar(1) DEFAULT NULL,
  `f4` varchar(1) DEFAULT NULL,
  `f5` varchar(1) DEFAULT NULL,
  `f6` varchar(1) DEFAULT NULL,
  `f7` varchar(1) DEFAULT NULL,
  `f8` varchar(1) DEFAULT NULL,
  `f9` varchar(1) DEFAULT NULL,
  `f10` varchar(1) DEFAULT NULL,
  `forder` varchar(2) DEFAULT NULL,
  `fdate` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1219 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of symptoms1
-- ----------------------------
INSERT INTO `symptoms1` VALUES ('19', '47', 'Limitation with daily tasks in the last 6 months', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '0', '2018-11-14');
INSERT INTO `symptoms1` VALUES ('20', '47', 'Limitation with familiy- and freetimeactivities in the last 6 months', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '1', '2018-11-14');
INSERT INTO `symptoms1` VALUES ('21', '47', 'Limitation with work and homework in the last 6 months', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '2', '2018-11-14');
INSERT INTO `symptoms1` VALUES ('22', '47', 'Actual pain intensity', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '3', '2018-11-14');
INSERT INTO `symptoms1` VALUES ('23', '47', 'Strongest pain in the last 6 months', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '4', '2018-11-14');
INSERT INTO `symptoms1` VALUES ('24', '47', 'Average pain in the last 6 months', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '5', '2018-11-14');
INSERT INTO `symptoms1` VALUES ('277', '47', 'Limitation with daily tasks in the last 6 months', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '2018-11-17');
INSERT INTO `symptoms1` VALUES ('278', '47', 'Limitation with familiy- and freetimeactivities in the last 6 months', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '1', '2018-11-17');
INSERT INTO `symptoms1` VALUES ('279', '47', 'Limitation with work and homework in the last 6 months', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '2', '2018-11-17');
INSERT INTO `symptoms1` VALUES ('280', '47', 'Actual pain intensity', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '3', '2018-11-17');
INSERT INTO `symptoms1` VALUES ('281', '47', 'Strongest pain in the last 6 months', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '4', '2018-11-17');
INSERT INTO `symptoms1` VALUES ('282', '47', 'Average pain in the last 6 months', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '5', '2018-11-17');
INSERT INTO `symptoms1` VALUES ('529', '47', 'Limitation with daily tasks in the last 6 months', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2018-11-16');
INSERT INTO `symptoms1` VALUES ('530', '47', 'Limitation with familiy- and freetimeactivities in the last 6 months', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '2018-11-16');
INSERT INTO `symptoms1` VALUES ('531', '47', 'Limitation with work and homework in the last 6 months', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '2', '2018-11-16');
INSERT INTO `symptoms1` VALUES ('532', '47', 'Actual pain intensity', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '3', '2018-11-16');
INSERT INTO `symptoms1` VALUES ('533', '47', 'Strongest pain in the last 6 months', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '4', '2018-11-16');
INSERT INTO `symptoms1` VALUES ('534', '47', 'Average pain in the last 6 months', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '5', '2018-11-16');
INSERT INTO `symptoms1` VALUES ('709', '47', 'Limitation with daily tasks in the last 6 months', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '2018-11-15');
INSERT INTO `symptoms1` VALUES ('710', '47', 'Limitation with familiy- and freetimeactivities in the last 6 months', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '1', '2018-11-15');
INSERT INTO `symptoms1` VALUES ('711', '47', 'Limitation with work and homework in the last 6 months', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '2', '2018-11-15');
INSERT INTO `symptoms1` VALUES ('712', '47', 'Actual pain intensity', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '0', '3', '2018-11-15');
INSERT INTO `symptoms1` VALUES ('713', '47', 'Strongest pain in the last 6 months', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '4', '2018-11-15');
INSERT INTO `symptoms1` VALUES ('714', '47', 'Average pain in the last 6 months', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '5', '2018-11-15');
INSERT INTO `symptoms1` VALUES ('1003', '48', 'Limitation with daily tasks in the last 6 months', '1', '1', '1', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2018-11-16');
INSERT INTO `symptoms1` VALUES ('1004', '48', 'Limitation with familiy- and freetimeactivities in the last 6 months', '1', '1', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '2018-11-16');
INSERT INTO `symptoms1` VALUES ('1005', '48', 'Limitation with work and homework in the last 6 months', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '2', '2018-11-16');
INSERT INTO `symptoms1` VALUES ('1006', '48', 'Actual pain intensity', '1', '1', '1', '0', '0', '0', '0', '0', '0', '0', '0', '3', '2018-11-16');
INSERT INTO `symptoms1` VALUES ('1007', '48', 'Strongest pain in the last 6 months', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '4', '2018-11-16');
INSERT INTO `symptoms1` VALUES ('1008', '48', 'Average pain in the last 6 months', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '5', '2018-11-16');
INSERT INTO `symptoms1` VALUES ('1009', '48', 'Limitation with daily tasks in the last 6 months', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '2018-11-17');
INSERT INTO `symptoms1` VALUES ('1010', '48', 'Limitation with familiy- and freetimeactivities in the last 6 months', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '1', '2018-11-17');
INSERT INTO `symptoms1` VALUES ('1011', '48', 'Limitation with work and homework in the last 6 months', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '2', '2018-11-17');
INSERT INTO `symptoms1` VALUES ('1012', '48', 'Actual pain intensity', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '0', '3', '2018-11-17');
INSERT INTO `symptoms1` VALUES ('1013', '48', 'Strongest pain in the last 6 months', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '4', '2018-11-17');
INSERT INTO `symptoms1` VALUES ('1014', '48', 'Average pain in the last 6 months', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '5', '2018-11-17');
INSERT INTO `symptoms1` VALUES ('1051', '48', 'Limitation with daily tasks in the last 6 months', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '2018-11-15');
INSERT INTO `symptoms1` VALUES ('1052', '48', 'Limitation with familiy- and freetimeactivities in the last 6 months', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '0', '1', '2018-11-15');
INSERT INTO `symptoms1` VALUES ('1053', '48', 'Limitation with work and homework in the last 6 months', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '2', '2018-11-15');
INSERT INTO `symptoms1` VALUES ('1054', '48', 'Actual pain intensity', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '3', '2018-11-15');
INSERT INTO `symptoms1` VALUES ('1055', '48', 'Strongest pain in the last 6 months', '1', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '4', '2018-11-15');
INSERT INTO `symptoms1` VALUES ('1056', '48', 'Average pain in the last 6 months', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '5', '2018-11-15');
INSERT INTO `symptoms1` VALUES ('1099', '48', 'Limitation with daily tasks in the last 6 months', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '0', '0', '2018-11-18');
INSERT INTO `symptoms1` VALUES ('1100', '48', 'Limitation with familiy- and freetimeactivities in the last 6 months', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '2018-11-18');
INSERT INTO `symptoms1` VALUES ('1101', '48', 'Limitation with work and homework in the last 6 months', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '2', '2018-11-18');
INSERT INTO `symptoms1` VALUES ('1102', '48', 'Actual pain intensity', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '3', '2018-11-18');
INSERT INTO `symptoms1` VALUES ('1103', '48', 'Strongest pain in the last 6 months', '1', '1', '1', '0', '0', '0', '0', '0', '0', '0', '0', '4', '2018-11-18');
INSERT INTO `symptoms1` VALUES ('1104', '48', 'Average pain in the last 6 months', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '5', '2018-11-18');
INSERT INTO `symptoms1` VALUES ('1213', '57', 'Limitation with daily tasks in the last 6 months', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '0', '2018-11-15');
INSERT INTO `symptoms1` VALUES ('1214', '57', 'Limitation with familiy- and freetimeactivities in the last 6 months', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '0', '1', '2018-11-15');
INSERT INTO `symptoms1` VALUES ('1215', '57', 'Limitation with work and homework in the last 6 months', '1', '1', '1', '0', '0', '0', '0', '0', '0', '0', '0', '2', '2018-11-15');
INSERT INTO `symptoms1` VALUES ('1216', '57', 'Actual pain intensity', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '3', '2018-11-15');
INSERT INTO `symptoms1` VALUES ('1217', '57', 'Strongest pain in the last 6 months', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '4', '2018-11-15');
INSERT INTO `symptoms1` VALUES ('1218', '57', 'Average pain in the last 6 months', '1', '1', '1', '1', '1', '1', '0', '0', '0', '0', '0', '5', '2018-11-15');

-- ----------------------------
-- Table structure for template
-- ----------------------------
DROP TABLE IF EXISTS `template`;
CREATE TABLE `template` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `template` varchar(2000) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of template
-- ----------------------------
INSERT INTO `template` VALUES ('9', 'His main symptom is as follows.\nSnoring - ok\n');
INSERT INTO `template` VALUES ('11', 'His main symptom is as follows.\nSnoring - ok\n');

-- ----------------------------
-- Table structure for treatment
-- ----------------------------
DROP TABLE IF EXISTS `treatment`;
CREATE TABLE `treatment` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) DEFAULT NULL,
  `Myocentric_splint` varchar(1) DEFAULT NULL,
  `Daysplint` varchar(1) DEFAULT NULL,
  `Longterm_temporaries` varchar(1) DEFAULT NULL,
  `Dental_hygiene` varchar(1) DEFAULT NULL,
  `Dental_treatment` varchar(1) DEFAULT NULL,
  `Periodontal_treatment` varchar(1) DEFAULT NULL,
  `Rootcanal_treatment` varchar(1) DEFAULT NULL,
  `Prosthetics` varchar(1) DEFAULT NULL,
  `Implants` varchar(1) DEFAULT NULL,
  `office_Orthodontics` varchar(1) DEFAULT NULL,
  `Bionator` varchar(1) DEFAULT NULL,
  `Expansion_Plate` varchar(1) DEFAULT NULL,
  `Brackets` varchar(1) DEFAULT NULL,
  `Aligner` varchar(1) DEFAULT NULL,
  `Aligner_CA` varchar(1) DEFAULT NULL,
  `Aligner_Invisalign` varchar(1) DEFAULT NULL,
  `Snoring_Splint` varchar(1) DEFAULT NULL,
  `Terminal_splint` varchar(1) DEFAULT NULL,
  `Recall` varchar(1) DEFAULT NULL,
  `Recall_Spint` varchar(1) DEFAULT NULL,
  `Recall_PA` varchar(1) DEFAULT NULL,
  `Recall_teeth` varchar(1) DEFAULT NULL,
  `Osteopathy` varchar(1) DEFAULT NULL,
  `Physiotherapy` varchar(1) DEFAULT NULL,
  `Eurythmics` varchar(1) DEFAULT NULL,
  `Metabolism` varchar(1) DEFAULT NULL,
  `Blood` varchar(1) DEFAULT NULL,
  `Feet` varchar(1) DEFAULT NULL,
  `Orthopedic` varchar(1) DEFAULT NULL,
  `Neurologist` varchar(1) DEFAULT NULL,
  `ORL` varchar(1) DEFAULT NULL,
  `Sleep_lab` varchar(1) DEFAULT NULL,
  `Orthodontics` varchar(1) DEFAULT NULL,
  `Dental_surgery` varchar(1) DEFAULT NULL,
  `Message` varchar(1) DEFAULT NULL,
  `Yoga_treatment` varchar(1) DEFAULT NULL,
  `Dental_treatment_txt` varchar(255) DEFAULT NULL,
  `Rootcanal_treatment_txt` varchar(255) DEFAULT NULL,
  `Implants_txt` varchar(255) DEFAULT NULL,
  `Snoring_Splint_txt` varchar(255) DEFAULT NULL,
  `Recall_txt` varchar(255) DEFAULT NULL,
  `Osteopathy_txt` varchar(255) DEFAULT NULL,
  `Physiotherapy_txt` varchar(255) DEFAULT NULL,
  `Eurythmics_txt` varchar(255) DEFAULT NULL,
  `Metabolism_txt` varchar(255) DEFAULT NULL,
  `Blood_txt` varchar(255) DEFAULT NULL,
  `Feet_txt` varchar(255) DEFAULT NULL,
  `Orthopedic_txt` varchar(255) DEFAULT NULL,
  `Neurologist_txt` varchar(255) DEFAULT NULL,
  `ORL_txt` varchar(255) DEFAULT NULL,
  `Sleep_lab_txt` varchar(255) DEFAULT NULL,
  `Orthodontics_txt` varchar(255) DEFAULT NULL,
  `Dental_surgery_txt` varchar(255) DEFAULT NULL,
  `Message_txt` varchar(255) DEFAULT NULL,
  `Yoga_treatment_txt` varchar(255) DEFAULT NULL,
  `Prosthetics_txt` varchar(255) DEFAULT NULL,
  `tabletops` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1086 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of treatment
-- ----------------------------
INSERT INTO `treatment` VALUES ('68', '47', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '2', '', null);
INSERT INTO `treatment` VALUES ('1055', '58', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '0');
INSERT INTO `treatment` VALUES ('1068', '57', '2', '2', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '', '', '', '', '', '1', '2', '3', '45', '5', '6', '7', '8', '9', '1', '2', '3', '4', '', '', '1');
INSERT INTO `treatment` VALUES ('1081', '63', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '0');
INSERT INTO `treatment` VALUES ('1083', '48', '0', '1', '0', '1', '1', '1', '1', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '1', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '1');
INSERT INTO `treatment` VALUES ('1085', '56', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '0');

-- ----------------------------
-- Table structure for user_info
-- ----------------------------
DROP TABLE IF EXISTS `user_info`;
CREATE TABLE `user_info` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL COMMENT 'Name',
  `surname` varchar(255) NOT NULL COMMENT 'surname',
  `birthday` varchar(255) DEFAULT NULL COMMENT 'birthday',
  `insurance` varchar(100) DEFAULT NULL COMMENT 'private',
  `company_name` varchar(500) DEFAULT NULL COMMENT 'social or beihilfe insurance',
  `main_symptom` varchar(2000) DEFAULT NULL COMMENT 'main symptom',
  `referral` varchar(1000) DEFAULT NULL COMMENT 'referral',
  `deleteflag` int(11) DEFAULT '0',
  `beihilfe` varchar(1) DEFAULT NULL,
  `profession` text,
  `doctor` text,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=65 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of user_info
-- ----------------------------
INSERT INTO `user_info` VALUES ('47', 'Reiniger', 'Schelor', '10/07/2000', '0', 'Kelvin\'s company', 'symptom', 'referral', '0', '1', null, null);
INSERT INTO `user_info` VALUES ('48', 'Kelvin', 'Schelor', '11/07/2000', '2', 'Schelor\'s company', 'symptom', 'referral', '0', '1', '123', 'ass');
INSERT INTO `user_info` VALUES ('49', 'Reiniger', 'Schelor', '10/07/2000', '0', 'Kelvin\'s company', 'symptom', 'referral', '0', '1', null, null);
INSERT INTO `user_info` VALUES ('50', 'Reiniger1', 'Schelor1', '12/07/2000', '0', 'Kelvin\'s company', 'qd;lsdfj ksf[fgl\' dfkl;j \'\ndfg;j ;df\nfgdf\n g\ndfg dfjk;gas jf;kasjf ;asdf\nasdf\nasdf as;fkasj fas;fklj gjaf\n\nag jk;dfg j;sdfkg dfsg \ndfg \nsdfgj;sdfigj gj ;sdfgjk;sdfgj ;', 'referral1', '0', '1', null, null);
INSERT INTO `user_info` VALUES ('51', 'Reiniger12', 'Schelor12', '12/07/2000', '0', 'Kelvin\'s company', 'symptom1', 'referral1', '0', '1', null, null);
INSERT INTO `user_info` VALUES ('52', 'Reiniger13', 'Schelor13', '12/07/2000', '0', 'Kelvin\'s company', 'symptom1', 'referral1', '1', '1', null, null);
INSERT INTO `user_info` VALUES ('53', 'Reiniger15', 'Schelor15', '12/07/2000', '0', 'Kelvin\'s company', 'symptom1', 'referral1', '1', '1', null, null);
INSERT INTO `user_info` VALUES ('54', 'Reiniger136', 'Schelor136', '12/07/2000', '0', 'Kelvin\'s company', 'symptom1', 'referral1', '1', '1', null, null);
INSERT INTO `user_info` VALUES ('55', 'Reiniger12666', 'Schelor12666', '12/07/2000', '0', 'Kelvin\'s company', 'symptom1', 'referral1', '0', '1', null, null);
INSERT INTO `user_info` VALUES ('56', 'Kelvin', 'Schelor', '11/07/2000', '2', 'Schelor\'s company', 'symptom', 'referral', '0', '1', '123', null);
INSERT INTO `user_info` VALUES ('57', '123', '123', '15/07/2019', '2', '123', '', '123', '0', '0', '123', '123');
INSERT INTO `user_info` VALUES ('58', '11', '1', '09/08/2019', '-1', '1', '', '1', '0', '0', '1', '1');
INSERT INTO `user_info` VALUES ('59', '12323', '1', '09/08/2019', '0', '1', '', '1', '0', '0', '1', '1');
INSERT INTO `user_info` VALUES ('60', '234', '234', '16/11/2018', '-1', '234', '', '234', '0', '0', '234', '234');
INSERT INTO `user_info` VALUES ('61', 'wer', 'wer', '09/08/2019', '-1', 'wer', '', 'er', '0', '0', '234', '234');
INSERT INTO `user_info` VALUES ('62', 'qwe123', '23', '09/08/2019', '-1', '123', '', '123', '0', '0', '234', '234123');
INSERT INTO `user_info` VALUES ('63', '123', '123', '16/11/2018', '-1', '123', '', '123', '0', '0', '123123', '123');
INSERT INTO `user_info` VALUES ('64', 'qaz', '123', '16/11/2018', '2', '123', '', '123', '0', '0', '123123', '123');
